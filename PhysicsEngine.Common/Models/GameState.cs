using System.Collections.Generic;
using PhysicsEngine.Common.Input;
using PhysicsEngine.Common.Scenes;

namespace PhysicsEngine.Common.Models
{
    public class GameState
    {
        public SceneManager SceneManager { get; private set; } = new SceneManager();
        public List<GameObject> GameObjects { get; set; } = new List<GameObject>();
        public Player Player { get; set; }
        public int CurrentLevel { get; set; }
        public int Score { get; set; }

        public GameState(Player player)
        {
            this.Player = player;
            GameObjects.Add(player);
        }

        public void AddGameObject(GameObject gameObject)
        {
            GameObjects.Add(gameObject);
        }

        public void Update(float deltaTime)
        {
            // Update each game object
            foreach (var gameObject in GameObjects)
            {
                gameObject.Update(deltaTime);
                HandleInteractions(gameObject);
            }
        }

        private void HandleInteractions(GameObject gameObject)
        {
            // Example: Check for and handle interactions between the provided gameObject and others in the GameObjects list
            foreach (var other in GameObjects)
            {
                if (gameObject != other && IsColliding(gameObject, other))
                {
                    // Handle collision or interaction
                    // This could involve calling a method on the gameObject or other object, updating state, etc.
                }
            }
        }

        private bool IsColliding(GameObject a, GameObject b)
        {
            // Implement collision detection logic
            return false;
        }

        public void HandleInput(GameAction action)
        {
            // Delegate the handling of the action directly to the player
            Player?.HandleAction(action);
        }
        // Methods for scene transitions, score updates, etc.
    }
}
