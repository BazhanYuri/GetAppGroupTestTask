using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace TestTask
{

    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AidKitConfig", order = 1)]
    public class AidKitConfig : ScriptableObject
    {
        public Clamps HealingCount;    
    }
}

