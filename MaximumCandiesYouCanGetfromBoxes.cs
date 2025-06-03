namespace LeetCode.MaximumCandiesYouCanGetfromBoxes;

public class Solution
{
    public int MaxCandies(int[] status, int[] candies, int[][] keys, int[][] containedBoxes, int[] initialBoxes)
    {
        int n = status.Length;
        bool[] canOpen = new bool[n];
        bool[] hasBox = new bool[n];
        bool[] used = new bool[n];

        for (int i = 0; i < n; ++i)
        {
            canOpen[i] = (status[i] == 1);
        }
        Queue<int> q = new Queue<int>();
        int ans = 0;
        foreach (int box in initialBoxes)
        {
            hasBox[box] = true;
            if (canOpen[box])
            {
                q.Enqueue(box);
                used[box] = true;
                ans += candies[box];
            }
        }

        while (q.Count > 0)
        {
            int bigBox = q.Dequeue();
            foreach (int key in keys[bigBox])
            {
                canOpen[key] = true;
                if (!used[key] && hasBox[key])
                {
                    q.Enqueue(key);
                    used[key] = true;
                    ans += candies[key];
                }
            }
            foreach (int box in containedBoxes[bigBox])
            {
                hasBox[box] = true;
                if (!used[box] && canOpen[box])
                {
                    q.Enqueue(box);
                    used[box] = true;
                    ans += candies[box];
                }
            }
        }

        return ans;
    }
}