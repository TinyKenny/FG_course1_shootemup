﻿using System;
using UnityEngine;

namespace ShootEmUp
{
    [RequireComponent(typeof(Movement))]
    public class PlayerInput : MonoBehaviour
    {
        // TODO homing missiles
        // TODO game over condition
        // TODO main menu
        // TODO game over menu
        // TODO high score system
        [SerializeField] private ShieldController shieldController = null;
        [SerializeField] private WeaponManager weaponManager = null;

        private Movement movement;
        
        #region Input Axes
        private const string horizontalID = "Horizontal";
        private const string verticalID = "Vertical";
        private const string shieldID = "Shield";
        private const string fireID = "Fire1";
        #endregion // Input Axes

        private void Awake()
        {
            movement = GetComponent<Movement>();
        }

        private void Update()
        {
            movement.input.Set(Input.GetAxisRaw(horizontalID), Input.GetAxisRaw(verticalID));
            
            if (Input.GetButtonDown(shieldID))
            {
                shieldController.ActivateShield();
            }

            if (Input.GetButtonDown(fireID))
            {
                weaponManager.BeginAttack();
            }
            else if (Input.GetButtonUp(fireID))
            {
                weaponManager.EndAttack();
            }
            
            #if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Keypad0))
            {
                weaponManager.UnlockNextWeapon();
            }
            #endif // UNITY_EDITOR
        }
    }
}