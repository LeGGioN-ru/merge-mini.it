using MiniIT.GRID.CELL;
using System.Collections.Generic;
using UnityEngine;

namespace MiniIT.GRID
{
    public class BoxGridGenerator : ICellContainer, IGridGenerator
    {
        private readonly Transform _centerPoint;
        private readonly Cell.Factory _cellFactory;
        private readonly List<Cell> _cells;
        private readonly GridSettings _settings;

        public IReadOnlyCollection<Cell> Cells => _cells;

        public BoxGridGenerator(Transform centerPoint, Cell.Factory factory, GridSettings gridSettings)
        {
            _settings = gridSettings;
            _centerPoint = centerPoint;
            _cellFactory = factory;

            _cells = new List<Cell>();
        }

        public void Generate()
        {
            Vector3 offset = new Vector3((_settings.ColumnsCount - 1) * _settings.Space / 2, (_settings.RowsCount - 1) * _settings.Space / 2, 0);

            for (int i = 0; i < _settings.RowsCount; i++)
            {
                for (int j = 0; j < _settings.ColumnsCount; j++)
                {
                    Vector3 position = new Vector3(_centerPoint.position.x + j * _settings.Space - offset.x, _centerPoint.position.y + i * _settings.Space - offset.y, _centerPoint.position.z);

                    Cell cell = _cellFactory.Create();

                    cell.transform.parent = _centerPoint;
                    cell.transform.position = position;

                    _cells.Add(cell);
                }
            }
        }
    }
}