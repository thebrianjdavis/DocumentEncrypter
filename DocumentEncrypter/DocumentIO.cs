using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DocumentEncrypter.Ciphers;

namespace DocumentEncrypter
{
    public class DocumentIO
    {
        public string FullPath { get; set; }
        public string Key { get; set; }
        public DocumentIO (string fullPath, string key)
        {
            FullPath = fullPath;
            Key = key;
        }
        public bool Encipher()
        {
            bool fileCreated = false;
            LongVigenere lv = new LongVigenere(Key);
            TranspositionMatrix tm = new TranspositionMatrix(Key);
            ReverseVigenere rv = new ReverseVigenere(Key);

            try
            {
                string fileName = Path.GetFileName(FullPath);
                string fileNameNoExt = Path.GetFileNameWithoutExtension(fileName);
                string fileExt = Path.GetExtension(fileName);

                string fileDir = FullPath.Substring(0, FullPath.Length - fileName.Length);
                string createFile = fileNameNoExt + "MLC" + fileExt;
                string createFull = Path.Combine(fileDir, createFile);

                using (StreamReader sr = new StreamReader(FullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        using (StreamWriter sw = new StreamWriter(createFull, true))
                        {
                            string lvE = lv.Encipher(sr.ReadLine());
                            string tmE = tm.Encipher(lvE);
                            string rvE = rv.Encipher(tmE);
                            sw.WriteLine(rvE);
                        }
                    }
                }
                if (Path.IsPathFullyQualified(createFull))
                {
                    fileCreated = true;
                }
                File.Move(createFull, FullPath, true);
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input for file path...");
            }
            return fileCreated;
        }
        public bool Decipher()
        {
            bool fileCreated = false;
            LongVigenere lv = new LongVigenere(Key);
            TranspositionMatrix tm = new TranspositionMatrix(Key);
            ReverseVigenere rv = new ReverseVigenere(Key);

            try
            {
                string fileName = Path.GetFileName(FullPath);
                string fileNameNoExt = Path.GetFileNameWithoutExtension(fileName);
                string fileExt = Path.GetExtension(fileName);

                string fileDir = FullPath.Substring(0, FullPath.Length - fileName.Length);
                string createFile = fileNameNoExt + "MLC" + fileExt;
                string createFull = Path.Combine(fileDir, createFile);

                using (StreamReader sr = new StreamReader(FullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        using (StreamWriter sw = new StreamWriter(createFull, true))
                        {
                            string rvD = rv.Decipher(sr.ReadLine());
                            string tmD = tm.Decipher(rvD);
                            string lvD = lv.Decipher(tmD);
                            sw.WriteLine(lvD);
                        }
                    }
                }
                if (Path.IsPathFullyQualified(createFull))
                {
                    fileCreated = true;
                }
                File.Move(createFull, FullPath, true);
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input for file path...");
            }
            return fileCreated;
        }
    }
}
