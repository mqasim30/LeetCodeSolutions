
namespace LeetCode.PalindromePartitioning
{
    public class Solution
    {
        public IList<IList<string>> Partition(string s)
        {
            List<IList<string>> result = new List<IList<string>>();
            backtrack(s, 0, new List<string>(), result);
            return result;
        }

        private bool IsPalindrome(string s, int left, int right)
        {
            while (left < right)
            {
                if (s[left++] != s[right--])
                {
                    return false;
                }
            }
            return true;
        }

        private void backtrack(string s, int start, List<string> path, List<IList<string>> result)
        {
            if (start == s.Length)
            {
                result.Add(new List<string>(path));
                return;
            }
            for (int end = start + 1; end <= s.Length; end++)
            {
                if (IsPalindrome(s, start, end - 1))
                {
                    path.Add(s.Substring(start, end - start));
                    backtrack(s, end, path, result);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();
            string s = "aab";
            IList<IList<string>> answer = solution.Partition(s);
            foreach (var item in answer)
            {
                Console.WriteLine(answer);
            }
        }
    }
}