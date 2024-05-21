namespace LeetCode.Group_Anagram_Another
{
    public class Solution
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            int[] saphabet = new int[26];
            foreach (char c in s)
            {
                saphabet[c - 'a']++;
            }
            foreach (char c in t)
            {
                if (saphabet[c - 'a'] > 0)
                {
                    saphabet[c - 'a']--;
                }
                else
                {
                    return false;
                }
            }
            return true;

        }
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> anagramGroups = new Dictionary<string, List<string>>();

            foreach (string str in strs)
            {
                char[] charArray = str.ToCharArray();
                Array.Sort(charArray);
                string sortedStr = new string(charArray);

                Console.WriteLine($"Original String: {str}, Sorted String: {sortedStr}");

                if (!anagramGroups.ContainsKey(sortedStr))
                {
                    anagramGroups[sortedStr] = new List<string>();
                    Console.WriteLine($"Creating new list for sorted string: {sortedStr}");
                }

                anagramGroups[sortedStr].Add(str);
                Console.WriteLine($"Adding {str} to list for sorted string: {sortedStr}");

                Console.WriteLine("Current state of anagram groups:");
                foreach (var kvp in anagramGroups)
                {
                    Console.WriteLine($"Sorted String: {kvp.Key}, Anagrams: [{string.Join(", ", kvp.Value)}]");
                }
                Console.WriteLine();

            }
            return anagramGroups.Values.ToList<IList<string>>();
        }
    // static void Main(string[] args)
    // {
    //     string[] strs = ["",""];
    //     Solution solution = new Solution();
    //     IList<IList<string>> groupedAnagrams = solution.GroupAnagrams(strs);
    //     foreach (var group in groupedAnagrams)
    //     {
    //         Console.WriteLine("Anagram Group:");
    //         foreach (string str in group)
    //         {
    //             Console.WriteLine($"[{str}]");
    //         }
    //         Console.WriteLine();
    //     }
    // }
    }
}