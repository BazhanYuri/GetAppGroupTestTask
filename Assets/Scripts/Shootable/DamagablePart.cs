using UnityEngine;




namespace TestTask
{
    public enum PlayerType
    {
        Player,
        Enemy
    }
    public class DamagablePart : MonoBehaviour
    {
        [SerializeField] private PlayerType _playerType;

        private Damagable _damagable;

        public Damagable Damagable { get => _damagable;}
        public PlayerType PlayerType { get => _playerType;}



        public void Init(Damagable damagable)
        {
            _damagable = damagable;
        }
    }
}

