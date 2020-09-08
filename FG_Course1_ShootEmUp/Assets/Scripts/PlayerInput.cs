using System;
using UnityEngine;

namespace ShootEmUp
{
    [RequireComponent(typeof(Movement))]
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private ShieldController shieldController = null;

        private Movement movement;
        
        #region Input Axes
        private const string shieldID = "Shield";
        private const string horizontalID = "Horizontal";
        private const string verticalID = "Vertical";
        #endregion // Input Axes

        private void Awake()
        {
            movement = GetComponent<Movement>();
        }

        private void Update()
        {
            if (Input.GetButtonDown(shieldID))
            {
                shieldController.ActivateShield();
            }
            movement.input.Set(Input.GetAxisRaw(horizontalID), Input.GetAxisRaw(verticalID));
        }
    }
}