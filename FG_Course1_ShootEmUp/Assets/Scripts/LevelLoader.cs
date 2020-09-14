using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShootEmUp
{
    public class LevelLoader : MonoBehaviour
    {
        #region SceneIDs
        private const int mainMenuID = 0;
        private const int gameplaySceneID = 1;
        private const int gameOverMenuID = 2;
        #endregion
        
        public void LoadMainMenu()
        {
            SceneManager.LoadScene(mainMenuID);
        }

        public void LoadGameplayScene()
        {
            SceneManager.LoadScene(gameplaySceneID);
        }

        public static void LoadGameOverMenu()
        {
            SceneManager.LoadScene(gameOverMenuID);
        }

        public void QuitGame()
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}
