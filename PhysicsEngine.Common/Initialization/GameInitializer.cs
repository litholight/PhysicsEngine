using PhysicsEngine.Common.Assets;
using PhysicsEngine.Common.Factories;
using PhysicsEngine.Common.Models;
using PhysicsEngine.Common.Scenes;

namespace PhysicsEngine.Common.Initialization
{
    public static class GameInitializer
    {
        public static GameState InitializeGame()
        {
            AssetManager assets = new AssetManager();

            // Assuming CreateEnemy is a static method of GameObjectFactory just like CreatePlayer
            GameObject enemy = GameObjectFactory.CreateEnemy(300, 100);

            // Use the factory to create a player with its sprite sheet and animations ready
            Player player = GameObjectFactory.CreatePlayer(assets);

            // Now pass the player to the GameState constructor
            GameState gameState = new GameState(player);

            Scene startScene = new Scene("StartScene");
            startScene.AddGameObject(enemy);
            startScene.AddGameObject(player);

            gameState.SceneManager.AddScene("StartScene", startScene);
            gameState.SceneManager.SwitchToScene("StartScene");

            return gameState;
        }
    }
}
