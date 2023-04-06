using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace TestTask
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private CollisionDetector _fightArea;
        [SerializeField] private DamagablePart[] _damagableParts;
        [SerializeField] private EnemyDeath _enemyDeath;


        private Damagable _damagable;
        private EnemyHitable _enemyHitable;
        private Transform _player;

        public Damagable Damagable { get => _damagable;}

        private void OnEnable()
        {
            //_enemyHitable.SubscribeAllEvents();
        }
        private void OnDisable()
        {
           // _enemyHitable.UnSubscribeAllEvents();
        }
        public void Init(Transform player)
        {
            _enemyHitable = new EnemyHitable();
            _player = player;

            _damagable = new Damagable();
            _damagable.Init(_enemyConfig.MaxHp);

            _enemyDeath = new EnemyDeath();
            _enemyDeath.Init(_damagable, transform);

            _enemyDeath.SubscribeAllEvents();

            for (int i = 0; i < _damagableParts.Length; i++)
            {
                _damagableParts[i].Init(_damagable);
            }

            _enemyMovement.Init(_player);
            _enemyHitable.Init(_fightArea, _enemyConfig, _damagable);

            _enemyHitable.SubscribeAllEvents();
        }
        public void ResetEnemy()
        {
            _damagable.Reset();
        }
        private void Update()
        {
            _enemyMovement.Update();
        }
    }
}

