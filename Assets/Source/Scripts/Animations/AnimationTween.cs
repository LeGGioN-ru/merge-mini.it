using DG.Tweening;
using Zenject;

namespace MiniIT.ANIMATION
{
    public abstract class AnimationTween
    {
        protected AnimationTweenSettings AnimationTweenSettings;

        public AnimationTween(AnimationTweenSettings animationTweenSettings)
        {
            AnimationTweenSettings = animationTweenSettings;
        }

        public abstract Tween Play();

        public class Factory : PlaceholderFactory<AnimationTweenSettings, AnimationTween> { }
    }
}