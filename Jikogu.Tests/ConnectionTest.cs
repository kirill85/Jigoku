using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

using nCrypto;

namespace Jigoku.Tests
{
    [TestFixture]
    public class ConnectionTest
    {
        private String connection = null;
        [Test]
        public void Connect()
        {
            Console.WriteLine();
            Console.WriteLine("---> Decrypting keyword");

            Encrypter encrypter = new Encrypter("64bit");
            String keyword = encrypter.Decrypt("QnV0IHlvdSBkb24ndCByZWFsbHkgbWVhbiBpdA==");

            Console.WriteLine("---> Decrypting connection parameters");

            Assert.AreEqual(true, encrypter.SetCrypter("AES"));

            Console.WriteLine("---> Connection test");

            this.connection = encrypter.Decrypt
                ("Sf+ulELX4tNuvsQtUG2EZWPJDPhm8obnrSyEm7F5mtg/eziYSjoIZndeCHk8iZOhvAuMNJBxiiatrRHTt2LVFv/vJNoo8yCHkOO7TwUWv3+l8+Wpis4TSsEvc8zHgEPIucH/OQ2tyYlMboyoFH26dZLZ2Y+Kevfu79VfqLBcKGE=", keyword);
        }
    }
}