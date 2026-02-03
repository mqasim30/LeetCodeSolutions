namespace LeetCode.DivideanArrayIntoSubarraysWithMinimumCostII;

public class Solution
{
    public long MinimumCost(int[] nums, int k, int dist)
    {
        long minSum = long.MaxValue;
        Window window = new Window(k - 2);
        for (int l = 1 + 1; l < Math.Min(1 + dist, nums.Length - 1); l++)
        {
            window.Insert(nums[l]);
        }
        for (int i = 1; i < nums.Length - (k - 2); ++i)
        {
            if (i + dist < nums.Length)
            {
                window.Insert(nums[i + dist]);
            }
            long temp = nums[0] + nums[i] + window.MinSum();
            minSum = Math.Min(minSum, temp);
            window.Remove(nums[i + 1]);
        }
        return minSum;
    }
    private class Window
    {
        List<long> list = new();
        public long sum = 0;
        private int minWinSize = 0;
        public Window(int minWinSize)
        {
            this.minWinSize = minWinSize;
        }
        public void Insert(int val)
        {
            int index = BinarySearch(val);
            if (index >= 0)
            {
                list.Insert(index, val);
            }
            else
            {
                list.Add(val);
                index = list.Count - 1;
            }
            if (index < minWinSize)
            {
                sum += list[index];
                if (minWinSize < list.Count)
                {
                    sum -= list[minWinSize];
                }
            }
        }
        public void Remove(int val)
        {
            int index = BinarySearch(val);
            if (index >= 0)
            {
                if (index < minWinSize)
                {
                    sum -= list[index];
                    if (minWinSize < list.Count)
                    {
                        sum += list[minWinSize];
                    }
                }
                list.RemoveAt(index);
            }
        }
        public long MinSum()
        {
            return this.sum;
        }
        public int BinarySearch(int val)
        {
            if (list.Count == 0)
            {
                return -1;
            }
            int l = 0, r = list.Count - 1;
            int mid = (l + r) / 2;
            if (val > list[r])
            {
                return -1;
            }
            while (l < r)
            {
                if (list[mid] < val)
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid;
                }
                mid = (l + r) / 2;
            }
            return r;
        }
    }
}