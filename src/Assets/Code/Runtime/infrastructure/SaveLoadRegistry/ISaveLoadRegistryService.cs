using System.Collections.Generic;
using Code.Runtime.infrastructure.SaveLoad;

namespace Code.Runtime.infrastructure.SaveLoadRegistry
{
    public interface ISaveLoadRegistryService
    {
        IEnumerable<IReadProgress> ProgressReaders { get; }
        IEnumerable<IWriteProgress> ProgressWriters { get; }
        void RegisterAsProgressReader(IReadProgress readProgress);
        void RegisterAsProgressWriter(IWriteProgress writeProgress);
    }
}