using System.Threading.Tasks;

namespace PhysicsEngine.Common.Abstractions
{
    public interface IGameControls
    {
        Task MoveUp();
        Task MoveDown();
        Task MoveLeft();
        Task MoveRight();
    }
}
