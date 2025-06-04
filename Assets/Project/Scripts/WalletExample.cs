using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts
{
    public class WalletExample: MonoBehaviour
    {
        private const int BalanceDecreationValue = 50;
        
        [SerializeField] private WalletView _walletView;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) 
                _walletView.DecreaseBalance(CurrencyTypesEnum.Coins, BalanceDecreationValue);

            if (Input.GetKeyDown(KeyCode.Alpha2))
                _walletView.DecreaseBalance(CurrencyTypesEnum.Diamonds, BalanceDecreationValue);
            
            if (Input.GetKeyDown(KeyCode.Alpha3))
                _walletView.DecreaseBalance(CurrencyTypesEnum.Energy, BalanceDecreationValue);
            
        }

        
    }
}