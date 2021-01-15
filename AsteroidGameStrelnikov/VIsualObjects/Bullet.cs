using AsteroidGameStrelnikov.VisualObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGameStrelnikov.VIsualObjects
{
    internal class Bullet : CollisionObject
    {

        private const int _BulletSpeed = 3;

        public Bullet(Point Position, Point Direction, int Size)
            : base(Position, Direction, new Size(Size, Size), Properties.Resources.bullet)
        {

        }

        //public override void Update() => _Position.X += _BulletSizeX;

        public override void Update()
        {
            _Position.X += _BulletSpeed;

            if (_Position.X < 0 - _Direction.X)
                _Position.X = Game.Width + _Size.Width;
        }

    }
}
