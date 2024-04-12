using MiniIT.GRID;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace MiniIT.FIGURE
{
    public class FigureSpawner
    {
        private readonly Figure.Factory _figureFactory;
        private readonly FigureSpawnerSettings _settings;
        private readonly WaitForSeconds _delaySpawn;
        private readonly CoroutineSwitcher _coroutineSwitcher;
        private readonly GridGenerator _gridGenerator;

        private Coroutine _spawnCoroutine;

        public FigureSpawner(Figure.Factory factory,
            FigureSpawnerSettings settings,
            CoroutineSwitcher coroutineStarter,
            GridGenerator gridGenerator)
        {
            _gridGenerator = gridGenerator;
            _settings = settings;
            _figureFactory = factory;
            _coroutineSwitcher = coroutineStarter;

            _delaySpawn = new WaitForSeconds(_settings.DelaySpawn);
        }

        public void StartSpawn()
        {
            if (_spawnCoroutine == null)
            {
                _spawnCoroutine = _coroutineSwitcher.StartCoroutine(SpawnRoutine());
            }
        }

        public void StopSpawn()
        {
            if (_spawnCoroutine != null)
            {
                _coroutineSwitcher.StopCoroutine(_spawnCoroutine);
            }
        }

        private IEnumerator SpawnRoutine()
        {
            while (true)
            {
                yield return _delaySpawn;

                Cell freeCell = _gridGenerator.Cells.FirstOrDefault(x => x.CellModel.IsEmpty);
                
                if (freeCell != null)
                {
                    Figure figure = _figureFactory.Create();
                    freeCell.SetFigure(figure);
                }
            }
        }
    }
}