using CodesConverter.Models.Ciphers.Interfaces;
using CodesConverter.Models.Encoding.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodesConverter.Models.Encoding
{
    public class Encoder : IEncoder
    {
        public IEnumerable<ICipher> Ciphers { get; private set; }

        public Encoder(IEnumerable<ICipher> ciphers)
        {
            Ciphers = ciphers;
        }

        public string Decode(string textToDecode, string cipherName, string key)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textToDecode))
                {
                    return string.Empty;
                }
                if (string.IsNullOrWhiteSpace(cipherName))
                {
                    return textToDecode;
                }
                var cipher = Ciphers.First(x => x.CipherName == cipherName);
                if (cipher.UsesKey)
                {
                    cipher.SetKey(key);
                }
                return cipher.Decode(textToDecode);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to decode: {e}");
                return textToDecode;
            };
        }

        public string Encode(string textToEncode, string cipherName, string key)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textToEncode))
                {
                    return string.Empty;
                }
                if (string.IsNullOrWhiteSpace(cipherName))
                {
                    return textToEncode;
                }

                var cipher = Ciphers.First(x => x.CipherName == cipherName);
                if (cipher.UsesKey)
                {
                    cipher.SetKey(key);
                }
                return cipher.Encode(textToEncode);

            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to encode: {e}");
                return textToEncode;
            };
        }
    }
}
