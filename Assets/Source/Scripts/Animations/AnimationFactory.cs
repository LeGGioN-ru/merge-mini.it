using MiniIT.ANIMATION;
using System;
using Zenject;

public class AnimationFactory : IFactory< AnimationTweenSettings, AnimationTween>
{
    private readonly DiContainer _diContainer;

    public AnimationFactory(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    public AnimationTween Create(AnimationTweenSettings settings)
    {
        switch (settings.AnimationType)
        {
            case AnimationType.Shake:
                return new ShakeAnimation(settings);

            case AnimationType.Bounce:
                return new BounceAnimation(settings);
        }

        throw new ArgumentException($"{nameof(AnimationFactory)} can't find {settings.AnimationType} animation");
    }
}
