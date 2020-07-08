//SYSTEM
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//XNA
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
//EYESENGINE
using EyesEngine_XNA.GUI.widget;

namespace EyesEngine_XNA.GUI
{
    class EyesInGameMenu : MenuModel
    {
        private EyesButton m_returnGame = new EyesButton();
        private EyesButton m_returnMenu = new EyesButton();

        //CONSTRUCTOR
        public EyesInGameMenu()
        {
            m_returnGame.initialized(230, 180, 10, 10, "Return in game");
            m_returnMenu.initialized(230, 220, 10, 10, "Return in Menu");
        }

        //METHODS
        public override void MouseInput(MouseState mouse)
        {
            m_returnGame.Update(mouse);
            m_returnMenu.Update(mouse);

            if (mouse.LeftButton == ButtonState.Pressed && m_returnGame.getChoose())
            {
                MainGame.menuType = menuList.Game;
            }
            else if (mouse.LeftButton == ButtonState.Pressed && m_returnMenu.getChoose())
            {
                MainGame.menuType = menuList.MainMenu;
            }
        }

        public override void ControllerInput(GameTime gameTime, GamePadState gamePad)
        {
            m_enter = false;
            m_returnGame.setChoose(false);
            m_returnMenu.setChoose(false);

            if (gamePad.Buttons.A == ButtonState.Pressed)
                m_enter = true;

            if (gamePad.ThumbSticks.Left.Y > 0.0f && m_choose > 0)
                m_choose--;
            else if (gamePad.ThumbSticks.Left.Y < 0.0f && m_choose <= 0)
            {
                m_choose++;
            }

            //Change of button state
            if (m_choose == 0)
            {
                m_returnGame.Update(true);
                if (m_enter)
                    MainGame.menuType = menuList.Game;
            }
            else if (m_choose == 1)
            {
                m_returnMenu.Update(true);
                if (m_enter)
                    MainGame.menuType = menuList.MainMenu;
            }
            m_timer = 0; //Reset Timer   
        }

        //DRAW
        public void draw(SpriteBatch spriteBatch)
        {
            m_returnGame.draw(spriteBatch);
            m_returnMenu.draw(spriteBatch);
        }
    }
}
