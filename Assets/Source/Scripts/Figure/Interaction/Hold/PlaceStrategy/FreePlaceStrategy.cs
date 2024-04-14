using MiniIT.FIGURE;
using MiniIT.GRID;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FreePlaceStrategy : IPlaceStrategy
{
    private readonly GridGenerator _gridGenerator;
    private readonly List<Collider2D> _colliders;
    private readonly ContactFilter2D _cellFilter;

    private Cell _currentCell;

    public FreePlaceStrategy(GridGenerator gridGenerator, ContactFilter2D cellFilter)
    {
        _gridGenerator = gridGenerator;
        _cellFilter = cellFilter;
        _colliders = new List<Collider2D>();
    }

    public virtual void Place(IHoldable holdable)
    {
        _currentCell = GetCurrentCell(holdable);

        if (TryGetNewCell(out Cell newCell) && newCell.CellModel.IsEmpty)
        {
            _currentCell.ClearFigure();
            newCell.SetFigure(holdable);
        }
        else
        {
            _currentCell.UpdatePosition(holdable);
        }
    }

    protected Cell GetCurrentCell(IHoldable holdable)
    {
        foreach (Cell cell in _gridGenerator.Cells)
        {
            if (cell.CellModel.IsSameFigure(holdable as Figure))
            {
                return cell;
            }
        }

        throw new System.Exception();
    }

    protected bool TryGetNewCell(out Cell newCell)
    {
        Physics2D.OverlapPoint(MousePositionGetter.GetValidZCurrentMousePosition(), _cellFilter, _colliders);

        if (_colliders.Count > 0 && _colliders.FirstOrDefault().TryGetComponent(out Cell cell))
        {
            newCell = cell;
            return true;
        }

        newCell = null;
        return false;
    }
}
