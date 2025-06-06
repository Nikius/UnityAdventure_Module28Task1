using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts
{
    public class WalletExample: MonoBehaviour
    {
        private const int BalanceDecreationValue = 50;
        
        [SerializeField] private WalletView _walletView;
        [SerializeField] private List<CurrencyTypesEnum> _currencyTypes;
        
        private WalletService _walletService;

        private void Awake()
        {
            InitializeWalletService();

            _walletView.Initialize(_walletService);
        }

        private void InitializeWalletService()
        {
            Dictionary<CurrencyTypesEnum, Currency> currencies = new();
            
            foreach (CurrencyTypesEnum currencyType in _currencyTypes)
                currencies.Add(currencyType, new Currency(currencyType));
            
            _walletService = new WalletService(currencies);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) 
                _walletService.DecreaseBalance(CurrencyTypesEnum.Coins, BalanceDecreationValue);
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
                _walletService.DecreaseBalance(CurrencyTypesEnum.Diamonds, BalanceDecreationValue);
            
            if (Input.GetKeyDown(KeyCode.Alpha3))
                _walletService.DecreaseBalance(CurrencyTypesEnum.Energy, BalanceDecreationValue);
            
        }
    }
}