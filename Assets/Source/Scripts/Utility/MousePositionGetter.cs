using UnityEngine;

namespace MiniIT.UTILITY
{
    public static class MousePositionGetter
    {
        public static Vector3 GetCurrentMousePosition()
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        public static Vector3 GetValidZCurrentMousePosition()
        {
            Vector3 mousePosition = GetCurrentMousePosition();
            mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;

            return mousePosition;
        }
    }

}