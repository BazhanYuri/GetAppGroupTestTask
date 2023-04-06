using UnityEngine;




namespace TestTask
{
    [System.Serializable]
    public class PlayerShootable
    {
        [SerializeField] private Shootable _shootable;
        private PlayerController _playerController;
        private PlayerConfig _playerConfig;

        public void Init(BulletPool bulletPool, PlayerController playerController, PlayerConfig playerConfig)
        {
            _playerController = playerController;
            _playerConfig = playerConfig;

            _shootable.Init(bulletPool, _playerConfig.ShootDelay, _playerConfig.Damage, _playerConfig.BulletType);
        }



        public void SubscribeEvents()
        {
            Debug.Log(_playerController);
            _playerController.ShootButtonPressed += _shootable.Shoot;
        }
        public void UnSubscribeEvents()
        {
            _playerController.ShootButtonPressed -= _shootable.Shoot;
        }
    }
}

