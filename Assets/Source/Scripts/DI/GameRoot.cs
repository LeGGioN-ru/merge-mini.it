using MiniIT.FIGURE;
using MiniIT.GAME;
using MiniIT.GRID;
using UnityEngine;
using Zenject;

namespace MiniIT.DI
{
    public class GameRoot : MonoInstaller
    {
        [SerializeField] private CoroutineSwitcher _coroutineSwitcher;
        [Header("Grid")]
        [SerializeField] private Cell _cellPrefab;
        [SerializeField] private Transform _centerPoint;
        [SerializeField] private GridSettings _gridSettings;
        [Header("Figure")]
        [SerializeField] private FigureSpawnerSettings _figureSpawnerSettings;
        [SerializeField] private Figure _figurePrefab;
        [SerializeField] private ContactFilter2D _figureFilter;
        [SerializeField] private ContactFilter2D _cellFilter;

        public override void InstallBindings()
        {
            Container.BindFactory<Cell, Cell.Factory>().FromComponentInNewPrefab(_cellPrefab).AsSingle();
            Container.BindFactory<Figure, Figure.Factory>().FromComponentInNewPrefab(_figurePrefab).AsSingle();

            Container.BindInterfacesAndSelfTo<CellModel>().AsTransient();
            Container.BindInterfacesAndSelfTo<FigureSpawner>().AsSingle().WithArguments(_coroutineSwitcher, _figureSpawnerSettings);
            Container.BindInterfacesAndSelfTo<GridGenerator>().AsSingle().WithArguments(_centerPoint);
            Container.BindInterfacesAndSelfTo<GameStarter>().AsSingle().WithArguments(_gridSettings);
            Container.BindInterfacesAndSelfTo<Graber2D>().AsSingle().WithArguments(_figureFilter, _cellFilter);
        }
    }
}