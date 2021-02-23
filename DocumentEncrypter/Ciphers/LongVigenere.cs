using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentEncrypter.Ciphers
{
    public class LongVigenere : Cipher
    {
        public LongVigenere(string key) : base(key)
        {

        }
        public override string Encipher(string message)
        {
            string output = "";
            try
            {
                for (int i = 0; i < message.Length; i++)
                {
                    int k = i;
                    if (k > Key.Length - 2)
                    {
                        k = (k % Key.Length);
                    }
                    foreach (KeyValuePair<int, string> charX in TabulaRecta)
                    {
                        int charPos = 0;
                        if ((int)Key[k] == charX.Key)
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
                    if (k > Key.Length - 2)
                    {
                        k = (k % Key.Length);
                    }
                    int charPos = (int)Key[k];
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
