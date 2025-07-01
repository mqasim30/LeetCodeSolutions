namespace LeetCode.FindtheLexicographicallyLargestStringFromtheBoxI;

public class Solution
{
    public string AnswerString(string word, int numFriends)
    {
        if (numFriends == 1)
        {
            return word;
        }
        int n = word.Length;
        string res = "";
        for (int i = 0; i < n; i++)
        {
            string s = word.Substring(i, Math.Min(n - numFriends + 1, n - i));
            if (string.Compare(res, s) <= 0)
            {
                res = s;
            }
        }
        return res;
    }
}