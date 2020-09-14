using UnityEngine;

namespace ShootEmUp
{
    
    public class EnemyExistanceArea : MonoBehaviour
    {
        private void OnTriggerExit2D(Collider2D other)
        {
            other.gameObject.SetActive(false);
        }
    }
}
