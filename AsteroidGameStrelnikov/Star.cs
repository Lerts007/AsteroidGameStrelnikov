using System;
using System.Drawing;

namespace AsteroidGameStrelnikov
{
    class Star : VizualObject
    {
        private Image Image = Image.FromFile("unnamed1.png");
        public Star(Point Position, Point Direction, int Size) 
            : base(Position, Direction, new Size(Size, Size))
        {

        }

        public override void Draw(Graphics g)
        {


            g.DrawImage(Image,
                 _Position.X, _Position.Y,
                 _Size.Width, _Size.Height);

        }

        public override void Update()
        {
            _Position.X -= _Direction.X;

            if (_Position.X < 0 - _Direction.X)
                _Position.X = Game.Width + _Size.Width;
        }
    }
}
