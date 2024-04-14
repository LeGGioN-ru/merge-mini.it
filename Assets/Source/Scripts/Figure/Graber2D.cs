using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class Graber2D : ITickable
{
    private readonly ContactFilter2D _figureFilter;
    private readonly ContactFilter2D _cellFilter;
    private readonly List<Collider2D> _colliders;

    private IHoldable _holdable;
    private Cell _cell;

    public Graber2D(ContactFilter2D figureFilter, ContactFilter2D cellFilter)
    {
        _cellFilter = cellFilter;
        _figureFilter = figureFilter;
        _colliders = new List<Collider2D>();
    }

    public void Tick()
    {
        if (_holdable != null)
        {
            MoveHoldableObject(_holdable, MousePositionGetter.GetValidZCurrentMousePosition());

            if (Input.GetMouseButtonUp(0))
            {
                PlaceHoldableObject(ref _holdable);
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

    private void MoveHoldableObject(IHoldable holdable, Vector3 position)
    {
        holdable.Hold();
        holdable.GetTransform().position = position;
    }

    private void PlaceHoldableObject(ref IHoldable holdable)
    {
        Physics2D.OverlapPoint(MousePositionGetter.GetValidZCurrentMousePosition(), _cellFilter, _colliders);

        Debug.Log(_colliders);

        if (_colliders.Count > 0 && _colliders.FirstOrDefault().TryGetComponent(out Cell cell))
        {
            if (holdable.TryPlace(cell))
            {
            }
            else if (cell.CellModel.IsEmpty)
            {
                cell.SetFigure(holdable);
                _cell.ClearFigure();
            }
            else
            {
                _cell.UpdatePosition(holdable);
            }
        }
        else
        {
            _cell.UpdatePosition(holdable);
        }

        holdable = null;
        _cell = null;
    }

    private void StartHoldObject(IHoldable holdable)
    {
        _holdable = holdable;
        Physics2D.OverlapPoint(MousePositionGetter.GetValidZCurrentMousePosition(), _cellFilter, _colliders);

        if (_colliders.FirstOrDefault().TryGetComponent(out Cell cell))
        {
            _cell = cell;
            Debug.Log(_cell);
        }
    }
}
