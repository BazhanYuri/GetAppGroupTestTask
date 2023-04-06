using System;
using UnityEngine;




namespace TestTask
{
    public class CollisionDetector : MonoBehaviour
    {
        public event Action<Collider> CollisionEntered;
        public event Action<Collider> CollisionExited;




        private void OnTriggerEnter(Collider other)
        {
            CollisionEntered?.Invoke(other);
        }
        private void OnTriggerExit(Collider other)
        {
            CollisionExited?.Invoke(other);
        }
    }
}

