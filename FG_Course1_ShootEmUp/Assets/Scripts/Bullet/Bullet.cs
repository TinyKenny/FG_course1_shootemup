using UnityEngine;

namespace ShootEmUp
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private BulletData data = null;
        private Rigidbody2D body;
        private Vector2 movementDirection;
        private float endOfLifeTime;

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            movementDirection = transform.up;
            endOfLifeTime = Time.time + data.timeToLive;
        }

        private void FixedUpdate()
        {
            body.MovePosition(body.position + Time.fixedDeltaTime * data.speed * movementDirection);
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
