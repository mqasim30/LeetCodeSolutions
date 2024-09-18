using System.Text;

namespace LeetCode.LargestNumber;
public class Solution
{
    // Custom comparator class that implements IComparer<string>
    public class CustomComparer : IComparer<string>
    {
#pragma warning disable CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
        public int Compare(string a, string b)
#pragma warning restore CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
        {
            // Compare concatenated strings in both possible orders
            string order1 = a + b;
            string order2 = b + a;
            // Return a negative value if order2 should come before order1, for descending sort
            return order2.CompareTo(order1);
        }
    }
    public string LargestNumber(int[] nums)
    {
        // Convert all integers to strings
        string[] strNums = nums.Select(n => n.ToString()).ToArray();

        // Sort the string numbers using the custom comparator
        Array.Sort(strNums, new CustomComparer());

        // If the largest number is "0", return "0"
        if (strNums[0] == "0")
        {
            return "0";
        }

        // Use StringBuilder to efficiently concatenate the sorted numbers
        StringBuilder largestNumber = new StringBuilder();
        foreach (var num in strNums)
        {
            largestNumber.Append(num);
        }

        // Return the concatenated result as a string
        return largestNumber.ToString();
    }
}