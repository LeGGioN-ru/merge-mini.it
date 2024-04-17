using MiniIT.WALLET;
using Zenject;

namespace MiniIT.FIGURE
{
    public class CoinFigure : TakeFigure
    {
        private Wallet _wallet;

        [Inject]
        public void Construct(Wallet wallet)
        {
            _wallet = wallet;
        }

        protected override bool OnTake()
        {
            _wallet.AddMoney();
            return base.OnTake();
        }
    }
}