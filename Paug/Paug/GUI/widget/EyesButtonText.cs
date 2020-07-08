//SYSTEM
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//XNA
using Microsoft.Xna.Framework;
//ENGINE
using EyesEngine_XNA.GUI.widget;
using EyesEngine_XNA;
using EyesEngine_XNA.GUI;
using Microsoft.Xna.Framework.Graphics;


namespace Operation_Desert_Storm_Remake.GUI.widget
{
    class EyesButtonText : EyesButton
    {
        public EyesButtonText()
        { }

        public override void initialized(int x, int y, int width, int height, string text)
        {
            m_choose = false;
            m_text = text;

            m_x = x;
            m_y = y;

            m_width = width;
            m_height = height;

            m_collisionMouse = new EyesCollisionMouse(m_x, m_y, m_height, m_width);
            m_texturePos = new Rectangle(m_x, m_y, m_width, m_height / 2);
        }

        //DRAW
        public override void draw(SpriteBatch spriteBatch)
        {
            if (m_choose)
            {
                spriteBatch.DrawString(Resource.segoeFont, m_text, new Vector2(m_x, m_y), Color.Orange);
            }
            else
                spriteBatch.DrawString(Resource.segoeFont, m_text, new Vector2(m_x, m_y), Color.White);
        }
    }
}
