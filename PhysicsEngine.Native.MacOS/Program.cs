using System;
using System.Threading.Tasks;
using PhysicsEngine.Common.Initialization;
using PhysicsEngine.Common.Input;
using PhysicsEngine.Common.Models;
using PhysicsEngine.Common.Scenes; // Make sure to include the namespace for SceneManager
using PhysicsEngine.Common.Services;
using SDL2;

namespace PhysicsEngine.Native.MacOS
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var graphicsRenderer = new SDL2GraphicsRenderer();
            await graphicsRenderer.Initialize();

            // Initialize game state and get it ready for use
            var gameState = GameInitializer.InitializeGame();

            var lastTick = DateTime.Now;
            bool running = true;
            SDL.SDL_Event e;
            while (running)
            {
                var currentTick = DateTime.Now;
                var deltaTime = (float)(currentTick - lastTick).TotalSeconds;
                lastTick = currentTick;

                // Clear the screen at the start of each frame
                await graphicsRenderer.ClearScreen();

                // Input handling
                while (SDL.SDL_PollEvent(out e) != 0)
                {
                    if (e.type == SDL.SDL_EventType.SDL_QUIT)
                    {
                        running = false;
                    }
                    else if (e.type == SDL.SDL_EventType.SDL_KEYDOWN)
                    {
                        var action = InputTranslator.TranslateKeyToGameAction(e.key.keysym.sym);
                        if (action.HasValue)
                        {
                            // Handle input within the game state
                            gameState.HandleInput(action.Value);
                        }
                    }
                }

                // Update game logic
                gameState.Update(deltaTime);

                // Render the current scene
                await gameState.SceneManager.CurrentScene.Render(graphicsRenderer);

                // Update the screen with the current rendering
                await graphicsRenderer.Present();
            }

            graphicsRenderer.Cleanup(); // Clean up SDL resources
        }
    }

    public static class InputTranslator
    {
        public static GameAction? TranslateKeyToGameAction(SDL.SDL_Keycode keycode)
        {
            switch (keycode)
            {
                case SDL.SDL_Keycode.SDLK_UP:
                    return GameAction.MoveUp;
                case SDL.SDL_Keycode.SDLK_DOWN:
                    return GameAction.MoveDown;
                case SDL.SDL_Keycode.SDLK_LEFT:
                    return GameAction.MoveLeft;
                case SDL.SDL_Keycode.SDLK_RIGHT:
                    return GameAction.MoveRight;
                // Add cases for other keycodes as needed
                default:
                    return null; // No action for this key
            }
        }
    }
}
