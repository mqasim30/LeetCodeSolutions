namespace LeetCode.FindCommonCharacters
{
    public class Solution
    {
        private Dictionary<char, int> Counter(string word)
        {
            Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();

            foreach (char c in word)
            {
                if (keyValuePairs.ContainsKey(c))
                {
                    keyValuePairs[c] += 1;
                }
                else
                {
                    keyValuePairs[c] = 1;
                }
            }

            return keyValuePairs;
        }
        public IList<string> CommonChars(string[] words)
        {
            IList<string> result = new List<string>();
            Dictionary<char, int> initialDict = Counter(words[0]);

            foreach (string item in words)
            {
                Dictionary<char, int> keyValuePairs = Counter(item);
                initialDict = initialDict
                .Where(kvp => keyValuePairs.ContainsKey(kvp.Key))
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => Math.Min(kvp.Value, keyValuePairs[kvp.Key])
                );

            }
            foreach (var kvp in initialDict)
            {
                for (int i = 0; i < kvp.Value; i++)
                {
                    result.Add(kvp.Key.ToString());
                }
            }
            return result;
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         string[] words = ["acabcddd", "bcbdbcbd", "baddbadb", "cbdddcac", "aacbcccd", "ccccddda", "cababaab", "addcaccd"];
    //         IList<string> result = solution.CommonChars(words);
    //         foreach (var item in result)
    //         {
    //             Console.WriteLine(item);
    //         }
    //     }
    // }
}