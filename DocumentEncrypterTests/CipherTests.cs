using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentEncrypter.Ciphers;

namespace DocumentEncrypterTests
{
    [TestClass]
    public class CipherTests
    {
        [TestMethod]
        public void LongVigenereReturnsExact()
        {
            string key = "tESt KeY!";
            string message = "Can you READ this 100%?!";
            
            LongVigenere lv = new LongVigenere(key);
            string lvE = lv.Encipher(message);
            string lvD = lv.Decipher(lvE);

            Assert.AreEqual(message, lvD);
        }
        [TestMethod]
        public void ReverseVigenereReturnsExact()
        {
            string key = "tESt KeY!";
            string message = "Can you READ this 100%?!";

            ReverseVigenere rv = new ReverseVigenere(key);
            string rvE = rv.Encipher(message);
            string rvD = rv.Decipher(rvE);

            Assert.AreEqual(message, rvD);
        }
        [TestMethod]
        public void TranspositionMatrixReturnsExact()
        {
            string key = "tESt KeY!";
            string message = "Can you READ this 100%?!";

            TranspositionMatrix tm = new TranspositionMatrix(key);
            string tmE = tm.Encipher(message);
            string tmD = tm.Decipher(tmE);

            Assert.AreEqual(message, tmD);
        }
        [TestMethod]
        public void MultilayerReturnsExact()
        {
            string key = "tESt KeY!";
            string message = "Can you READ this 100%?!";
            LongVigenere lv = new LongVigenere(key);
            TranspositionMatrix tm = new TranspositionMatrix(key);
            ReverseVigenere rv = new ReverseVigenere(key);
            string lvE = lv.Encipher(message);
            string tmE = tm.Encipher(lvE);
            string rvE = rv.Encipher(tmE);
            string rvD = rv.Decipher(rvE);
            string tmD = tm.Decipher(rvD);
            string lvD = lv.Decipher(tmD);

            Assert.AreEqual(message, lvD);
        }
    }
}
