using MiniIT.FIGURE;
using UnityEngine;
using Zenject;

public class Cell : MonoBehaviour
{
    public CellModel CellModel { get; private set; } = null;

    [Inject]
    public void Construct(CellModel cellModel)
    {
        CellModel = cellModel;
    }

    public void SetFigure(Figure figure)
    {
        CellModel.SetFigure(figure);

        figure.transform.parent = transform;
        figure.transform.position = transform.position;
    }

    public class Factory : PlaceholderFactory<Cell> { }
}
