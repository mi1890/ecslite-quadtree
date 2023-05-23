#if true
using UnityEngine;
#else
using System.Numerics;
#endif

namespace Nenuacho.EcsLiteQuadTree.Core
{
    public struct QuadBounds
    {
        public Vector2 Center;
        public Vector2 Size;

        public readonly float Left;
        public readonly float Right;
        public readonly float Top;
        public readonly float Bottom;

        public QuadBounds(Vector2 center, Vector2 size)
        {
            Center = center;
            Size = size;
#if true
            Left = Center.x - Size.x * 0.5f;
            Right = Center.x + Size.x * 0.5f;
            Top = Center.y + Size.y * 0.5f;
            Bottom = Center.y - Size.y * 0.5f;
#else
            Left = Center.X - Size.X * 0.5f;
            Right = Center.X + Size.X * 0.5f;
            Top = Center.Y + Size.Y * 0.5f;
            Bottom = Center.Y - Size.Y * 0.5f;
#endif
        }

        public bool Contains(in Vector2 point)
        {

#if true
            var hSizeX = Size.x * 0.5f;
            var hSizeY = Size.x * 0.5f;
            return point.x > Center.x - hSizeX && point.x < Center.x + hSizeX && point.y > Center.y - hSizeY && point.y < Center.y + hSizeY;
#else
            var hSizeX = Size.X * 0.5f;
            var hSizeY = Size.Y * 0.5f;
            return point.X > Center.X - hSizeX && point.X < Center.X + hSizeX && point.Y > Center.Y - hSizeY && point.Y < Center.Y + hSizeY;
#endif

        }

        public override string ToString()
        {
            return @$"Size: {Size}; Center: {Center}";
        }
    }
}