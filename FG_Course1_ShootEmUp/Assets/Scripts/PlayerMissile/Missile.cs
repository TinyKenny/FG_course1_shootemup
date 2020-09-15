using UnityEngine;

namespace ShootEmUp
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Missile : MonoBehaviour
    {
        [SerializeField] private MissileData data = null;
        
        private Rigidbody2D body = null;
        private float endOfLifeTime = 0.0f;

        [System.NonSerialized] public Vector2 targetDirection;
        
        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            endOfLifeTime = Time.time + data.timeToLive;
            targetDirection = transform.up;
        }

        private void FixedUpdate()
        {
            float targetAngle = Vector2.SignedAngle(transform.up, targetDirection);
            body.MoveRotation(body.rotation + Mathf.Clamp(targetAngle, -data.turnSpeed, data.turnSpeed) * Time.fixedDeltaTime);
            
            body.MovePosition(body.position + Time.fixedDeltaTime * data.speed * (Vector2)transform.up);
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
            IAttackable hitAttackable = other.GetComponent<IAttackable>();
            if (hitAttackable != null)
            {
                hitAttackable.TakeDamage(data.damage);
            }
            gameObject.SetActive(false);
        }
    }
}
