using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Projet_2._0.Menus
{
    public class Camera
    {
        public Matrix transform;
        Viewport view;
        Vector2 centre;

        public Camera(Viewport newView)
        {
            view = newView;
        }

        public void update(GameTime gametime, Casper casperr)
        {
            centre = new Vector2(casperr.Position.X + (casperr.Sprite.Width / 2) - 840, 0);
            transform = Matrix.CreateScale(new Vector3(1,1,0)) *
                Matrix.CreateTranslation(new Vector3(-centre.X, -centre.Y,0));
        }

    }
}
