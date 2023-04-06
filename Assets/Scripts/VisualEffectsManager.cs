using UnityEngine;




namespace TestTask
{
    [System.Serializable]
    public class VisualEffectsManager
    {
        [SerializeField] private ParticleSystem _enemyDeathParticle;

        public void SubscribeAllEvents()
        {
            EnemyDeath.EnemyDead += SpawnEnemyDeadParticle;
        }

        private void SpawnEnemyDeadParticle(Vector3 pos)
        {
            Debug.Log("Enemy deadparticle");
            Object.Instantiate(_enemyDeathParticle, pos, Quaternion.identity);
        }

        
    }
}

