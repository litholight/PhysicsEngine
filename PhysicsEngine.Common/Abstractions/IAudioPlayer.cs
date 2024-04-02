namespace PhysicsEngine.Common.Abstractions
{
    public interface IAudioPlayer
    {
        void PlaySound(string path);
        void StopSound(string path);
    }
}
