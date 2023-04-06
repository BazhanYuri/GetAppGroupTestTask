using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace TestTask
{
    [System.Serializable]
    public class Clamps
    {
        [SerializeField] private int _min;
        [SerializeField] private int _max;

        public int GetRandom()
        {
            return Random.Range(_min, _max);
        }
    }

    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameConfig", order = 1)]

    public class GameConfig : ScriptableObject
    {
        [Tooltip ("Miliseconds")]
        public int SpawnEnemyDelay;
        public Clamps CountOfSpawnedEnemies;
        public Clamps SpawnAidsTime ;
    }
}

