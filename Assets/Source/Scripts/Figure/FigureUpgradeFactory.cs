using MiniIT.FIGURE;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FigureUpgradeFactory
{
    private readonly List<MergeFigure> _figurePrefabs;
    private readonly DiContainer _diContainer;

    public FigureUpgradeFactory(List<MergeFigure> mergeFigures, DiContainer diContainer)
    {
        _figurePrefabs = mergeFigures;
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