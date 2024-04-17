using MiniIT.ANIMATION;
using UnityEngine;
using Zenject;

namespace MiniIT.FIGURE
{
    public abstract class Figure : MonoBehaviour, IReadOnlyFigure
    {
        private AnimationTween _incarnateAnimation;

        protected AnimationTween.Factory AnimationFactory;

        [Inject]
        public void Construct(AnimationTweenSettings incarnateSettings, AnimationTween.Factory animationFactory)
        {
            AnimationFactory = animationFactory;
            _incarnateAnimation = animationFactory.Create(incarnateSettings);
        }

        /// <summary>
        /// In fact, in a large potential project, everything should have an appearance animation. 
        /// So having this method in the base class makes sense. Since I have 2 animation in my project, 
        /// I don’t call this animation when the figures appear, otherwise it will get boring.
        /// </summary>
        public void Incarnate()
        {
            _incarnateAnimation.Play();
        }

        public class Factory : PlaceholderFactory<Figure> { }
    }
}
