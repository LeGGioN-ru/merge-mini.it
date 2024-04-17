using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace MiniIT.WALLET
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _moneyText;

        private SignalBus _signalBus;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void OnEnable()
        {
            _signalBus.Subscribe<MoneyChanged>(UpdateView);
        }
        public void OnDisable()
        {
            _signalBus.Unsubscribe<MoneyChanged>(UpdateView);
        }

        public void UpdateView(MoneyChanged moneyChanged)
        {
            _moneyText.text = moneyChanged.Money.ToString() + "$";
        }
    }
}