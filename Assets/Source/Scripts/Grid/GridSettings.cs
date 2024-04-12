using UnityEngine;

namespace MiniIT.GRID
{
    [CreateAssetMenu(fileName = "Grid Settings", menuName = "Game/Settings/Create Grid", order = 0)]
    public class GridSettings : ScriptableObject
    {
        [field: SerializeField] public int RowsCount { get; private set; }
        [field: SerializeField] public int ColumnsCount { get; private set; }
        [field: SerializeField] public int Space { get; private set; }
    }
}