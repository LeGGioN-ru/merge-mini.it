using System;
using UnityEngine;

namespace MiniIT.ANIMATION
{
    [Serializable]
    public class AnimationTweenSettings
    {
        [field:SerializeField] public AnimationType AnimationType { get;private set; }
        [field: SerializeField] public Transform Target { get; private set; }
        [field: SerializeField] public float Duration { get; private set; }
        [field: SerializeField] public float Delay { get; private set; }
    }
}