using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Projet_2._0
{
    class Menu_Pause
    {
        Rectangle Bouton_Resume, Bouton_Exit, Bouton_Main,Bouton_Options;
        Rectangle mouseClick;
        MouseState mouseState, previousmouseState;
        KeyboardState keyboardstate, previouskeyboardstate;
        Texture2D Text_Menu_Pause;

        public Menu_Pause(Texture2D Text_Menu_Pause)
        {
            this.Text_Menu_Pause = Text_Menu_Pause;
            Bouton_Resume = new Rectangle(675, 180, 225, 155);
            Bouton_Options = new Rectangle(675, 340, 225, 155);
            Bouton_Main = new Rectangle(675, 530, 225, 155);
            Bouton_Exit = new Rectangle(675, 690, 225, 155);
        }

        void MouseClicked(int x, int y, ref GameType gametype)
        {
            mouseClick = new Rectangle(x, y, 10, 10);
            if (mouseClick.Intersects(Bouton_Resume))
            {
                gametype = GameType.Menu_Play_Solo_world1_lvl1;
            }
            else if (mouseClick.Intersects(Bouton_Exit))
            {
                Game1.GetGame().Exit();
            }
            else if (mouseClick.Intersects(Bouton_Main))
            {
                MediaPlayer.Play(SoundManager.menu);
                gametype = GameType.Menu_Base_Type;

            }
            else if (mouseClick.Intersects(Bouton_Options))
            {
                gametype = GameType.Menu_Pause_Option;
            }
        }

        public void update(GameTime gametime, ref GameType gametype, ref GameType previousgametype)
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
            spritebatch.Draw(Text_Menu_Pause, new Rectangle(0,0, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height), Color.White);
        }
    }
}
