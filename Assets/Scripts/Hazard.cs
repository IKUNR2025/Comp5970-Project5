using UnityEngine;

public enum HazardType
{
    Death,
    Slow,
    Bounce
}

public class Hazard : MonoBehaviour
{
    public HazardType hazardType;
    public float slowDuration = 3f;
    public float bounceForce = 12f;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        PlayerController player = other.GetComponent<PlayerController>();

        if (player == null)
        {
            return;
        }

        if (hazardType == HazardType.Death)
        {
            GameManager.Instance.GameOver();
        }
        else if (hazardType == HazardType.Slow)
        {
            player.SlowDown(slowDuration);
            Destroy(gameObject);
        }
        else if (hazardType == HazardType.Bounce)
        {
            player.BounceBack(bounceForce);
            Destroy(gameObject);
        }
    }
}