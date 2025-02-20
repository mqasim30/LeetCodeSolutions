namespace LeetCode.FindUniqueBinaryString;
using System.Text;
public class Solution
{
    public string FindDifferentBinaryString(string[] nums)
    {
        var n = nums.Length;
        var set = new HashSet<string>(nums);
        var sb = new StringBuilder();

        for (var i = 0; i < n; i++)
        {
            sb.Append(nums[i][i] == '0' ? '1' : '0');
        }

        var result = sb.ToString();
        return set.Contains(result) ? string.Empty : result;
    }
}