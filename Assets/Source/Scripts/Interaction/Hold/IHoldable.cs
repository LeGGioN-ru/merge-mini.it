using UnityEngine;

namespace MiniIT.INTERACTION
{
    public interface IHoldable
    {
        public Transform GetTransform();
        public void Hold();
        public void Place();
    }
}