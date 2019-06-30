using CodesConverter.Models.Ciphers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodesConverter.Models.Ciphers
{
    public class TestCipher : ICipher
    {
        public string CipherName => "Test Cipher";

        public bool UsesKey => false;

        public string Decode(string textToDecode)
        {
            return "Decoded with TestCipher";
        }

        public string Encode(string textToEncode)
        {
            return "Encoded with testCipher";
        }

        public void SetKey(string key)
        {
            return;
        }
    }
}
