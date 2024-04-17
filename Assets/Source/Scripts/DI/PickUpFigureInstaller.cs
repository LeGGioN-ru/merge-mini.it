using MiniIT.ANIMATION;
using MiniIT.UTILITY;
using NaughtyAttributes;
using UnityEngine;

namespace MiniIT.DI
{
    public class PickUpFigureInstaller : FigureInstaller
    {
        [SerializeField] private bool _needSound;
        [ShowIf("_needSound")][SerializeField] private AudioSource _pickUpSound;
        [SerializeField] private AnimationTweenSettings _pickUpSettings;

        public override void InstallBindings()
        {
            base.InstallBindings();

            Container.BindInstance(_pickUpSettings).WithId(AppConstants.Animations.PickUp);
            Container.BindInstance(_pickUpSound);
        }
    }
}