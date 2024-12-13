namespace LeetCode.FindScoreofanArrayAfterMarkingAllElements;

// This is my first experiment using Sorting

public class Solution
{
    public long FindScore(int[] nums)
    {

        int n = nums.Length;
        long score = 0;
        // Create list to hold tuples of value, index from the nums array
        var m = new List<(int value, int index)>(n);

        // Populate the list with tuples
        for (int i = 0; i < n; i++)
        {
            m.Add((nums[i], i));
        }
        // Sort the list of tuples by value and if values are equal, sort by index
        m.Sort((a, b) =>
        {
            if (a.value == b.value)
            {
                return a.index.CompareTo(b.index);
            }
            else
            {
                return a.value.CompareTo(b.value);
            }
        });

        // Mark that already considered for scoring
        // Can use HashSet<int> if it need to frequently add and remove values
        // I only need to mark
        var marked = new bool[n];

        // Iterate through the sorted list of values
        foreach (var (value, idx) in m)
        {
            // If it has already been marked, just skip
            if (marked[idx])
            {
                continue;
            }
            score += value;
            // Mark the current index as used
            marked[idx] = true;

            // Mark the neighboring elements left and right as used if exist
            for (int i = idx - 1; i <= idx + 1; i++)
            {
                // Ensure the index is within bounds and hasn't been marked already
                if (i >= 0 && i < n && !marked[i])
                {
                    marked[i] = true;
                }
            }
        }
        return score;
    }
}