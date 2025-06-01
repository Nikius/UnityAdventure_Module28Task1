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
        private const int AddAmount = 100;
        
        [SerializeField] private Image _iconImage;
        [SerializeField] private Sprite _iconSprite;
        
        [SerializeField] private TMP_Text _valueLabel;

        [SerializeField] private Button _addButton;
        [SerializeField] private Currency _currency;

        private void Awake()
        {
            _iconImage.sprite = _iconSprite;
            SetValue(0);
            _addButton.onClick.AddListener(IncreaseBalance);
            _currency.OnUpdated += UpdateLabel;
        }

        private void OnDestroy()
        {
            _addButton.onClick.RemoveListener(IncreaseBalance);
            _currency.OnUpdated -= UpdateLabel;
        }
        
        private void IncreaseBalance()
        {
            _currency.IncreaseBalance(AddAmount);
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