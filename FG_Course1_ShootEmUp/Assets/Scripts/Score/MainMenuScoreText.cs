using System;
using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class MainMenuScoreText : MonoBehaviour
    {
        [SerializeField] private Text bestScoreText = null;

        private void Awake()
        {
            bestScoreText.text = "Current best score: " + (int)ScoreManager.GetBestScore();
        }
    }
}
