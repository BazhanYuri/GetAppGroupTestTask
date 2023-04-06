using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;



namespace TestTask
{
    [System.Serializable]
    public class HealthBar
    {
        [SerializeField] private Slider _slider;


        private Damagable _damagable;

       


        public void Init(Damagable damagable)
        {
            _damagable = damagable;
        }
        public void SubscribeAllEvents()
        {
            _damagable.UpdateHealth += OnHealthUpdated;
        }
        public void UnSubscribeAllEvents()
        {
            _damagable.UpdateHealth -= OnHealthUpdated;
        }

        public void LateUpdate()
        {
            LookAtCamera();
        }

        private void OnHealthUpdated(float healthPercentage)
        {
            _slider.DOValue(healthPercentage, 0.2f);
        }
        private void LookAtCamera()
        {
            _slider.transform.parent.LookAt(Camera.main.transform);
        }
    }
}

