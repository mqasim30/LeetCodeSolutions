namespace LeetCode.RelativeArraySort;
public class Solution
{
    public int[] RelativeSortArray(int[] arr1, int[] arr2)
    {
        Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
        List<int> result = new List<int>();
        for (int i = 0; i < arr1.Length; i++)
        {
            if (keyValuePairs.ContainsKey(arr1[i]))
            {
                keyValuePairs[arr1[i]] += 1;
            }
            else
            {
                keyValuePairs[arr1[i]] = 1;
            }
        }

        for (int i = 0; i < arr2.Length; i++)
        {
            if (keyValuePairs.ContainsKey(arr2[i]))
            {
                while (keyValuePairs[arr2[i]] != 0)
                {
                    result.Add(arr2[i]);
                    keyValuePairs[arr2[i]] -= 1;
                }
                keyValuePairs.Remove(arr2[i]);
            }
        }

        var SortedDict = keyValuePairs.OrderBy(kv => kv.Key).ToDictionary();
        foreach (var item in SortedDict)
        {
            for (int count = 0; count < item.Value; count++)
            {
                result.Add(item.Key);
            }
        }
        return result.ToArray();
    }
}

// public class Program
// {
//     static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         int[] arr1 = [2, 3, 1, 3, 2, 4, 6, 19, 7, 9, 2], arr2 = [2, 1, 4, 3, 9, 6];
//         Console.WriteLine(solution.RelativeSortArray(arr1, arr2));
//     }
// }
