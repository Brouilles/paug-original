//SYSTEM
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//EYESENGINE
using EyesEngine_XNA.GUI.widget;
using EyesEngine_XNA.GUI;
//XNA
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using EyesEngine_XNA;

namespace Paug.GUI.widget
{
    class EyesButtonTexture : EyesButton
    {
        private Texture2D m_buttonTexture;

        public virtual void initialized(ContentManager content, int x, int y, string texturePos)
        {
            m_choose = false;

            m_x = x;
            m_y = y;

            m_buttonTexture = content.Load<Texture2D>(texturePos);

            m_width = m_buttonTexture.Width;
            m_height = m_buttonTexture.Height / 2;

            m_collisionMouse = new EyesCollisionMouse(m_x, m_y, m_height, m_width);
            m_texturePos = new Rectangle(m_x, m_y, m_width, m_height);
        }

        //DRAW
        public override void draw(SpriteBatch spriteBatch)
        {
            if (m_choose)
            {
                spriteBatch.Draw(m_buttonTexture, m_texturePos, new Rectangle(0, m_height, m_width, m_height), Color.White);

                if (MainGame.input == inputType.Controller)
                    spriteBatch.Draw(Resource.xboxButtons, new Rectangle(m_x - 34, m_y, 34, 34), new Rectangle(0, 0, 128, 128), Color.White);
            }
            else
                spriteBatch.Draw(m_buttonTexture, m_texturePos, new Rectangle(0, 0, m_width, m_height), Color.White);
        }
    }
}
