using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            var window = new Window
            (
                width: 1200,
                height: 800,
                title: "Test OpenGL Application",
                updateFrequency: 60,
                renderFrequency: 10
            );

            window.Run();
        }
    }
}
