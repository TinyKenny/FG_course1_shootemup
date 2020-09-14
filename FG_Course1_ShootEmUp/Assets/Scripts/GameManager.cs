using System;
using UnityEngine;

namespace ShootEmUp
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _currentGameManager = null;
        private static GameManager CurrentGameManager
        {
            get
            {
                if (!_currentGameManager)
                {
                    _currentGameManager = FindObjectOfType<GameManager>();
                }
                return _currentGameManager;
            }
        }

        public static float highScoreThisSession { get; private set; }

        private float currentScore = 0.0f;

        private void Awake()
        {
            if (!_currentGameManager)
            {
                _currentGameManager = this;
            }
            else if (_currentGameManager != this)
            {
                Destroy(gameObject);
                return;
            }
        }

        public static void IncreaseScore(float amount)
        {
            CurrentGameManager.currentScore += amount;
        }
    }
}
