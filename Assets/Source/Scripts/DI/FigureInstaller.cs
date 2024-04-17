using MiniIT.ANIMATION;
using UnityEngine;
using Zenject;

namespace MiniIT.DI
{
    public class FigureInstaller : MonoInstaller
    {
        [SerializeField] private AnimationTweenSettings _incarnateSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(_incarnateSettings);
        }
    }
}
