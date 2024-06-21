namespace LeetCode.GrumpyBookStoreOwner;
public class Solution
{
    public int MaxSatisfied(int[] customers, int[] grumpy, int minutes)
    {
        int result = 0;
        int maxSum = 0;
        int tempSum = 0;

        for (int i = 0; i < customers.Length; i++)
        {
            if (grumpy[i] == 0)
            {
                result += customers[i];
            }
        }

        for (int i = 0; i < minutes; i++)
        {
            if (grumpy[i] == 1)
            {
                tempSum += customers[i];
            }
        }
        
        maxSum = tempSum;

        Console.WriteLine("Initial Sum: " + maxSum);

        for (int i = minutes; i < customers.Length; i++)
        {
            if (grumpy[i - minutes] == 1)
            {
                Console.WriteLine($"Found 1 in upper loop at {i - minutes}");
                tempSum -= customers[i - minutes];
                Console.WriteLine(tempSum);
            }
            if (grumpy[i] == 1)
            {
                Console.WriteLine($"Found 1 in lower loop at {i}");
                tempSum += customers[i];
                Console.WriteLine(tempSum);
            }
            Console.WriteLine($"{tempSum}, {maxSum}");
            maxSum = Math.Max(tempSum, maxSum);
            Console.WriteLine("maxSum = " + maxSum);
        }

        return result + maxSum;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] customers = [1, 0, 1, 2, 1, 1, 7, 5], grumpy = [0, 1, 0, 1, 0, 1, 0, 1];
        int minutes = 3;
        Console.WriteLine(solution.MaxSatisfied(customers, grumpy, minutes));
    }
}
