using UnityEngine;




namespace TestTask
{
    public class PlayerMovement
    {
        private Rigidbody _rigidbody;
        private PlayerController _playerController;
        private PlayerConfig _playerConfig;

        public PlayerMovement(Rigidbody rigidbody, PlayerController playerController, PlayerConfig config)
        {
            _rigidbody = rigidbody;
            _playerController = playerController;
            _playerConfig = config;
        }



        public void Update(float timeDeltaTime)
        {
            Move(_playerController.GetMoveVector());
            LookAt(_playerController.GetLookVector());
        }
        private void Move(Vector2 moveVector)
        {
            _rigidbody.velocity = new Vector3(moveVector.x, 0, moveVector.y) * _playerConfig.WalkSpeed * Time.deltaTime;
        }
        private void LookAt(Vector2 rot)
        {
            _rigidbody.transform.GetChild(0).LookAt(_rigidbody.transform.position + new Vector3(rot.x, 0, rot.y));
        }
    }
}

