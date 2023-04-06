using System.Threading.Tasks;
using UnityEngine;




namespace TestTask
{
    public class EnemyHitable
    {
        private EnemyConfig _enemyConfig;
        private CollisionDetector _fightArea;

        private Damagable _enemyDamagable;
        private DamagablePart _damagablePart;
        private bool _isAttacking = false;


        public void SubscribeAllEvents()
        {
            _fightArea.CollisionEntered += CheckIsPlayerEntered;
            _fightArea.CollisionExited += CheckIsPlayerExited;
            _enemyDamagable.Dead += StopHit;
        }
        public void UnSubscribeAllEvents()
        {
            _fightArea.CollisionEntered -= CheckIsPlayerEntered;
            _fightArea.CollisionExited -= CheckIsPlayerExited;
            _enemyDamagable.Dead -= StopHit;
        }

        public void Init(CollisionDetector fightArea, EnemyConfig enemyConfig, Damagable enemyDamagable)
        {
            _fightArea = fightArea;
            _enemyConfig = enemyConfig;
            _enemyDamagable = enemyDamagable;
        }


        private void CheckIsPlayerEntered(Collider collider)
        {
            if (collider.TryGetComponent(out DamagablePart damagablePart))
            {
                if (damagablePart.PlayerType == PlayerType.Player)
                {
                    _damagablePart = damagablePart;
                    StartHit();
                }
            }
        }
        private void CheckIsPlayerExited(Collider collider)
        {
            if (collider.TryGetComponent(out DamagablePart damagablePart))
            {
                if (damagablePart.PlayerType == PlayerType.Player)
                {
                    StopHit();
                }
            }
        }

        private async void StartHit()
        {
            _isAttacking = true;

            while (_isAttacking == true)
            {
                await Task.Delay(_enemyConfig.HitDelay);
                _damagablePart.Damagable.TakeHealth(_enemyConfig.Damage);
            }
        }
        private void StopHit()
        {
            _isAttacking = false;
        }
    }
}

