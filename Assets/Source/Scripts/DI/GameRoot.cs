using MiniIT.FIGURE;
using MiniIT.GAME;
using MiniIT.GRID;
using MiniIT.GRID.CELL;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using System;
using MiniIT.UTILITY;
using MiniIT.UTILITY.SCENE;
using MiniIT.WALLET;
using MiniIT.ANIMATION;

namespace MiniIT.DI
{
    public class GameRoot : MonoInstaller
    {
        [Header("Game Settings")]
        [SerializeField] private List<GameTypeSettings> _settings;
        [Header("Grid")]
        [SerializeField] private Cell _cellPrefab;
        [SerializeField] private Transform _centerPoint;
        [Header("Figure")]
        [SerializeField] private Figure _firstMergeFigure;
        [Header("Figure Upgrade")]
        [Tooltip("Please set unique figures with unique levels!")]
        [SerializeField] private List<MergeFigure> _mergeFigures;
        [Header("Other")]
        [SerializeField] private Camera _camera;
        [SerializeField] private CoroutineSwitcher _coroutineSwitcher;

        private void OnValidate()
        {
            Validator.ValidateIEnumerableUnique(_mergeFigures.Select(x => x.GetComponent<MergeFigureInstaller>().Level));
            Validator.ValidateIEnumerableUnique(_settings.Select(x => x.GameType));
        }

        public override void InstallBindings()
        {
            GameTypeSettings gameTypeSettings = GetCurrentGameTypeSettings();

            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<MoneyChanged>();

            Container.BindFactory<int, Figure, Figure.FactoryLevel>().FromFactory<FigureUpgradeFactory>();
            Container.BindFactory<Cell, Cell.Factory>().FromComponentInNewPrefab(_cellPrefab).AsSingle();
            Container.BindFactory<Figure, Figure.Factory>().FromFactory<WeightFigureFactory>();
            Container.BindFactory<AnimationTweenSettings, AnimationTween, AnimationTween.Factory>().FromFactory<AnimationFactory>();

            Container.BindInstance(gameTypeSettings.FiguresWeight);
            Container.BindInstance(_camera);
            Container.BindInstance(_mergeFigures);

            Container.BindInterfacesAndSelfTo<CameraSizeSetter>().AsSingle();
            Container.BindInterfacesAndSelfTo<Wallet>().AsSingle();
            Container.BindInterfacesAndSelfTo<FigureSpawner>().AsSingle().WithArguments(_coroutineSwitcher, gameTypeSettings.FigureSpawnerSettings);
            Container.BindInterfacesAndSelfTo<BoxGridGenerator>().AsSingle().WithArguments(_centerPoint, gameTypeSettings.GridSettings);
            Container.BindInterfacesAndSelfTo<GameStarter>().AsSingle();
            Container.BindInterfacesAndSelfTo<Graber2D>().AsSingle().WithArguments(AppConstants.Filters.FigureFilter);
        }

        private GameTypeSettings GetCurrentGameTypeSettings()
        {
            GameType currentGameType = (GameType)PlayerPrefs.GetInt(nameof(GameType), 0);
            GameTypeSettings gameTypeSettings = _settings.FirstOrDefault(x => x.GameType == currentGameType);

            if (gameTypeSettings == null)
            {
                throw new ArgumentException($"Game can't find {currentGameType} game type, in list game type settings.");
            }

            return gameTypeSettings;
        }
    }
}