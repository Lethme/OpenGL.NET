using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL.Window.Graphics.Properties
{
    public class FloatColor : IEquatable<FloatColor>
    {
        public float R { get; }
        public float G { get; }
        public float B { get; }
        public float A { get; }
        public static FloatColor DefaultColor => Transparent;
        public static FloatColor Transparent => FloatColor.Create(-1f, -1f, -1f, 0f);
        public bool IsTransparent => this.Equals(Transparent);
        public FloatColor(float r = 0.0f, float g = 0.0f, float b = 0.0f, float a = 1.0f)
        {
            this.R = r;
            this.G = g;
            this.B = b;
            this.A = a;
        }
        public FloatColor(byte r = 0, byte g = 0, byte b = 0, float a = 1.0f)
        {
            this.R = (float)r / 255;
            this.G = (float)g / 255;
            this.B = (float)b / 255;
            this.A = a;
        }
        public FloatColor(Color? color)
        {
            if (color == null) throw new ArgumentNullException();
            if (color == Color.Transparent)
            {
                this.R = -1f;
                this.G = -1f;
                this.B = -1f;
                this.A = 0f;
            }
            else
            {
                this.R = (float)color.Value.R / 255;
                this.G = (float)color.Value.G / 255;
                this.B = (float)color.Value.B / 255;
                this.A = (float)color.Value.A / 255;
            }
        }
        public override bool Equals(object obj)
        {
            return obj is FloatColor other && this.Equals(other);
        }
        public bool Equals(FloatColor other)
        {
            return R == other.R &&
                   G == other.G &&
                   B == other.B &&
                   A == other.A;
        }
        public override int GetHashCode()
        {
            int hashCode = 1960784236;
            hashCode = hashCode * -1521134295 + R.GetHashCode();
            hashCode = hashCode * -1521134295 + G.GetHashCode();
            hashCode = hashCode * -1521134295 + B.GetHashCode();
            hashCode = hashCode * -1521134295 + A.GetHashCode();
            return hashCode;
        }
        public static implicit operator FloatColor(Color? color)
        {
            return FloatColor.Create(color);
        }
        public static FloatColor Create(float r = 0.0f, float g = 0.0f, float b = 0.0f, float a = 1.0f) => new FloatColor(r, g, b, a);
        public static FloatColor Create(byte r = 0, byte g = 0, byte b = 0, float a = 1.0f) => new FloatColor(r, g, b, a);
        public static FloatColor Create(Color? color) => new FloatColor(color);
    }
}
