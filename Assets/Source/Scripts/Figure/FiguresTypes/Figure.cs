using MiniIT.ANIMATION;
using UnityEngine;
using Zenject;

namespace MiniIT.FIGURE
{
    public abstract class Figure : MonoBehaviour
    {
        private AnimationTween _incarnateAnimation;

        protected AnimationTween.Factory AnimationFactory;

        [Inject]
        public void Construct(AnimationTweenSettings incarnateSettings, AnimationTween.Factory animationFactory)
        {
            AnimationFactory = animationFactory;
            _incarnateAnimation = animationFactory.Create(incarnateSettings);
        }

        public void Incarnate()
        {
            _incarnateAnimation.Play();
        }

        public class Factory : PlaceholderFactory<Figure> { }
        public class FactoryLevel : PlaceholderFactory<int, Figure> { }
    }
}
