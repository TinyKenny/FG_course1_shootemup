using System;
using UnityEngine;

namespace ShootEmUp
{
    [RequireComponent(typeof(Movement), typeof(IAttackable))]
    public class PlayerInput : MonoBehaviour
    {
        // TODO adjust player collider and shield collider
        // TODO "how to play"-instructions (unlock new weapons, shield and game goal)
        // TODO graphics for everything
        
        [SerializeField] private ShieldController shieldController = null;
        [SerializeField] private WeaponManager weaponManager = null;

        private Movement movement;
        private IAttackable attackable;
        
        #region Input Axes
        private const string horizontalID = "Horizontal";
        private const string verticalID = "Vertical";
        private const string shieldID = "Shield";
        private const string fireID = "Fire1";
        #endregion // Input Axes

        private void Awake()
        {
            movement = GetComponent<Movement>();
            attackable = GetComponent<IAttackable>();
            attackable.onDeath += LevelLoader.LoadGameOverMenu;
        }

        private void Update()
        {
            movement.input.Set(Input.GetAxisRaw(horizontalID), Input.GetAxisRaw(verticalID));
            
            if (Input.GetButtonDown(shieldID))
            {
                shieldController.ActivateShield();
            }

            if (Input.GetButtonDown("SwapWeaponNext"))
            {
                weaponManager.SwapToNextWeapon();
            }
            else if (Input.GetButtonDown("SwapWeaponPrevious"))
            {
                weaponManager.SwapToPreviousWeapon();
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