using UnityEngine;
using UnityEngine.SceneManagement;

namespace BallBalance
{
    public enum GameScenes
    {
        MainScene,
    }
    public class PopupWindowControl : MonoBehaviour
    {
        [SerializeField]
        private GameObject StartGameWindow;
        [SerializeField]
        private GameObject TryAgainWindow;
        [SerializeField]
        private GameObject Timer;

        public static PopupWindowControl Instance;
        private void Start()
        {
            Instance = this;
            CheckIfTryAgain();
        }
        public void StartGame()
        {
            Time.timeScale = 1f;
            Timer.SetActive(true);
            Timer.GetComponent<Stopwatch>().StartTimer();
            StartGameWindow.SetActive(false);
        }
        public void EndGame()
        {
            Application.Quit();
        }
        public void EnableTryAgain()
        {
            TryAgainWindow.SetActive(true);
            Time.timeScale = 0f;
        }
        public void StartNewGame()
        {
            SceneReloadHandler.IsTryAgain = true;
            Time.timeScale = 1f;
            SceneManager.LoadScene(GameScenes.MainScene.ToString());
        }
        private void CheckIfTryAgain()
        {
            if (!SceneReloadHandler.IsTryAgain)
            {
                Time.timeScale = 0f;
            }
            else
            {
                StartGameWindow.SetActive(false);
                Timer.SetActive(true);
                Timer.GetComponent<Stopwatch>().StartTimer();
                Time.timeScale = 1f;
            }
        }
    }
}