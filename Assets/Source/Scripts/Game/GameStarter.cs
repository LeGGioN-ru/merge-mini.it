using MiniIT.FIGURE;
using MiniIT.GRID;
using Zenject;

namespace MiniIT.GAME
{
    public class GameStarter : IInitializable
    {
        private readonly IGridGenerator _gridGenerator;
        private readonly IFigureSpawner _figureSpawner;

        public GameStarter(IGridGenerator gridGenerator, 
            IFigureSpawner figureSpawner)
        {
            _figureSpawner = figureSpawner;
            _gridGenerator = gridGenerator;
        }

        public void Initialize()
        {
            _gridGenerator.Generate();
            _figureSpawner.StartSpawn();
        }
    }
}