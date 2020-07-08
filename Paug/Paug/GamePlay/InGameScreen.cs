//SYSTEM
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//XNA
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
//EYESENGINE
using EyesEngine_XNA.GUI;
using Microsoft.Xna.Framework.Content;
//PAUG
using Paug.GamePlay;
using Paug.GUI;

namespace EyesEngine_XNA.GamePlay
{
    class InGameScreen
    {
        private EyesInGameMenu m_inGameMenu;
        private EndScreen m_EndScreen;

        private EntityPlayer m_player;
        private EyesMapLoader m_map;

        //Game
        private EntityIA m_IA;
        private EntityBall m_ball;

        private int m_playerPoint;
        private int m_IAPoint;

        private bool m_playerWon;

        //CONSTRUCTOR
        public InGameScreen(ContentManager content, EntityPlayer player, EyesMapLoader map)
        {
            m_inGameMenu = new EyesInGameMenu();
            m_EndScreen = new EndScreen(content);
            m_player = player;
            m_map = map;

            m_IA = new EntityIA(content);
            m_ball = new EntityBall(content);

            m_playerPoint = 0;
            m_IAPoint = 0;

            m_playerWon = false;
        }

        //UPDATE
        public void Update(GameTime gameTime, MouseState mouse, KeyboardState keyboard, GamePadState gamePad)
        {
            if (MainGame.menuType == menuList.Game) //In Game
            {
                m_player.Update(mouse, keyboard, gamePad, gameTime);
                m_IA.Update(m_ball.getX(), m_ball.getY(), m_playerPoint);
                m_ball.Update(m_playerPoint, gameTime);
                m_map.playMusic();

                if (m_playerPoint == 12 || m_IAPoint == 12)
                    m_player.setSpeed(4);

                //COLLISION
                Random rndNumber = new Random(unchecked((int)DateTime.Now.Ticks));
                    //PLAYER
                    if (m_ball.getX() > m_player.getX() && m_ball.getX() < m_player.getXWidth() && m_ball.getYHeight() > m_player.getY() && m_ball.getY() < m_player.getYPart1())
                    {
                        if (rndNumber.Next(0, 100) <= 70)
                                m_ball.setDirection(BallDirection.RightUp);
                        else
                            m_ball.setDirection(BallDirection.Right);
                    }
                    else if (m_ball.getX() > m_player.getX() && m_ball.getX() < m_player.getXWidth() && m_ball.getYHeight() > m_player.getYPart1() && m_ball.getY() < m_player.getYPart2())
                    {
                        if (rndNumber.Next(0, 100) <= 70)
                            m_ball.setDirection(BallDirection.Right);
                        else if (rndNumber.Next(0, 100) > 70 && rndNumber.Next(0, 100) < 85)
                            m_ball.setDirection(BallDirection.RightDown);
                        else 
                            m_ball.setDirection(BallDirection.RightUp);
                    }
                    else if (m_ball.getX() > m_player.getX() && m_ball.getX() < m_player.getXWidth() && m_ball.getYHeight() > m_player.getYPart2() && m_ball.getY() < m_player.getYHeight())
                    {
                        if (rndNumber.Next(0, 100) < 70)
                            m_ball.setDirection(BallDirection.RightDown);
                        else
                            m_ball.setDirection(BallDirection.Right);
                    }

                        //IA
                    if (m_ball.getXWidth() > m_IA.getX() && m_ball.getXWidth() < m_IA.getXWidth() && m_ball.getYHeight() > m_IA.getY() && m_ball.getY() < m_IA.getYPart1())
                    {
                        if (rndNumber.Next(0, 100) <= 70)
                            m_ball.setDirection(BallDirection.LeftUp);
                        else
                            m_ball.setDirection(BallDirection.Left);
                    }
                    else if (m_ball.getXWidth() > m_IA.getX() && m_ball.getXWidth() < m_IA.getXWidth() && m_ball.getYHeight() > m_IA.getYPart1() && m_ball.getY() < m_IA.getYPart2())
                    {
                        if (rndNumber.Next(0, 100) <= 70)
                            m_ball.setDirection(BallDirection.Left);
                        else if (rndNumber.Next(0, 100) > 70 && rndNumber.Next(0, 100) < 85)
                            m_ball.setDirection(BallDirection.LeftDown);
                        else
                            m_ball.setDirection(BallDirection.LeftUp);
                    }
                    else if (m_ball.getXWidth() > m_IA.getX() && m_ball.getXWidth() < m_IA.getXWidth() && m_ball.getYHeight() > m_IA.getYPart2() && m_ball.getY() < m_IA.getYHeight())
                    {
                        if (rndNumber.Next(0, 100) < 70)
                            m_ball.setDirection(BallDirection.LeftDown);
                        else
                            m_ball.setDirection(BallDirection.Left);
                    }

                //POINT
                if (m_ball.getPointPlayer() == true)
                {
                    m_playerPoint++;
                    m_ball.setPos(384, 240);
                    m_ball.setPointPlayer(false);

                    m_ball.setDirection(BallDirection.Right);
                }
                else if (m_ball.getPointIA() == true)
                {
                    m_IAPoint++;
                    m_ball.setPos(384, 240);
                    m_ball.setPointIA(false);

                    m_ball.setDirection(BallDirection.Left);
                }

                if (m_playerPoint == 20)
                {
                    MainGame.menuType = menuList.GameEnd;
                    m_playerWon = true;
                }
                else if (m_IAPoint == 20)
                {
                    MainGame.menuType = menuList.GameEnd;
                    m_playerWon = false;
                }
            }

            if (MainGame.menuType == menuList.InGameMenu) //Game Menu 
            {
                m_inGameMenu.Update(gameTime, mouse, keyboard, gamePad);
            }

            if (MainGame.menuType == menuList.GameEnd) //Game End
            {
                m_EndScreen.Update(gameTime, mouse, keyboard, gamePad);
            }

            //InGame Input
            if (MainGame.input == inputType.Pc)
            {
                this.KeyBoardInput(gameTime, keyboard);
            }
            else if (MainGame.input == inputType.Controller)
            {
                this.ControllerInput(gameTime, gamePad);
            }
        }

