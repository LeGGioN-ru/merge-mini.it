using MiniIT.FIGURE;
using MiniIT.GRID;
using MiniIT.GRID.CELL;
using UnityEngine;
using Zenject;

namespace MiniIT.INTERACTION
{
    public class MergePlaceStrategy : FreePlaceStrategy
    {
        private readonly Figure.FactoryLevel _factory;

        public MergePlaceStrategy(GridGenerator gridGenerator, ContactFilter2D cellFilter, Figure.FactoryLevel figureUpgradeFactory) : base(gridGenerator, cellFilter)
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
                if (mergeFigure.Level == mergeFigure2.Level)
                {
                    Figure figure = _factory.Create(mergeFigure.Level);

                    if (figure != null)
                    {
                        newFigure = figure;
                        return true;
                    }
                }
            }

            newFigure = null;
            return false;
        }
    }
}