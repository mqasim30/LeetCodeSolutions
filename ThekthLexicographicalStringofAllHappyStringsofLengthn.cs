namespace LeetCode.ThekthLexicographicalStringofAllHappyStringsofLengthn;

public class Solution
{
    public string GetHappyString(int n, int k)
    {

        var happyStrings = new List<string>();
        var chars = new char[] { 'a', 'b', 'c' };

        void GenerateHappyStrings(int index, string current)
        {
            if (current.Length == n)
            {
                happyStrings.Add(current);
                return;
            }

            foreach (var c in chars)
            {
                if (current.Length == 0 || current[current.Length - 1] != c)
                {
                    GenerateHappyStrings(index + 1, current + c);
                }
            }
        }

        GenerateHappyStrings(0, string.Empty);

        return k > happyStrings.Count ? string.Empty : happyStrings[k - 1];

    }
}