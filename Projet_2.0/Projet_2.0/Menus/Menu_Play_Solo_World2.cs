using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Projet_2._0.Menus;

namespace Projet_2._0
{
    class Menu_Play_Solo_World2
    {
        Rectangle Bouton_Play, Bouton_Exit, Bouton_Options,Bouton_Solo, Bouton_Multi, Bouton_World1, Bouton_World2;
        Texture2D Text_Menu_Play_Solo_World2;
        Triangle w1 = new Triangle(new Vector2(245, 690), new Vector2(410, 682), new Vector2(320, 844), Triangle.Base.up);
        Triangle w2 = new Triangle(new Vector2(335, 850), new Vector2(496, 850), new Vector2(417, 695), Triangle.Base.down);
        Triangle w3 = new Triangle(new Vector2(330, 860), new Vector2(501, 860), new Vector2(417, 1015), Triangle.Base.up);
        Rectangle mouseClick;
        KeyboardState keyboardstate, previouskeyboardstate;
        MouseState mouseState, previousmouseState;

        public Menu_Play_Solo_World2(Texture2D Text_Menu_Play_Solo_World2)
        {
            this.Text_Menu_Play_Solo_World2 = Text_Menu_Play_Solo_World2;
            Bouton_Options = new Rectangle(955, 210, 225, 310);
            Bouton_Solo = new Rectangle(500, 525, 225, 310);
            Bouton_Multi = new Rectangle(755, 680, 225, 310);
            Bouton_Exit = new Rectangle(755, 280, 165, 80);
            Bouton_Play = new Rectangle(500, 210, 225, 310);
            Bouton_World1 = new Rectangle(250, 360, 225, 155);
            Bouton_World2 = new Rectangle(250, 520, 225, 155);
        }
        public void MouseClicked(int x, int y, ref GameType gameType)
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
            else if (mouseClick.Intersects(Bouton_Multi))
            {
                gameType = GameType.Menu_Play_Multi_Type;
            }
            else if (mouseClick.Intersects(Bouton_Play))
            {
                gameType = GameType.Menu_Play_Type;
            }
            else if (mouseClick.Intersects(Bouton_World1))
            {
                gameType = GameType.Menu_Play_Solo_World1_Type;
            }
            else if (mouseClick.Intersects(Bouton_World2))
            {
                gameType = GameType.Menu_Play_Solo_World2_Type;
            }
            else if (mouseClick.Intersects(Bouton_Solo))
            {
                gameType = GameType.Menu_Play_Solo_Type;
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
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && w1.Intersect(Mouse.GetState().X, Mouse.GetState().Y))
            {
                gametype = GameType.Menu_Play_Solo_world2_lvl1;
                MediaPlayer.Stop();
                MediaPlayer.Play(SoundManager.ingame);
                MediaPlayer.IsRepeating = true;

            }
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && w2.Intersect(Mouse.GetState().X, Mouse.GetState().Y))
            {
                gametype = GameType.Menu_Play_Solo_world1_lvl2;

            }
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && w3.Intersect(Mouse.GetState().X, Mouse.GetState().Y))
            {
                gametype = GameType.Menu_Play_Solo_world1_lvl3;

            }

            if (keyboardstate.IsKeyDown(Keys.Escape) && previouskeyboardstate.IsKeyUp(Keys.Escape))
            {
                gametype = previousgametype;
            }
            previouskeyboardstate = keyboardstate;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Text_Menu_Play_Solo_World2, new Rectangle(0, 0, Convert.ToInt32(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width), Convert.ToInt32(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height)), Color.White);
        }
    }
}
