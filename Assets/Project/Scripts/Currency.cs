using System;
using UnityEngine;

namespace Project.Scripts
{
    public class Currency: MonoBehaviour
    {
        public event Action OnUpdated;
        
        public CurrencyTypesEnum currencyType;
        
        private int _currentAmount;
        
        public int CurrentAmount => _currentAmount;

        public void Initialize(int startAmount)
        {
            _currentAmount = startAmount;
            OnUpdated?.Invoke();
        }

        public void IncreaseBalance(int value)
        {
            _currentAmount += value;
            OnUpdated?.Invoke();
        }
        
        public void DecreaseBalance(int value)
        {
            _currentAmount -= value;
            
            if (_currentAmount < 0)
                _currentAmount = 0;
                
            OnUpdated?.Invoke();
        }
    }
}