using Code.Runtime.Data;

namespace Code.Runtime.infrastructure.Service.Windows
{
    public interface IWindowService
    {
        void OpenWindow(WindowTypeId windowTypeId);
        void CloseWindow();
    }
}