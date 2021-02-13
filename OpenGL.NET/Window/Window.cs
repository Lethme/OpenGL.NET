using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL;

using Graphics = OpenGL.Window.Graphics.Graphics;
using OpenGL.Window.Graphics.Properties;

namespace OpenGL
{
    class OpenGLWindow : GameWindow
    {
        public OpenGLWindow
        (
            int width,
            int height,
            string title = WindowDefaultSettings.WindowTitle,
            int updateFrequency = WindowDefaultSettings.WindowUpdateFrequency,
            int renderFrequency = WindowDefaultSettings.WindowRenderFrequency
        )
            : base(width, height, GraphicsMode.Default, title)
        {
            TargetUpdateFrequency = updateFrequency;
            TargetRenderFrequency = renderFrequency;
        }
        public OpenGLWindow() : base
        (
            WindowDefaultSettings.WindowWidth,
            WindowDefaultSettings.WindowHeight,
            GraphicsMode.Default,
            WindowDefaultSettings.WindowTitle
        )
        {
            TargetUpdateFrequency = WindowDefaultSettings.WindowUpdateFrequency;
            TargetRenderFrequency = WindowDefaultSettings.WindowRenderFrequency;
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }
        protected override void OnLoad(EventArgs e)
        {
            Graphics.SetBackground(Color.CornflowerBlue);
            base.OnLoad(e);
        }
        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            Graphics.Clear();

            Graphics.Rectangle
            (
                x1: -0.5f, y1: 0.5f,
                x2: 0.5f, y2: 0.5f,
                x3: 0.5f, y3: -0.5f,
                x4: -0.5f, y4: -0.5f,
                fillColor: Color.Yellow
            );

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }
    }
}
