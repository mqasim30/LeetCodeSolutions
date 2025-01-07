namespace LeetCode.StringMatchinginanArray;

public class Solution
{
    public IList<string> StringMatching(string[] words)
    {
        List<string> result = new();
        HashSet<string> set = new();

        for (int i = 0; i < words.Length; i++)
        {
            for (int j = 0; j < words.Length; j++)
            {
                if (i == j)
                {
                    continue;
                }

                if (words[j].Contains(words[i]))
                {
                    set.Add(words[i]);
                }
            }
        }

        result.AddRange(set);
        return result;
    }
}
