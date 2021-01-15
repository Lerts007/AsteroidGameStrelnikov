﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGameStrelnikov.VIsualObjects
{
    internal abstract class CollisionObject : ImageObject
    {
        protected CollisionObject(Point Position, Point Direction, Size Size, Image Image) 
            : base(Position, Direction, Size, Image)
        {
        }

        public Rectangle Rect => new Rectangle(_Position, _Size);

        public bool CheckCollision(ICollision obj) => Rect.IntersectsWith(obj.Rect);

        
    }
}
