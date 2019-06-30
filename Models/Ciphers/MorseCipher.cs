using CodesConverter.Models.Ciphers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesConverter.Models.Ciphers
{
    public class MorseCipher : ICipher
    {
        private Dictionary<char, string> _morseCode;
        private Dictionary<string, char> _reverseMorseCode;

        public MorseCipher()
        {
            InitMorseCodes();
        }

        public string CipherName => "Morse Cipher";

        public bool UsesKey => false;

        public string Decode(string textToDecode)
        {
            StringBuilder result = new StringBuilder();
            var separatedWords = textToDecode.Split('/');
            foreach (var word in separatedWords)
            {
                result.Append(DecodeWord(word));
                result.Append(" ");
            }
            return result.ToString();
        }

        public string Encode(string textToEncode)
        {
            StringBuilder result = new StringBuilder();
            foreach (var character in textToEncode.ToUpper())
            {
                result.Append(EncodeSign(character));
                result.Append(" ");
            }
            return result.ToString();
        }

        public void SetKey(string key)
        {
            //Log this algorith does not use key
            return;
        }

        private void InitMorseCodes()
        {
            _morseCode = new Dictionary<char, string>();
            _morseCode.Add('A', ".-");
            _morseCode.Add('B', "-...");
            _morseCode.Add('C', "-.-.");
            _morseCode.Add('D', "-..");
            _morseCode.Add('E', ".");
            _morseCode.Add('F', "..-.");
            _morseCode.Add('G', "--.");
            _morseCode.Add('H', "....");
            _morseCode.Add('I', "..");
            _morseCode.Add('J', ".---");
            _morseCode.Add('K', "-.-");
            _morseCode.Add('L', ".-..");
            _morseCode.Add('M', "--");
            _morseCode.Add('N', "-.");
            _morseCode.Add('O', "---");
            _morseCode.Add('P', ".--.");
            _morseCode.Add('Q', "--.-");
            _morseCode.Add('R', ".-.");
            _morseCode.Add('S', "...");
            _morseCode.Add('T', "-");
            _morseCode.Add('U', "..-");
            _morseCode.Add('V', "...-");
            _morseCode.Add('W', ".--");
            _morseCode.Add('X', "-..-");
            _morseCode.Add('Y', "-.--");
            _morseCode.Add('Z', "--..");
            _morseCode.Add('1', ".----");
            _morseCode.Add('2', "..---");
            _morseCode.Add('3', "...--");
            _morseCode.Add('4', "....-");
            _morseCode.Add('5', ".....");
            _morseCode.Add('6', "-....");
            _morseCode.Add('7', "--...");
            _morseCode.Add('8', "---..");
            _morseCode.Add('9', "----.");
            _morseCode.Add('0', "-----");
            _morseCode.Add(' ', "/");

            _reverseMorseCode = new Dictionary<string, char>();
            foreach (var letter in _morseCode.Keys)
            {
                _reverseMorseCode.Add(_morseCode[letter], letter);
            }
        }

        private string EncodeSign(char character)
        {
            if (_morseCode.ContainsKey(character))
            {
                return _morseCode[character];
            }
            else
            {
                return _morseCode[character];
            }
        }

        private string DecodeWord(string word)
        {
            StringBuilder result = new StringBuilder();
            var separatedLetters = word.Trim().Split(' ');
            foreach (var morseLetter in separatedLetters)
            {
                if (_reverseMorseCode.ContainsKey(morseLetter))
                {
                    result.Append(_reverseMorseCode[morseLetter]);
                }
                else
                {
                    result.Append(morseLetter);
                }
            }
            return result.ToString();
        }
    }
}
