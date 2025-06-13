using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts
{
    public class WalletView: MonoBehaviour
    {
        [SerializeField] private List<CurrencyView> _currenciesPrefabs;
        
        private WalletService _walletService;
        private readonly List<CurrencyView> _currencyViews = new();

        private void OnDestroy()
        {
            foreach (CurrencyView currencyView in _currencyViews)
                currencyView.OnAddButtonClicked -= IncreaseBalance;
        }

        public void Initialize(WalletService walletService)
        {
            _walletService = walletService;
            
            foreach (KeyValuePair<CurrencyTypesEnum, Currency> keyValuePair in _walletService.Currencies)
                ShowCurrencyUI(keyValuePair);

            foreach (CurrencyView currencyView in _currencyViews)
                currencyView.OnAddButtonClicked += IncreaseBalance;
        }

        private void IncreaseBalance(CurrencyTypesEnum currencyViewCurrencyType)
        {
            if (_walletService.Currencies.TryGetValue(currencyViewCurrencyType, out Currency currency))
                _walletService.IncreaseBalance(currency.CurrencyType);
        }

        private void ShowCurrencyUI(KeyValuePair<CurrencyTypesEnum, Currency> currencyKvp)
        {
            foreach (CurrencyView currencyViewPrefab in _currenciesPrefabs)
                if (currencyViewPrefab.currencyType == currencyKvp.Key)
                {
                    CurrencyView currencyView = Instantiate(currencyViewPrefab, transform).GetComponent<CurrencyView>();
                    currencyView.Initialize(currencyKvp.Value);
                    _currencyViews.Add(currencyView);
                }
        }
    }
}