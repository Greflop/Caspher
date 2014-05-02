﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

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