namespace LeetCode.ConstructStringWithRepeatLimit;

public class Solution
{
    public string RepeatLimitedString(string s, int repeatLimit)
    {
        int[] freq = new int[26];
        foreach (char c in s)
        {
            freq[c - 'a']++;
        }

        StringBuilder result = new StringBuilder();

        int currentIndex = 25;
        while (true)
        {
            int added = 0;

            while (currentIndex >= 0 && freq[currentIndex] > 0 && added < repeatLimit)
            {
                result.Append((char)(currentIndex + 'a'));
                freq[currentIndex]--;
                added++;
            }

            if (freq[currentIndex] > 0)
            {
                int nextIndex = currentIndex - 1;
                while (nextIndex >= 0 && freq[nextIndex] == 0)
                {
                    nextIndex--;
                }

                if (nextIndex < 0) break;

                result.Append((char)(nextIndex + 'a'));
                freq[nextIndex]--;

            }
            else
            {
                currentIndex--;
                while (currentIndex >= 0 && freq[currentIndex] == 0)
                {
                    currentIndex--;
                }

                if (currentIndex < 0) break;
            }
        }

        return result.ToString();
    }
}