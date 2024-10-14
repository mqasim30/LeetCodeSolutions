namespace LeetCode.MaximalScoreAfterApplyingKOperations;
public class Solution
{
    public long MaxKelements(int[] nums, int k)
    {

        // Create a max heap using a priority queue
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b - a));

        // Add elements to the priority queue
        foreach (int x in nums)
        {
            pq.Enqueue(x, x);
        }

        long score = 0;

        // Process the queue while there are elements and k is greater than 0
        while (pq.Count > 0 && k > 0)
        {
            int x = pq.Dequeue();
            score += x;

            // Add the next element as the ceiling of x/3
            int newElement = (int)Math.Ceiling(x / 3.0);
            pq.Enqueue(newElement, newElement);

            k--;
        }

        return score;


    }
}