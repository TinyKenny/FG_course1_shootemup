using UnityEngine;

namespace ShootEmUp
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 2.0f;
        
        [System.NonSerialized] public Vector2 input;

        private Rigidbody2D body;

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (input.sqrMagnitude > Mathf.Epsilon)
            {
                body.MovePosition(body.position +
                                  movementSpeed * Time.fixedDeltaTime * Vector2.ClampMagnitude(input, 1.0f));
            }
        }
    }
}