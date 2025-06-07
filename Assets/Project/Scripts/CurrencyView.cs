using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts
{
    public class CurrencyView: MonoBehaviour
    {
        private const int MaxViewValue = 999999;
        private const int MinViewValue = 0;
        
        public event Action<CurrencyTypesEnum> OnAddButtonClicked;
        
        [SerializeField] private Image _iconImage;
        [SerializeField] private Sprite _iconSprite;

        [SerializeField] private TMP_Text _valueLabel;
        [SerializeField] private Button _addButton;

        public CurrencyTypesEnum currencyType;
        
        private Currency _currency;

        private void OnDestroy()
        {
            _addButton.onClick.RemoveListener(OnAddButtonClick);
            _currency.OnUpdated -= UpdateLabel;
        }

        public void Initialize(Currency currency)
        {
            _currency = currency;
            _currency.OnUpdated += UpdateLabel;
            
            _iconImage.sprite = _iconSprite;
            SetValue(_currency.CurrentAmount);
            _addButton.onClick.AddListener(OnAddButtonClick);
        }

        private void OnAddButtonClick()
        {
            OnAddButtonClicked?.Invoke(currencyType);
        }

        private void SetValue(int value)
        {
            value = Math.Clamp(value, MinViewValue, MaxViewValue);
            _valueLabel.text = value.ToString();
        }

        private void UpdateLabel()
        {
            SetValue(_currency.CurrentAmount);
        }
    }
}