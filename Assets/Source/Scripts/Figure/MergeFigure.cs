using MiniIT.FIGURE;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeFigure : Figure, ITakeable, IHoldable
{
    public Transform GetTransform()
    {
        return transform;
    }

    public void Hold()
    {

    }

    public bool TryPlace(Cell cell)
    {
        if (cell.CellModel.IsEmpty == false && cell.CellModel.IsSameFigure(this) == false)
        {
            cell.CellModel.DestroyFigure();
            Destroy(gameObject);
            return true;
        }

        return false;
    }

    public void Take()
    {

    }
}
