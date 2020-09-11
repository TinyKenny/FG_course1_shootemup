using UnityEngine;

namespace ShootEmUp
{
    public class EnemyAbilityController : MonoBehaviour
    {
        [SerializeField, Min(0.01f)] private float cooldown = 1.0f;
        
        private EnemyAbility[] abilities;

        private void Awake()
        {
            abilities = GetComponentsInChildren<EnemyAbility>();
        }

        private void OnEnable()
        {
            foreach (EnemyAbility ability in abilities)
            {
                StartCoroutine(ability.UseAbilityRepeating(cooldown));
            }
        }
    }
}
