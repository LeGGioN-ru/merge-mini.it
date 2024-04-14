using UnityEngine;
using Zenject;

public class MergeFigureContext : MonoInstaller
{
    [SerializeField] private ContactFilter2D _cellFilter;
    [SerializeField] private MergeFigure _mergeFigure;
    [SerializeField] private int _level;

    public override void InstallBindings()
    {
        Container.BindInstance(_level);
        Container.BindInterfacesAndSelfTo<BaseHoldStrategy>().AsSingle();
        Container.BindInterfacesAndSelfTo<MergePlaceStrategy>().AsSingle().WithArguments(_cellFilter);
    }
}
