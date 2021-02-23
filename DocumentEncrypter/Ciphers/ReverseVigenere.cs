using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentEncrypter.Ciphers
{
    public class ReverseVigenere : Cipher
    {
        public string AltKey { get; set; }
        public ReverseVigenere(string key) : base(key)
        {
            AltKey = KeySwitch(key);
        }
        public override string Encipher(string message)
        {
            string output = "";

            try
            {
                for (int i = 0; i < message.Length; i++)
                {
                    int k = i;
                    if (k > AltKey.Length - 2)
                    {
                        k = (k % AltKey.Length);
                    }
                    foreach (KeyValuePair<int, string> charX in TabulaRecta)
                    {
                        int charPos = 0;
                        if ((int)AltKey[k] == charX.Key)
                        {
                            for (int x = 0; x < CharLine.Length; x++)
                            {
                                if (message[i] == CharLine[x])
                                {
                                    charPos = x;
                                }
                            }
                            output += charX.Value[charPos];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return output;
        }
        public override string Decipher(string message)
        {
            string output = "";
            try
            {
                for (int i = 0; i < message.Length; i++)
                {
                    int k = i;
                    if (k > AltKey.Length - 2)
                    {
                        k = (k % AltKey.Length);
                    }
                    int charPos = (int)AltKey[k];
                    int charPosB = 0;
                    string temp = "";
                    foreach (KeyValuePair<int, string> charX in TabulaRecta)
                    {
                        if (charPos == charX.Key)
                        {
                            temp = charX.Value;
                            for (int x = 0; x < temp.Length; x++)
                            {
                                if (message[i] == temp[x])
                                {
                                    charPosB = x;
                                }
                            }
                        }
                    }
                    output += CharLine[charPosB];
                }

            }
            catch (Exception e)
            {
                //MultiCipherCLI.InvalidChar();
            }
            return output;
        }
    }
}
