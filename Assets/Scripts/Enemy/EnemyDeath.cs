using System;
using UnityEngine;




namespace TestTask
{
    [Serializable]
    public class EnemyDeath
    {
        public static event Action<Vector3> EnemyDead;
        private Damagable _damagable;
        private Transform _enemy;




        public void Init(Damagable damagable, Transform enemy)
        {
            _damagable = damagable;
            _enemy = enemy;
        }
        public void SubscribeAllEvents()
        {
            _damagable.Dead += Dead;
        }
        public void UnSubscribeAllEvents()
        {
            _damagable.Dead -= Dead;
        }


        private void Dead()
        {
            EnemyDead?.Invoke(_enemy.transform.position);
            _enemy.gameObject.SetActive(false);
        }
    }
}

