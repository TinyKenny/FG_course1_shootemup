using UnityEngine;

namespace ShootEmUp
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class WeaponPickup : MonoBehaviour
    {
        // TODO system for dropping weapon-unlocks
        // TODO weapon pickup prefab
        
        private Rigidbody2D body;

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // TODO unlock next weapon
            gameObject.SetActive(false);
        }
    }
}
