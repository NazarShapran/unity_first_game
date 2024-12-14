namespace Code.Runtime.infrastructure.Service.WindowButtons
{
    public interface IWindowButtonsService
    {
        void PressPauseButton();
        void PressExitButton(string bootstrapSceneMenu);
        void PressRestartButton(string levelName);
        void PressResumeButton();
    }
}