        //Input
        public void KeyBoardInput(GameTime gameTime, KeyboardState keyboard)
        {
            if (keyboard.IsKeyDown(Keys.Escape) && MainGame.menuType == menuList.Game) //ESCAPE
            {
                m_map.stopMusic();
                MainGame.menuType = menuList.InGameMenu;
            }
        }

        public void ControllerInput(GameTime gameTime, GamePadState gamePad)
        {
            if (gamePad.Buttons.Start == ButtonState.Pressed && MainGame.menuType == menuList.Game) //ESCAPE
            {
                m_map.stopMusic();
                MainGame.menuType = menuList.InGameMenu;
            }
        }

        //DRAW
        public void draw(SpriteBatch spriteBatch)
        {
            m_map.draw(spriteBatch);
            m_player.draw(spriteBatch);
            m_IA.draw(spriteBatch);
            m_ball.draw(spriteBatch);

            spriteBatch.DrawString(Resource.segoeFontBig, Convert.ToString(m_playerPoint), new Vector2(225, 10), Color.White);
            spriteBatch.DrawString(Resource.segoeFontBig, Convert.ToString(m_IAPoint), new Vector2(510, 10), Color.White);

            if (MainGame.menuType == menuList.InGameMenu) //Game Menu 
                m_inGameMenu.draw(spriteBatch);

            if (MainGame.menuType == menuList.GameEnd) //Game End
                m_EndScreen.draw(spriteBatch, m_playerWon);
        }

        //OTHER
        public void reset()
        {
            m_player.setY(180);
            m_IA.setY(180);
            m_IA.resetSpeed();
            m_ball.setPos(384, 240);
            m_ball.resetSpeed();

            m_IAPoint = 0;
            m_playerPoint = 0;
        }
    }
}
