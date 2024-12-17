namespace Code.Runtime.Gameplay.Logic.Collectables
{
    public interface ICollectable
    {
        bool IsCollected { get; }
        void Collect(Collector collector);
    }
}   