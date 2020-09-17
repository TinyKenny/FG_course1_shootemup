using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class GameOverScoreText : MonoBehaviour
    {
        [SerializeField] private Text scoreThisRunText = null;
        [SerializeField] private Text previousBestScoreText = null;
        [SerializeField] private Text newBestScoreAlertText = null;

        private void Awake()
        {
            scoreThisRunText.text = "Score this run: " + (int) ScoreManager.scoreThisRun;
            previousBestScoreText.text = "Previous best: " + (int) ScoreManager.previousBestScore;
            newBestScoreAlertText.gameObject.SetActive(ScoreManager.bestScoreIsNew);
        }
    }
}
