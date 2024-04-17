using MiniIT.FIGURE;
using UnityEngine;
using Zenject;
using System;
using NaughtyAttributes;
using MiniIT.INTERACTION;

namespace MiniIT.GRID.CELL
{
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
            UpdatePosition(figure);
        }

        public void SetFigure(IHoldable holdable)
        {
            SetFigure(ToFigure(holdable));
        }

        public void ClearFigure()
        {
            CellModel.ClearFigure();
        }

        public void UpdatePosition(Figure figure)
        {
            figure.transform.parent = transform;
            figure.transform.position = transform.position;
        }

        public void UpdatePosition(IHoldable holdable)
        {
            UpdatePosition(ToFigure(holdable));
        }

        private Figure ToFigure(IHoldable holdable)
        {
            Figure figure = holdable as Figure;

            if (figure == null)
            {
                throw new ArgumentException("All holdables must be figure type");
            }

            return figure;
        }

        public class Factory : PlaceholderFactory<Cell> { }
    }
}