using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts
{
    public class WalletExample: MonoBehaviour
    {
        private const int BalanceDecreationValue = 50;
        private const int StartBalanceValue = 150;
        
        [SerializeField] private GameObject _walletView;
        [SerializeField] private List<Currency> _currenciesPrefabs;
        
        private readonly Dictionary<CurrencyTypesEnum, Currency> _currencies = new();

        private void Awake()
        {
            foreach (Currency currencyPrefab in _currenciesPrefabs)
            {
                Currency currency = Instantiate(currencyPrefab, _walletView.transform).GetComponent<Currency>();
                currency.Initialize(StartBalanceValue);
                _currencies.Add(currency.currencyType, currency);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) 
                DecreaseBalance(CurrencyTypesEnum.Coins);

            if (Input.GetKeyDown(KeyCode.Alpha2))
                DecreaseBalance(CurrencyTypesEnum.Diamonds);
            
            if (Input.GetKeyDown(KeyCode.Alpha3))
                DecreaseBalance(CurrencyTypesEnum.Energy);
            
        }

        private void DecreaseBalance(CurrencyTypesEnum type)
        {
            if (_currencies.TryGetValue(type, out Currency currency))
                currency.DecreaseBalance(BalanceDecreationValue);
        }
    }
}