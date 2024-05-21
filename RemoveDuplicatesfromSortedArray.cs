namespace LeetCode.RemoveDuplicatesfromSortedArray
{
    public class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            int uniqueIndex = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                bool isDuplicate = false;
                Console.WriteLine("i: "+i);
                Console.WriteLine("unique index: "+uniqueIndex);
                for (int j = 0; j < uniqueIndex; j++)
                {
                    Console.WriteLine("j: "+j);


                    Console.WriteLine("Comparing "+ nums[i] + " and " + nums[j]);
                    if (nums[i] == nums[j])
                    {
                        Console.WriteLine("Found Duplicate");
                        isDuplicate = true;
                        break;
                    }
                }
                if (!isDuplicate)
                {
                    Console.WriteLine("UniqueIndex before: "+ uniqueIndex);
                    nums[uniqueIndex] = nums[i];
                    uniqueIndex++;
                    Console.WriteLine("UniqueIndex after: "+ uniqueIndex);
                }
            }
            Array.Resize(ref nums, uniqueIndex);
            Console.WriteLine("Array after removing duplicates in place:");
            Console.WriteLine(string.Join(", ", nums));
            return nums.Length;
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         int[] nums = [0,3,1,1,0,2,2,4,3,3,4];
    //         Console.WriteLine(solution.RemoveDuplicates(nums));
    //     }
    // }

}
