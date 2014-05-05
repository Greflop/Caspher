﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Projet_2._0
{
    public class Animation
    {
        public enum State
	    {
            Right,
            Left,
            Top,
            Basic,
            Falling,
            TopRight,
            TopLeft
	    }
        State state;
        Texture2D texture;
       public GameType gametype;
        int delta;

        public Animation()
        {
            state = State.Basic;
        }

        public State getState(Vector2 Position, Vector2 previousPosition)
        {
            if (previousPosition == Position)
                state = State.Basic;
            else if (previousPosition.X < Position.X && previousPosition.Y > Position.Y)
                state = State.TopRight;
            else if (previousPosition.X > Position.X && previousPosition.Y > Position.Y)
                state = State.TopLeft;
            else if (previousPosition.X < Position.X)
                state = State.Right;
            else if (previousPosition.X > Position.X)
                state = State.Left;
            else if (previousPosition.Y > Position.Y)
                state = State.Top;
            else if (previousPosition.Y < Position.Y)
                state = State.Falling;
            return state;
        }

        public Texture2D getText(State state,GameType gametype)
        {
            if (gametype == GameType.Menu_Play_Solo_world1_lvl1 || gametype == GameType.Menu_Play_Multi_Type)
            {
                if (state == State.Basic)
                    texture = Content_Manager.getInstance().Textures["Casper"];
                else if (state == State.Right)
                {
                    if (delta < 15)
                        texture = Content_Manager.getInstance().Textures["Casper/CasperDroite1"];
                    else if (delta < 30)
                        texture = Content_Manager.getInstance().Textures["Casper/CasperDroite2"];
                    else if (delta < 45)
                        texture = Content_Manager.getInstance().Textures["Casper/CasperDroite3"];
                    else if (delta < 60)
                        texture = Content_Manager.getInstance().Textures["Casper/CasperDroite4"];
                }
                else if (state == State.Left)
                {
                    if (delta < 15)
                        texture = Content_Manager.getInstance().Textures["Casper/CasperGauche1"];
                    else if (delta < 30)
                        texture = Content_Manager.getInstance().Textures["Casper/CasperGauche2"];
                    else if (delta < 45)
                        texture = Content_Manager.getInstance().Textures["Casper/CasperGauche3"];
                    else if (delta < 60)
                        texture = Content_Manager.getInstance().Textures["Casper/CasperGauche4"];
                }
                else if (state == State.TopRight)
                    texture = Content_Manager.getInstance().Textures["Casper/CasperDroiteSaut"];
                else if (state == State.TopLeft)
                    texture = Content_Manager.getInstance().Textures["Casper/CasperGaucheSaut"];
                else if (state == State.Top)
                    texture = Content_Manager.getInstance().Textures["Casper/CasperSaut"];
                else if (state == State.Falling)
                    texture = Content_Manager.getInstance().Textures["Casper/CasperFall"];
            }
            else if (gametype == GameType.Menu_Play_Solo_world2_lvl1)
            {
                if (state == State.Basic)
                    texture = Content_Manager.getInstance().Textures["Player1"];
                else if (state == State.Right)
                {
                    if (delta < 15)
                        texture = Content_Manager.getInstance().Textures["PlayerWorld2/Player13"];
                    else if (delta < 30)
                        texture = Content_Manager.getInstance().Textures["PlayerWorld2/Player14"];
                    else if (delta < 45)
                        texture = Content_Manager.getInstance().Textures["PlayerWorld2/Player15"];
                    else if (delta < 60)
                        texture = Content_Manager.getInstance().Textures["PlayerWorld2/Player16"];
                }
                else if (state == State.Left)
                {
                    if (delta < 15)
                        texture = Content_Manager.getInstance().Textures["PlayerWorld2/Player5"];
                    else if (delta < 30)
                        texture = Content_Manager.getInstance().Textures["PlayerWorld2/Player6"];
                    else if (delta < 45)
                        texture = Content_Manager.getInstance().Textures["PlayerWorld2/Player7"];
                    else if (delta < 60)
                        texture = Content_Manager.getInstance().Textures["PlayerWorld2/Player8"];
                }
                else if (state == State.Top)
                {
                    if (delta < 15)
                        texture = Content_Manager.getInstance().Textures["PlayerWorld2/Player9"];
                    else if (delta < 30)
                        texture = Content_Manager.getInstance().Textures["PlayerWorld2/Player10"];
                    else if (delta < 45)
                        texture = Content_Manager.getInstance().Textures["PlayerWorld2/Player11"];
                    else if (delta < 60)
                        texture = Content_Manager.getInstance().Textures["PlayerWorld2/Player12"];
                }
                else if (state == State.Falling)
                {
                    if (delta < 15)
                        texture = Content_Manager.getInstance().Textures["PlayerWorld2/Player1"];
                    if (delta < 30)
                        texture = Content_Manager.getInstance().Textures["PlayerWorld2/Player2"];
                    else if (delta < 45)
                        texture = Content_Manager.getInstance().Textures["PlayerWorld2/Player3"];
                    else if (delta < 60)
                        texture = Content_Manager.getInstance().Textures["PlayerWorld2/Player4"];
                }
            }
            return texture;
        }

        public void update(GameTime gametime, GameType gametype)
        {
            if (state == State.Left || state == State.Right)
                delta++;
            if (delta > 60)
                delta = 0;
        }
    }
}
