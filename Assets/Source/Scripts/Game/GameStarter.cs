using MiniIT.FIGURE;
using MiniIT.GRID;
using Zenject;

namespace MiniIT.GAME
{
    public class GameStarter : IInitializable
    {
        private readonly GridGenerator _gridGenerator;
        private readonly GridSettings _gridSettings;
        private readonly FigureSpawner _figureSpawner;

        public GameStarter(GridGenerator gridGenerator, 
            GridSettings gridSettings,
            FigureSpawner figureSpawner)
        {
            _figureSpawner = figureSpawner;
            _gridSettings = gridSettings;
            _gridGenerator = gridGenerator;
        }

        public void Initialize()
        {
            _gridGenerator.Generate(_gridSettings.ColumnsCount, _gridSettings.RowsCount, _gridSettings.Space);
            _figureSpawner.StartSpawn();
        }
    }
}