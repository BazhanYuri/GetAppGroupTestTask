using UnityEngine;




namespace TestTask
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerConfig", order = 1)]
    public class PlayerConfig : ScriptableObject
    {
        public float WalkSpeed;
        [Tooltip ("Miliseconds")]
        public int ShootDelay;
        public int MaxHealth;
        public int Damage;
        public BulletType BulletType;
    }
}

