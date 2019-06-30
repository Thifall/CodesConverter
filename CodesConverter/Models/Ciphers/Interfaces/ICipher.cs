using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodesConverter.Models.Ciphers.Interfaces
{
    public interface ICipher
    {
        string CipherName { get; }
        bool UsesKey { get; }
        string Encode(string textToEncode);
        string Decode(string textToDecode);
        void SetKey(string key);
    }
}
