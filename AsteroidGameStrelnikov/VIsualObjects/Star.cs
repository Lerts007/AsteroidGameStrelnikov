using AsteroidGameStrelnikov.VIsualObjects;
using System;
using System.Drawing;

namespace AsteroidGameStrelnikov.VisualObjects
{
    class Star : ImageObject
    {
        public Star(Point Position, Point Direction, int Size) 
            : base(Position, Direction, new Size(Size, Size), Properties.Resources.Star)
        {

        }
        
        public override void Update()
        {
            _Position.X -= _Direction.X;

            if (_Position.X < 0 - _Direction.X)
                _Position.X = Game.Width + _Size.Width;
        }
    }
}
