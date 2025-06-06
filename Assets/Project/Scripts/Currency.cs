using System;
using UnityEngine;

namespace Project.Scripts
{
    public class Currency
    {
        private const int TopUpAmount = 100;
        
        public event Action OnUpdated;
        
        public readonly CurrencyTypesEnum CurrencyType;
        
        private int _currentAmount;
        
        public int CurrentAmount => _currentAmount;

        public Currency(CurrencyTypesEnum currencyType)
        {
            CurrencyType = currencyType;
        }

        public void TopUpButtonListener()
        {
            IncreaseBalance(TopUpAmount);
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