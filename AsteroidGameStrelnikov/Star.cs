using System;
using System.Drawing;

namespace AsteroidGameStrelnikov
{
    class Star : VizualObject
    {
        public Star(Point Position, Point Direction, int Size) 
            : base(Position, Direction, new Size(Size, Size))
        {

        }

        public override void Draw(Graphics g)
        {
            g.DrawLine(Pens.WhiteSmoke,
                _Position.X, _Position.Y,
                _Position.X + _Size.Width, _Position.Y + _Size.Height);

            g.DrawLine(Pens.WhiteSmoke,
               _Position.X + _Size.Width, _Position.Y,
               _Position.X, _Position.Y + _Size.Height);
        }

        public override void Update()
        {
            _Position.X += _Direction.X;

            if (_Position.X < 0)
                _Direction.X *= -1;

            if (_Position.X > Game.Width - 50)
                _Position.X = 0 - _Size.Width;
        }
    }
}
