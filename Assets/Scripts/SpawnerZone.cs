using UnityEngine;




namespace TestTask
{
    [System.Serializable]
    public class SpawnerZone
    {
        [SerializeField] private BoxCollider[] _spawnAreas;




        public Vector3 GetRandomPoint()
        {
            Bounds bounds = GetRandomArea().bounds;

            return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            0,
            Random.Range(bounds.min.z, bounds.max.z)
            );
        }
        private BoxCollider GetRandomArea()
        {
            return _spawnAreas[Random.Range(0, _spawnAreas.Length)];
        }
           
    }
}

