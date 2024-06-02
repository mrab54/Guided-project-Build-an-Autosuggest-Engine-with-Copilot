namespace TrieDictionaryTest;

[TestClass]
public class TrieTest
{
  // Test that a word is inserted in the trie
  [TestMethod]
  public void InsertWord()
  {
    // Arrange
    Trie trie = new Trie();
    string word = "hello";

    // Act
    trie.Insert(word);

    // Assert
    Assert.IsTrue(trie.Search(word));
  }

  // Test that a word is not inserted twice in the trie
  [TestMethod]
  public void InsertWordTwice()
  {
    // Arrange
    Trie trie = new Trie();
    string word = "hello";

    // Act
    trie.Insert(word);
    trie.Insert(word);

    // Assert
    Assert.IsTrue(trie.Search(word));
  }

  // Test that a word is deleted from the trie
  [TestMethod]
  public void DeleteWord()
  {
    // Arrange
    Trie trie = new Trie();
    string word = "hello";

    // Act
    trie.Insert(word);
    trie.Delete(word);

    // Assert
    Assert.IsFalse(trie.Search(word));
  }

  // Test that a word is not deleted from the trie if it is not present
  [TestMethod]
  public void DeleteWordNotPresent()
  {
    // Arrange
    Trie trie = new Trie();
    string word = "hello";

    // Act
    trie.Delete(word);

    // Assert
    Assert.IsFalse(trie.Search(word));
  }

  // Test that a word is deleted from the trie if it is a prefix of another word
  [TestMethod]
  public void DeleteWordPrefix()
  {
    // Arrange
    Trie trie = new Trie();
    string word1 = "hello";
    string word2 = "hell";

    // Act
    trie.Insert(word1);
    trie.Insert(word2);
    trie.Delete(word2);

    // Assert
    Assert.IsTrue(trie.Search(word1));
    Assert.IsFalse(trie.Search(word2));
  }

  // Test AutoSuggest for the prefix "cat" not present in the trie containing "catastrophe", "catatonic", and "caterpillar"
  [TestMethod]
  public void AutoSuggestPrefixNotPresent()
  {
    // Arrange
    Trie trie = new Trie();
    trie.Insert("catastrophe");
    trie.Insert("catatonic");
    trie.Insert("caterpillar");

    // Act
    List<string> suggestions = trie.AutoSuggest("cat");

    // Assert
    Assert.AreEqual(3, suggestions.Count);
    Assert.AreEqual("catastrophe", suggestions[0]);
    Assert.AreEqual("catatonic", suggestions[1]);
    Assert.AreEqual("caterpillar", suggestions[2]);
  }

  [TestMethod]
  public void TestGetSpellingSuggestions()
  {
    Trie dictionary = new Trie();
    dictionary.Insert("cat");
    dictionary.Insert("caterpillar");
    dictionary.Insert("catastrophe");
    List<string> suggestions = dictionary.GetSpellingSuggestions("caterpiller");
    Assert.AreEqual(1, suggestions.Count);
    Assert.AreEqual("caterpillar", suggestions[0]);
  }



}