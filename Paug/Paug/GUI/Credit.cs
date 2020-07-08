//SYSTEM
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//XNA
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

//GUI
using EyesEngine_XNA.GUI.widget;
using Microsoft.Xna.Framework.Content;
using Operation_Desert_Storm_Remake.GUI.widget;

namespace EyesEngine_XNA.GUI
{
    class Credit : MenuModel
    {
        private Texture2D m_gameLogo;

        //CONSTRUCTOR
        public Credit(ContentManager content)
        {
            this.initialized();

            m_gameLogo = content.Load<Texture2D>("texture/gameLogo");
        }

        //UPDATE
        public new void Update(GameTime gameTime, MouseState mouse, KeyboardState keyboard, GamePadState gamePad)
        {
            m_enter = false;

            base.Update(gameTime, mouse, keyboard, gamePad);

            if (keyboard.IsKeyDown(Keys.Enter) || keyboard.IsKeyDown(Keys.Escape) || gamePad.Buttons.Y == ButtonState.Pressed)
                m_enter = true;

            if (m_enter == true)
                MainGame.menuType = menuList.MainMenu;
        }

        //DRAW
        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Resource.backgroundMenu, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(m_gameLogo, new Vector2(0, 0), Color.White);

            spriteBatch.DrawString(Resource.segoeFont, "Push Escape", new Vector2(10, 0), Color.Black);

            if (MainGame.input == inputType.Controller) //GamePad verification
                spriteBatch.Draw(Resource.xboxButtons, new Rectangle(134, 0, 34, 34), new Rectangle(384, 0, 128, 128), Color.White);

            //Team Aubega
            spriteBatch.DrawString(Resource.segoeFont, "Team:", new Vector2(30, 160+30), Color.Black);
            spriteBatch.DrawString(Resource.segoeFont, "Lynni Happy : lead graphic artist", new Vector2(40, 190+30), Color.Black); //Lynni
            spriteBatch.DrawString(Resource.segoeFont, "Skigen : graphic artist", new Vector2(40, 210 + 30), Color.Black); //Skigen
            spriteBatch.DrawString(Resource.segoeFont, "Gaëtan Dezeiraud : programmer", new Vector2(40, 230 +30), Color.Black); //Brouilles

            spriteBatch.DrawString(Resource.segoeFont, "Music:", new Vector2(30, 260 + 30), Color.Black);
            spriteBatch.DrawString(Resource.segoeFont, "TheSoulScream : Author, musique name: DuckTales2 Egypt (Remake)", new Vector2(40, 290 + 30), Color.Black); //Lynni

            spriteBatch.DrawString(Resource.segoeFont, "© 2013 Aubega, © 2019 Exoway, All rights reserved.", new Vector2(20, 445), Color.Black);
        }
    }
}
