using UnityEngine;

namespace ShootEmUp
{
    public class WeaponManager : MonoBehaviour
    {
        private IWeapon[] weapons;
        private int lockedWeaponIndex;
        private IWeapon currentWeapon;
        private int currentWeaponIndex;

        private void Awake()
        {
            lockedWeaponIndex = 1;
            currentWeaponIndex = 0;
            
            weapons = GetComponentsInChildren<IWeapon>();
            currentWeapon = weapons[currentWeaponIndex];

            foreach (IWeapon weapon in weapons)
            {
                weapon.gameObject.SetActive(false);
            }
            currentWeapon.gameObject.SetActive(true);
        }

        public void SwapToNextWeapon()
        {
            SwapWeapon(1);
        }

        public void SwapToPreviousWeapon()
        {
            SwapWeapon(-1);
        }

        public void BeginAttack()
        {
            currentWeapon.BeginAttack();
        }

        public void EndAttack()
        {
            currentWeapon.EndAttack();
        }

        public void UnlockNextWeapon()
        {
            if (lockedWeaponIndex < weapons.Length)
            {
                lockedWeaponIndex++;
            }
            else
            {
                WeaponDropManager.DisableWeaponDrops();
            }
        }

        private void SwapWeapon(int relativeIndex)
        {
            currentWeapon.gameObject.SetActive(false);
            currentWeaponIndex = (lockedWeaponIndex + currentWeaponIndex + relativeIndex) % lockedWeaponIndex;
            currentWeapon = weapons[currentWeaponIndex];
            currentWeapon.gameObject.SetActive(true);
        }
    }
}
