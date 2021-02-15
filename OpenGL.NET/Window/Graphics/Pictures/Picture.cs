using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenGL.Window.Graphics.Figures;

namespace OpenGL.Window.Graphics.Pictures
{
    public class Picture : IEnumerable<Figure>
    {
        public List<Figure> Figures { get; }
        public int FiguresCount => Figures.Count;
        public bool IsEmpty => Figures.Count == 0;
        public Picture() => Figures = new List<Figure>();
        public Picture(params Figure[] figures) => Figures = figures.ToList();
        public Picture(IEnumerable<Figure> figures) => Figures = figures.ToList();
        public void AddFigure(params Figure[] figures) => Figures.AddRange(figures);
        public void AddFigure(IEnumerable<Figure> figures) => Figures.AddRange(figures);
        public void Draw() 
        {
            Graphics.Clear();
            foreach (var figure in Figures) figure.Draw();
        }
        public IEnumerable<T> GetFigures<T>() where T : Figure
        {
            foreach(var figure in Figures)
            {
                if (figure.GetType() == typeof(T)) yield return (T)figure;
            }
        }
        public static Picture Create() => new Picture();
        public static Picture Create(params Figure[] figures) => new Picture(figures);
        public static Picture Create(IEnumerable<Figure> figures) => new Picture(figures);
        public IEnumerator<Figure> GetEnumerator() => Figures.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Figures.GetEnumerator();
    }
}
