using MiniIT.FIGURE;
using System;

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
}
