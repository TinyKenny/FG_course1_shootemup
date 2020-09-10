using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(menuName = "Scriptable objects/Bullet data")]
    public class BulletData : ScriptableObject
    {
        [Min(0.0f)] public float speed = 1.0f;
        [Min(0.0f)] public float damage = 1.0f;
        [Min(0.0f)] public float timeToLive = 1.0f;
    }
}
