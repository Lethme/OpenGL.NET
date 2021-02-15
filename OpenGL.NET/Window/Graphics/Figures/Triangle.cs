using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenGL.Window.Graphics.Properties;
using System.Drawing;

namespace OpenGL.Window.Graphics.Figures
{
    public class Triangle : Figure
    {
        public FloatPoint[] Points { get; }
        public FloatColor FillColor { get; }
        public FloatColor BorderColor { get; }
        public int PointsCount => Points.Length;
        public Triangle(float x1 = 0f, float y1 = 0f, float x2 = 0f, float y2 = 0f, float x3 = 0f, float y3 = 0f, FloatColor fillColor = null, FloatColor borderColor = null)
        {
            Points = new FloatPoint[] 
            {
                FloatPoint.Create(x1, y1),
                FloatPoint.Create(x2, y2),
                FloatPoint.Create(x3, y3)
            };

            if (fillColor == null) this.FillColor = FloatColor.Create(Color.White);
            else this.FillColor = fillColor;

            if (borderColor == null) this.BorderColor = FloatColor.Create(Color.Black);
            else this.BorderColor = borderColor;
        }
        public void Draw() => Graphics.DrawTriangle(this);
        public static Triangle Create(float x1 = 0f, float y1 = 0f, float x2 = 0f, float y2 = 0f, float x3 = 0f, float y3 = 0f, FloatColor fillColor = null, FloatColor borderColor = null) => new Triangle(x1, y1, x2, y2, x3, y3, fillColor, borderColor);
    }
}
