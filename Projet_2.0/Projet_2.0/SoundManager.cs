using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;


namespace Projet_2._0
{

    static class SoundManager
    {
        static public SoundEffect jump;
        static public Song ingame;
        static public Song pause;
        static public Song menu;

        static public void LoadContent(ContentManager Content)
        {
            ingame = Content.Load<Song>("Songs/Ambiance_ingame");
            pause = Content.Load<Song>("Songs/Ambiance_Pause");
            menu = Content.Load<Song>("Songs/Ambiance");
            jump = Content.Load<SoundEffect>("Songs/Jump");
        }


    }
}
