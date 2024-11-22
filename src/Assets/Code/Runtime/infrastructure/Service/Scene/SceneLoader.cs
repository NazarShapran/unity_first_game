using UnityEngine.SceneManagement;

namespace Code.Runtime.infrastructure.Service.Scene
{
    public class SceneLoader : ISceneLoader
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}