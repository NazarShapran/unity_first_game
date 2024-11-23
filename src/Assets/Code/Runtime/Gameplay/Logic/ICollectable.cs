namespace Code.Runtime.Gameplay.Logic
{
    public interface ICollectable
    {
        bool IsCollected { get; }
        void Collect(Collector collector);
    }
}   