using Code.Runtime.Data;

namespace Code.Runtime.infrastructure.Service.Progress
{
    public interface IProgressService
    {
        PlayerProgress PlayerProgress { get; set; }
    }
}