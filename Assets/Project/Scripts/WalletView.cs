using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts
{
    public class WalletView: MonoBehaviour
    {
        [SerializeField] private List<CurrencyView> _currenciesPrefabs;
        
        private readonly Dictionary<CurrencyTypesEnum, Currency> _currencies = new();

        private void Awake()
        {
            foreach (CurrencyView currencyPrefab in _currenciesPrefabs)
            {
                CurrencyView currencyView = Instantiate(currencyPrefab, transform).GetComponent<CurrencyView>();
                _currencies.Add(currencyView.Currency.CurrencyType, currencyView.Currency);
            }
        }
        
        public void DecreaseBalance(CurrencyTypesEnum type, int amount)
        {
            if (_currencies.TryGetValue(type, out Currency currency))
                currency.DecreaseBalance(amount);
        }
    }
}