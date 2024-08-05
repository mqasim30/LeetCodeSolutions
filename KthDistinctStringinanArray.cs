namespace LeetCode.KthDistinctStringinanArray;
public class Solution
{
    public string KthDistinct(string[] arr, int k)
    {
        Dictionary<string, int> keyValuePairs = new();
        
        foreach (var item in arr)
        {
            if (!keyValuePairs.TryAdd(item, 1))
            {
                keyValuePairs[item]++;
            }
        }

        var distinctElements = keyValuePairs
                                .Where(kv => kv.Value == 1)
                                .Select(kv => kv.Key)
                                .ToList();

        return k > distinctElements.Count ? "" : distinctElements[k - 1];
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Solution solution = new();
        string[] arr = ["d", "b", "c", "b", "c", "a"];
        int k = 2;
        Console.WriteLine(solution.KthDistinct(arr, k));
    }
}