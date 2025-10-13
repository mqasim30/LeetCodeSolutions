namespace LeetCode.FindResultantArrayAfterRemovingAnagrams;

public class Solution
{
    public IList<string> RemoveAnagrams(string[] words)
    {
        List<string> result = new List<string>();

        foreach (string word in words)
        {
            if (result.Count == 0)
            {
                result.Add(word);
            }
            else
            {
                string prev = result[result.Count - 1];
                if (!IsAnagram(prev, word))
                {
                    result.Add(word);
                }
            }
        }

        return result;
    }
    private bool IsAnagram(string s1, string s2)
    {
        if (s1.Length != s2.Length) return false;
        char[] a = s1.ToCharArray();
        char[] b = s2.ToCharArray();
        Array.Sort(a);
        Array.Sort(b);
        return a.SequenceEqual(b);
    }
}