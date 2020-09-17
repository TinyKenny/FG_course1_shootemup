using UnityEngine;

namespace ShootEmUp
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class WeaponPickup : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 0.0f;
        [SerializeField, Min(0.0f)] private float timeToLive = 10.0f;
        
        private Rigidbody2D body;
        private float endOfLifeTime;

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            body.velocity = movementSpeed * Vector2.down;
            endOfLifeTime = Time.time + timeToLive;
        }

        private void Update()
        {
            if (Time.time >= endOfLifeTime)
            {
                gameObject.SetActive(false);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            WeaponManager weaponManager = other.GetComponentInChildren<WeaponManager>();
            if (weaponManager)
            {
                weaponManager.UnlockNextWeapon();
            }
            gameObject.SetActive(false);
        }
    }
}
