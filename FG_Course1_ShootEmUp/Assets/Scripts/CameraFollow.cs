using System;
using UnityEngine;

namespace ShootEmUp
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform = null;

        private void LateUpdate()
        {
            transform.position = playerTransform.position + new Vector3(0.0f, 0.0f, -10.0f);
        }
    }
}
