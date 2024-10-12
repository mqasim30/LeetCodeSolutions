namespace LeetCode.TheNumberoftheSmallestUnoccupiedChair;

public class Solution
{
    public int SmallestChair(int[][] times, int targetFriend)
    {
        int n = times.Length;

        int[][] timesWithIndex = new int[n][];
        for (int i = 0; i < n; i++)
        {
            timesWithIndex[i] = new int[] { times[i][0], times[i][1], i };
        }

        Array.Sort(timesWithIndex, (a, b) => a[0].CompareTo(b[0]));

        bool[] occupied = new bool[n];
        int[] chairAssignment = new int[n];
        var leavingList = new List<Tuple<int, int>>();

        for (int i = 0; i < n; i++)
        {
            int arrivalTime = timesWithIndex[i][0];
            int leavingTime = timesWithIndex[i][1];
            int friendIndex = timesWithIndex[i][2];
            leavingList.RemoveAll(l =>
            {
                if (l.Item1 <= arrivalTime)
                {
                    occupied[l.Item2] = false;
                    return true;
                }
                return false;
            });
            int assignedChair = -1;
            for (int j = 0; j < n; j++)
            {
                if (!occupied[j])
                {
                    assignedChair = j;
                    occupied[j] = true;
                    break;
                }
            }
            chairAssignment[friendIndex] = assignedChair;
            if (friendIndex == targetFriend)
            {
                return assignedChair;
            }
            leavingList.Add(Tuple.Create(leavingTime, assignedChair));
        }
        return -1;
    }
}