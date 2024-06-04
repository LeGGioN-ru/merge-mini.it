using MiniIT.INTERACTION;
using UnityEngine;
using Zenject;

namespace MiniIT.FIGURE
{
    public class MergeFigure : Figure, IHoldable
    {
        private IPlacementConfiguration _placeConfiguration;
        private IHoldmentConfiguration _holdConfiguration;

        public int Level { get; private set; }

        [Inject]
        public void Construct(IPlacementConfiguration placeConfiguration, IHoldmentConfiguration holdConfiguration, int level)
        {
            _placeConfiguration = placeConfiguration;
            _holdConfiguration = holdConfiguration;
            Level = level;
        }

        public Transform GetTransform()
        {
            return transform;
        }

        public void Hold()
        {
            _holdConfiguration.Hold(this);
        }

        public void Place()
        {
            _placeConfiguration.Place(this);
        }
    }
}