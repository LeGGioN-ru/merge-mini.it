using System;
using UnityEngine;

namespace MiniIT.UTILITY
{
    [Serializable]
    public static class AppConstants
    {
        public static class Scenes
        {
            public readonly static string GameScene=nameof(GameScene);
            public readonly static string MenuScene = nameof(MenuScene);
        }

        public static class Animations
        {
            public readonly static string PickUp = nameof(PickUp);
        }

        public static class Currency
        {
            public readonly static string Money = nameof(Money);
        }

        public static class Layers
        {
            public readonly static string Figure = nameof(Figure);
            public readonly static string Cell = nameof(Cell);
        }

        public static class Filters
        {
            public static ContactFilter2D FigureFilter => CreateFilter(Layers.Figure);
            public static ContactFilter2D CellFilter => CreateFilter(Layers.Cell);

            private static ContactFilter2D CreateFilter(string layerMask) //this method can be extended in the future 
            {
                ContactFilter2D contactFilter2D = new ContactFilter2D();

                contactFilter2D.useLayerMask = true;
                contactFilter2D.layerMask = LayerMask.GetMask(layerMask);

                return contactFilter2D;
            }
        }
    }

}