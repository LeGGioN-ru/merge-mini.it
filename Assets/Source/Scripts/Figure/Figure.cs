using UnityEngine;
using Zenject;

namespace MiniIT.FIGURE
{
    public abstract class Figure : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<Figure> { }
    }
}
