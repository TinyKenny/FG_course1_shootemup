﻿using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    public class StandardEnemyBehavior : EnemyBehaviour
    {
        // TODO enemies give points when defeated

        [SerializeField, Range(0.01f, 1.0f)] private float movementSpeedPortionX = 0.5f;
        [SerializeField, Min(0.1f)] private float turnFrequency;
        private float timeSinceSpawn;
        
        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            movement.input = new Vector2(0.0f, movementSpeedPortionX - 1.0f);
        }

        private void OnEnable()
        {
            timeSinceSpawn = 0.0f;
        }

        private void Update()
        {
            timeSinceSpawn += Time.deltaTime;
            movement.input.x = Mathf.Cos(timeSinceSpawn * Mathf.PI * 2.0f / turnFrequency) * movementSpeedPortionX;
        }

        private void OnDrawGizmos()
        {
            Color oldColor = Gizmos.color;

            if (Application.isPlaying)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position,
                    transform.position + new Vector3(movement.input.x, movement.input.y, 0.0f));
            }

            Gizmos.color = oldColor;
        }
    }
}