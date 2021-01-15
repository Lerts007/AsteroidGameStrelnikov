using AsteroidGameStrelnikov.VisualObjects;
using System.Drawing;

namespace AsteroidGameStrelnikov.VIsualObjects
{
    internal abstract class ImageObject : VizualObject
    {
        private readonly Image _Image;

        protected ImageObject(Point Position, Point Direction, Size Size, Image Image)
            : base(Position, Direction, Size)
        {
            _Image = Image;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(_Image, _Position.X, _Position.Y, _Size.Width, _Size.Height);
        }

        public abstract void Update();
    }
}
