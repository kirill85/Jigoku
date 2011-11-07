using System;
using NUnit.Framework;

using nCrypto;
using Npgsql;
using Jigoku.Tests;

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
            TestHelper.log("Decrypting keyword");
            Encrypter encrypter = new Encrypter("64bit");
            String keyword = encrypter.Decrypt("QnV0IHlvdSBkb24ndCByZWFsbHkgbWVhbiBpdA==");
            TestHelper.done();

            TestHelper.log("Decrypting connection parameters");
            Assert.AreEqual(true, encrypter.SetCrypter("AES"));
            TestHelper.done();

            TestHelper.log("Connection decritpion");
            try
            {
                this.connection = encrypter.Decrypt
                    ("Sf+ulELX4tNuvsQtUG2EZWPJDPhm8obnrSyEm7F5mtg/eziYSjoIZndeCHk8iZOhvAuMNJBxiiatrRHTt2LVFv/vJNoo8yCHkOO7TwUWv3+l8+Wpis4TSsEvc8zHgEPIucH/OQ2tyYlMboyoFH26dZLZ2Y+Kevfu79VfqLBcKGE=", keyword);
                TestHelper.done();
            }
            catch (Exception e)
            {
                TestHelper.error(e.Message);
            }

            TestHelper.log("Connection test");
            try
            {
                NpgsqlConnection _Connection = new NpgsqlConnection(connection);
                Assert.IsNotNull(_Connection);
                TestHelper.done();
            }
            catch (Exception e)
            {
                TestHelper.error(e.Message);
            }
        }
    }
}