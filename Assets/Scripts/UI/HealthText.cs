using UnityEngine;
using TMPro;




namespace TestTask
{
    [System.Serializable]
    public class HealthText
    {
        [SerializeField] private TextMeshProUGUI _healthText;



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

        private void OnHealthUpdated(float healthPercentage)
        {
            Debug.Log(healthPercentage);
            _healthText.text = _damagable.CurrentHealth + "/" + _damagable.MaxHealth;
        }

    }
}

