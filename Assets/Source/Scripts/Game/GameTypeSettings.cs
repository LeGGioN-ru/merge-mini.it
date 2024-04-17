using MiniIT.FIGURE;
using MiniIT.GRID;
using MiniIT.UTILITY.SCENE;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MiniIT.GAME
{
    [Serializable]
    public class GameTypeSettings
    {
        [field: SerializeField] public GameType GameType { get; private set; }
        [field: SerializeField] public GridSettings GridSettings { get; private set; }
        [field: SerializeField] public FigureSpawnerSettings FigureSpawnerSettings { get; private set; }
        [field: SerializeField] public List<FigureWeight> FiguresWeight { get; private set; }
    }
}