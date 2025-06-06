using System.Collections.Generic;

namespace Project.Scripts
{
    public class WalletService
    {
        private readonly Dictionary<CurrencyTypesEnum, Currency> _currencies;

        public WalletService(Dictionary<CurrencyTypesEnum, Currency> currencies)
        {
            _currencies = currencies;
        }

        public IReadOnlyDictionary<CurrencyTypesEnum, Currency> Currencies => _currencies;
        
        public void DecreaseBalance(CurrencyTypesEnum type, int amount)
        {
            if (_currencies.TryGetValue(type, out Currency currency))
                currency.DecreaseBalance(amount);
        }
    }
}