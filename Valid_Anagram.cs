namespace LeetCode.Valid_Anagram
{
    class Solution
    {
        public Dictionary<string, int> firstString = new Dictionary<string, int>();
        public Dictionary<string, int> secondString = new Dictionary<string, int>();

        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            MapString(s, firstString);
            MapString(t, secondString);

            bool isAnagram = firstString.OrderBy(kv => kv.Value).SequenceEqual(secondString.OrderBy(kv => kv.Value));
            return isAnagram;
        }

        public void MapString(string s, Dictionary<string, int> keyValuePairs)
        {
            foreach (char letter in s)
            {
                string l = letter.ToString();
                if (keyValuePairs.ContainsKey(l))
                {
                    keyValuePairs[l]++;
                }
                else
                {
                    keyValuePairs[l] = 1;
                }
            }
        }
    }

    class Program
    {
        // private static void Main(string[] args)
        // {
        //     Solution solution = new Solution();
        //     Console.WriteLine(solution.IsAnagram("anagram", "nagaram"));
        // }
    }
}