using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace TestTask
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TurretConfig", order = 1)]
    public class TurretConfig : ScriptableObject
    {
        public Clamps ShootDelay;
        public float ShootRadius;
        public int Damage;
        public BulletType BulletType;
    }
}

