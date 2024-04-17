using System;
using UnityEngine;

namespace MiniIT.FIGURE
{
    [Serializable]
    public class FigureWeight
    {
        [field:SerializeField] public Figure Figure { get;private set; }
        [field: SerializeField] public float Weight { get; private set; }
    }
}
