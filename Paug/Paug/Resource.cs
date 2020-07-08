//System
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//XNA
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace EyesEngine_XNA
{
    class Resource
    {
        //TEXTURE
        public static Texture2D xboxButtons;
        public static Texture2D backgroundMenu;

        public static SpriteFont segoeFont;
        public static SpriteFont segoeFontBig;

        //Widget
        public static Texture2D button;
        public static Texture2D slider;
        public static Texture2D input;

        //LOAD CONTENT
        public static void loadContent(ContentManager content)
        {
            Console.WriteLine("-Resource Load: in progress");

            xboxButtons = content.Load<Texture2D>("widget/xbox360_buttons");
            Console.WriteLine("--->xboxButtons Load: Check");

            backgroundMenu = content.Load<Texture2D>("texture/background");
            Console.WriteLine("--->backgroundMenu Load: Check");

            segoeFont = content.Load<SpriteFont>("font/Segoe");
            Console.WriteLine("--->segoeFont Load: Check");

            segoeFontBig = content.Load<SpriteFont>("font/SegoeBig");
            Console.WriteLine("--->segoeFontBig Load: Check");

            //Widget
            button = content.Load<Texture2D>("widget/button");
            Console.WriteLine("--->Gui Button Load: Check");

            slider = content.Load<Texture2D>("widget/slider");
            Console.WriteLine("--->Gui Slider Load: Check");

            input = content.Load<Texture2D>("widget/input");
            Console.WriteLine("--->Gui input Load: Check");
        }
    }
}
