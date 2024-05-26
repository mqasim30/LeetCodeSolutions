namespace LeetCode.WordBreakII
{
    public class Solution
    {
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            HashSet<string> wordSet = new HashSet<string>(wordDict);
            List<string> res = new List<string>();
            List<string> cur = new List<string>();

            void Backtrack(int i)
            {
                if (i == s.Length)
                {
                    res.Add(string.Join(" ", cur));
                    return;
                }
                for (int j = i; j < s.Length; j++)
                {
                    string w = s.Substring(i, j - i + 1);
                    if (wordSet.Contains(w))
                    {
                        cur.Add(w);
                        Backtrack(j + 1);
                        cur.RemoveAt(cur.Count - 1);
                    }
                }
            }
            Backtrack(0);
            return res;
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         string s = "catsanddog";
    //         IList<string> wordDict = ["apple", "pen", "applepen", "pine", "pineapple"];
    //         IList<string> result = solution.WordBreak(s, wordDict);
    //         foreach (var item in result)
    //         {
    //             Console.WriteLine(item);
    //         }
    //     }
    //}
}