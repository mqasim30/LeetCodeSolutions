namespace LeetCode.UniqueNumberofOccurrences;
public class Solution
{
    public bool UniqueOccurrences(int[] arr)
    {
        Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
        HashSet<int> ints = new HashSet<int>();

        foreach (var item in arr)
        {
            if (keyValuePairs.ContainsKey(item))
            {
                keyValuePairs[item] += 1;
            }
            else
            {
                keyValuePairs.Add(item, 1);
            }
        }

        foreach (var item in keyValuePairs)
        {
            if (!ints.Contains(item.Value))
            {
                ints.Add(item.Value);
            }
            else
            {
                return false;
            }
        }
        return true;
    }
}
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         int[] arr = [-3, 0, 1, -3, 1, 1, 1, -3, 10, 0];
//         System.Console.WriteLine(solution.UniqueOccurrences(arr));
//     }
// }


