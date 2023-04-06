using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;




namespace TestTask
{
    [System.Serializable]
    public class EnemyMovement
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;


        private Transform _player;

        public void Init(Transform player)
        {
            _player = player;
        }



        public void Update()
        {
            _navMeshAgent.destination = _player.position;
        }
        
    }
}

