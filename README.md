Crystal Collector

Project Overview
Crystal Collector is a simple 2D game created in Unity 2022.3 using C#. The purpose of this project is to demonstrate how design patterns can help organize game code and make it easier to maintain and expand.
The game uses three design patterns: Singleton, Factory, and Observer.

Gameplay
The player controls a blue square and moves around an arena collecting five yellow crystals. Each crystal increases the score by one. Once all five crystals are collected, a victory message appears and the player can restart the game.

Controls
W, A, S, D -> Move player
Arrow keys -> Move player
R -> Restart game
Design Patterns

Singleton - GameManager
The GameManager uses the Singleton pattern to ensure only one instance exists. It manages the score, game state, and win condition.

Factory - CollectibleFactory
The CollectibleFactory creates five collectible objects at predetermined locations using a prefab. It also removes and recreates the collectibles when restarting the game.

Observer - Collectible, GameManager, and GameUI
The Observer pattern uses C# events to communicate between scripts. When the player collects a crystal, the Collectible broadcasts an event. The GameManager receives it and updates the score. The GameUI listens for score and game-state changes to update the display.

How to Run the Game
- Clone or download this GitHub repository.
- Open Unity Hub and select Add project from disk.
- Select the downloaded project folder.
- Open the project using Unity 2022.3.
- Open Assets/Scenes/MainScene.unity.
- Press Play in the Unity Editor.
- Collect all five crystals to win. Press R to reset the game.

Project Files
- GameManager.cs - Singleton, score management, and game states.
- CollectibleFactory.cs - Factory pattern and collectible spawning.
- Collectible.cs - Collision detection and collection events.
- GameUI.cs - Score, victory message, and restart instructions.
- PlayerMovement.cs - Player movement, arena boundaries, and restart input.
- Pseudocode.txt - Pseudocode outlining the game's structure and design pattern interactions.

Repository
https://github.com/robertstahldev/CrystalCollector

Video Demonstration
https://www.loom.com/share/0f0f4a484369498087cdda09a2b39f18
