﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class FullAutoCanon : MonoBehaviour, IWeapon
    {
        [SerializeField] private GameObject bulletPrefab = null;
        [SerializeField] private float secondsBetweenShots = 0.1f;
        //[SerializeField] private Image weaponImage = null;
        //[SerializeField] private Texture2D weaponActiveIcon = null;
        //[SerializeField] private Texture2D weaponInactiveIcon = null;

        private Coroutine attackCoroutine;
        private float timeOfLastShot = 0.0f;

        public void BeginAttack()
        {
            attackCoroutine = StartCoroutine(FullAutoAttack(Mathf.Max(0.0f, timeOfLastShot + secondsBetweenShots - Time.time)));
        }

        public void EndAttack()
        {
            StopCoroutine(attackCoroutine);
        }

        private IEnumerator FullAutoAttack(float startDelay)
        {
            yield return new WaitForSeconds(startDelay);

            while (true)
            {
                GameObject bullet = ObjectPoolManager.GetPooledObject(bulletPrefab, transform.position, transform.rotation);
                timeOfLastShot = Time.time;
                yield return new WaitForSeconds(secondsBetweenShots);
            }
        }
    }
}
