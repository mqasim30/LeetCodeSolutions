namespace LeetCode.UglyNumberII;

public class Solution
{
    public int NthUglyNumber(int n)
    {
        int[] primes = { 2, 3, 5 };
        var uglyHeap = new PriorityQueue<long, long>(); // PriorityQueue with long values
        var visited = new HashSet<long>();

        uglyHeap.Enqueue(1L, 1L); // Enqueue the first ugly number
        visited.Add(1L);

        long currentUgly = 1L;

        for (int i = 0; i < n; i++)
        {
            currentUgly = uglyHeap.Dequeue(); // Get the smallest ugly number from the heap

            foreach (int prime in primes)
            {
                long newUgly = currentUgly * prime;

                if (!visited.Contains(newUgly))
                {
                    uglyHeap.Enqueue(newUgly, newUgly);
                    visited.Add(newUgly);
                }
            }
        }

        return (int)currentUgly; // Convert the result to int before returning
    }
}
