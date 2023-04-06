using UnityEngine;




namespace TestTask
{
    [System.Serializable]
    public class PlayerUI
    {
        [SerializeField] private HealthBar _healthBar;
        [SerializeField] private HealthText _healthText;

        public HealthBar HealthBar { get => _healthBar;}
        public HealthText HealthText { get => _healthText;}

        public void SubscribeAllEvents()
        {
            _healthBar.SubscribeAllEvents();
            _healthText.SubscribeAllEvents();
        }
        public void UnSubscribeAllEvents()
        {
            _healthBar.UnSubscribeAllEvents();
            _healthText.UnSubscribeAllEvents();
        }
        public void LateUpdate()
        {
            _healthBar.LateUpdate();
        }
    }
}

