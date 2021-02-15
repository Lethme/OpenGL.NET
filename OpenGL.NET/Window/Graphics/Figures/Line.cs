using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenGL.Window.Graphics.Properties;
using System.Drawing;

namespace OpenGL.Window.Graphics.Figures
{
    public class Line : Figure
    {
        public FloatPoint[] Points { get; }
        public FloatColor LineColor { get; }
        public float LineWidth { get; }
        public int PointsCount => Points.Length;
        public Line(float x1 = 0f, float y1 = 0f, float x2 = 0f, float y2 = 0f, FloatColor lineColor = null, float lineWidth = 1f)
        {
            Points = new FloatPoint[]
            {
                FloatPoint.Create(x1, y1),
                FloatPoint.Create(x2, y2)
            };
            LineWidth = lineWidth;
            
            if (lineColor == null) LineColor = FloatColor.Create(Color.Black);
            else LineColor = lineColor;
        }
        public void Draw() => Graphics.DrawLine(this);
        public static Line Create(float x1 = 0f, float y1 = 0f, float x2 = 0f, float y2 = 0f, FloatColor lineColor = null, float lineWidth = 1f) => new Line(x1, y1, x2, y2, lineColor, lineWidth);
    }
}
