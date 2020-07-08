//System
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//XNA
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace EyesEngine_XNA.GamePlay
{
    class EyesEntity
    {
        //Timer
        protected float m_elapsed;
        protected int m_timer;

        //Entity
        protected Rectangle m_entity;
        protected Texture2D m_entityTexture;

        protected int m_frameLine;
        protected int m_frameColumn;

        protected int m_x, m_y;
        protected int m_spriteHeight, m_spriteWidth;
        protected int m_life;
        protected int m_speed;

        protected int m_animSpeed;
        protected bool m_animation;

        protected bool m_hurt;

        //CONSTRUCTOR
        public EyesEntity()
        { }

        public virtual void initialized(ContentManager content, string texturePos, int x, int y, int w, int h, int life, int speed, int animSpeed)
        {
            m_x = x;
            m_y = y;

            m_spriteWidth = w;
            m_spriteHeight = h;

            m_frameLine = 0;
            m_frameColumn = 1;

            m_life = life;
            m_speed = speed;
            m_hurt = false;

            m_animSpeed = animSpeed;
            m_animation = true;

            m_entity = new Rectangle(m_x, m_y, m_spriteWidth, m_spriteHeight);
            m_entityTexture = content.Load<Texture2D>(texturePos);
        }

        //METHOD
        public virtual void animation()
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

        public virtual void input(MouseState mouse, KeyboardState keyboard)
        { }

        public virtual void controller(GamePadState gamePad)
        { }

        //UPDATE
        public virtual void Update(MouseState mouse, KeyboardState keyboard, GamePadState gamePad, GameTime gameTime)
        {
            //Timer
            m_elapsed = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            m_timer = m_timer - (int)m_elapsed;

            m_entity = new Rectangle(m_x, m_y, m_spriteWidth, m_spriteHeight);

            if (MainGame.input == inputType.Pc)
            {
                this.input(mouse, keyboard);
            }
            else if (MainGame.input == inputType.Controller)
            {
                this.controller(gamePad);
            }
        }

        //DRAW
        public virtual void draw(SpriteBatch spriteBatch)
        {
            if (m_hurt)
            {
                spriteBatch.Draw(m_entityTexture, m_entity, new Rectangle((m_frameColumn * 25), (m_frameLine * 27), m_spriteWidth, m_spriteHeight), Color.Red);
                m_hurt = false;
            }
            else
            {
                if(m_animation == true)
                    spriteBatch.Draw(m_entityTexture, m_entity, new Rectangle((m_frameColumn * 25), (m_frameLine * 27), m_spriteWidth, m_spriteHeight), Color.White);
                else
                    spriteBatch.Draw(m_entityTexture, m_entity, Color.White);
            }
        }

        //OTHER
        //SET
        public void setPos(int x, int y) //X and Y
        {
            m_x = x;
            m_y = y;
        }

        public void setSpeed(int speed)
        {
            m_speed = speed;
        }

        public void setX(int x) //X
        {
            m_x = x;
        }

        public void setY(int y)//Y
        {
            m_y = y;
        }

        public void setLife(int life)//LIFE
        {
            m_life = life;
        }

        public void setHurt(bool hurt)
        {
            m_hurt = hurt;
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

        public int getH()
        {
            return m_spriteHeight;
        }

        public int getW()
        {
            return m_spriteWidth;
        }

        public int getLife()
        {
            return m_life;
        }
    }
}
