using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(menuName = "Scriptable objects/Health data")]
    public class HealthData : ScriptableObject
    {
        [Min(0.0f)] public float MaxHealth = 10.0f;
    }
}
