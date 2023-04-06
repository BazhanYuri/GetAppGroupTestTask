using System.Threading.Tasks;
using UnityEngine;




namespace TestTask
{
    [System.Serializable]
    public class AidKitSpawner
    {
        [SerializeField] private GameConfig _gameConfig;
        [SerializeField] private AidKitPool _aidKitPool;
        [SerializeField] private SpawnerZone _spawnerZone;

        public void InitSpawner()
        {
            _aidKitPool.InitPool();
        }

        public async void StartSpawning()
        {
            while (true)
            {
                await Task.Delay(_gameConfig.SpawnAidsTime.GetRandom());
                SpawnAidKit();
            }
        }
        private void SpawnAidKit()
        {
            AidKit aid = _aidKitPool.Take();
            if (aid == null)
            {
                return;
            }
            aid.transform.position = _spawnerZone.GetRandomPoint() + new Vector3(0, 10, 0);
        }

    }

}

