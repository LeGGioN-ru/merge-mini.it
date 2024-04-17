using DG.Tweening;
using UnityEngine;

namespace MiniIT.ANIMATION
{
    public class ShakeAnimation : AnimationTween
    {
        private Vector3 _originalPosition;

        public ShakeAnimation(AnimationTweenSettings animationTweenSettings) : base(animationTweenSettings)
        {
            _originalPosition = animationTweenSettings.Target.localPosition;
        }

        public override Tween Play()
        {
            return Shake(AnimationTweenSettings.Duration, AnimationTweenSettings.Delay);
        }

        public Tween Shake(float duration, float delay)
        {
            Sequence mySequence = DOTween.Sequence().SetDelay(delay);

            mySequence.Append(AnimationTweenSettings.Target.DOLocalMoveX(_originalPosition.x - 0.1f, duration).SetEase(Ease.InBounce));
            mySequence.Append(AnimationTweenSettings.Target.DOLocalMoveX(_originalPosition.x + 0.1f, duration).SetEase(Ease.InBounce));
            mySequence.Append(AnimationTweenSettings.Target.DOLocalMoveX(_originalPosition.x - 0.1f, duration).SetEase(Ease.InBounce));
            mySequence.Append(AnimationTweenSettings.Target.DOLocalMoveX(_originalPosition.x, duration).SetEase(Ease.InBounce));

            return mySequence;
        }
    }
}
