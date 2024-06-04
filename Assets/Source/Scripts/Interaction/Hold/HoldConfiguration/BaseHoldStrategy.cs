using MiniIT.UTILITY;

namespace MiniIT.INTERACTION
{
    public class BaseHoldStrategy : IHoldmentConfiguration
    {
        public void Hold(IHoldable holdable)
        {
            holdable.GetTransform().position = MousePositionGetter.GetValidZCurrentMousePosition();
        }
    }
}