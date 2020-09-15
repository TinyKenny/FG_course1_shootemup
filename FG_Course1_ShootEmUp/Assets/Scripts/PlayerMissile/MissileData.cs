using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(menuName = "Scriptable objects/Missile data")]
    public class MissileData : BulletData
    {
        [Min(0.0f)] public float turnSpeed = 15.0f;
    }
}
