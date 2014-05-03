using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Projet_2._0
{
    public enum GameType   // A laisser ici, pas dans la classe
    {
        Exit,
        Menu_Base_Type,
        Menu_Play_Type,
        Menu_Play_Solo_Type,
        Menu_Play_Solo_World1_Type,
        Menu_Play_Solo_World2_Type,
        Menu_Play_Multi_Type,
        Menu_Option_Type,
        Menu_Play_Solo_world1_lvl1,
        Menu_Play_Solo_world1_lvl2,
        Menu_Play_Solo_world1_lvl3
    }
    
    class ScreenManager
    {
        public Casper casper;
        Menu_Base menubase;
        Menu_Options menuoptions;
        GameType gametype, previousgametype;
        Menu_Play menuplay;
        Menu_Play_Solo menuSolo;
        Menu_Play_Multi menuMulti;
        Menu_Play_Solo_World1 menusolo1;
        Menu_Play_Solo_World2 menusolo2;
        Decors decors;
        KeyboardState keyboardstate, previouskeyboardstate;

        public ScreenManager(GameType gametype, Game1 game)
        {
            menubase = new Menu_Base(Content_Manager.getInstance().Textures["menubase"]);
            menuoptions = new Menu_Options(Content_Manager.getInstance().Textures["menuoptions"]);
            menuplay = new Menu_Play(Content_Manager.getInstance().Textures["menuplay"]);
            menuSolo = new Menu_Play_Solo(Content_Manager.getInstance().Textures["menusolo"]);
            menusolo1 = new Menu_Play_Solo_World1(Content_Manager.getInstance().Textures["solo1"]);
            menusolo2 = new Menu_Play_Solo_World2(Content_Manager.getInstance().Textures["solo2"]);
            menuMulti = new Menu_Play_Multi(Content_Manager.getInstance().Textures["menumulti"]);
            casper = new Casper(Content_Manager.getInstance().Textures["Casper"], new Rectangle(0, 0, 0, 0));
            game.casper = casper;
            decors = new Decors(Content_Manager.getInstance().Textures["Level1"], new Rectangle(0, 0, 1680, 1050));
            previousgametype = GameType.Exit;
            this.gametype = gametype;
        }
        public void update(GameTime gametime)
        {
            keyboardstate = Keyboard.GetState();
            switch (gametype)
            {
                case GameType.Menu_Base_Type:
                    menubase.update(gametime, ref gametype, ref previousgametype);
                    previousgametype = GameType.Exit;
                    break;
                case GameType.Menu_Play_Type:
                    menuplay.update(gametime, ref gametype, ref previousgametype);
                    previousgametype = GameType.Menu_Base_Type;
                    break;
                case GameType.Menu_Play_Solo_Type:
                    menuSolo.update(gametime, ref gametype, ref previousgametype);
                    previousgametype = GameType.Menu_Play_Type;
                    break;
                case GameType.Menu_Play_Solo_World1_Type:
                    menusolo1.update(gametime, ref gametype, ref previousgametype);
                    previousgametype = GameType.Menu_Play_Solo_Type;
                    break;
                case GameType.Menu_Play_Solo_World2_Type:
                    menusolo2.update(gametime, ref gametype, ref previousgametype);
                    previousgametype = GameType.Menu_Play_Solo_Type;
                    break;
                case GameType.Menu_Play_Multi_Type:
                    menuMulti.update(gametime, ref gametype, ref previousgametype);
                    previousgametype = GameType.Menu_Play_Type;
                    break;
                case GameType.Menu_Option_Type:
                    menuoptions.update(gametime, ref gametype, ref previousgametype);
                    previousgametype = GameType.Menu_Base_Type;
                    break;
                case GameType.Menu_Play_Solo_world1_lvl1:
                    casper.update(gametime);
                    Game1.GetGame().IsMouseVisible = false;
                    if (keyboardstate.IsKeyDown(Keys.Escape) && previouskeyboardstate.IsKeyUp(Keys.Escape))
                    {
                        gametype = previousgametype;
                        Game1.GetGame().IsMouseVisible = true;
                    }
                    previouskeyboardstate = keyboardstate;
                    break;
                case GameType.Exit:
                    Game1.GetGame().Exit();
                    break;
                default:
                    menubase.update(gametime, ref gametype, ref previousgametype);
                    break;
            }
        }
        public void Draw(SpriteBatch spritebatch)
        {
            switch (gametype)
            {
                case GameType.Menu_Base_Type:
                    menubase.Draw(spritebatch);
                    break;
                case GameType.Menu_Play_Type:
                    menuplay.Draw(spritebatch);
                    break;
                case GameType.Menu_Play_Solo_Type:
                    menuSolo.Draw(spritebatch);
                    break;
                case GameType.Menu_Play_Solo_World1_Type:
                    menusolo1.Draw(spritebatch);
                    break;
                case GameType.Menu_Play_Solo_World2_Type:
                    menusolo2.Draw(spritebatch);
                    break;
                case GameType.Menu_Play_Multi_Type:
                    menuMulti.Draw(spritebatch);
                    break;
                case GameType.Menu_Option_Type:
                    menuoptions.Draw(spritebatch);
                    break;
                case GameType.Menu_Play_Solo_world1_lvl1:
                    decors.Draw(spritebatch);
                    casper.Draw(spritebatch);
                    
                    break;
                default:
                    menubase.Draw(spritebatch);
                    break;
            }
        }
    }
}
