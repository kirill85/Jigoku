using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Data;
using Npgsql;
using NHibernate;
using nCrypto;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace DevLair.Tests.DataBase
{
    [TestClass]
    public class ConnectionTest
    {
        private String connection = null;

        [TestMethod]
        [TestInitialize]
        public void Connect()
        {
            Encrypter encrypter = new Encrypter("64bit");

            String keyword = encrypter.Decrypt("QnV0IHlvdSBkb24ndCByZWFsbHkgbWVhbiBpdA==");

            // Check if crypter is changed
            Assert.AreEqual(true, encrypter.SetCrypter("AES"));

            this.connection = encrypter.Decrypt
                ("Sf+ulELX4tNuvsQtUG2EZWPJDPhm8obnrSyEm7F5mtg/eziYSjoIZndeCHk8iZOhvAuMNJBxiiatrRHTt2LVFv/vJNoo8yCHkOO7TwUWv3+l8+Wpis4TSsEvc8zHgEPIucH/OQ2tyYlMboyoFH26dZLZ2Y+Kevfu79VfqLBcKGE=", keyword);
        }

        [TestMethod]
        public void NhibernateFluentTest()
        {
            Assert.IsNotNull(this.connection);

            ISessionFactory session = 
               Fluently.Configure().Database(PostgreSQLConfiguration.Standard.ConnectionString(this.connection)).BuildSessionFactory();

            Assert.IsNotNull(session);
        }
    }
}
