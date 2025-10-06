namespace Leetcode {
    public class Trie {
        private readonly Node _root = new();

        public void Insert(string word) {
            var node = _root;
            foreach (var c in word) {
                var idx = c - 'a';
                var child = node.Children[idx];
                if (child is null) {
                    child = new Node();
                    node.Children[idx] = child;
                }

                node = child;
            }

            node.IsWord = true;
        }

        public bool Search(string word) {
            var node = _root;
            foreach (var c in word) {
                var idx = c - 'a';
                node = node.Children[idx];
                if (node is null) {
                    return false;
                }
            }

            return node.IsWord;
        }

        public bool StartsWith(string prefix) {
            var node = _root;
            foreach (var ch in prefix) {
                var idx = ch - 'a';
                node = node.Children[idx];
                if (node is null) {
                    return false;
                }
            }

            return true;
        }

        private sealed class Node {
            public readonly Node?[] Children = new Node?[26];
            public bool IsWord;
        }
    }
}