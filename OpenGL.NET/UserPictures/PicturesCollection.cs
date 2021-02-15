using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using OpenGL.Window.Graphics.Pictures;
using OpenGL.Window.Graphics.Figures;
using OpenGL.Window.Graphics.Properties;
using OpenGL.Window.Graphics;

using Rectangle = OpenGL.Window.Graphics.Figures.Rectangle;
using Ellipse = OpenGL.Window.Graphics.Figures.Ellipse;
using Triangle = OpenGL.Window.Graphics.Figures.Triangle;
using Line = OpenGL.Window.Graphics.Figures.Line;
using Polygon = OpenGL.Window.Graphics.Figures.Polygon;


namespace OpenGL.UserPictures
{
    public static class PicturesCollection
    {
        public static Dictionary<String, Picture> Pictures { get; } = new Dictionary<String, Picture>()
        {
            /* Create your own pictures here by using Picture.Create() method */
            /* You can add new figures by using constructors or Create() methods of any figure class */
            { 
                "Test Picture",
                Picture.Create
                (
                    Rectangle.Create
                    (
                        x1: -0.5f, y1: 0.5f,
                        x2: 0.5f, y2: 0.5f,
                        x3: 0.5f, y3: -0.5f,
                        x4: -0.5f, y4: -0.5f,
                        fillColor: Color.Yellow,
                        borderColor: Color.Black
                    ),
                    Line.Create
                    (
                        x1: -1f, y1: 1f,
                        x2: 1f, y2: -1f,
                        lineColor: Color.DarkOrange,
                        lineWidth: 2f
                    ),
                    Triangle.Create
                    (
                        x1: -.3f, y1: 0f,
                        x2: -.9f, y2: 0f,
                        x3: -.6f, y3: -.7f,
                        fillColor: FloatColor.Transparent,
                        borderColor: Color.Bisque
                    ),
                    Polygon.Create
                    (
                        fillColor: Color.Aquamarine,
                        borderColor: Color.Green,
                        points: new FloatPoint[]
                        {
                            (0f, .5f),
                            (.2f, .2f),
                            (.5f, 0f),
                            (.2f, -.2f),
                            (0f, -.5f),
                            (-.2f, -.2f),
                            (-.5f, 0f),
                            (-.2f, .2f),
                        }
                    ),
                    Ellipse.Create
                    (
                        (0f, 0f),
                        .15f, .22f,
                        0f, 360f,
                        Color.Blue,
                        Color.Red
                    )
                )
            }
        };
        public static int PicturesCount => Pictures.Count;
        public static void DrawPicture(String pictureTitle)
        {
            if (Pictures.ContainsKey(pictureTitle)) Pictures[pictureTitle].Draw();
        }
        public static Picture GetPicture(String pictureTitle)
        {
            if (Pictures.ContainsKey(pictureTitle)) return Pictures[pictureTitle];
            return Picture.Create();
        }
        public static Picture GetPicture(int pictureNumber)
        {
            if (pictureNumber < 0 || pictureNumber >= Pictures.Count) return Picture.Create();
            return Pictures.ElementAt(pictureNumber).Value;
        }
    }
}
