using MiniIT.FIGURE;
using MiniIT.GRID;
using MiniIT.GRID.CELL;
using UnityEngine;

namespace MiniIT.INTERACTION
{
    public class MergePlaceStrategy : FreePlaceStrategy
    {
        private readonly FigureUpgradeFactory _factory;

        public MergePlaceStrategy(GridGenerator gridGenerator, ContactFilter2D cellFilter, FigureUpgradeFactory figureUpgradeFactory) : base(gridGenerator, cellFilter)
        {
            _factory = figureUpgradeFactory;
        }

        public override void Place(IHoldable holdable)
        {
            Cell currentCell = GetCurrentCell(holdable);

            if (TryGetNewCell(out Cell newCell) && currentCell != newCell && CanBeUpgraded(holdable, newCell, out Figure newFigure))
            {
                currentCell.CellModel.DestroyFigure();
                newCell.CellModel.DestroyFigure();
                newCell.SetFigure(newFigure);
                newFigure.Incarnate();
            }
            else
            {
                base.Place(holdable);
            }
        }

        private bool CanBeUpgraded(IHoldable holdable, Cell newCell, out Figure newFigure)
        {
            if (holdable is MergeFigure mergeFigure && newCell.CellModel.Figure is MergeFigure mergeFigure2)
            {
                if (mergeFigure != null && mergeFigure2 != null)
                {
                    if (mergeFigure.Level == mergeFigure2.Level)
                    {
                        if (_factory.TryCreateUpgradedFigure(mergeFigure.Level, out Figure figure))
                        {
                            newFigure = figure;
                            return true;
                        }
                    }
                }
            }

            newFigure = null;
            return false;
        }
    }
}