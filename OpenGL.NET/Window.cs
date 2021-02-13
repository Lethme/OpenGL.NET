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

namespace OpenGL.NET
{
    class Window : GameWindow
    {
        public Window
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
        public Window() : base
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
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color.CornflowerBlue);

            GL.Begin(PrimitiveType.Quads);

            GL.Color3(Color.Yellow);
            GL.Vertex2(0, 0);
            GL.Color3(Color.Green);
            GL.Vertex2(1, 0);
            GL.Color3(Color.Red);
            GL.Vertex2(1, -1);
            GL.Color3(Color.BlueViolet);
            GL.Vertex2(0, -1);

            GL.End();

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }
    }
}
