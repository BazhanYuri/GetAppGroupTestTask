using UnityEngine;




namespace TestTask
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private CameraManager _cameraManager;
        [SerializeField] private VariableJoystick _moveJoystick;
        [SerializeField] private VariableJoystick _lookJoystick;
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private Turret _turretPrefab;
        [SerializeField] private BulletPool _bulletPool;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private AidKitSpawner _aidKitSpawner;
        [SerializeField] private VisualEffectsManager _visualEffectsManager;


        private Player _player;
        private Turret _turret;



        
        private void Awake()
        {
            SpawnPlayer();
            SetDepenciens();
            _bulletPool.InitPool();

            _enemySpawner.InitSpawner(_player.transform);
            _enemySpawner.StartSpawning();
            _visualEffectsManager.SubscribeAllEvents();

            _aidKitSpawner.InitSpawner();
            _aidKitSpawner.StartSpawning();

            SpawnTurret();
        }
        private void SpawnPlayer()
        {
            _player = Instantiate(_playerPrefab);
            _player.Init(_bulletPool);
        }
        private void SpawnTurret()
        {
            _turret = Instantiate(_turretPrefab);
            _turret.Init(_enemySpawner.EnemyPool, _bulletPool);
        }
        private void SetDepenciens()
        {
            _cameraManager.SetPlayer(_player.transform);
            _player.PlayerController.SetJoysticks(_moveJoystick, _lookJoystick);
        }

    }
}

