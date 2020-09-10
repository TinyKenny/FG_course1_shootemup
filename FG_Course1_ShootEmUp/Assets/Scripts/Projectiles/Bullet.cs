using System;
using UnityEngine;

namespace ShootEmUp
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private BulletData data = null;
        private Rigidbody2D body;
        private Vector2 movementDirection;
        private float timeToLive;

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            movementDirection = transform.up;
            timeToLive = data.timeToLive;
        }

        private void FixedUpdate()
        {
            body.MovePosition(body.position + Time.deltaTime * data.speed * movementDirection);
        }

        private void Update()
        {
            timeToLive -= Time.deltaTime;
            if (timeToLive <= 0.0f)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
