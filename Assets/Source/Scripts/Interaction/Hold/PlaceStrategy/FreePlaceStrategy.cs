using MiniIT.FIGURE;
using MiniIT.GRID.CELL;
using MiniIT.UTILITY;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MiniIT.INTERACTION
{
    public class FreePlaceStrategy : IPlaceStrategy
    {
        private readonly ICellContainer _cellContainer;
        private readonly List<Collider2D> _colliders;
        private readonly ContactFilter2D _cellFilter;

        public FreePlaceStrategy(ICellContainer cellContainer, ContactFilter2D cellFilter)
        {
            _cellContainer = cellContainer;
            _cellFilter = cellFilter;
            _colliders = new List<Collider2D>();
        }

        public virtual void Place(IHoldable holdable)
        {
            Cell currentCell = GetCurrentCell(holdable);

            if (TryGetNewCell(out Cell newCell) && newCell.CellModel.IsEmpty)
            {
                currentCell.ClearFigure();
                newCell.SetFigure(holdable);
            }
            else
            {
                currentCell.UpdatePosition(holdable);
            }
        }

        protected Cell GetCurrentCell(IHoldable holdable)
        {
            foreach (Cell cell in _cellContainer.Cells)
            {
                if (cell.CellModel.IsSameFigure(holdable as Figure))
                {
                    return cell;
                }
            }

            throw new Exception();
        }

        protected bool TryGetNewCell(out Cell newCell)
        {
            Physics2D.OverlapPoint(MousePositionGetter.GetValidZCurrentMousePosition(), _cellFilter, _colliders);

            if (_colliders.Count > 0 && _colliders.TryTakeFirstObject(out Cell cell))
            {
                newCell = cell;
                return true;
            }

            newCell = null;
            return false;
        }
    }
}