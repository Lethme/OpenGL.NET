using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static FloatColor BackgroundColor { get; private set; } = FloatColor.Create(Color.Black);
        public static void SetBackground(FloatColor backgroundColor) => BackgroundColor = backgroundColor;
        public static void SetBackground(Color backgroundColor) => BackgroundColor = FloatColor.Create(backgroundColor);
        public static void Clear()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(BackgroundColor.R, BackgroundColor.G, BackgroundColor.B, BackgroundColor.A);
        }
        public static void DrawRectangle(Figures.Rectangle rectangle)
        {
            GL.Begin(PrimitiveType.Quads);

            GL.Color4(rectangle.FillColor.R, rectangle.FillColor.G, rectangle.FillColor.B, rectangle.FillColor.A);
            GL.Vertex2(rectangle.Points[0].X, rectangle.Points[0].Y);
            GL.Vertex2(rectangle.Points[1].X, rectangle.Points[1].Y);
            GL.Vertex2(rectangle.Points[2].X, rectangle.Points[2].Y);
            GL.Vertex2(rectangle.Points[3].X, rectangle.Points[3].Y);

            GL.End();
        }
        public static void Rectangle(float x1 = 0f, float y1 = 0f, float x2 = 0f, float y2 = 0f, float x3 = 0f, float y3 = 0f, float x4 = 0f, float y4 = 0f, FloatColor fillColor = null, FloatColor borderColor = null)
        {
            Graphics.DrawRectangle(Figures.Rectangle.Create(x1, y1, x2, y2, x3, y3, x4, y4, fillColor, borderColor));
        }
        public static void Rectangle(float x1 = 0f, float y1 = 0f, float x2 = 0f, float y2 = 0f, float x3 = 0f, float y3 = 0f, float x4 = 0f, float y4 = 0f, Color? fillColor = null, Color? borderColor = null)
        {
            Graphics.DrawRectangle(Figures.Rectangle.Create(x1, y1, x2, y2, x3, y3, x4, y4, fillColor, borderColor));
        }
    }
}
