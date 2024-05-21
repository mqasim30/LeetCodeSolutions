namespace LeetCode.ValidParentheses
{
    public class Solution
    {
        public bool IsValid(string s)
        {
            Stack<char> parantheses = new Stack<char>();
            Dictionary<char, char> keyValuePairs = new Dictionary<char, char>(){
            {'}', '{'},
            {')','('},
            {']','['}
        };
            if (s.Length <= 1)
            {
                return false;
            }
            foreach (char ch in s)
            {
                if (keyValuePairs.ContainsKey(ch))
                {
                    char c = ' ';
                    if (parantheses.Count != 0)
                    {
                        c = parantheses.Pop();
                    }
                    else
                    {
                        return false;
                    }
                    if (keyValuePairs[ch] == c)
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    parantheses.Push(ch);
                }
            }
            if (parantheses.Count != 0)
            {
                return false;
            }
            return true;
        }

        // public static void Main(string[] args)
        // {
        //     Solution solution = new Solution();
        //     Console.WriteLine(solution.IsValid("({"));
        // }
    }
}