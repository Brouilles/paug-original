//SYSTEM
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//XNA
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace EyesEngine_XNA.GUI.widget
{
    class EyesSlider : EyesButton
    {
        protected Rectangle m_texturePosButton;
        protected int m_xButton;
        protected int m_yButton;
        protected bool m_selected;
        protected float m_value;

        protected int m_percentageValue;

        //CONSTRUCTOR
        public EyesSlider()
        { }

        public void initialized(int x, int y, int textX, int textY, string text, double percentage)
        {
            m_choose = false;
            m_selected = false;
            m_text = text;

            m_x = x;
            m_y = y;

            m_textX = textX;
            m_textY = textY;

            m_width = 454;
            m_height = Resource.button.Height;

            this.setPercentage(percentage); // m_xButton value
            m_yButton = m_y;

            m_collisionMouse = new EyesCollisionMouse(m_xButton, m_yButton, m_height / 2, 11);
            m_texturePosButton = new Rectangle(m_xButton, m_yButton, 11, m_height / 2);
            m_texturePos = new Rectangle(m_x, m_y, m_width, m_height / 2);
        }

        //METHODS
        public void calculate()
        {
            if (m_xButton != 0)
                m_percentageValue = 100 * (m_xButton - m_x) / m_width;

            if (m_percentageValue < 0)
                m_percentageValue = 0;
            else if (m_percentageValue > m_width)
                m_percentageValue = 100;

            m_value = m_percentageValue / 100f;
        }

        //UPDATE
        public override void Update(MouseState mouse)
        {
            this.calculate();
            m_collisionMouse.Update(mouse);

            if (m_collisionMouse.collision())
                this.setChoose(true);
            else
                this.setChoose(false);

            if (m_choose)
                m_selected = true;

            if (mouse.LeftButton == ButtonState.Pressed && m_selected)
            {
                if (mouse.X > m_x + m_width + 1)
                {
                    m_xButton = m_x + m_width;
                }
                else if (mouse.X < m_x - 1)
                {
                    m_xButton = m_x;
                }
                else
                {
                    m_xButton = mouse.X - 5;
                    m_collisionMouse = new EyesCollisionMouse(m_xButton, m_yButton, m_height / 2, 11);
                    m_texturePosButton = new Rectangle(m_xButton, m_yButton, 11, m_height / 2);
                }
            }
            else if (mouse.LeftButton == ButtonState.Released)
            {
                m_selected = false;
                this.setChoose(false);
            }
        }

        public override void Update(bool choose)
        {
            this.setChoose(choose);
        }

        //DRAW
        public override void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Resource.slider, m_texturePos, new Rectangle(0, 0, m_width, m_height), Color.White);

            if (m_selected)
                spriteBatch.Draw(Resource.slider, m_texturePosButton, new Rectangle(m_width + 12, 0, 11, m_height), Color.White);
            else
                spriteBatch.Draw(Resource.slider, m_texturePosButton, new Rectangle(m_width, 0, 11, m_height), Color.White);

            spriteBatch.DrawString(Resource.segoeFont, m_text, new Vector2(m_textX, m_textY), Color.Black);
            spriteBatch.DrawString(Resource.segoeFont, m_percentageValue + "%", new Vector2((m_width + m_x + 10), m_y), Color.Black);
        }

        //Other
        //GET
        public float getValue()
        {
            return m_value;
        }

        //Set
        public void setValue(float value)
        {
            m_value = value;
        }

        public void setPercentage(double percentage)
        {
            percentage = Math.Round(percentage, 2) + 0.01;

            m_percentageValue = (int)(percentage * 100);
            m_xButton = (int)(m_x + (percentage * m_width));
        }
    }
}
