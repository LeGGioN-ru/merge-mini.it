using DG.Tweening;
using UnityEngine;

namespace MiniIT.ANIMATION
{
    public class BounceAnimation : AnimationTween
    {
        private Vector3 _startScale;

        public BounceAnimation(AnimationTweenSettings animationTweenSettings) : base(animationTweenSettings)
        {
            _startScale = animationTweenSettings.Target.localScale;
        }

        public override Tween Play()
        {
            return Bounce(AnimationTweenSettings.Target, AnimationTweenSettings.Duration, AnimationTweenSettings.Delay);
        }

        private Tween Bounce(Transform transform, float duration, float delay)
        {
            Sequence sequence = DOTween.Sequence().SetDelay(delay);
            transform.localScale = Vector3.zero;
            return sequence.Append(transform.DOScale(_startScale + new Vector3(.3f, .3f, .3f), duration))
                        .Append(transform.DOScale(_startScale - new Vector3(.2f, .2f, .2f), duration))
                        .Append(transform.DOScale(_startScale, duration));
        }
    }
}