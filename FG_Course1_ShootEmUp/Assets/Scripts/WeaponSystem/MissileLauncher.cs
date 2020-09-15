using UnityEngine;

namespace ShootEmUp
{
    public class MissileLauncher : MonoBehaviour, IWeapon
    {
        // TODO semi-auto missile (or just use shotgun?)
        [SerializeField] private GameObject missilePrefab = null;
        
        public void BeginAttack()
        {
        }

        public void EndAttack()
        {
        }
    }
}
