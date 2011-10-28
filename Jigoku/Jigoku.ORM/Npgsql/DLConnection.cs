using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using nCrypto;
using Npgsql;

namespace Jigoku.Core.Npgsql
{
    static class DLConnection
    {
        public static NpgsqlConnection conn = (new XConnection()).Connection;
    }
    class XConnectionException : Exception
    {
        public string ErrorMessage
        {
            get
            {
                return "nCrypto library failed to change crypter";
            }
        }
    }
    class XConnection
    {
        private NpgsqlConnection _Connection;
        public NpgsqlConnection Connection
        {
            get
            {
                return _Connection;
            }
        }
        public XConnection()
        {
            Encrypter encrypter = new Encrypter("64bit");

            String keyword = encrypter.Decrypt("QnV0IHlvdSBkb24ndCByZWFsbHkgbWVhbiBpdA==");

            if (encrypter.SetCrypter("AES"))
            {
                String connection = encrypter.Decrypt
                    ("Sf+ulELX4tNuvsQtUG2EZWPJDPhm8obnrSyEm7F5mtg/eziYSjoIZndeCHk8iZOhvAuMNJBxiiatrRHTt2LVFv/vJNoo8yCHkOO7TwUWv3+l8+Wpis4TSsEvc8zHgEPIucH/OQ2tyYlMboyoFH26dZLZ2Y+Kevfu79VfqLBcKGE=", keyword);

                _Connection = new NpgsqlConnection(connection);
            }
            else
            {
                throw new XConnectionException();
            }
        }
    }
}
