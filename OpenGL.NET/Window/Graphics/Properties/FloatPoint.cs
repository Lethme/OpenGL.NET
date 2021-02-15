using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL.Window.Graphics.Properties
{
    public class FloatPoint : IEquatable<FloatPoint>
    {
        public float X { get; }
        public float Y { get; }
        public static FloatPoint DefaultPoint => FloatPoint.Create(0f, 0f);
        public FloatPoint(float x = 0.0f, float y = 0.0f)
        {
            this.X = x;
            this.Y = y;
        }
        public override bool Equals(object obj)
        {
            return obj is FloatPoint other && this.Equals(other);
        }
        public bool Equals(FloatPoint other)
        {
            return X == other.X && Y == other.Y;
        }
        public override int GetHashCode()
        {
            int hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
        public static FloatPoint operator +(FloatPoint first, FloatPoint second)
        {
            return FloatPoint.Create(first.X + second.X, first.Y + second.Y);
        }
        public static FloatPoint operator -(FloatPoint first, FloatPoint second)
        {
            return FloatPoint.Create(first.X - second.X, first.Y - second.Y);
        }
        public static implicit operator (float X, float Y)(FloatPoint point)
        {
            return (point.X, point.Y);
        }
        public static implicit operator FloatPoint((float X, float Y) point)
        {
            return new FloatPoint(point.X, point.Y);
        }
        public static FloatPoint Create(float x = 0.0f, float y = 0.0f) => new FloatPoint(x, y);
    }
}
