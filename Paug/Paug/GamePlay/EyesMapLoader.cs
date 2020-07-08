//SYSTEM
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
//XNA
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using EyesEngine_XNA.Other;

namespace EyesEngine_XNA.GamePlay
{
    class EyesMapLoader
    {
        private Texture2D m_background;

        //Music
        SoundEffectInstance m_instance;
        private SoundEffect m_music;
        private string m_musicPos;
        private bool m_looped;

        //CONSTRUCTOR
        public EyesMapLoader()
        {
            m_looped = false;
        }

        //METHOD
        public void load(string fileName, string fileMusic, bool musicLoop,ContentManager content)
        {
            m_background = content.Load<Texture2D>(fileName);

            //Music
            m_musicPos = fileMusic;
            m_looped = musicLoop;

            Console.WriteLine("Music: " + getMusicPos());
            Console.WriteLine("Looped: " + getLooped());

            //Load Music
            m_music = content.Load<SoundEffect>(getMusicPos());
            m_instance = m_music.CreateInstance();
            m_instance.IsLooped = m_looped;

        }

        //METHODS
        public void playMusic()
        {
            m_instance.Volume = EyesOptionTreatment.soundVolume;
            m_instance.Play();
        }

        public void pauseMusic()
        {
            m_instance.Pause();
        }

        public void stopMusic()
        {
            m_instance.Stop();
        }

        //DRAW
        public void draw(SpriteBatch spriteBatch)
        {
            //Draw map
            spriteBatch.Draw(m_background, new Vector2(0,0), Color.White);
        }

        //OTHER
        //GET
        public bool getLooped()
        {
            return m_looped;
        }

        public string getMusicPos()
        {
            return m_musicPos;
        }
    }
}
