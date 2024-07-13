namespace LeetCode.DetermineifTwoStringsAreClose;

public class Solution
{
    public bool CloseStrings(string word1, string word2)
    {
        if (word1.Length != word2.Length)
        {
            return false;
        }

        Dictionary<char, int> keyValuePairs1 = new Dictionary<char, int>();
        Dictionary<char, int> keyValuePairs2 = new Dictionary<char, int>();


        for (int i = 0; i < word1.Length; i++)
        {
            if (!keyValuePairs1.TryAdd(word1[i], 1))
            {
                keyValuePairs1[word1[i]]++;
            }
            if (!keyValuePairs2.TryAdd(word2[i], 1))
            {
                keyValuePairs2[word2[i]]++;
            }

        }

        foreach (var item in keyValuePairs1)
        {
            if (!keyValuePairs2.ContainsKey(item.Key))
            {
                return false;
            }
        }

        List<int> sortedSet1 = keyValuePairs1.Values.OrderByDescending(x => x).ToList();
        List<int> sortedSet2 = keyValuePairs2.Values.OrderByDescending(x => x).ToList();

        return sortedSet1.SequenceEqual(sortedSet2);
    }
}
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         string word1 = "cabbba", word2 = "abbccc";
//         Console.WriteLine(solution.CloseStrings(word1, word2));
//     }
// }


