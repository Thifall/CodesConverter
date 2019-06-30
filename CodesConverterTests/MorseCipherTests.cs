using CodesConverter.Models.Ciphers;
using System;
using Xunit;

namespace CodesConverterTests
{
    public class MorseCipherTests
    {
        [Theory]
        [InlineData("a", ".-")]
        [InlineData("A", ".-")]
        [InlineData("b", "-...")]
        [InlineData("B", "-...")]
        [InlineData("1", ".----")]
        [InlineData(" ", "/")]
        public void Encode_ValidCharacter_ReturnsEncodedCharacter(string toEncode, string expected)
        {
            //arrange
            var cipher = new MorseCipher();

            //act
            var result = cipher.Encode(toEncode);

            //assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("¹", "¹")]
        [InlineData("!", "!")]
        [InlineData("/", "/")]
        public void Encode_InValidCharacter_ReturnsSameCharacter(string toEncode, string expected)
        {
            //arrange
            var cipher = new MorseCipher();

            //act
            var result = cipher.Encode(toEncode);

            //assert
            Assert.Equal(expected, result);
        }
    }
}
