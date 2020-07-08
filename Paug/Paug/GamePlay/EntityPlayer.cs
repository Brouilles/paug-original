//SYSTEM
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//XNA
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
//EyesEngine
using EyesEngine_XNA.GUI;
using EyesEngine_XNA.Other;


namespace EyesEngine_XNA.GamePlay
{
    class EntityPlayer : EyesEntity
    {
        public EntityPlayer(ContentManager content)
        {
            this.initialized(content, "texture/sprite/LeftRaquette", 40, 180, 79, 142, 100, 3, 0);
            m_animation = false;
        }

        //UPDATE
        public override void Update(MouseState mouse, KeyboardState keyboard, GamePadState gamePad, GameTime gameTime)
        {
            base.Update(mouse, keyboard, gamePad, gameTime);

            if (m_y < 0)
                m_y = 0;
            else if (m_y > 480 - m_spriteHeight)
                m_y = 480 - m_spriteHeight;
        }

        //DRAW
        public override void draw(SpriteBatch spriteBatch)
        {
            base.draw(spriteBatch);
        }

        //METHODS
        public override void input(MouseState mouse, KeyboardState keyboard)
        {
            /** KEYBOARD **/
            if (keyboard.IsKeyDown(EyesOptionTreatment.keyUp)) //UP
            {
                m_y = m_y - m_speed;
            }

            else if (keyboard.IsKeyDown(EyesOptionTreatment.keyDown)) //Down
            {
                m_y = m_y + m_speed;
            }
        }

        public override void controller(GamePadState gamePad)
        {
            /** KEYBOARD **/
            if (gamePad.ThumbSticks.Left.Y > 0.0f) //UP
            {
                m_y = m_y - m_speed;
            }

            else if (gamePad.ThumbSticks.Left.Y < 0.0f) //Down
            {
                m_y = m_y + m_speed;
            }
        }

        //OTHER
            //GET
            public int getXWidth()
            {
                return m_x + m_spriteWidth + 20;
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
