using System;
using System.Collections.Generic;
using System.IO;

namespace DocumentEncrypter
{
    class DocumentEncrypterCLI
    {
        const string Command_Instructions = "i";
        const string Command_Encrypt = "1";
        const string Command_Decrypt = "2";
        const string Command_Quit = "q";

        public DocumentEncrypterCLI() { }

        public void RunCLI()
        {
            PrintInstructions();

            while (true)
            {
                PrintMenu();
                string command = Console.ReadLine();
                Console.Clear();

                switch (command.ToLower())
                {
                    case Command_Instructions:
                        PrintInstructions();
                        break;

                    case Command_Encrypt:
                        RunEncrypt();
                        break;

                    case Command_Decrypt:
                        RunDecrypt();
                        break;

                    case Command_Quit:
                        Goodbye();
                        return;
                }
            }
        }
        public void RetToCon()
        {
            Console.WriteLine("Press RETURN to continue...");
            Console.ReadLine();
            Console.Clear();
        }
        public void PrintHeader()
        {
            Console.WriteLine("0100101101001011010010110100101101001011");
            Console.WriteLine("010010110100101 DOCUMENT 100101101001011");
            Console.WriteLine("010010110100101 ENCRYPTER 10010110100101");
            Console.WriteLine("0100101101001011010010110100101101001011\n");
        }
        public void PrintInstructions()
        {
            PrintHeader();
            Console.WriteLine("This program will encrypt a document");
            Console.WriteLine("with a key of your choosing.\n");
            Console.WriteLine("WARNING: IT IS RECOMMENDED THAT YOU MAKE");
            Console.WriteLine("A COPY OF YOUR DOCUMENT BEFORE RUNNING");
            Console.WriteLine("THIS PROGRAM!!! IT WILL BE OVERWRITTEN!!\n");
            RetToCon();
        }
        public void PrintMenu()
        {
            PrintHeader();
            Console.WriteLine("(1) to encrypt a document");
            Console.WriteLine("(2) to decrypt a document");
            Console.WriteLine("(i) to re-read the instructions");
            Console.WriteLine("(q) to quit the program");
        }
        public void Invalid()
        {
            PrintHeader();
            Console.WriteLine("Invalid selection, please choose again.");
            RetToCon();
        }
        public string GetFilePath()
        {
            string fullPath = "";
            while (true)
            {
                PrintHeader();
                Console.WriteLine("Please input a fully qualified file path:\n");
                fullPath = Console.ReadLine();
                Console.Clear();
                if (!Path.IsPathFullyQualified(fullPath))
                {
                    Invalid();
                }
                else
                {
                    break;
                }
            }
            return fullPath;
        }
        public string GetKey()
        {
            string key = "";
            while (true)
            {
                PrintHeader();
                Console.WriteLine("Please input your cipher key (2 char min):\n");
                key = Console.ReadLine();
                Console.Clear();
                if (key.Length >= 2)
                {
                    break;
                }
                else
                {
                    Invalid();
                }
            }
            return key;
        }
        public void RunEncrypt()
        {
            Console.Clear();
            string fullPath = GetFilePath();
            string key = GetKey();
            DocumentIO dIO = new DocumentIO(fullPath, key);
            bool wasSuccessful = dIO.Encipher();
            if (wasSuccessful)
            {
                PrintHeader();
                Console.WriteLine("File was succesfully encrypted!");
                RetToCon();
            }
            else
            {
                PrintHeader();
                Console.WriteLine("File encryption did not succeed!");
                RetToCon();
            }
        }
        public void RunDecrypt()
        {
            Console.Clear();
            string fullPath = GetFilePath();
            string key = GetKey();
            DocumentIO dIO = new DocumentIO(fullPath, key);
            bool wasSuccessful = dIO.Decipher();
            if (wasSuccessful)
            {
                PrintHeader();
                Console.WriteLine("File was succesfully decrypted!");
                RetToCon();
            }
            else
            {
                PrintHeader();
                Console.WriteLine("File decryption did not succeed!");
                RetToCon();
            }
        }
        public void Goodbye()
        {
            PrintHeader();
            Console.WriteLine("Make sure to remember your encryption");
            Console.WriteLine("key!\n");
            Console.WriteLine("\nThank you for using document encrypter!");
        }
    }
}
