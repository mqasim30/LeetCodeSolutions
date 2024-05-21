namespace LeetCode.RomanToInteger
{
    public class Solution
    {
        public int RomanToInt(string s)
        {
            Dictionary<char, int> romanNumerals = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

            int sum = 0;
            int previous = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (previous == 0)
                {
                    sum += romanNumerals[s[i]];
                    previous = romanNumerals[s[i]];
                }
                else
                {
                    if (romanNumerals[s[i]] > previous)
                    {
                        sum -= previous;
                        sum += romanNumerals[s[i]] - previous;
                    }
                    else
                    {
                        sum += romanNumerals[s[i]];
                        previous = romanNumerals[s[i]];
                    }
                }
            }
            return sum;
        }
    }
}