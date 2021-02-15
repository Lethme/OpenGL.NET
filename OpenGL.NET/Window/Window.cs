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
using OpenGL.Window.Graphics.Figures;
using OpenGL.Window.Graphics.Pictures;

using OpenGL.UserPictures;

namespace OpenGL
{
    public class OpenGLWindow : GameWindow
    {
        public Picture WindowPicture { get; }
        public OpenGLWindow
        (
            int width,
            int height,
            string title = WindowDefaultSettings.WindowTitle,
            int updateFrequency = WindowDefaultSettings.WindowUpdateFrequency,
            int renderFrequency = WindowDefaultSettings.WindowRenderFrequency,
            FloatColor backgroundColor = null,
            Picture picture = null
        )
            : base(width, height, GraphicsMode.Default, title)
        {
            Graphics.Initialize(this);
            TargetUpdateFrequency = updateFrequency;
            TargetRenderFrequency = renderFrequency;

            if (picture == null) WindowPicture = Picture.Create();
            else WindowPicture = picture;

            Graphics.SetBackground(backgroundColor);
        }
        public OpenGLWindow() : base
        (
            WindowDefaultSettings.WindowWidth,
            WindowDefaultSettings.WindowHeight,
            GraphicsMode.Default,
            WindowDefaultSettings.WindowTitle
        )
        {
            Graphics.Initialize(this);
            TargetUpdateFrequency = WindowDefaultSettings.WindowUpdateFrequency;
            TargetRenderFrequency = WindowDefaultSettings.WindowRenderFrequency;
            WindowPicture = Picture.Create();
            Graphics.SetBackground(Color.White);
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
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            WindowPicture.Draw();
            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }
    }
}
