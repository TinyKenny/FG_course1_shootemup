using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public class SemiAutoShotgun : MonoBehaviour, IWeapon
    {
        [SerializeField] private GameObject bulletPrefab = null;
        [SerializeField, Range(0.0f, 360.0f)] private float coneAngle = 10.0f;
        [SerializeField, Min(2)] private int projectileCount = 5;
        [SerializeField, HideInInspector] private float secondsBetweenShots = 1.0f;

        private float timeOfLastShot = 0.0f;

        public void BeginAttack()
        {
            if (timeOfLastShot + secondsBetweenShots - Time.time <= 0.0f)
            {
                timeOfLastShot = Time.time;
                float anglePerStep = coneAngle / (projectileCount - 1);

                Quaternion rotation = transform.rotation;
                rotation *= Quaternion.AngleAxis(-coneAngle * 0.5f, transform.forward);
                Quaternion rotationPerBullet =
                    Quaternion.AngleAxis(coneAngle / (projectileCount - 1), transform.forward);

                for (int i = 0; i < projectileCount; i++)
                {
                    ObjectPooler.GetPooledObject(bulletPrefab, transform.position, rotation);
                    rotation *= Quaternion.AngleAxis(anglePerStep, transform.forward);
                }
            }
        }

        public void EndAttack()
        {
            
        }
    }
}
