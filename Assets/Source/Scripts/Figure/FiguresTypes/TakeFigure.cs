using DG.Tweening;
using MiniIT.ANIMATION;
using MiniIT.INTERACTION;
using System.Collections;
using UnityEngine;
using Zenject;

namespace MiniIT.FIGURE
{
    public abstract class TakeFigure : Figure, ITakeable
    {
        private AudioSource _takeSound;
        private AnimationTween _takeAnimation;
        private bool _isTaken;

        private Tween _pickUpAnimationTween;

        public bool IsTaken => _isTaken;

        [Inject]
        public void Construct([InjectOptional] AudioSource audioSource, [Inject(Id = "PickUp")] AnimationTweenSettings takeAnimationSettings)
        {
            _takeSound = audioSource;
            _takeAnimation = AnimationFactory.Create(takeAnimationSettings);
        }

        public void Take()
        {
            if (_takeSound != null)
            {
                _takeSound.Play();
            }

            _pickUpAnimationTween = _takeAnimation.Play();
            _isTaken = OnTake();
        }

        protected IEnumerator DestroyRoutine()
        {
            yield return new WaitUntil(() => _takeSound.isPlaying == false && _pickUpAnimationTween.IsPlaying() == false && _isTaken);

            _pickUpAnimationTween.Kill();
            Destroy(gameObject);
        }

        protected virtual bool OnTake()
        {
            StartCoroutine(DestroyRoutine());
            return true;
        }
    }
}