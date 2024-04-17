using MiniIT.GRID.CELL;
using System.Collections.Generic;
using UnityEngine;

namespace MiniIT.GRID
{
    public class GridGenerator : ICellContainer
    {
        private readonly Transform _centerPoint;
        private readonly Cell.Factory _cellFactory;
        private readonly List<Cell> _cells;

        public IReadOnlyCollection<Cell> Cells => _cells;

        public GridGenerator(Transform centerPoint, Cell.Factory factory)
        {
            _centerPoint = centerPoint;
            _cellFactory = factory;

            _cells = new List<Cell>();
        }

        public void Generate(int columns, int rows, float space)
        {
            Vector3 offset = new Vector3((columns - 1) * space / 2, (rows - 1) * space / 2, 0);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Vector3 position = new Vector3(_centerPoint.position.x + j * space - offset.x, _centerPoint.position.y + i * space - offset.y, _centerPoint.position.z);

                    Cell cell = _cellFactory.Create();

                    cell.transform.parent = _centerPoint;
                    cell.transform.position = position;

                    _cells.Add(cell);
                }
            }
        }
    }
}