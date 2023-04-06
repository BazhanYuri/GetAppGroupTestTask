using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace TestTask
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemyConfig", order = 1)]

    public class EnemyConfig : ScriptableObject
    {
        public int Damage;
        [Tooltip ("Miliseconds")]
        public int HitDelay;
        public int MaxHp;
    }
}

