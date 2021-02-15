using OpenGL.Window.Graphics.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenGL.UserPictures;

namespace OpenGL
{
    class Program
    {
        static void Main(string[] args)
        {
            var window = new OpenGLWindow
            (
                width: 1200,
                height: 800,
                title: "Test OpenGL Application",
                updateFrequency: 60,
                renderFrequency: 10,
                backgroundColor: Color.CornflowerBlue,
                picture: PicturesCollection.GetPicture("Test Picture")
            );

            window.Run();
        }
    }
}
