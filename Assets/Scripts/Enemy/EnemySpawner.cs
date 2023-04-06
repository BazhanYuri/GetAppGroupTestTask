using System.Threading.Tasks;
using UnityEngine;




namespace TestTask
{
    [System.Serializable]
    public class EnemySpawner
    {
        [SerializeField] private GameConfig _gameConfig;
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private SpawnerZone _spawnerZone;

        public EnemyPool EnemyPool { get => _enemyPool;}

        public void InitSpawner(Transform player)
        {
            _enemyPool.InitPool();

            foreach (Enemy enemy in _enemyPool.ObjectPooled)
            {
                enemy.Init(player);
            }
        }

        public async void StartSpawning()
        {
            while (true)
            {
                await Task.Delay(_gameConfig.SpawnEnemyDelay);
                SpawnEnemies();
            }
        }
        private void SpawnEnemies()
        {
            int countOfEnemies = _gameConfig.CountOfSpawnedEnemies.GetRandom();

            for (int i = 0; i < countOfEnemies; i++)
            {
                Enemy enemy = _enemyPool.Take();
                enemy.transform.position = _spawnerZone.GetRandomPoint();
                enemy.ResetEnemy();
            }
        }

    }
}

