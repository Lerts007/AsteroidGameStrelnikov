using System.Drawing;

namespace AsteroidGameStrelnikov
{
    class VizualObject
    {
        protected Point _Position;
        protected Point _Direction;
        protected Size _Size;

        public VizualObject(Point Position, Point Direction, Size Size)
        {
            _Position = Position;
            _Direction = Direction;
            _Size = Size;
        }

        public virtual void Draw(Graphics g)
        {
            g.DrawEllipse(Pens.White,
                _Position.X, _Position.Y,
                _Size.Width, _Size.Height);
        }

        public virtual void Update()
        {
            _Position.X += _Direction.X;
            _Position.Y += _Direction.Y;

            if (_Position.X < 5)
                _Direction.X *= -1;
            if (_Position.Y < _Size.Height)
                _Direction.Y *= -1;

            if (_Position.X > Game.Width - 50)
                _Direction.X *= -1;
            if (_Position.Y > Game.Height - 75)
                _Direction.Y *= -1;
        }
    }
}
