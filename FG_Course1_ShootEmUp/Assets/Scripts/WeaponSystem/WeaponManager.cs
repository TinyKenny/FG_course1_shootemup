using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class WeaponManager : MonoBehaviour
    {
        private IWeapon[] weapons;
        private IWeapon currentWeapon;
        private int currentWeaponIndex;

        private void Awake()
        {
            Debug.Log((-1)%3);
            currentWeaponIndex = 0;
            weapons = GetComponentsInChildren<IWeapon>();
            currentWeapon = weapons[currentWeaponIndex];

            foreach (IWeapon weapon in weapons)
            {
                ((MonoBehaviour)weapon).gameObject.SetActive(false);
            }
            ((MonoBehaviour)currentWeapon).gameObject.SetActive(true);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SwapWeapon(1);
            }
        }

        private void SwapWeapon(int relativeIndex)
        {
            ((MonoBehaviour)currentWeapon).gameObject.SetActive(false);
            currentWeaponIndex = (weapons.Length + currentWeaponIndex + relativeIndex) % weapons.Length;
            currentWeapon = weapons[currentWeaponIndex];
            ((MonoBehaviour)currentWeapon).gameObject.SetActive(true);
        }
    }
}
