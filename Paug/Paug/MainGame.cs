//System
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
using EyesEngine_XNA.GamePlay;
using EyesEngine_XNA.GUI;
using EyesEngine_XNA.Other;

namespace EyesEngine_XNA
{
    enum inputType { Pc, Controller };
    enum menuList { MainMenu, OptionMenu, Credit, Game, InGameMenu, GameEnd };

    class MainGame
    {
        //PUBLIC
        public static bool m_restart;
        public static inputType input;
        public static menuList menuType;

        //PRIVATE
        private InGameScreen m_inGameScreen;

        private EntityPlayer m_player;

        private Credit m_credit;
        private EyesMainMenu m_menu;
        private EyesOptionMenu m_optionMenu;

        private EyesMapLoader m_map = new EyesMapLoader();

        //CONSTRUCTOR
        public MainGame(ContentManager content, GraphicsDevice graphicsDevice)
        {
            m_restart = false;

            Resource.loadContent(content);
            Console.WriteLine("-Resource Load: Check");

            menuType = menuList.MainMenu;
            Console.WriteLine("-Menu Type: " + menuType);;

            m_player = new EntityPlayer(content);

            m_credit = new Credit(content);
            Console.WriteLine("-Credit Load: Check");

            m_menu = new EyesMainMenu(content);
            Console.WriteLine("-MainMenu Load: Check");

            m_optionMenu = new EyesOptionMenu();
            Console.WriteLine("-OptionMenu Load: Check");

            //Load level
            m_map.load("texture/background1", "music/music1", true, content);

            m_inGameScreen = new InGameScreen(content, m_player, m_map);
            Console.WriteLine("-InGameScreen Load: Check");

            Console.WriteLine("\n \n-Game started:");
        }

        //UPDATE
        public void Update(GameTime gameTime, MouseState mouse, KeyboardState keyboard, GamePadState gamePad)
        {
            if (m_restart == true)
            {
                m_inGameScreen.reset();
                m_restart = false;
            }

            //Menu and Game
            if (menuType == menuList.MainMenu)
                m_menu.Update(gameTime, mouse, keyboard, gamePad);
            else if (menuType == menuList.Credit)
                m_credit.Update(gameTime, mouse, keyboard, gamePad);
            else if (menuType == menuList.OptionMenu)
                m_optionMenu.Update(gameTime, mouse, keyboard, gamePad);
            else if (menuType == menuList.Game || menuType == menuList.InGameMenu || menuType == menuList.GameEnd)
            {
                m_inGameScreen.Update(gameTime, mouse, keyboard, gamePad);
            }
        }

        //DRAW
        public void Draw(SpriteBatch spriteBatch)
        {
            //Menu and Game
            if (menuType == menuList.MainMenu)
                m_menu.draw(spriteBatch);
            else if (menuType == menuList.Credit)
                m_credit.draw(spriteBatch);
            else if (menuType == menuList.OptionMenu)
                m_optionMenu.draw(spriteBatch);
            else if (menuType == menuList.Game || menuType == menuList.InGameMenu || menuType == menuList.GameEnd)
            {
                m_inGameScreen.draw(spriteBatch);
            }
        }
    }
}
