namespace LeetCode.FindWordsContainingCharacter;

public class Solution
{
    public IList<int> FindWordsContaining(string[] words, char x)
    {

        List<int> res = new List<int>();
        int n = words.Length;
        for (int i = 0; i < n; i++)
        {
            if (words[i].Contains(x))
            {
                res.Add(i);
            }
        }
        return res;
    }
}