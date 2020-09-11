using UnityEngine;

namespace ShootEmUp
{
    public class WeaponManager : MonoBehaviour
    {
        private IWeapon[] weapons; // TODO a total of at least 3 different weapons
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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SwapWeapon(1);
            }
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
            // TODO in-game weapon unlocks
            if (lockedWeaponIndex < weapons.Length)
            {
                lockedWeaponIndex++;
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
