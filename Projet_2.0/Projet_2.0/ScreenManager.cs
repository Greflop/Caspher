using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Projet_2._0.Menus;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;


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
        Menu_Pause,
        Menu_Pause_Option,
        Menu_Play_Solo_world1_lvl1,
        Menu_Play_Solo_world1_lvl2,
        Menu_Play_Solo_world1_lvl3,
        Menu_Play_Solo_world2_lvl1,
    }

    class ScreenManager
    {
        public Casper casper;
        public Casper casper2;
        public Casper player2;
        Menu_Base menubase;
        Menu_Options menuoptions;
        GameType gametype, previousgametype;
        Menu_Play menuplay;
        Menu_Play_Solo menuSolo;
        Menu_Play_Multi menuMulti;
        Menu_Play_Solo_World1 menusolo1;
        Menu_Play_Solo_World2 menusolo2;
        Menu_Pause menupause;
        Menu_Pause_Options menupauseoption;
        Decors decors, world2, world2vert1, world2vert2, decors1, decors2;
        public Camera camera;

        public Level1 level1;
        Obstacles obstacles;
        KeyboardState keyboardstate, previouskeyboardstate;

        public Controls controls, controlsPlayer2, controlsWorld2;


        public ScreenManager(GameType gametype, Game1 game)
        {
            menubase = new Menu_Base(Content_Manager.getInstance().Textures["menubase"]);
            menuoptions = new Menu_Options(Content_Manager.getInstance().Textures["menuoptions"]);
            menuplay = new Menu_Play(Content_Manager.getInstance().Textures["menuplay"]);
            menuSolo = new Menu_Play_Solo(Content_Manager.getInstance().Textures["menusolo"]);
            menusolo1 = new Menu_Play_Solo_World1(Content_Manager.getInstance().Textures["solo1"]);
            menusolo2 = new Menu_Play_Solo_World2(Content_Manager.getInstance().Textures["solo2"]);
            menuMulti = new Menu_Play_Multi(Content_Manager.getInstance().Textures["menumulti"]);
            menupauseoption = new Menu_Pause_Options(Content_Manager.getInstance().Textures["menupauseoption"]);
            casper = new Casper(Content_Manager.getInstance().Textures["Casper"], new Rectangle(0, 0, 16, 34));
            player2 = new Casper(Content_Manager.getInstance().Textures["Casper"], new Rectangle(50, 50, 16, 34));
            casper2 = new Casper(Content_Manager.getInstance().Textures["Player1"], new Rectangle(50, 50, 0, 0));
            controls = new Controls(casper.Position, casper.Velocity, casper.Speed, Keys.W, Keys.A, Keys.D, Keys.S);
            controlsPlayer2 = new Controls(player2.Position, player2.Velocity, player2.Speed, Keys.Up, Keys.Left, Keys.Right, Keys.Down);
            controlsWorld2 = new Controls(casper2.Position, casper2.Velocity, casper2.Speed, Keys.Up, Keys.Left, Keys.Right, Keys.Down);
            world2vert1 = new Decors(Content_Manager.getInstance().Textures["vert"], new Rectangle(-1680, 0, 1680, 1050));
            world2vert2 = new Decors(Content_Manager.getInstance().Textures["vert"], new Rectangle(1680, 0, 1680, 1050));


            camera = new Camera(Game1.GetGame().GraphicsDevice.Viewport);
            game.casperr = casper;
            decors = new Decors(Content_Manager.getInstance().Textures["Level1"], new Rectangle(0, 0, 1680, 1050));
            decors1 = new Decors(Content_Manager.getInstance().Textures["Level1"], new Rectangle(1680, 0, 1680, 1050));
            decors2 = new Decors(Content_Manager.getInstance().Textures["Level1"], new Rectangle(-1680, 0, 1680, 1050));
            world2 = new Decors(Content_Manager.getInstance().Textures["world2"], new Rectangle(0, 0, 1680, 1050));
            menupause = new Menu_Pause(Content_Manager.getInstance().Textures["menupause"]);
            level1 = new Level1(new Vector2(0, 0));
            obstacles = new Obstacles(level1.getList());
            previousgametype = GameType.Exit;

            this.gametype = gametype;
        }

        public void update(GameTime gametime)
        {
            camera.update(gametime, new Vector2(840, 0));
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
                    // menuMulti.update(gametime, ref gametype, ref previousgametype);
                    camera.update(gametime, casper.Position);
                    casper.update(gametime, controls, gametype, level1);
                    player2.update(gametime, controlsPlayer2, gametype, level1);

                    Game1.GetGame().IsMouseVisible = false;
                    if (keyboardstate.IsKeyDown(Keys.Escape) && previouskeyboardstate.IsKeyUp(Keys.Escape))
                    {
                        previousgametype = GameType.Menu_Play_Multi_Type;
                        casper.update(gametime, controls, gametype, level1);
                        player2.update(gametime, controlsPlayer2, gametype, level1);

                        Game1.GetGame().IsMouseVisible = true;
                        MediaPlayer.Stop();
                        MediaPlayer.Play(SoundManager.pause);
                        gametype = GameType.Menu_Pause;

                    }
                    previouskeyboardstate = keyboardstate;
                    break;
                case GameType.Menu_Option_Type:
                    menuoptions.update(gametime, ref gametype, ref previousgametype);
                    previousgametype = GameType.Menu_Base_Type;
                    break;
                case GameType.Menu_Play_Solo_world1_lvl1:
                    camera.update(gametime, casper.Position);
                    casper.update(gametime, controls, gametype, level1);
                    Game1.GetGame().IsMouseVisible = false;
                    if (keyboardstate.IsKeyDown(Keys.Escape) && previouskeyboardstate.IsKeyUp(Keys.Escape))
                    {
                        //casper.update(gametime);
                        Game1.GetGame().IsMouseVisible = true;
                        MediaPlayer.Stop();
                        MediaPlayer.Play(SoundManager.pause);
                        gametype = GameType.Menu_Pause;
                        previousgametype = GameType.Menu_Play_Solo_world1_lvl1;
                    }
                    previouskeyboardstate = keyboardstate;
                    break;
                case GameType.Menu_Play_Solo_world2_lvl1:
                    camera.update(gametime, casper2.Position);
                    casper2.update(gametime, controlsPlayer2, gametype, level1);
                    Game1.GetGame().IsMouseVisible = false;
                    if (keyboardstate.IsKeyDown(Keys.Escape) && previouskeyboardstate.IsKeyUp(Keys.Escape))
                    {
                        //casper.update(gametime);
                        Game1.GetGame().IsMouseVisible = true;
                        MediaPlayer.Stop();
                        MediaPlayer.Play(SoundManager.pause);
                        gametype = GameType.Menu_Pause;
                        previousgametype = GameType.Menu_Play_Solo_world2_lvl1;
                    }
                    previouskeyboardstate = keyboardstate;

                    break;
                case GameType.Exit:
                    Game1.GetGame().Exit();
                    break;
                case GameType.Menu_Pause:
                    camera.update(gametime, casper.Position);
                    if (keyboardstate.IsKeyDown(Keys.Escape) && previouskeyboardstate.IsKeyUp(Keys.Escape))
                    {
                        Game1.GetGame().IsMouseVisible = false;
                        gametype = previousgametype;
                        MediaPlayer.Stop();
                        MediaPlayer.Play(SoundManager.ingame);

                    }
                    menupause.update(gametime, ref gametype, ref previousgametype, camera.centre);
                    previouskeyboardstate = keyboardstate;
                    break;
                case GameType.Menu_Pause_Option:
                    camera.update(gametime, casper.Position);
                    menupauseoption.update(gametime, ref gametype, ref previousgametype, camera.centre);
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
                    //  menuMulti.Draw(spritebatch);
                    decors.Draw(spritebatch);
                    decors1.Draw(spritebatch);
                    decors2.Draw(spritebatch);
                    obstacles.Draw(spritebatch);
                    casper.Draw(spritebatch, Color.White);
                    player2.Draw(spritebatch, Color.CornflowerBlue);
                    break;
                case GameType.Menu_Option_Type:
                    menuoptions.Draw(spritebatch);
                    break;
                case GameType.Menu_Play_Solo_world1_lvl1:
                    decors.Draw(spritebatch);
                    decors1.Draw(spritebatch);
                    decors2.Draw(spritebatch);
                    obstacles.Draw(spritebatch);
                    casper.Draw(spritebatch, Color.White);
                    break;
                case GameType.Menu_Play_Solo_world2_lvl1:
                    world2.Draw(spritebatch);
                    world2vert1.Draw(spritebatch);
                    world2vert2.Draw(spritebatch);
                    casper2.Draw(spritebatch, Color.White);
                    break;
                case GameType.Menu_Pause:
                    switch (previousgametype)
                    {
                        case GameType.Menu_Play_Solo_world1_lvl1:
                            decors.Draw(spritebatch);
                            decors1.Draw(spritebatch);
                            decors2.Draw(spritebatch);
                            obstacles.Draw(spritebatch);
                            break;
                        case GameType.Menu_Play_Solo_world1_lvl2:
                            //decors lvl2
                            break;
                        case GameType.Menu_Play_Solo_world1_lvl3:
                            //decors lvl 3
                            break;
                        case GameType.Menu_Play_Solo_world2_lvl1:
                            world2.Draw(spritebatch);
                            world2vert1.Draw(spritebatch);
                            world2vert2.Draw(spritebatch);
                            casper2.Draw(spritebatch, Color.White);
                            break;
                        case GameType.Menu_Play_Multi_Type:
                            decors.Draw(spritebatch);
                            decors1.Draw(spritebatch);
                            decors2.Draw(spritebatch);
                            obstacles.Draw(spritebatch);
                            casper.Draw(spritebatch, Color.White);
                            player2.Draw(spritebatch, Color.CornflowerBlue);
                            break;
                        default:
                            break;
                    }
                    //casper.Draw(spritebatch, Color.White);
                    //player2.Draw(spritebatch, Color.CornflowerBlue);
                    menupause.Draw(spritebatch);
                    break;
                case GameType.Menu_Pause_Option:
                    switch (previousgametype)
                    {
                        case GameType.Menu_Play_Solo_world1_lvl1:
                            decors.Draw(spritebatch);
                            decors1.Draw(spritebatch);
                            decors2.Draw(spritebatch);
                            obstacles.Draw(spritebatch);
                            break;
                        case GameType.Menu_Play_Solo_world1_lvl2:
                            //decors lvl2
                            break;
                        case GameType.Menu_Play_Solo_world1_lvl3:
                            //decors lvl 3
                            break;
                        case GameType.Menu_Play_Solo_world2_lvl1:
                            world2.Draw(spritebatch);
                            world2vert1.Draw(spritebatch);
                            world2vert2.Draw(spritebatch);
                            break;
                        case GameType.Menu_Play_Multi_Type:
                            decors.Draw(spritebatch);
                            decors1.Draw(spritebatch);
                            decors2.Draw(spritebatch);
                            obstacles.Draw(spritebatch);
                            casper.Draw(spritebatch, Color.White);
                            player2.Draw(spritebatch, Color.CornflowerBlue);

                            break;
                        default:
                            break;
                    }
                    //casper.Draw(spritebatch, Color.White);
                    //player2.Draw(spritebatch, Color.CornflowerBlue);
                    menupauseoption.Draw(spritebatch);
                    break;
                default:
                    menubase.Draw(spritebatch);
                    break;
            }
        }
    }
}
