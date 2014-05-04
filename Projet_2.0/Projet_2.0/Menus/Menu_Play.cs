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
    class Menu_Play
    {
        Rectangle Bouton_Exit, Bouton_Options, Bouton_Solo, Bouton_Multi;
        Texture2D Text_Menu_Play;
        Rectangle mouseClick;
        MouseState mouseState, previousmouseState;
        KeyboardState keyboardstate, previouskeyboardstate;

        public Menu_Play(Texture2D Text_Menu_Play)
        {
            this.Text_Menu_Play = Text_Menu_Play;
            Bouton_Options = new Rectangle(955, 210, 225, 310);
            Bouton_Solo = new Rectangle(500, 525, 225, 310);
            Bouton_Multi = new Rectangle(755, 680, 225, 310);
            Bouton_Exit = new Rectangle(755, 280, 165, 80);
        }

        void MouseClicked(int x, int y, ref GameType gameType)
        {
            mouseClick = new Rectangle(x, y, 10, 10);

            if (mouseClick.Intersects(Bouton_Exit))
            {
                Game1.GetGame().Exit();
            }
            else if (mouseClick.Intersects(Bouton_Options))
            {
                gameType = GameType.Menu_Option_Type;
            }
            else if (mouseClick.Intersects(Bouton_Solo))
            {
                gameType = GameType.Menu_Play_Solo_Type;
            }
            else if (mouseClick.Intersects(Bouton_Multi))
            {
                gameType = GameType.Menu_Play_Multi_Type;
                MediaPlayer.Stop();
                MediaPlayer.Play(SoundManager.ingame);
                MediaPlayer.IsRepeating = true;
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
            spritebatch.Draw(Text_Menu_Play, new Rectangle(0, 0, Convert.ToInt32(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width), Convert.ToInt32(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height)), Color.White);
        }
    }
}
