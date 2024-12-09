using Code.Runtime.Data;

namespace Code.Runtime.infrastructure.Service.Progress
{
    public class ProgressService : IProgressService
    {
        public PlayerProgress PlayerProgress { get; set; }
    }
}