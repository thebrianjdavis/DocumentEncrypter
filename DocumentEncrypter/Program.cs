using System;
using DocumentEncrypter.Ciphers;

namespace DocumentEncrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            DocumentEncrypterCLI cli = new DocumentEncrypterCLI();
            cli.RunCLI();
        }
    }
}
