﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Projet_2._0
{
    class Content_Manager
    {
        private static Content_Manager instance;
        ContentManager CM;

        public Dictionary<String,Texture2D> Textures;

        private Content_Manager() 
        {
            Textures = new Dictionary<String,Texture2D>();
        }

        public static Content_Manager getInstance() 
        {
            if (instance == null)
                instance = new Content_Manager();
            return instance;
        }

        public void LoadTextures(ContentManager Content) 
        {
            CM = Content;
            AddTextures("Casper/CasperStop", "Casper");
            AddTextures("Casper/CasperDroite1");
            AddTextures("Casper/CasperDroite2");
            AddTextures("Casper/CasperDroite3");
            AddTextures("Casper/CasperDroite4");
            AddTextures("Casper/CasperDroiteSaut");
            AddTextures("Casper/CasperFall");
            AddTextures("Casper/CasperGauche1");
            AddTextures("Casper/CasperGauche2");
            AddTextures("Casper/CasperGauche3");
            AddTextures("Casper/CasperGauche4");
            AddTextures("Casper/CasperGaucheSaut");
            AddTextures("Casper/CasperSaut");
            AddTextures("Decors/Background1", "Level1");
            AddTextures("Decors/world2", "world2");
            AddTextures("Decors/Block3x2", "Block");
            AddTextures("Menu/Menu_Base", "menubase");
            AddTextures("Menu/Menu_Options", "menuoptions");
            AddTextures("Menu/Menu_Play", "menuplay");
            AddTextures("Menu/Menu_Play_Solo", "menusolo");
            AddTextures("Menu/Menu_Play_Solo_World1", "solo1");
            AddTextures("Menu/Menu_Play_Solo_World2", "solo2");
            AddTextures("Menu/Menu_Multi", "menumulti");
            AddTextures("Menu/Menu_pause", "menupause");
            AddTextures("Menu/Menu_pause_option", "menupauseoption");
            AddTextures("PlayerWorld2/PlayerBas1", "Player1");
            AddTextures("PlayerWorld2/PlayerBas2", "PlayerBas2");
            AddTextures("PlayerWorld2/PlayerBas3", "PlayerBas3");
            AddTextures("PlayerWorld2/PlayerBas4", "PlayerBas4");
            AddTextures("PlayerWorld2/PlayerDroite1","PlayerDroite1");
            AddTextures("PlayerWorld2/PlayerDroite2","PlayerDroite2");
            AddTextures("PlayerWorld2/PlayerDroite3","PlayerDroite3");
            AddTextures("PlayerWorld2/PlayerDroite4","PlayerDroite4");
            AddTextures("PlayerWorld2/PlayerHaut1","PlayerHaut1");
            AddTextures("PlayerWorld2/PlayerHaut2" , "PlayerHaut2");
            AddTextures("PlayerWorld2/PlayerHaut3" ,"PlayerHaut3");
            AddTextures("PlayerWorld2/PlayerHaut4","PlayerHaut4");
            AddTextures("PlayerWorld2/PlayerGauche1","PlayerGauche1");
            AddTextures("PlayerWorld2/PlayerGauche2","PlayerGauche2");
            AddTextures("PlayerWorld2/PlayerGauche3","PlayerGauche3");
            AddTextures("PlayerWorld2/PlayerGauche4","PlayerGauche4");
            AddTextures("Decors/world2vert" , "vert");
        }

        public void AddTextures(String file, String name = "") 
        {
            Texture2D newTexture = CM.Load<Texture2D>(file);
            if (name == "")
                Textures.Add(file, newTexture);
            else
                Textures.Add(name, newTexture);
        }
    }
}
