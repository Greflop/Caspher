using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;



namespace Projet_2._0
{
    public class Casper : Animated
    {
        public Texture2D casper;
        public Controls controls;

        public Casper(Texture2D casper, Rectangle hitbox) : base(2, casper, hitbox)
        {
            this.casper = casper;
            this.Position = new Vector2(300, 250);
            this.Velocity = new Vector2(0,0);
            this.Speed = 0.01f;
            controls = new Controls(Position, Velocity, Speed);

        }

        public void update(GameTime gametime)
        {
            controls.update(gametime);
            Position = controls.getPosition();
            Velocity = controls.getVelocity();
        }

        public void Draw(SpriteBatch spritebatch)
        {
            //spritebatch.DrawString(fontdebug, Convert.ToString(Velocity.X), new Vector2(10, 10), Color.Red);
            spritebatch.Draw(casper, Position, Color.White);
        }
    }
}
