namespace LeetCode.SortanArray;

public class Solution
{
    public int[] SortArray(int[] nums)
    {
        MergeSort(nums, 0, nums.Length - 1);
        return nums;
    }

    private void MergeSort(int[] array, int low, int high)
    {
        if (low >= high)
        {
            return;
        }
        int mid = low + (high - low) / 2;
        MergeSort(array, low, mid);
        MergeSort(array, mid + 1, high);
        Merge(array, low, mid, high);
    }

    private void Merge(int[] array, int low, int mid, int high)
    {
        int n1 = mid - low + 1;
        int n2 = high - mid;
        int[] leftPart = new int[n1];
        int[] rightPart = new int[n2];

        Array.Copy(array, low, leftPart, 0, n1);
        Array.Copy(array, mid + 1, rightPart, 0, n2);

        int p1 = 0, p2 = 0, writeInd = low;
        while (p1 < n1 && p2 < n2)
        {
            if (leftPart[p1] <= rightPart[p2])
            {
                array[writeInd++] = leftPart[p1++];
            }
            else
            {
                array[writeInd++] = rightPart[p2++];
            }
        }

        while (p1 < n1)
        {
            array[writeInd++] = leftPart[p1++];
        }

        while (p2 < n2)
        {
            array[writeInd++] = rightPart[p2++];
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] nums = [8, 9, 4, 0, 2, 1, 3, 5, 7, 6];
        var answer = solution.SortArray(nums);
        foreach (var item in answer)
        {
            Console.WriteLine("Result = " + item);
        }
    }
}