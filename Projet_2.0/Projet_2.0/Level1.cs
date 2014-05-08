using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Projet_2._0
{
    public class Level1
    {
        List<Rectangle> level1 = new List<Rectangle>();

        public Level1(Vector2 Position)
        {
            level1.Add(new Rectangle(0, 970, 120, 80));
            level1.Add(new Rectangle(120, 970, 120, 80));
            level1.Add(new Rectangle(240, 970, 120, 80));
            level1.Add(new Rectangle(360, 970, 120, 80));
            level1.Add(new Rectangle(480, 970, 120, 80));
            level1.Add(new Rectangle(720, 970, 120, 80));
            level1.Add(new Rectangle(840, 970, 120, 80));
            level1.Add(new Rectangle(960, 970, 120, 80));
            level1.Add(new Rectangle(1080, 970, 120, 80));
            level1.Add(new Rectangle(1200, 970, 120, 80));
            level1.Add(new Rectangle(1320, 970, 120, 80));
            level1.Add(new Rectangle(1560, 730, 120, 80));
            level1.Add(new Rectangle(1560, 810, 120, 80));
            level1.Add(new Rectangle(1560, 890, 120, 80));
            level1.Add(new Rectangle(1560, 970, 120, 80));
            level1.Add(new Rectangle(840, 890, 120, 80));
            level1.Add(new Rectangle(960, 890, 120, 80));
            level1.Add(new Rectangle(960, 810, 120, 80));
            level1.Add(new Rectangle(1080, 810, 120, 80));
            level1.Add(new Rectangle(1080, 730, 120, 80));
            level1.Add(new Rectangle(1320, 810, 120, 80));
            level1.Add(new Rectangle(1320, 570, 120, 80));
            level1.Add(new Rectangle(1440, 570, 120, 80));
            level1.Add(new Rectangle(1200, 490, 120, 80));
            level1.Add(new Rectangle(1320, 490, 120, 80));
            level1.Add(new Rectangle(1080, 410, 120, 80));
            level1.Add(new Rectangle(1200, 410, 120, 80));
            level1.Add(new Rectangle(840, 410, 120, 80));
            level1.Add(new Rectangle(960, 410, 120, 80));
            level1.Add(new Rectangle(840, 330, 120, 80));
            level1.Add(new Rectangle(480, 410, 120, 80));
            level1.Add(new Rectangle(600, 410, 120, 80));
            level1.Add(new Rectangle(120, 330, 120, 80));
            level1.Add(new Rectangle(240, 330, 120, 80));
            level1.Add(new Rectangle(120, 250, 120, 80));
            level1.Add(new Rectangle(360, 130, 120, 80));
            level1.Add(new Rectangle(600, 130, 120, 80));
            level1.Add(new Rectangle(840, 130, 120, 80));
            level1.Add(new Rectangle(1080, 130, 120, 80));
            level1.Add(new Rectangle(1320, 210, 120, 80));
            level1.Add(new Rectangle(1560, 210, 120, 80));
        }

        public List<Rectangle> getList()
        {
            return level1;
        }
    }
}
