//SYSTEM
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using Microsoft.Xna.Framework.Input;

namespace EyesEngine_XNA.Other
{
    class EyesOptionTreatment
    {
        private string m_OptionFile;

        private char m_keyUp; //KeyBoard char
        private char m_keyDown;
        private char m_keyRight;
        private char m_keyLeft;

        //Option
        public static float soundVolume; //Volume

        public static Keys keyUp; //KeyBoard Input
        public static Keys keyDown;
        public static Keys keyRight;
        public static Keys keyLeft;

        //CONSTRUCTOR
        public EyesOptionTreatment(string optionFile)
        {
            m_OptionFile = optionFile;
        }

        //METHODS
        public void load()
        {
            StreamReader fileReader = new StreamReader(m_OptionFile);

            //Sound Volume
            soundVolume = (float)Convert.ToDouble(fileReader.ReadLine());
            Console.WriteLine("-->Sound Volume: " + soundVolume);
            //Input
            m_keyUp = Convert.ToChar(fileReader.ReadLine());
            keyUp = (Keys)((int)(char.ToUpper(m_keyUp)));
            Console.WriteLine("-->Key UP: " + keyUp);

            m_keyDown = Convert.ToChar(fileReader.ReadLine());
            keyDown = (Keys)((int)(char.ToUpper(m_keyDown)));
            Console.WriteLine("-->Key DOWN: " + keyDown);

            m_keyRight = Convert.ToChar(fileReader.ReadLine());
            keyRight = (Keys)((int)(char.ToUpper(m_keyRight)));
            Console.WriteLine("-->Key RIGHT: " + keyRight);

            m_keyLeft = Convert.ToChar(fileReader.ReadLine());
            keyLeft = (Keys)((int)(char.ToUpper(m_keyLeft)));
            Console.WriteLine("-->Key LEFT: " + keyLeft);

            //Close all
            fileReader.Close();
        }

        public void save(float newSoundVolume, char newKeyUp, char newKeyDown, char newKeyRight, char newKeyLeft)
        {
            Console.WriteLine("\n->Option Update/Save");

            File.WriteAllText(m_OptionFile, String.Empty);
            StreamWriter fileReader = new StreamWriter(m_OptionFile);

            //Sound Volume
            fileReader.WriteLine(newSoundVolume);
            //Input
            fileReader.WriteLine(newKeyUp);

            fileReader.WriteLine(newKeyDown);

            fileReader.WriteLine(newKeyRight);

            fileReader.WriteLine(newKeyLeft);

            //Close all
            fileReader.Close();
            this.load();
        }
    }
}
