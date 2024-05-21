namespace LeetCode.GroupAnagram
{
    public class Solution
    {
        public bool IsAnagram(string s, string t)
        {
            Console.WriteLine("Checking if is anagram");
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
            Console.WriteLine("It is an anagram");
            return true;
    
        }
    
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IList<IList<string>> output = new List<IList<string>>();
            HashSet<string> groupedWords = new HashSet<string>();
    
            for (int i = 0; i < strs.Length; i++)
            {
                if (!groupedWords.Contains(strs[i]))
                {
                    List<string> group = new List<string>();
                    group.Add(strs[i]);
                    groupedWords.Add(strs[i]);
                    for (int j = i + 1; j < strs.Length; j++)
                    {
                        if (IsAnagram(strs[i], strs[j]))
                        {
                            Console.WriteLine("Adding to list");
                            group.Add(strs[j]);
                            groupedWords.Add(strs[j]);
                        }
                    }
                    output.Add(new List<string>(group));
                }
            }
    
            return output;
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