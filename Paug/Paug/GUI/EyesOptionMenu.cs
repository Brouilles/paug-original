//SYSTEM
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//XNA
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
//EYESENGINE
using EyesEngine_XNA.GUI.widget;
using EyesEngine_XNA.Other;

namespace EyesEngine_XNA.GUI
{
    class EyesOptionMenu : MenuModel
    {
        private EyesOptionTreatment m_optionTreatment = new EyesOptionTreatment("Content/option.txt");

        private EyesSlider m_volume = new EyesSlider();

        private EyesInput m_inputUp = new EyesInput();
        private EyesInput m_inputDown = new EyesInput();

        private EyesButton m_saveOption = new EyesButton();
        private EyesButton m_return = new EyesButton();

        //CONSTRUCTOR
        public EyesOptionMenu()
        {
            m_optionTreatment.load();
            Console.WriteLine("-Option Load: Check");

            m_volume.initialized(100, 100, 10, 100, "Volume:", EyesOptionTreatment.soundVolume);
            m_volume.setValue(EyesOptionTreatment.soundVolume);

            m_inputUp.initialized(100, 160, 75, 165, "Up", Convert.ToString(EyesOptionTreatment.keyUp));
            m_inputDown.initialized(300, 160, 250, 165, "Down", Convert.ToString(EyesOptionTreatment.keyDown));

            m_saveOption.initialized(60, 360, 10, 10, "Save");
            m_return.initialized(430, 360, 10, 10, "Return");
        }

        //UPDATE
        public new void Update(GameTime gameTime, MouseState mouse, KeyboardState keyboard, GamePadState gamePad)
        {
            m_elapsed = (float)gameTime.ElapsedGameTime.TotalMilliseconds; //Timer
            m_timer = m_timer - (int)m_elapsed;

            if (MainGame.input == inputType.Pc)
            {
                this.MouseInput(mouse, keyboard);
                if (m_timer <= -90)
                {
                    this.KeyBoardInput(gameTime, keyboard);
                    m_timer = 0; //Reset Timer
                }
            }
        }

        public void MouseInput(MouseState mouse, KeyboardState keyBoard)
        {
            m_volume.Update(mouse);

            m_inputUp.Update(mouse, keyBoard);
            m_inputDown.Update(mouse, keyBoard);

            m_saveOption.Update(mouse);
            m_return.Update(mouse);

            if (mouse.LeftButton == ButtonState.Pressed && m_saveOption.getChoose())
            {
                m_optionTreatment.save(m_volume.getValue(), Convert.ToChar(m_inputUp.getInput()), Convert.ToChar(m_inputDown.getInput()), Convert.ToChar("Q"), Convert.ToChar("D"));
                MainGame.menuType = menuList.MainMenu;
            }
            else if (mouse.LeftButton == ButtonState.Pressed && m_return.getChoose())
            {
                MainGame.menuType = menuList.MainMenu;
            }
        }

        //DRAW
        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Resource.backgroundMenu, new Vector2(0, 0), Color.White);
            m_volume.draw(spriteBatch);

            m_inputUp.draw(spriteBatch);
            m_inputDown.draw(spriteBatch);

            m_saveOption.draw(spriteBatch);
            m_return.draw(spriteBatch);
        }
    }


}
