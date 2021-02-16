using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL;

using OpenGL.Window.Graphics.Figures;
using OpenGL.Window.Graphics.Properties;
using System.Drawing;

namespace OpenGL.Window.Graphics
{
    public static class Graphics
    {
        public static GameWindow Window { get; private set; }
        public static FloatColor BackgroundColor { get; private set; } = FloatColor.Create(Color.Black);
        public static void Initialize<T> (T window) where T : GameWindow
        {
            Window = window;
        }
        public static void SetBackground(FloatColor backgroundColor)
        {
            if (backgroundColor != null)
                BackgroundColor = backgroundColor;
            else
                BackgroundColor = FloatColor.Create(Color.White);
        }
        public static void Clear()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(BackgroundColor.R, BackgroundColor.G, BackgroundColor.B, BackgroundColor.A);
        }
        public static void SetBorder(Figure figure, FloatColor borderColor = null, float borderWidth = 1f)
        {
            if (!borderColor.IsTransparent)
            {
                GL.Begin(PrimitiveType.LineLoop);

                GL.Color4(borderColor.R, borderColor.G, borderColor.B, borderColor.A);
                GL.LineWidth(borderWidth);

                if ((FigureCheck<Ellipse>(figure) && ((Ellipse)figure).IsCompleted) || !FigureCheck<Ellipse>(figure))
                {
                    foreach (var point in figure.Points)
                    {
                        GL.Vertex2(point.X, point.Y);
                    }
                }
                else
                {
                    var points = figure.Points.ToList();
                    points.Add(((Ellipse)figure).Center);
                    foreach (var point in points)
                    {
                        GL.Vertex2(point.X, point.Y);
                    }
                }

                GL.LineWidth(1f);

                GL.End();
            }
        }
        public static bool FigureCheck<T> (Figure figure) where T : Figure
        {
            return typeof(T) == figure.GetType();
        }
        public static void DrawLine(Figures.Line line)
        {
            if (!line.LineColor.IsTransparent)
            {
                GL.Begin(PrimitiveType.Lines);

                GL.Color4(line.LineColor.R, line.LineColor.G, line.LineColor.B, line.LineColor.A);
                GL.LineWidth(line.LineWidth);

                foreach (var point in line.Points)
                {
                    GL.Vertex2(point.X, point.Y);
                }

                GL.LineWidth(1f);

                GL.End();
            }
        }
        public static void Line(float x1 = 0f, float y1 = 0f, float x2 = 0f, float y2 = 0f, FloatColor lineColor = null, float lineWidth = 1f)
        {
            Graphics.DrawLine(Figures.Line.Create(x1, y1, x2, y2, lineColor, lineWidth));
        }
        public static void DrawTriangle(Figures.Triangle triangle)
        {
            if (!triangle.FillColor.IsTransparent)
            {
                GL.Begin(PrimitiveType.Triangles);

                GL.Color4(triangle.FillColor.R, triangle.FillColor.G, triangle.FillColor.B, triangle.FillColor.A);
                
                foreach(var point in triangle.Points)
                {
                    GL.Vertex2(point.X, point.Y);
                }

                GL.End();
            }

            Graphics.SetBorder(triangle, triangle.BorderColor);
        }
        public static void Triangle(float x1 = 0f, float y1 = 0f, float x2 = 0f, float y2 = 0f, float x3 = 0f, float y3 = 0f, FloatColor fillColor = null, FloatColor borderColor = null)
        {
            Graphics.DrawTriangle(Figures.Triangle.Create(x1, y1, x2, y2, x3, y3, fillColor, borderColor));
        }
        public static void DrawRectangle(Figures.Rectangle rectangle)
        {
            if (!rectangle.FillColor.IsTransparent)
            {
                GL.Begin(PrimitiveType.Quads);

                GL.Color4(rectangle.FillColor.R, rectangle.FillColor.G, rectangle.FillColor.B, rectangle.FillColor.A);
                
                foreach (var point in rectangle.Points)
                {
                    GL.Vertex2(point.X, point.Y);
                }

                GL.End();
            }

            Graphics.SetBorder(rectangle, rectangle.BorderColor);
        }
        public static void Rectangle(float x1 = 0f, float y1 = 0f, float x2 = 0f, float y2 = 0f, float x3 = 0f, float y3 = 0f, float x4 = 0f, float y4 = 0f, FloatColor fillColor = null, FloatColor borderColor = null)
        {
            Graphics.DrawRectangle(Figures.Rectangle.Create(x1, y1, x2, y2, x3, y3, x4, y4, fillColor, borderColor));
        }
        public static void DrawPolygon(Figures.Polygon polygon)
        {
            if (!polygon.FillColor.IsTransparent)
            {
                GL.Begin(PrimitiveType.Polygon);

                GL.Color4(polygon.FillColor.R, polygon.FillColor.G, polygon.FillColor.B, polygon.FillColor.A);
                
                foreach (var point in polygon.Points.Reverse())
                {
                    GL.Vertex2(point.X, point.Y);
                }

                GL.End();
            }

            Graphics.SetBorder(polygon, polygon.BorderColor);
        }
        public static void Polygon(FloatColor fillColor = null, FloatColor borderColor = null, params FloatPoint[] points)
        {
            Graphics.DrawPolygon(Figures.Polygon.Create(fillColor, borderColor, points));
        }
        public static void Polygon(FloatColor fillColor = null, FloatColor borderColor = null, IEnumerable<FloatPoint> points = null)
        {
            Graphics.DrawPolygon(Figures.Polygon.Create(fillColor, borderColor, points));
        }
        public enum EllipseDrawingMethod
        {
            Triangles,
            Polygon
        }
        public static void DrawEllipse(Figures.Ellipse ellipse, EllipseDrawingMethod drawingMethod = EllipseDrawingMethod.Polygon)
        {
            switch(drawingMethod)
            {
                case EllipseDrawingMethod.Triangles:
                    {
                        for (var i = 0; i < ellipse.PointsCount - 1; i++)
                        {
                            Graphics.Triangle
                            (
                                x1: ellipse.Center.X, y1: ellipse.Center.Y,
                                x2: ellipse.Points[i].X, y2: ellipse.Points[i].Y,
                                x3: ellipse.Points[i + 1].X, y3: ellipse.Points[i + 1].Y,
                                fillColor: ellipse.FillColor,
                                borderColor: FloatColor.Transparent
                            );
                        }

                        if (ellipse.IsCompleted)
                        {
                            Graphics.Triangle
                            (
                                x1: ellipse.Center.X, y1: ellipse.Center.Y,
                                x2: ellipse.Points[0].X, y2: ellipse.Points[0].Y,
                                x3: ellipse.Points[ellipse.PointsCount - 1].X, y3: ellipse.Points[ellipse.PointsCount - 1].Y,
                                fillColor: ellipse.FillColor,
                                borderColor: FloatColor.Transparent
                            );
                        }

                        break;
                    }
                case EllipseDrawingMethod.Polygon:
                    {
                        if (ellipse.IsCompleted)
                        {
                            Graphics.Polygon(ellipse.FillColor, FloatColor.Transparent, ellipse.Points.Where((point, index) => index != ellipse.PointsCount - 1));
                        }
                        else
                        {
                            Graphics.Polygon(ellipse.FillColor, FloatColor.Transparent, ellipse.Points.Where((point, index) => index != ellipse.PointsCount).Append(ellipse.Center));
                        }

                        break;
                    }
            }

            Graphics.SetBorder(ellipse, ellipse.BorderColor);
        }
        public static void Ellipse(FloatPoint center = null, float horizontalRadius = 0f, float verticalRadius = 0f, float firstAngle = 0f, float secondAngle = 360f, FloatColor fillColor = null, FloatColor borderColor = null)
        {
            Graphics.DrawEllipse(Figures.Ellipse.Create(center, horizontalRadius, verticalRadius, firstAngle, secondAngle, fillColor, borderColor), EllipseDrawingMethod.Triangles);
        }
    }
}
