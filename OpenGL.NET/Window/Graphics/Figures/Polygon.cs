using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenGL.Window.Graphics.Properties;
using System.Drawing;

namespace OpenGL.Window.Graphics.Figures
{
    public class Polygon : Figure
    {
        public FloatPoint[] Points { get; }
        public FloatColor FillColor { get; }
        public FloatColor BorderColor { get; }
        public int PointsCount => Points.Length;
        public Polygon(FloatColor fillColor = null, FloatColor borderColor = null, params FloatPoint[] points)
        {
            Points = points.ToArray();

            if (fillColor == null) this.FillColor = FloatColor.Create(Color.White);
            else this.FillColor = fillColor;

            if (borderColor == null) this.BorderColor = FloatColor.Create(Color.Black);
            else this.BorderColor = borderColor;
        }
        public Polygon(FloatColor fillColor = null, FloatColor borderColor = null, IEnumerable<FloatPoint> points = null)
        {
            if (points == null) throw new ArgumentNullException();
            
            Points = points.ToArray();

            if (fillColor == null) this.FillColor = FloatColor.Create(Color.White);
            else this.FillColor = fillColor;

            if (borderColor == null) this.BorderColor = FloatColor.Create(Color.Black);
            else this.BorderColor = borderColor;
        }
        public void Draw() => Graphics.DrawPolygon(this);
        public static Polygon Create(FloatColor fillColor = null, FloatColor borderColor = null, params FloatPoint[] points) => new Polygon(fillColor, borderColor, points);
        public static Polygon Create(FloatColor fillColor = null, FloatColor borderColor = null, IEnumerable<FloatPoint> points = null) => new Polygon(fillColor, borderColor, points);
    }
}
