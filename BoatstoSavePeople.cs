namespace LeetCode.BoatstoSavePeople
{
    public class Solution
    {
        public int NumRescueBoats(int[] people, int limit)
        {
            Array.Sort(people);
            int boatsCount = 0;
            int left = 0;
            int right = people.Length - 1;

            while (left <= right)
            {
                if (people[left] + people[right] <= limit)
                {
                    left++;
                }
                right--; 
                boatsCount++; 
            }
            Console.WriteLine(boatsCount);
            return boatsCount;
        }
    }

    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         int[] nums = [21, 40, 16, 24, 30];
    //         // 16, 21, 24, 30, 40
    //         solution.NumRescueBoats(nums, 50);
    //     }
    // }
}