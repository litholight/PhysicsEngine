using System.Threading.Tasks;
using PhysicsEngine.Common.Abstractions;
using PhysicsEngine.Common.Input;
using PhysicsEngine.Common.Models;

namespace PhysicsEngine.Common.Models
{
    public class Player : GameObject, IInputHandler
    {
        public float Speed { get; set; } = 80.0f; // Example speed
        private bool isMovingRight = false;
        private bool isMovingLeft = false; // Added flag for moving left

        public Player()
        {
            Width = 66;
            Height = 30;
            Color = Color.Orange;
            CurrentAnimation = "SmallFacingRight";
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            // Using a switch statement to determine the current animation based on movement flags
            switch (CurrentAnimation)
            {
                case "SmallMovingRight":
                    if (isMovingRight)
                    {
                        X += Speed * deltaTime;
                    }
                    break;
                case "SmallMovingLeft": // Assuming you have a "SmallMovingLeft" animation
                    if (isMovingLeft)
                    {
                        X -= Speed * deltaTime;
                    }
                    break;
                default:
                    // Reset to facing direction if not moving
                    if (!isMovingRight && !isMovingLeft)
                    {
                        CurrentAnimation = "SmallFacingRight";
                    }
                    break;
            }
        }

        public void HandleAction(GameAction action)
        {
            // Reset movement flags
            isMovingRight = false;
            isMovingLeft = false;

            switch (action)
            {
                case GameAction.MoveUp:
                    Y -= Speed * 0.5f; // Adjusted to use the Speed property for consistency
                    break;
                case GameAction.MoveDown:
                    Y += Speed * 0.5f;
                    break;
                case GameAction.MoveLeft:
                    isMovingLeft = true;
                    CurrentAnimation = "SmallMovingLeft"; // Switch to moving left animation
                    break;
                case GameAction.MoveRight:
                    isMovingRight = true;
                    CurrentAnimation = "SmallMovingRight"; // Keep or switch to moving right animation
                    break;
                // Handle other actions as needed
            }
        }
    }
}
