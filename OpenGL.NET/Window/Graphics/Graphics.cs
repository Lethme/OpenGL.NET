﻿using System;
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

                foreach (var point in figure.Points)
                {
                    GL.Vertex2(point.X, point.Y);
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
                GL.Vertex2(line.Points[0].X, line.Points[0].Y);
                GL.Vertex2(line.Points[1].X, line.Points[1].Y);
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
                GL.Vertex2(triangle.Points[0].X, triangle.Points[0].Y);
                GL.Vertex2(triangle.Points[1].X, triangle.Points[1].Y);
                GL.Vertex2(triangle.Points[2].X, triangle.Points[2].Y);

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
                GL.Vertex2(rectangle.Points[0].X, rectangle.Points[0].Y);
                GL.Vertex2(rectangle.Points[1].X, rectangle.Points[1].Y);
                GL.Vertex2(rectangle.Points[2].X, rectangle.Points[2].Y);
                GL.Vertex2(rectangle.Points[3].X, rectangle.Points[3].Y);

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
    }
}
