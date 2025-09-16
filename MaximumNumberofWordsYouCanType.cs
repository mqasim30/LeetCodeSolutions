namespace LeetCode.MaximumNumberofWordsYouCanType;
public class Solution
{
    public int CanBeTypedWords(string text, string brokenLetters)
    {
        HashSet<char> brokenSet = new HashSet<char>(brokenLetters);
        string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int count = 0;
        foreach (string w in words)
        {
            bool canType = true;
            foreach (char c in w)
            {
                if (brokenSet.Contains(c))
                {
                    canType = false;
                    break;
                }
            }

            if (canType)
                count++;
        }

        return count;
    }
}