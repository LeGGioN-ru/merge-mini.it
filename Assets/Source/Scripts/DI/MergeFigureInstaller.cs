using MiniIT.FIGURE;
using MiniIT.INTERACTION;
using MiniIT.UTILITY;
using UnityEngine;

namespace MiniIT.DI
{
    public class MergeFigureInstaller : FigureInstaller
    {
        [SerializeField] private int _level;

        public int Level => _level;

        public override void InstallBindings()
        {
            base.InstallBindings();
            Container.BindInstance(_level);
            Container.BindInterfacesAndSelfTo<MergeFigure>().AsSingle();

            Container.BindInterfacesAndSelfTo<BaseHoldStrategy>().AsSingle();
            Container.BindInterfacesAndSelfTo<MergePlaceStrategy>().AsSingle().WithArguments(AppConstants.Filters.CellFilter);
        }
    }
}