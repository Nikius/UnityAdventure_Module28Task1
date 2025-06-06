using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts
{
    public class WalletView: MonoBehaviour
    {
        [SerializeField] private List<CurrencyView> _currenciesPrefabs;
        
        private WalletService _walletService;
        
        public void Initialize(WalletService walletService)
        {
            _walletService = walletService;
            
            foreach (KeyValuePair<CurrencyTypesEnum, Currency> keyValuePair in _walletService.Currencies)
                ShowCurrencyUI(keyValuePair);
        }

        private void ShowCurrencyUI(KeyValuePair<CurrencyTypesEnum, Currency> currencyKvp)
        {
            foreach (CurrencyView currencyViewPrefab in _currenciesPrefabs)
                if (currencyViewPrefab.currencyType == currencyKvp.Key)
                {
                    CurrencyView currencyView = Instantiate(currencyViewPrefab, transform).GetComponent<CurrencyView>();
                    currencyView.Initialize(currencyKvp.Value);
                }
        }
    }
}