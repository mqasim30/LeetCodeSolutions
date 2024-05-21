using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace LeetCode.ClimbingStairs
{
    // My approach using recursion and memoization
    public class Solution
    {
        public int ClimbStairs(int n)
        {
            Dictionary<int, int> memo = new Dictionary<int, int>();
            return RecursiveSteps(n, 0, memo);
        }

        private int RecursiveSteps(int goal, int currentStep, Dictionary<int, int> memo)
        {
            if (currentStep == goal)
            {
                return 1; 
            }
            else if (currentStep > goal)
            {
                return 0;
            }
            if (memo.ContainsKey(currentStep))
            {
                return memo[currentStep]; 
            }

            int result = RecursiveSteps(goal, currentStep + 1, memo) + RecursiveSteps(goal, currentStep + 2, memo);
            memo[currentStep] = result;
            return result;
        }
    }


    // Super easy approach

    // public class Solution{
    //     public int ClimbStairs(int n){
    //         int oneStep = 1, twoStep = 1;
    //         for (int i = 0; i < n-1; i++)
    //         {
    //             oneStep = oneStep + twoStep;
    //             twoStep = oneStep - twoStep;
    //         }

    //         return oneStep;
    //     }
    // }

    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         Console.WriteLine(solution.ClimbStairs(44));
    //     }
    // }
}