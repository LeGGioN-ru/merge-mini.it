using MiniIT.FIGURE;
using System;
using UnityEngine;

public class CellModel
{
    private Figure _figure;

    public bool IsEmpty => _figure == null;

    public void SetFigure(Figure figure)
    {
        if (figure == null)
        {
            throw new NullReferenceException();
        }

        _figure = figure;
    }

    public void ClearFigure()
    {
        _figure = null;
    }

    public bool IsSameFigure(Figure figure)
    {
        return _figure == figure;
    }

    public void DestroyFigure()
    {
        if (_figure != null)
        {
            GameObject.Destroy(_figure.gameObject);
        }
    }
}
