//SYSTEM
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//XNA
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EyesEngine_XNA.Other;

namespace EyesEngine_XNA.GUI.widget
{
    class EyesInput : EyesButton
    {
        protected bool m_selected;
        protected string m_afterInputEnter;
        protected string m_inputEnter;

        public EyesInput()
        { }

        public void initialized(int x, int y, int textX, int textY, string text, string input)
        {
            m_text = text;
            m_afterInputEnter = input;
            m_inputEnter = input;

            m_x = x;
            m_y = y;

            m_textX = textX;
            m_textY = textY;

            m_width = Resource.input.Width;
            m_height = Resource.input.Height;

            m_collisionMouse = new EyesCollisionMouse(m_x, m_y, m_height / 3, m_width);
            m_texturePos = new Rectangle(m_x, m_y, m_width, m_height / 3);
        }

        //UPDATE
        public void Update(MouseState mouse, KeyboardState keyBoard)
        {
            this.setChoose(false);
            m_collisionMouse.Update(mouse);

            if (m_collisionMouse.collision())
            {
                this.setChoose(true);

                if (mouse.LeftButton == ButtonState.Pressed && m_selected == false)
                    m_selected = true;
            }
            else
            {
                if (m_selected)
                {
                    Keys[] pressedKeys = keyBoard.GetPressedKeys();     //BUG 

                    if (pressedKeys.GetLongLength(0) != 0)
                    {
                        m_inputEnter = pressedKeys[0].ToString();
                        if (m_inputEnter != m_afterInputEnter)
                        {
                            m_afterInputEnter = m_inputEnter;
                            m_selected = false;
                        }
                    }
                }
            }
        }
        //DRAW
        public override void draw(SpriteBatch spriteBatch)
        {
            if (m_selected)
                spriteBatch.Draw(Resource.input, m_texturePos, new Rectangle(0, ((m_height / 3) + (m_height / 3)), m_width, m_height / 3), Color.White);
            else if (m_choose)
            {
                spriteBatch.Draw(Resource.input, m_texturePos, new Rectangle(0, (m_height / 3), m_width, m_height / 3), Color.White);

                if (MainGame.input == inputType.Controller)
                    spriteBatch.Draw(Resource.xboxButtons, new Rectangle(m_x - 34, m_y, 34, 34), new Rectangle(0, 0, 128, 128), Color.White);
            }
            else
                spriteBatch.Draw(Resource.input, m_texturePos, new Rectangle(0, 0, m_width, m_height / 3), Color.White);

            spriteBatch.DrawString(Resource.segoeFont, m_inputEnter, new Vector2(m_x + 10, m_textY + 3), Color.Black);
            spriteBatch.DrawString(Resource.segoeFont, m_text, new Vector2(m_textX, m_textY), Color.Black);
        }

        //Other
        //Get
        public string getInput()
        {
            return m_inputEnter;
        }
    }
}
