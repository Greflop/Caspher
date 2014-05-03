using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Projet_2._0
{
    class Menu_Options
    {
        Rectangle Bouton_Play, Bouton_Exit, Bouton_Res, Bouton_Full, Bouton_Sound;
        Texture2D Text_Menu_Options;
        Rectangle mouseClick;
        MouseState mouseState, previousmouseState;
        KeyboardState keyboardstate, previouskeyboardstate;

        public Menu_Options(Texture2D Text_Menu_Options)
        {
            Bouton_Play = new Rectangle(500, 210, 225, 310);
            Bouton_Exit = new Rectangle(755, 280, 165, 80);
            Bouton_Res = new Rectangle(500, 530, 225, 310);
            Bouton_Full = new Rectangle(750, 700, 225, 310);
            Bouton_Sound = new Rectangle(1000, 530, 225, 310);
            this.Text_Menu_Options = Text_Menu_Options;
        }

        void MouseClicked(int x, int y, ref GameType gametype)
        {
            mouseClick = new Rectangle(x, y, 10, 10);
            if (mouseClick.Intersects(Bouton_Play))
            {
                gametype = GameType.Menu_Play_Type;
            }
            else if (mouseClick.Intersects(Bouton_Exit))
            {
                Game1.GetGame().Exit();
            }
            else if (mouseClick.Intersects(Bouton_Res))
            {
                gametype = GameType.Menu_Option_Type;
            }
            else if (mouseClick.Intersects(Bouton_Full))
            {
                Game1.GetGame().IsFullScreen = !Game1.GetGame().IsFullScreen;
            }
            else if (mouseClick.Intersects(Bouton_Sound))
            {
                SoundEffect.MasterVolume = 1.0f - SoundEffect.MasterVolume;
                MediaPlayer.Volume = 1.0f - MediaPlayer.Volume;
            }
        }

        public void update(GameTime gametime, ref GameType gametype,ref GameType previousgametype)
        {
            keyboardstate = Keyboard.GetState();
            mouseState = Mouse.GetState();
            /// <check if mouseclick>
            if (previousmouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released)
            {
                MouseClicked(mouseState.X, mouseState.Y, ref gametype);
            }
            /// </check if mouseclick>
            previousmouseState = mouseState;
            if (keyboardstate.IsKeyDown(Keys.Escape) && previouskeyboardstate.IsKeyUp(Keys.Escape))
            {
                gametype = previousgametype;
            }
            previouskeyboardstate = keyboardstate;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Text_Menu_Options, new Rectangle(0, 0, Convert.ToInt32(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width), Convert.ToInt32(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height)), Color.White);
        }
    }
}
