using System.Collections.Generic;

namespace MiniIT.GRID.CELL
{
    public interface ICellContainer
    {
        public IReadOnlyCollection<Cell> Cells { get; }
    }
}