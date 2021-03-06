﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenGL.Window.Graphics.Properties;
using System.Drawing;

namespace OpenGL.Window.Graphics.Figures
{
    public class Rectangle : Figure
    {
        public FloatPoint[] Points { get; }
        public FloatColor FillColor { get; }
        public FloatColor BorderColor { get; }
        public int PointsCount => Points.Length;
        public Rectangle(float x1 = 0f, float y1 = 0f, float x2 = 0f, float y2 = 0f, float x3 = 0f, float y3 = 0f, float x4 = 0f, float y4 = 0f, FloatColor fillColor = null, FloatColor borderColor = null)
        {
            this.Points = new FloatPoint[] 
            {
                (x1, y1),
                (x2, y2),
                (x3, y3),
                (x4, y4)
            };

            if (fillColor == null) this.FillColor = Color.White;
            else this.FillColor = fillColor;

            if (borderColor == null) this.BorderColor = Color.Black;
            else this.BorderColor = borderColor;
        }
        public void Draw() => Graphics.DrawRectangle(this);
        public static Rectangle Create(float x1 = 0f, float y1 = 0f, float x2 = 0f, float y2 = 0f, float x3 = 0f, float y3 = 0f, float x4 = 0f, float y4 = 0f, FloatColor fillColor = null, FloatColor borderColor = null) => new Rectangle(x1, y1, x2, y2, x3, y3, x4, y4, fillColor, borderColor);
    }
}
