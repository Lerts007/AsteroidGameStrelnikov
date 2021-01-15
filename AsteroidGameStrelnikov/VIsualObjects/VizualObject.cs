using System;
using System.Drawing;

namespace AsteroidGameStrelnikov.VisualObjects
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

    }
}
