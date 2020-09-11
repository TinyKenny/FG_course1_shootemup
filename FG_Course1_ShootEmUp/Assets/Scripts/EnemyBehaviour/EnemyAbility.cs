using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public abstract class EnemyAbility : MonoBehaviour
    {
        public IEnumerator UseAbilityRepeating(float abilityCooldown)
        {
            while (true)
            {
                yield return new WaitForSeconds(abilityCooldown);
                UseAbility();
            }
        }

        protected abstract void UseAbility();
    }
}
