using NUnit.Framework;
using ConsoleApp6;
using System.Linq;

namespace ConsoleApp6.Tests
{
    [TestFixture]
    public class WordDictionaryTests
    {
        [Test]
        public void FindByRoot_WordIsContained_ReturnsCorrectWords()
        {
            // Arrange
            var wordDictionary = new WordDictionary();
            var word1 = new Word { Prefix = "un", Root = "know", Suffix = "n" };
            var word2 = new Word { Prefix = "un", Root = "known", Suffix = "" };
            wordDictionary.Add(word1);
            wordDictionary.Add(word2);

            // Act
            var result = wordDictionary.FindByRoot("known");

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(word2.ToString(), result.First().ToString());
        }

        [Test]
        public void Add_NullWord_DoNotAddToWords()
        {
            // Arrange
            var wordDictionary = new WordDictionary();

            // Act
            wordDictionary.Add(null);

            // Assert
            Assert.AreEqual(0, wordDictionary.FindByRoot("").Count());
        }
    }

    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void IsWordValid_ValidAssembledWord_ReturnsTrue()
        {
            // Arrange
            string prefix = "dis";
            string root = "connect";
            string suffix = "ed";
            string originalWord = "disconnected";

            // Act
            bool result = Program.IsWordValid($"{prefix}-{root}-{suffix}", originalWord);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsWordValid_InvalidAssembledWord_ReturnsFalse()
        {
            // Arrange
            string prefix = "dis";
            string root = "connect";
            string suffix = "ion";
            string originalWord = "disconnected";

            // Act
            bool result = Program.IsWordValid($"{prefix}-{root}-{suffix}", originalWord);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
