using ShootEmUp;
using Unity.Mathematics;
using UnityEngine;

public class WeaponDropManager : MonoBehaviour
{
    private static WeaponDropManager _currentWeaponDropManager;
    private static WeaponDropManager CurrentWeaponDropManager
    {
        get
        {
            if (!_currentWeaponDropManager)
            {
                _currentWeaponDropManager = FindObjectOfType<WeaponDropManager>();
            }
            return _currentWeaponDropManager;
        }
    }

    [SerializeField] private GameObject weaponPickupPrefab = null;
    [SerializeField, Min(0)] private int requiredKillsToDrop = 10;
    
    private int killsUntilDrop = 0;
    

    private void Awake()
    {
        if (!_currentWeaponDropManager)
        {
            _currentWeaponDropManager = this;
        }
        else if (_currentWeaponDropManager != this)
        {
            Destroy(gameObject);
            return;
        }

        killsUntilDrop = requiredKillsToDrop;
    }

    public static void EnemyDied(Vector3 location)
    {
        CurrentWeaponDropManager.killsUntilDrop--;
        if (CurrentWeaponDropManager.killsUntilDrop <= 0)
        {
            ObjectPoolManager.GetPooledObject(CurrentWeaponDropManager.weaponPickupPrefab, location,
                quaternion.identity);
            CurrentWeaponDropManager.killsUntilDrop = CurrentWeaponDropManager.requiredKillsToDrop;
        }
    }
}
