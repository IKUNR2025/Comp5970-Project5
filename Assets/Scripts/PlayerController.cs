using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float sideForce = 15f;
    public float forwardForce = 10f;
    public float maxSpeed = 12f;

    private Rigidbody rb;
    private bool canMove = false;
    private float horizontalInput;

    private float originalSideForce;
    private float originalForwardForce;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        originalSideForce = sideForce;
        originalForwardForce = forwardForce;
    }

    void Update()
    {
        if (!canMove)
        {
            horizontalInput = 0f;
            return;
        }

        horizontalInput = 0f;

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            horizontalInput = -1f;
        }

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            horizontalInput = 1f;
        }
    }

    void FixedUpdate()
    {
        if (!canMove)
        {
            return;
        }

        Vector3 force = new Vector3(horizontalInput * sideForce, 0f, forwardForce);
        rb.AddForce(force, ForceMode.Force);

        Vector3 flatVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if (flatVelocity.magnitude > maxSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * maxSpeed;
            rb.linearVelocity = new Vector3(limitedVelocity.x, rb.linearVelocity.y, limitedVelocity.z);
        }
    }

    public void StartMoving()
    {
        canMove = true;
    }

    public void SlowDown(float duration)
    {
        StopCoroutine("SlowDownRoutine");
        StartCoroutine(SlowDownRoutine(duration));
    }

    private IEnumerator SlowDownRoutine(float duration)
    {
        sideForce = originalSideForce * 0.4f;
        forwardForce = originalForwardForce * 0.5f;

        yield return new WaitForSeconds(duration);

        sideForce = originalSideForce;
        forwardForce = originalForwardForce;
    }

    public void BounceBack(float force)
    {
        Vector3 bounceDirection = new Vector3(Random.Range(-1f, 1f), 0.5f, -1f).normalized;
        rb.AddForce(bounceDirection * force, ForceMode.Impulse);
    }

    public void StopPlayer()
    {
        canMove = false;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}