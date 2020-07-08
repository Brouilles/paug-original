//SYSTEM
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//XNA
using Microsoft.Xna.Framework.Input;

namespace EyesEngine_XNA.GUI
{
    class EyesCollisionMouse
    {
        private float m_entityX, m_entityY;
        private float m_entityH, m_entityW;

        private float m_MouseX, m_MouseY;

        //CONSTRUCTOR
        public EyesCollisionMouse(float entityX, float entityY, float entityH, float entityW)
        {
            m_entityX = entityX;
            m_entityY = entityY;

            m_entityH = entityH;
            m_entityW = entityW;
        }

        //METHODS   
        public bool collision()
        {
            if (m_MouseX > m_entityX && m_MouseX < m_entityX + m_entityW && m_MouseY > m_entityY && m_MouseY < m_entityY + m_entityH)
                return true;
            else
                return false;
        }

        //UPDATE
        public void Update(MouseState mouse)
        {
            m_MouseX = mouse.X;
            m_MouseY = mouse.Y;
        }
    }
}
