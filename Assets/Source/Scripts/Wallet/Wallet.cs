using MiniIT.UTILITY;
using UnityEngine;
using Zenject;

namespace MiniIT.WALLET
{
    public class Wallet : IInitializable
    {
        private readonly SignalBus _signalBus;

        public Wallet(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Fire(new MoneyChanged(GetCurrentMoney()));
        }

        public void AddMoney()
        {
            int currentMoney = GetCurrentMoney();
            currentMoney++;
            PlayerPrefs.SetInt(AppConstants.Currency.Money, currentMoney);

            _signalBus.Fire(new MoneyChanged(currentMoney));
        }

        public int GetCurrentMoney()
        {
            return PlayerPrefs.GetInt(AppConstants.Currency.Money, 0);
        }
    }
}