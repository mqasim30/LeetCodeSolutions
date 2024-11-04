using System.Text;

namespace LeetCode.StringCompressionIII;

public class Solution
{
    public string CompressedString(string word)
    {
        // Handle empty string case
        if (string.IsNullOrEmpty(word)) return "";

        // Initialize result StringBuilder for efficient string concatenation
        StringBuilder comp = new StringBuilder(word.Length * 2);

        // Initialize counter and first character
        int cnt = 1;
        char ch = word[0];

        // Iterate through string starting from second character
        for (int i = 1; i < word.Length; i++)
        {
            // If current character matches previous and count < 9
            // increment counter
            if (word[i] == ch && cnt < 9)
            {
                cnt++;
            }
            // If character changes or count reaches 9
            // append count and character to result
            else
            {
                comp.Append((char)(cnt + '0')); // Convert count to character and append
                comp.Append(ch);                // Append the character
                ch = word[i];                   // Update current character
                cnt = 1;                        // Reset counter for new character
            }
        }

        // Handle the last group of characters
        comp.Append((char)(cnt + '0')); // Append final count
        comp.Append(ch);                // Append final character

        return comp.ToString();
    }
}