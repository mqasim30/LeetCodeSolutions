namespace LeetCode.PartitionArrayAccordingtoGivenPivot;

public class Solution
{
    public int[] PivotArray(int[] nums, int pivot)
    {
        int pivotCount = 0;
        List<int> greaterNums = new List<int>();
        List<int> r = new List<int>();
        for (int c = 0; c < nums.Length; c++)
        {
            if (nums[c] < pivot) r.Add(nums[c]);
            if (nums[c] == pivot) pivotCount++;
            if (nums[c] > pivot) greaterNums.Add(nums[c]);
        }
        while (pivotCount > 0)
        {
            r.Add(pivot);
            pivotCount--;
        }
        r.AddRange(greaterNums);
        return r.ToArray();
    }
}