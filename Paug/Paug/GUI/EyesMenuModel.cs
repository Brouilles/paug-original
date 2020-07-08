//SYSTEM
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//XNA
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace EyesEngine_XNA.GUI.widget
{
    class MenuModel
    {
        protected float m_elapsed; //Timer
        protected int m_timer;

        protected int m_choose;
        protected bool m_enter;

        //CONSTRUCTOR
        public MenuModel()
        { }

        public void initialized()
        {
            m_choose = 1;
        }
        //UPDATE
        public void Update(GameTime gameTime, MouseState mouse, KeyboardState keyboard, GamePadState gamePad)
        {
            m_elapsed = (float)gameTime.ElapsedGameTime.TotalMilliseconds; //Timer
            m_timer = m_timer - (int)m_elapsed;

            if (MainGame.input == inputType.Pc)
            {
                this.MouseInput(mouse);
                if (m_timer <= -90)
                {
                    this.KeyBoardInput(gameTime, keyboard);
                    m_timer = 0; //Reset Timer
                }
            }
            else if (MainGame.input == inputType.Controller)
            {
                if (m_timer <= -90)
                {
                    this.ControllerInput(gameTime, gamePad);
                    m_timer = 0; //Reset Timer
                }
            }
        }

        //METHODS
        public virtual void MouseInput(MouseState mouse)
        {

        }

        public virtual void KeyBoardInput(GameTime gameTime, KeyboardState keyboard)
        {

        }

        public virtual void ControllerInput(GameTime gameTime, GamePadState gamePad)
        {

        }
    }
}
