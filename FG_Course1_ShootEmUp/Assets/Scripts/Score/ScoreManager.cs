using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class ScoreManager : MonoBehaviour
    {
        private static ScoreManager _currentScoreManager = null;
        private static ScoreManager CurrentScoreManager
        {
            get
            {
                if (!_currentScoreManager)
                {
                    _currentScoreManager = FindObjectOfType<ScoreManager>();
                }
                return _currentScoreManager;
            }
        }

        public static float previousBestScore { get; private set; } = 0.0f;
        public static bool bestScoreIsNew { get; private set; } = false;
        public static float scoreThisRun { get; private set; } = 0.0f;

        [SerializeField] private Text scoreText = null;

        private void Awake()
        {
            if (!_currentScoreManager)
            {
                _currentScoreManager = this;
            }
            else if (_currentScoreManager != this)
            {
                Destroy(gameObject);
                return;
            }

            if (bestScoreIsNew)
            {
                previousBestScore = scoreThisRun;
            }
            
            SetScoreTo(0.0f);
        }

        private void OnDestroy()
        {
            if (previousBestScore < scoreThisRun)
            {
                bestScoreIsNew = true;
            }
            else
            {
                bestScoreIsNew = false;
            }
        }

        public static float GetBestScore()
        {
            if (bestScoreIsNew)
            {
                return scoreThisRun;
            }
            return previousBestScore;
        }

        public static void IncreaseScore(float amount)
        {
            SetScoreTo(scoreThisRun + amount);
        }

        private static void SetScoreTo(float amount)
        {
            scoreThisRun = amount;
            CurrentScoreManager.scoreText.text = "Current score: " + (int)scoreThisRun;
        }
    }
}
