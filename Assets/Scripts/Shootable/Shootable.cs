using UnityEngine;
using System.Threading.Tasks;



namespace TestTask
{
    [System.Serializable]
    public class Shootable
    {
        [SerializeField] private Transform Shooter;
        [SerializeField] private Transform ShootPoint;

        private BulletPool _bulletPool;
        private bool _isDelayed = false;
        private BulletType _bulletType;
        private int _delay;
        private int _damage;

        public void Init(BulletPool bulletPool, int delay, int damage, BulletType bulletType)
        {
            _bulletPool = bulletPool;
            _delay = delay;
            _damage = damage;
            _bulletType = bulletType;
        }

        public void Shoot() 
        {
            if (_isDelayed == true)
            {
                return;
            }

            Bullet bullet = _bulletPool.Take();

            bullet.transform.position = ShootPoint.position;
            bullet.Shoot(Shooter, _damage, _bulletType);
            Delay();
        }
        private async void Delay()
        {
            _isDelayed = true;
            await Task.Delay(_delay);
            _isDelayed = false;
        }
    }
}

