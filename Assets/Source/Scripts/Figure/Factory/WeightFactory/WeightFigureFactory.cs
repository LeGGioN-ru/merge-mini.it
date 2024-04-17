using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace MiniIT.FIGURE
{
    public class WeightFigureFactory : IFactory<Figure>
    {
        private readonly List<FigureWeight> _figuresWeight;
        private readonly DiContainer _diContainer;

        public WeightFigureFactory(List<FigureWeight> figuresWeight, DiContainer diContainer)
        {
            _figuresWeight = figuresWeight;
            _diContainer = diContainer;
        }

        public Figure Create()
        {
            double currentWeight = new System.Random().NextDouble();

            currentWeight = Math.Round(currentWeight, 3);

            Figure figure = _figuresWeight.Where(x => x.Weight >= currentWeight).GetRandomElement().Figure;

            return _diContainer.InstantiatePrefabForComponent<Figure>(figure);
        }
    }
}