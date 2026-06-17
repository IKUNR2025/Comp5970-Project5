# Cyber Ball Rush

## COMP5970 Project 4

Cyber Ball Rush is a 3D endless survival rolling ball game made in Unity. The player controls a cyber-style ball, moves across procedurally generated platforms, avoids hazards, and tries to survive as long as possible while the score increases based on distance traveled.

## Features

* 3D rolling ball movement using A/D or arrow keys
* Camera follow system
* Endless procedural platform generation
* Multiple platform section prefabs
* Old platform removal system to improve performance
* Three different hazard types
* Red death hazards that cause instant Game Over
* Yellow slow hazards that reduce player movement speed
* Blue bounce hazards that push the player and affect control
* Survival score based on distance traveled
* Score UI displayed during gameplay
* Lose condition when the player falls off the platforms
* Game Over screen with final score
* Restart button after Game Over
* Start menu screen
* Cyber-style platform textures and background visuals
* Background music during gameplay

## Controls

* **A / D**: Move the ball left and right
* **Left / Right Arrow Keys**: Move the ball left and right
* **Start Game Button**: Begin the game
* **Restart Button**: Restart after Game Over

## Gameplay

The goal is to survive as long as possible by staying on the platforms and avoiding hazards.

The player controls a rolling cyber ball that automatically moves forward. New platform sections are generated ahead of the player as the game continues, while old platform sections behind the player are removed. The player must react to platform changes and avoid dangerous objects.

The survival score increases based on how far the player travels. The game ends when the player falls off the platforms or hits a death hazard.

## Main Systems

### Procedural Platform Generation

The game uses an endless platform generation system. New platform sections spawn ahead of the player as the ball moves forward. Old platform sections behind the player are destroyed so the scene does not keep filling up with objects.

### Platform Variety

The game includes multiple platform prefabs with different widths and layouts. These platform sections are randomly selected by the generator to create a changing endless path for the player.

### Hazard System

The game includes three hazard types. Red hazards cause an instant Game Over. Yellow hazards slow down the player for a short time. Blue hazards bounce the player and affect movement control. These hazards make the gameplay more challenging than simply avoiding falling.

### Survival Score System

The game tracks the player's survival score based on distance traveled. The score is displayed on the screen during gameplay and the final score is shown on the Game Over screen.

### Game Flow

The game starts with a Start Menu. After the player clicks the Start Game button, the ball begins moving, the score starts increasing, and platforms continue to generate. When the player loses, the Game Over screen appears with the final score and a Restart button.

### Visual and Audio Design

The game uses cyber-style platform textures, background visuals, colored hazard materials, and background music to create a futuristic endless runner feeling.

## Asset Notes

The game textures and visual assets were generated or edited with AI tools.
Background music and sound settings were added and configured in Unity.

## Author

Cunzhi You
