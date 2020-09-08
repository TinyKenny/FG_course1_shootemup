using UnityEngine;

namespace ShootEmUp
{
    public class ShieldController : MonoBehaviour
    {
        [SerializeField] private GameObject shield = null;
        [SerializeField] private Timer shieldTimer = null;
        [SerializeField] private Timer shieldCooldownTimer = null;

        [SerializeField] private float shieldDuration = 1.0f;
        [SerializeField] private float shieldCooldown = 10.0f;

        private bool shieldAvailable = true;

        private void Awake()
        {
            shield.SetActive(false);
            shieldTimer.onTimerCompleted.AddListener(DeactivateShield);
            shieldCooldownTimer.onTimerCompleted.AddListener(OnCooldownEnd);
        }

        public void ActivateShield()
        {
            if (shieldAvailable)
            {
                shieldAvailable = false;
                shield.SetActive(true);
                shieldTimer.StartTimer(shieldDuration);
            }
        }

        private void DeactivateShield()
        {
            shield.SetActive(false);
            BeginCooldown();
        }

        private void BeginCooldown()
        {
            shieldCooldownTimer.StartTimer(shieldCooldown);
        }

        private void OnCooldownEnd()
        {
            shieldAvailable = true;
        }
    }
}