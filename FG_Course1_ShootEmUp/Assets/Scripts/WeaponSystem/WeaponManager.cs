using UnityEngine;

namespace ShootEmUp
{
    public class WeaponManager : MonoBehaviour
    {
        private IWeapon[] weapons;
        private IWeapon currentWeapon;
        private int currentWeaponIndex;
        //private bool Attacking

        private void Awake()
        {
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

        private void SwapWeapon(int relativeIndex)
        {
            currentWeapon.gameObject.SetActive(false);
            currentWeaponIndex = (weapons.Length + currentWeaponIndex + relativeIndex) % weapons.Length;
            currentWeapon = weapons[currentWeaponIndex];
            currentWeapon.gameObject.SetActive(true);
        }
    }
}
