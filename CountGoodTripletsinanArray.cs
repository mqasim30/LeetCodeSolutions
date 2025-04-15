namespace LeetCode.CountGoodTripletsinanArray;


public class Solution
{
    private int[] nums1, nums2, indices1;
    private int[] left, right;

    public long GoodTriplets(int[] nums1, int[] nums2)
    {
        int len = nums1.Length;
        this.nums1 = nums1;
        this.nums2 = nums2;

        // Create an array indices1 where indices1[nums1[i]] = i.
        indices1 = new int[len];
        for (int i = 0; i < len; ++i)
        {
            indices1[nums1[i]] = i;
        }

        // Arrays to store the count of valid triplets on the left and right side for each element in nums2.
        left = new int[len];
        right = new int[len];

        // Apply divide and conquer to fill left and right arrays.
        DivideAndConquer(0, len - 1);

        long output = 0L;
        for (int i = 0; i < len; ++i)
        {
            output += (long)left[i] * (long)right[i];
        }

        return output;
    }

    // This function recursively divides the range and fills the left and right count arrays.
    private void DivideAndConquer(int l, int r)
    {
        if (l == r)
        {
            return; // Base case, when the range is a single element.
        }

        // Divide the range into two halves
        int mid = l + (r - l) / 2;
        DivideAndConquer(l, mid);
        DivideAndConquer(mid + 1, r);

        // Create temporary arrays to store the left and right parts of nums2
        int[] temp1 = new int[mid - l + 1];
        int[] temp2 = new int[r - mid];

        Array.Copy(nums2, l, temp1, 0, mid - l + 1);
        Array.Copy(nums2, mid + 1, temp2, 0, r - mid);

        int[] temp = new int[r - l + 1];

        // Merging step: populate left[]
        int i = 0, j = 0, k = 0;
        while (i < temp1.Length && j < temp2.Length)
        {
            if (indices1[temp1[i]] < indices1[temp2[j]])
            {
                temp[k] = temp1[i];
                ++i;
            }
            else
            {
                temp[k] = temp2[j];
                left[temp2[j]] += i; // Count how many elements before temp2[j] in nums2
                ++j;
            }
            ++k;
        }

        // Copy remaining elements from temp1, if any
        while (i < temp1.Length)
        {
            temp[k] = temp1[i];
            ++i;
            ++k;
        }

        // Copy remaining elements from temp2, if any
        while (j < temp2.Length)
        {
            temp[k] = temp2[j];
            left[temp2[j]] += i; // Count how many elements before temp2[j] in nums2
            ++j;
            ++k;
        }

        // Copy the merged array back to nums2
        Array.Copy(temp, 0, nums2, l, r - l + 1);

        // Now, fill the right[] array using a reverse merge process
        i = temp1.Length - 1;
        j = temp2.Length - 1;
        k = temp.Length - 1;
        while (i >= 0 && j >= 0)
        {
            if (indices1[temp1[i]] > indices1[temp2[j]])
            {
                right[temp1[i]] += temp2.Length - j - 1; // Count how many elements after temp1[i] in nums2
                --i;
            }
            else
            {
                --j;
            }
        }

        // If there are remaining elements in temp1
        while (i >= 0)
        {
            right[temp1[i]] += temp2.Length - j - 1;
            --i;
        }
    }
}