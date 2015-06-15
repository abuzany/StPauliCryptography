using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StPauliSystems.Security.Cryptography.File;

namespace StPSCryptographyTest
{
    [TestClass]
    public class AESTest
    {
        private string inFile = "FileTest.txt";
        private string outFileEnc = "FileTestEnc.txt";
        private string inFileEnc = "FileTestEnc.txt";
        private string outFileDec = "FileTestDec.txt";

        [TestMethod]
        public void EncryptTest()
        {
            try
            {
                AES.Encrypt(inFile, outFileEnc);
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message + e.StackTrace);
            }
        }

        [TestMethod]
        public void DecryptTest()
        {
            try
            {
                AES.Decrypt(inFileEnc, outFileDec);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message + e.StackTrace);
            }
        }
    }
}
