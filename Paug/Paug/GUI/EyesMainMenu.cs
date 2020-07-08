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
using Paug.GUI.widget;

namespace EyesEngine_XNA.GUI
{
    class EyesMainMenu : MenuModel
    {
        private Texture2D m_backgroundMainMenu;
        private Texture2D m_gameLogo;

        private EyesButtonTexture m_play = new EyesButtonTexture();
        private EyesButtonTexture m_restart = new EyesButtonTexture();
        private EyesButtonTexture m_credit = new EyesButtonTexture();
        private EyesButtonTexture m_option = new EyesButtonTexture();
        private EyesButtonTexture m_quit = new EyesButtonTexture();

        //CONSTRUCTOR
        public EyesMainMenu(ContentManager content)
        {
            this.initialized();

            m_backgroundMainMenu = content.Load<Texture2D>("GUI/backgroundMainMenu");
            m_gameLogo = content.Load<Texture2D>("texture/gameLogo");

            m_play.initialized(content, 460, 180, "widget/menu/buttonStart");
            m_restart.initialized(content, 230, 260, "widget/menu/buttonRestart");
            m_credit.initialized(content, 325, 410, "widget/menu/buttonCredit");
            m_option.initialized(content, 10, 10, "widget/menu/buttonOption");
            m_quit.initialized(content, 550, 22, "widget/menu/buttonQuit");
        }

        //METHODS
        public override void MouseInput(MouseState mouse)
        {
            m_play.Update(mouse);
            m_restart.Update(mouse);
            m_credit.Update(mouse);
            m_option.Update(mouse);
            m_quit.Update(mouse);

            if (mouse.LeftButton == ButtonState.Pressed && m_play.getChoose())
            {
                MainGame.menuType = menuList.Game;
            }
            else if (mouse.LeftButton == ButtonState.Pressed && m_restart.getChoose())
            {
                MainGame.m_restart = true;
                MainGame.menuType = menuList.Game;
            }
            else if (mouse.LeftButton == ButtonState.Pressed && m_credit.getChoose())
            {
                MainGame.menuType = menuList.Credit;
            }
            else if (mouse.LeftButton == ButtonState.Pressed && m_option.getChoose())
            {
                MainGame.menuType = menuList.OptionMenu;
            }
            else if (mouse.LeftButton == ButtonState.Pressed && m_quit.getChoose())
            {
                Environment.Exit(0);
            }
        }

        public override void ControllerInput(GameTime gameTime, GamePadState gamePad)
        {
            m_enter = false;
            m_play.setChoose(false);
            m_restart.setChoose(false);
            m_credit.setChoose(false);
            m_quit.setChoose(false);

            if (gamePad.Buttons.A == ButtonState.Pressed)
                m_enter = true;

            if (gamePad.ThumbSticks.Left.Y > 0.0f && m_choose > 0)
                m_choose--;
            else if (gamePad.ThumbSticks.Left.Y < 0.0f && m_choose <= 2)
            {
                m_choose++;
            }

            //Change of button state
            if (m_choose == 0) //Quit
            {
                m_quit.Update(true);
                if (m_enter)
                    Environment.Exit(0);
            }
            else if (m_choose == 1) //Play
            {
                m_play.Update(true);
                if (m_enter)
                    MainGame.menuType = menuList.Game;
            }
            else if (m_choose == 2) //Restart
            {
                m_restart.Update(true);
                if (m_enter)
                {
                    MainGame.m_restart = true;
                    MainGame.menuType = menuList.Game;
                }
            }
            else if (m_choose == 3) //credit
            {
                m_credit.Update(true);
                if (m_enter)
                    MainGame.menuType = menuList.Credit;
            }
            m_timer = 0; //Reset Timer   
        }

        //DRAW
        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Resource.backgroundMenu, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(m_backgroundMainMenu, new Vector2(0, 0), Color.White);

            spriteBatch.Draw(m_gameLogo, new Vector2(0, 0), Color.White);

            m_play.draw(spriteBatch);
            m_restart.draw(spriteBatch);
            m_credit.draw(spriteBatch);
            m_option.draw(spriteBatch);
            m_quit.draw(spriteBatch);

            spriteBatch.DrawString(Resource.segoeFont, "Version 1.1.0.2", new Vector2(630, 456), Color.Black);
        }
    }
}
