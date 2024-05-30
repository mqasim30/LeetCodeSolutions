namespace LeetCode.CountTripletsThatCanFormTwoArraysofEqualXOR
{
    public class Solution
    {
        public int CountTriplets(int[] arr)
        {
            int arrayLength = arr.Length;
            int result = 0;
            int xorResult = 0;
            for (int i = 0; i < arrayLength - 1; i++)
            {
                xorResult = arr[i];
                for (int j = i + 1; j < arrayLength; j++)
                {
                    xorResult ^= arr[j];
                    if (xorResult == 0)
                    {
                        result += j - i;
                    }
                }
            }
            return result;
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         int[] arr = [2, 3, 1, 6, 7];
    //         Console.WriteLine(solution.CountTriplets(arr));
    //     }
    // }
}