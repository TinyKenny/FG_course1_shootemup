﻿using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

namespace ShootEmUp
{
    [RequireComponent(typeof(Movement), typeof(IAttackable))]
    public abstract class EnemyBehaviour : MonoBehaviour
    {
        // TODO enemy scaling
        
        protected Movement movement = null;
        protected IAttackable attackable = null;
        [SerializeField] private float scoreValue = 1.0f;

        protected virtual void Awake()
        {
            movement = GetComponent<Movement>();
            attackable = GetComponent<IAttackable>();
            Assert.IsNotNull(attackable, "Enemy must have an attackable component, for example Unit Health");

            attackable.onDeath += OnDeath;
        }

        protected virtual void OnEnable()
        {
            MissileTargetManager.AddTarget(gameObject);
        }

        private void OnDeath()
        {
            ScoreManager.IncreaseScore(scoreValue);
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            MissileTargetManager.RemoveTarget(gameObject);
        }
    }
}
