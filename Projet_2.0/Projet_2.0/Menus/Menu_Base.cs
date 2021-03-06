﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Projet_2._0
{
    class Menu_Base
    {
        Rectangle Bouton_Play, Bouton_Exit, Bouton_Options;
        Texture2D Text_Menu_base;
        Rectangle mouseClick;
        MouseState mouseState, previousmouseState;
        KeyboardState keyboardstate, previouskeyboardstate;


        public Menu_Base(Texture2D Text_Menu_base)
        {
            this.Text_Menu_base = Text_Menu_base;
            Bouton_Play = new Rectangle(500, 210, 225, 310);
            Bouton_Options = new Rectangle(955, 210, 225, 310);
            Bouton_Exit = new Rectangle(755, 280, 165, 80);
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
            else if (mouseClick.Intersects(Bouton_Options))
            {
                gametype = GameType.Menu_Option_Type;
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
            spritebatch.Draw(Text_Menu_base, new Rectangle(0, 0, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height), Color.White);
        }

    }
}
