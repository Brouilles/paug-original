//SYSTEM
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//XNA
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace EyesEngine_XNA.GUI.widget
{
    class EyesButton
    {
        protected EyesCollisionMouse m_collisionMouse;
        protected Rectangle m_texturePos;

        protected bool m_choose;
        protected int m_x, m_y, m_textX, m_textY;
        protected int m_height, m_width;
        protected string m_text;

        //CONSTRUCTOR
        public EyesButton()
        { }

        public virtual void initialized(int x, int y, int textX, int textY, string text)
        {
            m_choose = false;
            m_text = text;

            m_x = x;
            m_y = y;

            m_textX = textX + m_x;
            m_textY = textY + m_y;

            m_width = Resource.button.Width - 160;
            m_height = Resource.button.Height;

            m_collisionMouse = new EyesCollisionMouse(m_x, m_y, m_height / 2, m_width);
            m_texturePos = new Rectangle(m_x, m_y, m_width, m_height / 2);
        }

        //UPDATE
        public virtual void Update(MouseState mouse)
        {
            this.setChoose(false);
            m_collisionMouse.Update(mouse);

            if (m_collisionMouse.collision())
                this.setChoose(true);

        }

        public virtual void Update(bool choose)
        {
            this.setChoose(choose);
        }

        //DRAW
        public virtual void draw(SpriteBatch spriteBatch)
        {
            if (m_choose)
            {
                spriteBatch.Draw(Resource.button, m_texturePos, new Rectangle(0, m_height / 2, m_width, m_height / 2), Color.White);

                if (MainGame.input == inputType.Controller)
                    spriteBatch.Draw(Resource.xboxButtons, new Rectangle(m_x - 34, m_y, 34, 34), new Rectangle(0, 0, 128, 128), Color.White);
            }
            else
                spriteBatch.Draw(Resource.button, m_texturePos, new Rectangle(0, 0, m_width, m_height / 2), Color.White);

            spriteBatch.DrawString(Resource.segoeFont, m_text, new Vector2(m_textX, m_textY), Color.Black);
        }

        //OTHER
        //SET
        public void setPos(int x, int y) //X and Y
        {
            m_x = x;
            m_y = y;
        }

        public void setX(int x) //X
        {
            m_x = x;
        }

        public void setY(int y)//Y
        {
            m_y = y;
        }

        public void setPosText(int x, int y)
        {
            m_textX = x;
            m_textY = y;
        }

        public void setTextX(int x)
        {
            m_textX = x;
        }

        public void setTextY(int y)
        {
            m_textY = y;
        }

        public void setChoose(bool choose)
        {
            m_choose = choose;
        }

        public void setText(string text)
        {
            m_text = text;
        }

        //GET
        public int getX()
        {
            return m_x;
        }

        public int getY()
        {
            return m_y;
        }

        public int getTextX()
        {
            return m_textX;
        }

        public int getTextY()
        {
            return m_textY;
        }

        public bool getChoose()
        {
            return m_choose;
        }

        public string getText()
        {
            return m_text;
        }
    }
}
