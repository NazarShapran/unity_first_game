using Code.Runtime.Data;

namespace Code.Runtime.infrastructure.SaveLoad
{
    public interface IWriteProgress
    {
        public void Write(PlayerProgress playerProgress);

    }
}