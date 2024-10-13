namespace LeetCode.SmallestRangeCoveringElementsfromKLists;

public class Solution
{
    public int[] SmallestRange(IList<IList<int>> nums)
    {
        // Create a priority queue to store points, sorted by their values
        PriorityQueue<Point, Point> pq = new(new SortComparer());

        // Initialize the answer array with default values
        int[] ans = [0, Int32.MaxValue];

        // Keep track of the maximum value in the current range
        int max = Int32.MinValue;

        // Initialize the priority queue with the first element from each list
        for (int i = 0; i < nums.Count; i++)
        {
            Point p = new Point(i, 0, nums[i][0]);
            max = Math.Max(max, nums[i][0]);
            pq.Enqueue(p, p);
        }

        while (true)
        {
            // Get the point with the smallest value from the queue
            Point curr = pq.Dequeue();

            // Update the answer if the current range is smaller
            if (ans[1] - ans[0] > max - curr.val)
            {
                ans[0] = curr.val;
                ans[1] = max;
            }

            int row = curr.i;
            int col = curr.j + 1;

            // If there are more elements in the current list
            if (col < nums[row].Count)
            {
                // Update the maximum value
                max = Math.Max(max, nums[row][col]);

                // Create a new point for the next element and add it to the queue
                Point n = new Point(row, col, nums[row][col]);
                pq.Enqueue(n, n);
            }
            else
                // If we've reached the end of a list, we're done
                break;
        }

        return ans;
    }
}

// Class to represent a point in the 2D list
public class Point
{
    public int val; // The value at this point
    public int j;   // The column index
    public int i;   // The row index (list number)

    public Point(int a, int b, int c)
    {
        i = a;
        j = b;
        val = c;
    }
}

// Custom comparer for the priority queue to sort points by their values
public class SortComparer : IComparer<Point>
{
#pragma warning disable CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
    public int Compare(Point a, Point b)
#pragma warning restore CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
    {
        return a.val - b.val;
    }
}