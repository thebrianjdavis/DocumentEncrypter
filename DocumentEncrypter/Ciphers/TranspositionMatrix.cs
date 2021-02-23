using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentEncrypter.Ciphers
{
    public class TranspositionMatrix : Cipher
    {
        public int Delta { get; set; }
        public TranspositionMatrix(string key) : base(key)
        {
            Delta = Key.Length;
            while (Delta > 6)
            {
                Delta -= 5;
            }
        }
        public override string Encipher(string message)
        {
            string output = "";

            for (int i = 0; i <= message.Length - 1; i += Delta)
            {
                output += message[i];
            }
            for (int i = 1; i <= message.Length - 1; i += Delta)
            {
                output += message[i];
            }
            if (Delta > 2)
            {
                for (int i = 2; i <= message.Length - 1; i += Delta)
                {
                    output += message[i];
                }
            }
            if (Delta > 3)
            {
                for (int i = 3; i <= message.Length - 1; i += Delta)
                {
                    output += message[i];
                }
            }
            if (Delta > 4)
            {
                for (int i = 4; i <= message.Length - 1; i += Delta)
                {
                    output += message[i];
                }
            }
            if (Delta > 5)
            {
                for (int i = 5; i <= message.Length - 1; i += Delta)
                {
                    output += message[i];
                }
            }
            if (Delta > 6)
            {
                for (int i = 6; i <= message.Length - 1; i += Delta)
                {
                    output += message[i];
                }
            }
            return output;
        }
        public override string Decipher(string message)
        {
            string output = "";
            int removeI = 0;

            while ((message.Length % Delta) != 0)
            {
                message += "X";
                removeI++;
            }

            if (Delta == 2)
            {
                string temp1 = "";
                string temp2 = "";
                int factor = message.Length / Delta;
                temp1 = message.Substring(0, factor);
                temp2 = message.Substring(factor, factor - removeI);

                for (int i = 0; i < temp1.Length; i++)
                {
                    output += temp1[i];
                    if (i < temp2.Length)
                    {
                        output += temp2[i];
                    }
                }
            }
            if (Delta == 3)
            {
                string temp1 = "";
                string temp2 = "";
                string temp3 = "";
                int factor = message.Length / Delta;
                temp1 = message.Substring(0, factor);
                if (removeI == 2)
                {
                    temp2 = message.Substring(factor, factor - 1);
                    temp3 = message.Substring((factor * 2) - 1, factor - 1);
                }
                else if (removeI == 1)
                {
                    temp2 = message.Substring(factor, factor);
                    temp3 = message.Substring((factor * 2), factor - 1);
                }
                else
                {
                    temp2 = message.Substring(factor, factor);
                    temp3 = message.Substring(factor * 2, factor);
                }
                for (int i = 0; i < temp1.Length; i++)
                {
                    output += temp1[i];
                    if (i < temp2.Length)
                    {
                        output += temp2[i];
                    }
                    if (i < temp3.Length)
                    {
                        output += temp3[i];
                    }
                }
            }
            if (Delta == 4)
            {
                string temp1 = "";
                string temp2 = "";
                string temp3 = "";
                string temp4 = "";
                int factor = message.Length / Delta;
                temp1 = message.Substring(0, factor);
                if (removeI == 3)
                {
                    temp2 = message.Substring(factor, factor - 1);
                    temp3 = message.Substring((factor * 2) - 1, factor - 1);
                    temp4 = message.Substring((factor * 3) - 2, factor - 1);
                }
                else if (removeI == 2)
                {
                    temp2 = message.Substring(factor, factor);
                    temp3 = message.Substring((factor * 2), factor - 1);
                    temp4 = message.Substring((factor * 3) - 1, factor - 1);
                }
                else if (removeI == 1)
                {
                    temp2 = message.Substring(factor, factor);
                    temp3 = message.Substring((factor * 2), factor);
                    temp4 = message.Substring((factor * 3), factor - 1);
                }
                else
                {
                    temp2 = message.Substring(factor, factor);
                    temp3 = message.Substring(factor * 2, factor);
                    temp4 = message.Substring(factor * 3, factor);
                }
                for (int i = 0; i < temp1.Length; i++)
                {
                    output += temp1[i];
                    if (i < temp2.Length)
                    {
                        output += temp2[i];
                    }
                    if (i < temp3.Length)
                    {
                        output += temp3[i];
                    }
                    if (i < temp4.Length)
                    {
                        output += temp4[i];
                    }
                }
            }
            if (Delta == 5)
            {
                string temp1 = "";
                string temp2 = "";
                string temp3 = "";
                string temp4 = "";
                string temp5 = "";
                int factor = message.Length / Delta;
                temp1 = message.Substring(0, factor);
                if (removeI == 4)
                {
                    temp2 = message.Substring(factor, factor - 1);
                    temp3 = message.Substring((factor * 2) - 1, factor - 1);
                    temp4 = message.Substring((factor * 3) - 2, factor - 1);
                    temp5 = message.Substring((factor * 4) - 3, factor - 1);
                }
                else if (removeI == 3)
                {
                    temp2 = message.Substring(factor, factor);
                    temp3 = message.Substring((factor * 2), factor - 1);
                    temp4 = message.Substring((factor * 3) - 1, factor - 1);
                    temp5 = message.Substring((factor * 4) - 2, factor - 1);
                }
                else if (removeI == 2)
                {
                    temp2 = message.Substring(factor, factor);
                    temp3 = message.Substring((factor * 2), factor);
                    temp4 = message.Substring((factor * 3), factor - 1);
                    temp5 = message.Substring((factor * 4) - 1, factor - 1);
                }
                else if (removeI == 1)
                {
                    temp2 = message.Substring(factor, factor);
                    temp3 = message.Substring((factor * 2), factor);
                    temp4 = message.Substring((factor * 3), factor);
                    temp5 = message.Substring((factor * 4), factor - 1);
                }
                else
                {
                    temp2 = message.Substring(factor, factor);
                    temp3 = message.Substring(factor * 2, factor);
                    temp4 = message.Substring(factor * 3, factor);
                    temp5 = message.Substring(factor * 4, factor);
                }
                for (int i = 0; i < temp1.Length; i++)
                {
                    output += temp1[i];
                    if (i < temp2.Length)
                    {
                        output += temp2[i];
                    }
                    if (i < temp3.Length)
                    {
                        output += temp3[i];
                    }
                    if (i < temp4.Length)
                    {
                        output += temp4[i];
                    }
                    if (i < temp5.Length)
                    {
                        output += temp5[i];
                    }
                }
            }
            if (Delta == 6)
            {
                string temp1 = "";
                string temp2 = "";
                string temp3 = "";
                string temp4 = "";
                string temp5 = "";
                string temp6 = "";
                int factor = message.Length / Delta;
                temp1 = message.Substring(0, factor);
                if (removeI == 5)
                {
                    temp2 = message.Substring(factor, factor - 1);
                    temp3 = message.Substring((factor * 2) - 1, factor - 1);
                    temp4 = message.Substring((factor * 3) - 2, factor - 1);
                    temp5 = message.Substring((factor * 4) - 3, factor - 1);
                    temp6 = message.Substring((factor * 5) - 4, factor - 1);
                }
                else if (removeI == 4)
                {
                    temp2 = message.Substring(factor, factor);
                    temp3 = message.Substring((factor * 2), factor - 1);
                    temp4 = message.Substring((factor * 3) - 1, factor - 1);
                    temp5 = message.Substring((factor * 4) - 2, factor - 1);
                    temp6 = message.Substring((factor * 5) - 3, factor - 1);
                }
                else if (removeI == 3)
                {
                    temp2 = message.Substring(factor, factor);
                    temp3 = message.Substring((factor * 2), factor);
                    temp4 = message.Substring((factor * 3), factor - 1);
                    temp5 = message.Substring((factor * 4) - 1, factor - 1);
                    temp6 = message.Substring((factor * 5) - 2, factor - 1);
                }
                else if (removeI == 2)
                {
                    temp2 = message.Substring(factor, factor);
                    temp3 = message.Substring((factor * 2), factor);
                    temp4 = message.Substring((factor * 3), factor);
                    temp5 = message.Substring((factor * 4), factor - 1);
                    temp6 = message.Substring((factor * 5) - 1, factor - 1);
                }
                else if (removeI == 1)
                {
                    temp2 = message.Substring(factor, factor);
                    temp3 = message.Substring((factor * 2), factor);
                    temp4 = message.Substring((factor * 3), factor);
                    temp5 = message.Substring((factor * 4), factor);
                    temp6 = message.Substring((factor * 5), factor - 1);
                }
                else
                {
                    temp2 = message.Substring(factor, factor);
                    temp3 = message.Substring(factor * 2, factor);
                    temp4 = message.Substring(factor * 3, factor);
                    temp5 = message.Substring(factor * 4, factor);
                    temp6 = message.Substring(factor * 5, factor);
                }
                for (int i = 0; i < temp1.Length; i++)
                {
                    output += temp1[i];
                    if (i < temp2.Length)
                    {
                        output += temp2[i];
                    }
                    if (i < temp3.Length)
                    {
                        output += temp3[i];
                    }
                    if (i < temp4.Length)
                    {
                        output += temp4[i];
                    }
                    if (i < temp5.Length)
                    {
                        output += temp5[i];
                    }
                    if (i < temp6.Length)
                    {
                        output += temp6[i];
                    }
                }
            }
            return output;
        }
    }
}
