public class BaseHoldStrategy : IHoldStrategy
{
    public void Hold(IHoldable holdable)
    {
        holdable.GetTransform().position = MousePositionGetter.GetValidZCurrentMousePosition();
    }
}
