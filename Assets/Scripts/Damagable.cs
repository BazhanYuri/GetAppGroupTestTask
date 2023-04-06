using System;
using UnityEngine;




namespace TestTask
{
    public class Damagable
    {
        public event Action<float> UpdateHealth;
        public event Action Dead;

        private int _maxHealth;
        private int _currentHealth;
        private bool _isAlive = true;
        private bool _isMaxHealth = true;

        public int MaxHealth { get => _maxHealth;}
        public int CurrentHealth { get => _currentHealth;}
        public bool IsAlive { get => _isAlive;}
        public bool IsMaxHealth { get => _isMaxHealth;}

        public void Init(int maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = _maxHealth;

            HealthUpdate();
        }
        public void Reset()
        {
            _currentHealth = _maxHealth;
            _isAlive = true;
            _isMaxHealth = true;

        }
        public void TakeHealth(int damage)
        {
            if (_currentHealth <= 0)
            {
                
                return;
            }
            _isMaxHealth = false;
            _currentHealth -= damage;

            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
                _isAlive = false;
                Dead?.Invoke();
            }

            HealthUpdate();
        }
        public void AddHealth(int heal)
        {
            _currentHealth += heal;
            if (_currentHealth >= _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
            HealthUpdate();
        }
        private void HealthUpdate()
        {
            UpdateHealth?.Invoke((float)_currentHealth / (float)_maxHealth);
        }
    }
}

