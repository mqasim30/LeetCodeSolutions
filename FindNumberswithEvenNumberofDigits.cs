namespace LeetCode.FindNumberswithEvenNumberofDigits;

public class Solution
{
    public int FindNumbers(int[] nums) => nums.Count(d => d.ToString().Length % 2 == 0);

}