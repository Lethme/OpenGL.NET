using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenGL.Window.Graphics.Properties;
using System.Drawing;

namespace OpenGL.Window.Graphics.Figures
{
    public class Ellipse : Figure
    {
        public FloatPoint[] Points { get; private set; }
        public float HorizontalRadius { get; }
        public float VerticalRadius { get; }
        public float FirstAngle { get; }
        public float SecondAngle { get; }
        public float AngleSum => SecondAngle - FirstAngle;
        public FloatPoint Center { get; }
        public FloatColor FillColor { get; }
        public FloatColor BorderColor { get; }
        public int PointsCount => Points.Length;
        public bool IsCompleted => AngleSum / 360f >= 1f;
        public Ellipse(FloatPoint center = null, float horizontalRadius = 0f, float verticalRadius = 0f, float firstAngle = 0f, float secondAngle = 360f, FloatColor fillColor = null, FloatColor borderColor = null)
        {
            if (center == null) Center = FloatPoint.DefaultPoint;
            else Center = center;

            FirstAngle = firstAngle;
            SecondAngle = secondAngle;
            if (AngleSum <= 0) FirstAngle -= 360f;

            if (fillColor == null) this.FillColor = Color.White;
            else this.FillColor = fillColor;

            if (borderColor == null) this.BorderColor = Color.Black;
            else this.BorderColor = borderColor;

            HorizontalRadius = horizontalRadius;
            VerticalRadius = verticalRadius;

            Points = GetEllipsePoints();
        }
        private FloatPoint[] GetEllipsePoints()
        {
            var points = new FloatPoint[(int)Math.Round(AngleSum)];
            var count = 0;
            for (var angle = FirstAngle; angle < SecondAngle; angle += AngleSum / (int)Math.Round(AngleSum))
            {
                points[count++] = FloatPoint.Create
                (
                    (float)(Center.X + Math.Cos(Math.PI / 180f * angle) * HorizontalRadius),
                    (float)(Center.Y + Math.Sin(Math.PI / 180f * angle) * VerticalRadius)
                );
            }

            return points;
        }
        public void Draw() => Graphics.DrawEllipse(this);
        public static Ellipse Create(FloatPoint center = null, float horizontalRadius = 0f, float verticalRadius = 0f, float firstAngle = 0f, float secondAngle = 360f, FloatColor fillColor = null, FloatColor borderColor = null) => new Ellipse(center, horizontalRadius, verticalRadius, firstAngle, secondAngle, fillColor, borderColor);
    }
}
