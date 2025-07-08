namespace Leetcode;

public class LargestWordCount {
    public static string RunLargestWordCount(string[] messages, string[] senders) {
        if (messages.Length == 1) {
            return senders[0];
        }

        var maxSender = string.Empty;
        long maxWordCount = 0;

        var senderStats = new Dictionary<string, long>();

        for (var i = 0; i < messages.Length; i++) {
            var wordCount = CountWords(messages[i]);
            var sender = senders[i];

            if (senderStats.TryGetValue(sender, out var currentCount)) {
                senderStats[sender] = currentCount + wordCount;
            }
            else {
                senderStats[sender] = wordCount;
            }

            var totalCount = senderStats[sender];
            if (totalCount > maxWordCount || (totalCount == maxWordCount && IsNameSorted(sender, maxSender))) {
                maxWordCount = totalCount;
                maxSender = sender;
            }
        }

        return maxSender;
    }

    private static int CountWords(string message) {
        if (message.Length == 0) return 0;

        var wordCount = 1;
        for (var i = 0; i < message.Length; i++) {
            if (message[i] == ' ') {
                wordCount++;
            }
        }

        return wordCount;
    }

    private static bool IsNameSorted(string s1, string s2) {
        var minLength = s1.Length < s2.Length ? s1.Length : s2.Length;

        for (var i = 0; i < minLength; i++) {
            if (s1[i] != s2[i]) {
                return s1[i] > s2[i];
            }
        }

        return s1.Length >= s2.Length;
    }
}