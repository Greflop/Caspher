using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Projet_2._0.Menus;

namespace Projet_2._0
{
    public class Player2 : Animated
    {
        public Texture2D player_texture;
        public ControlsPlayer2 controlsplayer2;

        public Player2(Texture2D player_texture, Rectangle hitbox)
            : base(2, player_texture, hitbox)
        {
            this.player_texture = player_texture;
            this.Position = new Vector2(400, 300);
            this.Velocity = new Vector2(0, 0);
            this.Speed = 0.01f;
            controlsplayer2 = new ControlsPlayer2(Position, Velocity, Speed);
        }

        public void update(GameTime gametime)
        {
            controlsplayer2.update(gametime);
            Position = controlsplayer2.getPosition();
            Velocity = controlsplayer2.getVelocity();
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(player_texture, Position, Color.Blue);
        }

    }
}
