using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Projet_2._0
{
    class Collisions
    {
        Vector2 Position, previousPosition;
        //Rectangle Hitbox;
        //List<Rectangle> Level;


        public Collisions()
        { previousPosition = Position; }

        public void update(Vector2 casperPosition, Rectangle casperHitbox, List<Rectangle> level)
        {
            Position = casperPosition;
            foreach (Rectangle rect in level)
            {
                if (rect.Intersects(casperHitbox))
                {
                    Position = previousPosition;
                }
            }
            previousPosition = Position;
        }

    }
}
