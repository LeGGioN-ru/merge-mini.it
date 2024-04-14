using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class Graber2D : ITickable
{
    private readonly ContactFilter2D _figureFilter;
    private readonly List<Collider2D> _colliders;

    private IHoldable _holdable;

    public Graber2D(ContactFilter2D figureFilter)
    {
        _figureFilter = figureFilter;
        _colliders = new List<Collider2D>();
    }

    public void Tick()
    {
        if (_holdable != null)
        {
            _holdable.Hold();

            if (Input.GetMouseButtonUp(0))
            {
                PlaceHoldableObject();
            }

            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Physics2D.OverlapPoint(MousePositionGetter.GetValidZCurrentMousePosition(), _figureFilter, _colliders);

            if (_colliders.Count == 0)
                return;

            if (_colliders.FirstOrDefault().TryGetComponent(out ITakeable takeable))
            {
                takeable.Take();
            }

            if (_colliders.FirstOrDefault().TryGetComponent(out IHoldable holdable))
            {
                StartHoldObject(holdable);
            }
        }
    }

    private void PlaceHoldableObject()
    {
        _holdable.Place();
        _holdable = null;
    }

    private void StartHoldObject(IHoldable holdable)
    {
        _holdable = holdable;
    }
}
