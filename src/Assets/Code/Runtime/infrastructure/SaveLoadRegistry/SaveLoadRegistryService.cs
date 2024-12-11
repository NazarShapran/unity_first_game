using System.Collections.Generic;
using Code.Runtime.infrastructure.SaveLoad;

namespace Code.Runtime.infrastructure.SaveLoadRegistry
{
    public class SaveLoadRegistryService : ISaveLoadRegistryService
    {
        private readonly List<IReadProgress> _progressReaders = new();
        private readonly List<IWriteProgress> _progressWriters = new ();
        public IEnumerable<IReadProgress> ProgressReaders => _progressReaders;
        public IEnumerable<IWriteProgress> ProgressWriters => _progressWriters;

        public void RegisterAsProgressReader(IReadProgress readProgress)
        {
            _progressReaders.Add(readProgress);
        }
        public void RegisterAsProgressWriter(IWriteProgress writeProgress)
        {
            _progressWriters.Add(writeProgress);
        }

    }
}