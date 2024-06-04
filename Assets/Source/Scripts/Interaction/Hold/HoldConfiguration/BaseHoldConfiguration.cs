using MiniIT.UTILITY;

namespace MiniIT.INTERACTION
{
    public class BaseHoldConfiguration : IHoldmentConfiguration
    {
        public void Hold(IHoldable holdable)
        {
            holdable.GetTransform().position = MousePositionGetter.GetValidZCurrentMousePosition();
        }
    }
}