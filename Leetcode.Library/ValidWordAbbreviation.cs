using System.Text;

namespace Leetcode {
    public abstract class ValidWordAbbreviation {
        public static bool RunValidWordAbbreviation(string word, string abbr) {
            var nw = word.Length;
            var na = abbr.Length;

            var iw = 0;
            var ia = 0;

            while (ia < na && iw < nw) {
                if (char.IsLetter(abbr[ia])) {
                    // If characters don't match, return false
                    if (abbr[ia] != word[iw]) {
                        return false;
                    }

                    ia++;
                    iw++;
                }
                else if (char.IsDigit(abbr[ia])) {
                    // Check for leading zero - invalid abbreviation
                    if (abbr[ia] == '0') {
                        return false;
                    }

                    // Parse the number
                    var sb = new StringBuilder();
                    while (ia < na && char.IsDigit(abbr[ia])) {
                        sb.Append(abbr[ia]);
                        ia++;
                    }

                    var skipCount = int.Parse(sb.ToString());

                    // Skip the specified number of characters in word
                    iw += skipCount;

                    // Check if we've gone beyond the word length
                    if (iw > nw) {
                        return false;
                    }
                }
                else {
                    // Invalid character in abbreviation
                    return false;
                }
            }

            // Both pointers should reach the end of their respective strings
            return ia == na && iw == nw;
        }
    }
}