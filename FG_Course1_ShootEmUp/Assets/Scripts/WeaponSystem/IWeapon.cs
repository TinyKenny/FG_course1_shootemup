using UnityEngine;

namespace ShootEmUp
{
    public interface IWeapon
    {
        GameObject gameObject { get; }
        void BeginAttack();
        void EndAttack();
    }
}
