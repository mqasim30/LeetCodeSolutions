namespace LeetCode.MoveZeroes;

public class Solution
{
    public void MoveZeroes(int[] nums)
    {
        if (nums.Length <= 1)
        {
            return;
        }
        int left = 0;
        for (int right = 0; right < nums.Length; right++)
        {
            if (nums[right] != 0)
            {
                if (left != right)
                {
                    (nums[left], nums[right]) = (nums[right], nums[left]);
                }
                left++;
            }
        }
    }
}

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         int[] nums = [1, 2, 0, 3, 12];
//         solution.MoveZeroes(nums);
//     }
// }
