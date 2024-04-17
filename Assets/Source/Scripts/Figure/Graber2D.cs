using MiniIT.INTERACTION;
using MiniIT.UTILITY;
using System.Collections.Generic;
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
        if (TryHoldObject())
        {
            return;
        }

        TryTakeObject();
    }

    private bool TryTakeObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Physics2D.OverlapPoint(MousePositionGetter.GetValidZCurrentMousePosition(), _figureFilter, _colliders);

            if (_colliders.Count == 0)
            {
                return false;
            }

            bool isTaken = false;

            if (_colliders.TryTakeFirstObject(out ITakeable takeable) && takeable.IsTaken == false)
            {
                takeable.Take();
                isTaken = true;
            }

            if (_colliders.TryTakeFirstObject(out IHoldable holdable))
            {
                StartHoldObject(holdable);
                isTaken = true;
            }

            return isTaken;
        }

        return false;
    }

    private bool TryHoldObject()
    {
        if (_holdable != null)
        {
            _holdable.Hold();

            if (Input.GetMouseButtonUp(0))
            {
                PlaceHoldableObject();
            }

            return true;
        }

        return false;
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
