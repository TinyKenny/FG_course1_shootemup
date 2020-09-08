using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    [SerializeField] private float shieldDuration = 1.0f;
    [SerializeField] private float shieldCooldown = 10.0f;

    private bool shieldAvailable = true;
    
    
    public void ActivateShield()
    {
        if (shieldAvailable)
        {
            StartCoroutine(Shielding());
        }
    }

    private IEnumerator Shielding()
    {
        shieldAvailable = false;
        yield return new WaitForSeconds(shieldDuration);

        shieldAvailable = true;
    }
}
