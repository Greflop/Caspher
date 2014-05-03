using System;
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
            AddTextures("Decors/Background1", "Level1");
            AddTextures("Menu/Menu_Base", "menubase");
            AddTextures("Menu/Menu_Options", "menuoptions");
            AddTextures("Menu/Menu_Play", "menuplay");
            AddTextures("Menu/Menu_Play_Solo", "menusolo");
            AddTextures("Menu/Menu_Play_Solo_World1", "solo1");
            AddTextures("Menu/Menu_Play_Solo_World2", "solo2");
            AddTextures("Menu/Menu_Multi", "menumulti");
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
