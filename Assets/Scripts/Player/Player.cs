using UnityEngine;




namespace TestTask
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private PlayerUI _playerUI;
        [SerializeField] private PlayerShootable _playerShootable;
        [SerializeField] private DamagablePart[] _damagableParts;


        private PlayerMovement _playerMovement;
        private Damagable _damagable;

        public PlayerController PlayerController { get => _playerController;}



        
        private void OnDisable()
        {
            _playerUI.UnSubscribeAllEvents();
            _playerShootable.UnSubscribeEvents();
        }
        public void Init(BulletPool bulletPool)
        {
            _playerMovement = new PlayerMovement(_rigidbody, _playerController, _playerConfig);
            _damagable = new Damagable();

            _playerUI.HealthBar.Init(_damagable);
            _playerUI.HealthText.Init(_damagable);

            _damagable.Init(_playerConfig.MaxHealth);
            _playerShootable.Init(bulletPool, _playerController, _playerConfig);

            _playerController.Awake();
            

            for (int i = 0; i < _damagableParts.Length; i++)
            {
                _damagableParts[i].Init(_damagable);
            }
            


            _playerShootable.SubscribeEvents();
            _playerUI.SubscribeAllEvents();
        }

        private void Update()
        {
            _playerMovement.Update(Time.deltaTime);
        }
        private void LateUpdate()
        {
            _playerUI.LateUpdate();
        }
    }
}

