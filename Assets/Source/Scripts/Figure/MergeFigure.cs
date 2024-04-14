using MiniIT.FIGURE;
using UnityEngine;
using Zenject;

public class MergeFigure : Figure, IHoldable
{
    private IPlaceStrategy _placeStrategy;
    private IHoldStrategy _holdStrategy;

    public int Level { get; private set; }

    [Inject]
    public void Construct(IPlaceStrategy placeStrategy, IHoldStrategy holdStrategy, int level)
    {
        _placeStrategy = placeStrategy;
        _holdStrategy = holdStrategy;
        Level = level;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Hold()
    {
        _holdStrategy.Hold(this);
    }

    public void Place()
    {
        _placeStrategy.Place(this);
    }
}
