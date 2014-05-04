using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Projet_2._0
{
    /*class Obstacles
    {
        List<Rectangle> list;

        public Obstacles(List<Rectangle> list)          
        {
            this.list = list;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            foreach (Rectangle rectangle in list)
            {
                spritebatch.Draw(Content_Manager.getInstance().Textures["Block"], rectangle, Color.White);
            }
        }
    }*/
    public class Obstacles
    {
        Rectangle Hitbox;
        Vector2 Position;
        Texture2D Texture;

        public Obstacles(Vector2 Position)
        {
            this.Position = Position;
            Hitbox = new Rectangle((int)Position.X,(int)Position.Y, 120,80);
            Texture = Content_Manager.getInstance().Textures["Block"];
        }


        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Texture, Hitbox, Color.White);
        }
    }
}
