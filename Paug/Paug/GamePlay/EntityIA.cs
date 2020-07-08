//SYSTEM
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//EYESENGINE
using EyesEngine_XNA.GamePlay;
//XNA
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Paug.GamePlay
{
    enum Speed { level0, level1, level2, level3, level4, level5 };
    class EntityIA : EyesEntity
    {
        private Speed m_speedState;
        private int m_lastBallY;

        public EntityIA(ContentManager content)
        {
            this.initialized(content, "texture/sprite/RightRaquette", 682, 180, 79, 142, 100, 3, 0);
            m_animation = false;
            m_speedState = Speed.level1;
        }

        //UPDATE
        public void Update(int ballX, int ballY, int playerPoint)
        {
            ballY = ballY - (m_spriteHeight / 2);
            if (playerPoint == 3 && m_speedState == Speed.level0)
            {
                m_speed = m_speed + 3;
                m_speedState = Speed.level1;
            }

            if (playerPoint == 6 && m_speedState == Speed.level1)
            {
                m_speed = m_speed + 3;
                m_speedState = Speed.level2;
            }

            if (playerPoint == 9 && m_speedState == Speed.level2)
            {
                m_speed = m_speed + 3;
                m_speedState = Speed.level3;
            }

            if (playerPoint == 15 && m_speedState == Speed.level3)
            {
                m_speed = m_speed + 3;
                m_speedState = Speed.level4;
            }

            if (playerPoint == 18 && m_speedState == Speed.level4)
            {
                m_speed = m_speed + 2;
                m_speedState = Speed.level5;
            }

            //IA
            Random rndNumbers = new Random(unchecked((int)DateTime.Now.Ticks));
            if (ballY == m_lastBallY && ballX < m_x - 100)
            { }
            else if (m_y < ballY)
            {
                m_y = m_y + m_speed;

                if (rndNumbers.Next(0, 100) < 40 ) // Y+
                    m_y = m_y - m_speed + m_speed;
                else if (rndNumbers.Next(0, 100) > 60)
                    m_y = m_y - m_speed + m_speed;

            }
            else if (m_y > ballY)
            {
                m_y = m_y - m_speed;

                if (rndNumbers.Next(0, 100) < 40) // Y-
                    m_y = m_y + m_speed - m_speed;
                else if (rndNumbers.Next(0, 100) > 60)
                    m_y = m_y + m_speed - m_speed;
            }

            //Update
            if (m_y < 0)
                m_y = 0;
            else if (m_y > 480 - m_spriteHeight)
                m_y = 480 - m_spriteHeight;

            m_entity = new Rectangle(m_x, m_y, m_spriteWidth, m_spriteHeight);
            m_lastBallY = ballY;
        }

        //OTHER
        public void resetSpeed()
        {
            m_speed = 3;
            m_speedState = Speed.level1;
        }

            //GET
            public new int getX()
            {
                return m_x + 40;
            }

            public int getXWidth()
            {
                return m_x + 90;
            }

            public int getYHeight()
            {
                return m_y + m_spriteHeight;
            }

            public int getYPart1()
            {
                return m_y + 51;
            }

            public int getYPart2()
            {
                return m_y + 86;
            }
    }
}
