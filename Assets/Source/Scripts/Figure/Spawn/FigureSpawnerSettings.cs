using UnityEngine;

namespace MiniIT.FIGURE
{
    [CreateAssetMenu(fileName = "Figure Spawner", menuName = "Game/Settings/Create Figure Spawner", order = 0)]
    public class FigureSpawnerSettings : ScriptableObject
    {
        [field: SerializeField] public float DelaySpawn { get; private set; }
    }

}