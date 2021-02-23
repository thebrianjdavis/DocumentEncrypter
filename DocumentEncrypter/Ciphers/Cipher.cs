using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentEncrypter.Ciphers
{
    public class Cipher
    {
        public string CharLine { get; set; }
        public string Key { get; set; }
        public Dictionary<int, string> TabulaRecta { get; set; }
        public Cipher(string key)
        {
            Key = key;
            CharLine = MakeCharLine();
            TabulaRecta = MakeTable(CharLine);
        }
        public virtual string Encipher(string message)
        {
            return message;
        }
        public virtual string Decipher(string message)
        {
            return message;
        }
        public string MakeCharLine()
        {
            string alphaOrigin = "";
            for (int i = 0; i < 255; i++)
            {
                alphaOrigin += (char)i;
            }
            return alphaOrigin;
        }
        public Dictionary<int, string> MakeTable(string alphaOrigin)
        {
            Dictionary<int, string> tabulaRecta = new Dictionary<int, string>();
            string alphaShift = alphaOrigin;

            for (int i = 0; i < alphaOrigin.Length; i++)
            {
                string dictStr = "";
                for (int j = 0; j < alphaShift.Length; j++)
                {
                    dictStr += alphaShift[j];
                }
                tabulaRecta.Add(i, dictStr);
                string temp = "";
                for (int k = 1; k < alphaShift.Length; k++)
                {
                    temp += alphaShift[k];
                }
                temp += alphaShift[0];
                alphaShift = temp;
            }

            return tabulaRecta;
        }
        public string KeySwitch(string key)
        {
            string altKey = "";
            for (int i = key.Length - 1; i >= 0; i--)
            {
                altKey += key[i];
            }
            return altKey;
        }
    }
}
