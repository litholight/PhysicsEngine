// PhysicsEngine.Common/Services/GameInitializationService.cs
using PhysicsEngine.Common.Abstractions;
using PhysicsEngine.Common.Models;
using PhysicsEngine.Common.Scenes;

namespace PhysicsEngine.Common.Services
{
    public class GameInitializationService : IGameInitializationService
    {
        private readonly SceneManager _sceneManager;

        public GameInitializationService(SceneManager sceneManager)
        {
            _sceneManager = sceneManager;
        }

        public void InitializeGame()
        {
            var mainScene = new Scene("Main");
            var player = new Player();
            mainScene.AddGameObject(player);

            var enemy = new GameObject
            {
                X = 300,
                Y = 100,
                Width = 50,
                Height = 50,
                Color = Color.Brown
            };
            mainScene.AddGameObject(enemy);

            _sceneManager.AddScene("Main", mainScene);
            _sceneManager.SwitchToScene("Main");
        }
    }
}
