using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyesEngine_XNA.GUI.widget;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using EyesEngine_XNA;

namespace Paug.GUI
{
    class EndScreen : MenuModel
    {
        private Texture2D m_background;
        private Texture2D m_footer;

        private EyesButton m_returnMenu = new EyesButton();

        public EndScreen(ContentManager content)
        {
            this.initialized();

            m_background = content.Load<Texture2D>("GUI/endBackground");
            m_footer = content.Load<Texture2D>("GUI/HeaderBackground");

            m_returnMenu.initialized(30, 360, 10, 10, "Return in Main Menu");
        }

        //METHODS
        public override void MouseInput(MouseState mouse)
        {
            m_returnMenu.Update(mouse);

            if (mouse.LeftButton == ButtonState.Pressed && m_returnMenu.getChoose())
            {
                MainGame.m_restart = true;
                MainGame.menuType = menuList.MainMenu;
            }
        }

        public override void ControllerInput(GameTime gameTime, GamePadState gamePad)
        {
            m_enter = false;
            m_returnMenu.setChoose(false);
            m_choose = 0;

            if (gamePad.Buttons.A == ButtonState.Pressed)
                m_enter = true;

            //Change of button state
            else if (m_choose == 0)
            {
                m_returnMenu.Update(true);
                if (m_enter)
                {
                    MainGame.m_restart = true;
                    MainGame.menuType = menuList.MainMenu;
                }
            }
            m_timer = 0; //Reset Timer   
        }
        //DRAW
        public void draw(SpriteBatch spriteBatch, bool win)
        {
            spriteBatch.Draw(m_background, new Vector2(0, 0), Color.White);
            if(win)
                spriteBatch.DrawString(Resource.segoeFontBig, "You won !", new Vector2(30, 30), Color.White);
            else
                spriteBatch.DrawString(Resource.segoeFontBig, "You Lost !     :(", new Vector2(30, 30), Color.White);

            spriteBatch.DrawString(Resource.segoeFont, "Thank you for playing.", new Vector2(30, 100), Color.White);

            for (int loop = 0; loop < 13; loop++)
            {
                spriteBatch.Draw(m_footer, new Vector2(loop * 64, 416), Color.White);
            }

            m_returnMenu.draw(spriteBatch);
        }
    }
}
