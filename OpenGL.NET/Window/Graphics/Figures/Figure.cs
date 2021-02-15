using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenGL.Window.Graphics.Properties;

namespace OpenGL.Window.Graphics.Figures
{
    public interface Figure
    {
        FloatPoint[] Points { get; }
        int PointsCount { get; }
        void Draw();
    }
}
