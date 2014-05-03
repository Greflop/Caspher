using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Projet_2._0
{
    class Level1
    {
        List<Rectangle> level1 = new List<Rectangle>();
        Vector2 Position;

        public Level1(Vector2 Position)
        {
            this.Position = Position;
            int x = (int)Position.X;
            level1.Add(new Rectangle(0 + x, 970, 120, 80));
            level1.Add(new Rectangle(120 + x, 970, 120, 80));
            level1.Add(new Rectangle(240 + x, 970, 120, 80));
            level1.Add(new Rectangle(360 + x, 970, 120, 80));
            level1.Add(new Rectangle(480 + x, 970, 120, 80));
            level1.Add(new Rectangle(720 + x, 970, 120, 80));
            level1.Add(new Rectangle(840 + x, 970, 120, 80));
            level1.Add(new Rectangle(960 + x, 970, 120, 80));
            level1.Add(new Rectangle(1080 + x, 970, 120, 80));
            level1.Add(new Rectangle(1200 + x, 970, 120, 80));
            level1.Add(new Rectangle(1320 + x, 970, 120, 80));
            level1.Add(new Rectangle(1560 + x, 730, 120, 80));
            level1.Add(new Rectangle(1560 + x, 650, 120, 80));
            level1.Add(new Rectangle(1560 + x, 570, 120, 80));
            level1.Add(new Rectangle(1560 + x, 490, 120, 80));
            level1.Add(new Rectangle(840 + x, 890, 120, 80));
            level1.Add(new Rectangle(960 + x, 890, 120, 80));
            level1.Add(new Rectangle(960 + x, 810, 120, 80));
            level1.Add(new Rectangle(1080 + x, 810, 120, 80));
            level1.Add(new Rectangle(1080 + x, 730, 120, 80));
            level1.Add(new Rectangle(1320 + x, 810, 120, 80));
            level1.Add(new Rectangle(1320 + x, 570, 120, 80));
            level1.Add(new Rectangle(1440 + x, 570, 120, 80));
            level1.Add(new Rectangle(1200 + x, 490, 120, 80));
            level1.Add(new Rectangle(1320 + x, 490, 120, 80));
            level1.Add(new Rectangle(1080 + x, 410, 120, 80));
            level1.Add(new Rectangle(1200 + x, 410, 120, 80));
            level1.Add(new Rectangle(840 + x, 410, 120, 80));
            level1.Add(new Rectangle(960 + x, 410, 120, 80));
            level1.Add(new Rectangle(840 + x, 330, 120, 80));
            level1.Add(new Rectangle(480 + x, 410, 120, 80));
            level1.Add(new Rectangle(600 + x, 410, 120, 80));
            level1.Add(new Rectangle(120 + x, 330, 120, 80));
            level1.Add(new Rectangle(240 + x, 330, 120, 80));
            level1.Add(new Rectangle(120 + x, 250, 120, 80));
            level1.Add(new Rectangle(360 + x, 130, 120, 80));
            level1.Add(new Rectangle(600 + x, 130, 120, 80));
            level1.Add(new Rectangle(840 + x, 130, 120, 80));
            level1.Add(new Rectangle(1080 + x, 130, 120, 80));
            level1.Add(new Rectangle(1320 + x, 210, 120, 80));
            level1.Add(new Rectangle(1560 + x, 210, 120, 80));
        }
    }
}
