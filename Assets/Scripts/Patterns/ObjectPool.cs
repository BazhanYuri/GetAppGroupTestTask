using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace TestTask
{
    public abstract class ObjectPool<T> where T : MonoBehaviour
    {
        [SerializeField] private int _maxCount;
        [SerializeField] private T _objectPrefab;


        private List<T> _objectPool = new List<T>();

        public List<T> ObjectPooled { get => _objectPool;}

        public T Take()
        {
            for (int i = 0; i < _objectPool.Count; i++)
            {
                if (_objectPool[i].gameObject.active == false)
                {
                    _objectPool[i].gameObject.SetActive(true);
                    return _objectPool[i];
                }
            }
            return null;
        }

        public void InitPool()
        {
            CreatePool();
        }
        private void CreatePool()
        {
            for (int i = 0; i < _maxCount; i++)
            {
                T bullet = Object.Instantiate(_objectPrefab);
                bullet.gameObject.SetActive(false);
                _objectPool.Add(bullet);
            }
        }
    }
}

