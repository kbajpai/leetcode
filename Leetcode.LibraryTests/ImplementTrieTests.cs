using Leetcode;
using Xunit;

namespace LeetcodeTests;

public class ImplementTrieTests {
    [Fact]
    public void EmptyString_Behavior_IsHandled() {
        var trie = new Trie();

        // By design inserting empty string marks root as a word
        trie.Insert("");
        Assert.True(trie.Search(""));
        Assert.True(trie.StartsWith("")); // empty prefix should always be true

        // When nothing is inserted, startsWith("") should still be true
        var emptyTrie = new Trie();
        Assert.True(emptyTrie.StartsWith(""));
        Assert.False(emptyTrie.Search(""));
    }

    [Fact]
    public void InsertAndSearch_BasicOperations_WorksAsExpected() {
        var trie = new Trie();
        trie.Insert("apple");

        Assert.True(trie.Search("apple")); // exact match
        Assert.False(trie.Search("app")); // not inserted yet
        Assert.True(trie.StartsWith("app")); // prefix exists

        trie.Insert("app");
        Assert.True(trie.Search("app")); // now inserted
    }

    [Fact]
    public void MultipleWords_SharedPrefixes_WorkCorrectly() {
        var trie = new Trie();
        trie.Insert("abc");
        trie.Insert("abd");
        trie.Insert("b");

        Assert.True(trie.Search("abc"));
        Assert.True(trie.Search("abd"));
        Assert.True(trie.Search("b"));

        Assert.True(trie.StartsWith("a"));
        Assert.True(trie.StartsWith("ab"));
        Assert.False(trie.StartsWith("ac"));
    }

    [Fact]
    public void Search_NonExistentWords_ReturnsFalse() {
        var trie = new Trie();
        trie.Insert("hello");

        Assert.False(trie.Search("hell")); // prefix only, not full word
        Assert.False(trie.Search("helloo")); // not present
        Assert.True(trie.StartsWith("he")); // prefix present
    }
}