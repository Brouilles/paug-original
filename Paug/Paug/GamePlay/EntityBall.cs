//SYSTEM
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//XNA
using Microsoft.Xna.Framework.Content;
//EYESENGINE
using EyesEngine_XNA.GamePlay;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Paug.GamePlay
{
    enum BallDirection { Left, LeftUp, LeftDown, Right, RightUp, RightDown };
    enum BallSpeed { level0, level1, level2, level3, level4 };

    class EntityBall : EyesEntity
    {
        private new Vector2 m_entity;

        private BallDirection m_direction;
        private BallSpeed m_ballSpeed;
        private bool m_pointPlayer;
        private bool m_pointIA;

        private double m_rotationAngle;
        private Vector2 m_origin;

        public EntityBall(ContentManager content)
        {
            this.initialized(content, "texture/sprite/ball", 384, 240, 64, 32, 100, 4, -60);
            m_entity = new Vector2((float)m_x, (float)m_y);
            m_direction = BallDirection.Left;
            m_ballSpeed = BallSpeed.level0;

            m_pointPlayer = false;
            m_pointIA = false;

            m_rotationAngle = 0;
            m_origin.X = m_spriteWidth / 2;
            m_origin.Y = m_spriteHeight / 2;
        }

        //UPDATE
        public void Update(int playerPoint, GameTime gameTime)
        {
            //Timer
            m_elapsed = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            m_timer = m_timer - (int)m_elapsed;

            //IA
            if (playerPoint == 3 && m_ballSpeed == BallSpeed.level0)
            {
                m_speed = m_speed + 2;
                m_ballSpeed = BallSpeed.level1;
            }

            if (playerPoint == 6 && m_ballSpeed == BallSpeed.level1)
            {
                m_speed = m_speed + 2;
                m_ballSpeed = BallSpeed.level2;
            }

            if (playerPoint == 9 && m_ballSpeed == BallSpeed.level2)
            {
                m_speed = m_speed + 2;
                m_ballSpeed = BallSpeed.level3;
            }

            if (playerPoint == 15 && m_ballSpeed == BallSpeed.level3)
            {
                m_speed = m_speed + 2;
                m_ballSpeed = BallSpeed.level4;
            }

            //COLLISION
                if (m_y < 0)
                {
                    if(m_direction == BallDirection.Left || m_direction == BallDirection.LeftUp)
                        m_direction = BallDirection.LeftDown;
                    else if(m_direction == BallDirection.Right || m_direction == BallDirection.RightUp)
                        m_direction = BallDirection.RightDown;
                }
                else if (m_y > 480 - m_spriteHeight)
                {
                    if (m_direction == BallDirection.Left || m_direction == BallDirection.LeftDown)
                        m_direction = BallDirection.LeftUp;
                    else if (m_direction == BallDirection.Right || m_direction == BallDirection.RightDown)
                        m_direction = BallDirection.RightUp;
                }

                if (m_x < 0)
                    m_pointIA = true;
                else if (m_x > 800 - m_spriteWidth)
                    m_pointPlayer = true;
            
            //Move
                if (m_direction == BallDirection.Left)  //LEFT
                {
                    m_x = m_x - m_speed - 2;
                    m_rotationAngle = MathHelper.ToRadians(0);
                }
                else if (m_direction == BallDirection.LeftDown)
                {
                    m_x = m_x - m_speed;
                    m_y = m_y + m_speed;
                    m_rotationAngle = MathHelper.ToRadians(315);
                }
                else if (m_direction == BallDirection.LeftUp)
                {
                    m_x = m_x - m_speed;
                    m_y = m_y - m_speed;
                    m_rotationAngle = MathHelper.ToRadians(45);
                }
                else if (m_direction == BallDirection.Right)    //RIGHT
                {
                    m_x = m_x + m_speed + 2;
                    m_rotationAngle = MathHelper.ToRadians(180);
                }
                else if (m_direction == BallDirection.RightDown)
                {
                    m_x = m_x + m_speed;
                    m_y = m_y + m_speed;
                    m_rotationAngle = MathHelper.ToRadians(225);
                }
                else if (m_direction == BallDirection.RightUp)
                {
                    m_x = m_x + m_speed;
                    m_y = m_y - m_speed;
                    m_rotationAngle = MathHelper.ToRadians(135);
                }

            this.animation();
            m_entity = new Vector2((float)m_x, (float)m_y);
        }

        //METHOD
        public override void animation()
        {
            if (m_timer <= m_animSpeed)
            {
                m_timer = 0;
                if (m_animation)
                {
                    m_frameColumn++;
                    if (m_frameColumn > 2)
                    {
                        m_frameColumn--;
                        m_animation = false;
                    }
                }
                else
                {
                    m_frameColumn--;
                    if (m_frameColumn < 0)
                    {
                        m_frameColumn++;
                        m_animation = true;
                    }
                }
            }
        }

        //DRAW
        public override void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(m_entityTexture, m_entity, new Rectangle((m_frameColumn * m_spriteWidth), 0, m_spriteWidth, m_spriteHeight), Color.White, (float)m_rotationAngle, m_origin, 1.0f, SpriteEffects.None, 0f);
        }

        //OTHER
        public void resetSpeed()
        {
            m_speed = 4;
        }

            public bool getPointPlayer()
            {
                return m_pointPlayer;
            }

            public bool getPointIA()
            {
                return m_pointIA;
            }

            public BallDirection getDirection()
            {
                return m_direction;
            }

            public int getXWidth()
            {
                return m_x + m_spriteWidth;
            }

            public int getYHeight()
            {
                return m_y + m_spriteHeight;
            }

            //SET
            public void setPointPlayer(bool value)
            {
                m_pointPlayer = value;
            }

            public void setPointIA(bool value)
            {
                m_pointIA = value;
            }

            public void setDirection(BallDirection direction)
            {
                m_direction = direction;
            }
    }
}
