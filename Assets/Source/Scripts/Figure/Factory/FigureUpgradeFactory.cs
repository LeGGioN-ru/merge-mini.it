using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace MiniIT.FIGURE
{
    public class FigureUpgradeFactory 
    {
        private readonly List<MergeFigure> _figurePrefabs;
        private readonly DiContainer _diContainer;

        public FigureUpgradeFactory(List<MergeFigure> mergeFigures, DiContainer diContainer)
        {
            _figurePrefabs = mergeFigures.OrderBy(figure => figure.Level).ToList();

            _diContainer = diContainer;
        }

        public bool TryCreateUpgradedFigure(int currentLevel, out Figure figure)
        {
            currentLevel++;

            if (currentLevel >= _figurePrefabs.Count)
            {
                figure = null;
                return false;
            }

            figure = _figurePrefabs[currentLevel];
            figure = _diContainer.InstantiatePrefabForComponent<MergeFigure>(figure);
            return true;
        }
    }
}
