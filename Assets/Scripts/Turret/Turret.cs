using System.Collections;
using UnityEngine;
using DG.Tweening;



namespace TestTask
{
    public class Turret : MonoBehaviour
    {
        [SerializeField] private Transform _rotatablePart;
        [SerializeField] private TurretConfig _turretConfig;
        [SerializeField] private Shootable _shootable;

        private EnemyPool _enemyPool;
        private Enemy _currentShootedEnemy;


        private bool _isShootingEnemy = false;


        public void Init(EnemyPool enemyPool, BulletPool bulletPool)
        {
            _enemyPool = enemyPool;
            _shootable.Init(bulletPool, _turretConfig.ShootDelay.GetRandom(), _turretConfig.Damage, _turretConfig.BulletType);
        }


        private void Update()
        {
            CheckEnemies();
        }
        private void CheckEnemies()
        {
            if (_isShootingEnemy == true)
            {
                return;
            }

            foreach (Enemy enemy in _enemyPool.ObjectPooled)
            {
                bool isAim = enemy.gameObject.active == true && enemy.Damagable.IsAlive == true && Vector3.Distance(transform.position, enemy.transform.position) <= _turretConfig.ShootRadius;
                if (isAim == true)
                {
                    _isShootingEnemy = true;
                    _currentShootedEnemy = enemy;

                    Vector3 relativePos = enemy.transform.position - transform.position;
                    Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
                    Sequence seq = DOTween.Sequence();


                    seq.Append(_rotatablePart.DORotate(rotation.eulerAngles, 0.3f));
                    seq.AppendCallback(() => StartCoroutine(ShootAtEnemy()));
                    seq.AppendCallback(() => StartCoroutine(LookAtEnemy()));
                    return;
                }
            }
        }
        private IEnumerator ShootAtEnemy()
        {
            while (true)
            {
                yield return new WaitForSeconds(_turretConfig.ShootDelay.GetRandom());
                _shootable.Shoot();
            }
        }
        private IEnumerator LookAtEnemy()
        {
            while (true)
            {
                if (_currentShootedEnemy.Damagable.IsAlive == false)
                {
                    _isShootingEnemy = false;
                    StopAllCoroutines();
                }
                yield return null;


                Vector3 lookAt = _currentShootedEnemy.transform.position;
                lookAt.y = _rotatablePart.position.y;
                _rotatablePart.LookAt(lookAt);
                _shootable.Shoot();
            }
        }
    }
}

