using MiniIT.FIGURE;
using MiniIT.INTERACTION;
using System;
using UnityEngine;
using Zenject;

namespace MiniIT.GRID.CELL
{
    public class Cell : MonoBehaviour
    {
        public CellModel CellModel { get; private set; } = null;

        private void Awake()
        {
            CellModel = new CellModel();
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