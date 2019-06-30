using CodesConverter.Models.Ciphers.Interfaces;
using System.Collections.Generic;

namespace CodesConverter.Models.Encoding.Interfaces
{
    public interface IEncoder
    {
        string Encode(string textToEncode, string cipherName, string key);
        string Decode(string textToDecode, string cipherName, string key);
        IEnumerable<ICipher> Ciphers { get; }
    }
}
