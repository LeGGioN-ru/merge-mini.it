using MiniIT.FIGURE;
using System;
using UnityEngine;

public class CellModel
{
    public Figure Figure { get; private set; }
    public bool IsEmpty => Figure == null;

    public void SetFigure(Figure figure)
    {
        if (figure == null)
        {
            throw new NullReferenceException();
        }

        Figure = figure;
    }

    public void ClearFigure()
    {
        Figure = null;
    }

    public bool IsSameFigure(Figure figure)
    {
        return Figure == figure;
    }

    public void DestroyFigure()
    {
        if (Figure != null)
        {
            GameObject.Destroy(Figure.gameObject);
        }
    }
}
