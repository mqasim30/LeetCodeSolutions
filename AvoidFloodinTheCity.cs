namespace LeetCode.AvoidFloodinTheCity;

public class Solution
{
    public int[] AvoidFlood(int[] rains)
    {
        int len = rains.Length;
        int[] res = Enumerable.Repeat(1, len).ToArray();
        Dictionary<int, int> lakeFilled = new();
        List<int> dryDays = new();

        for (int i = 0; i < len; i++)
        {
            int cur = rains[i];

            if (cur == 0)
                dryDays.Add(i);
            else
            {
                if (lakeFilled.ContainsKey(cur))
                {
                    int fullDay = lakeFilled[cur];
                    int idx = dryDays.BinarySearch(fullDay);
                    if (idx < 0)
                        idx = ~idx;

                    if (idx >= dryDays.Count)
                        return new int[0];

                    int dryDay = dryDays[idx];
                    dryDays.RemoveAt(idx);
                    res[dryDay] = cur;
                    lakeFilled[cur] = i;
                }

                if (!lakeFilled.ContainsKey(cur))
                    lakeFilled.Add(cur, i);
                else
                    lakeFilled[cur] = i;

                res[i] = -1;
            }
        }

        return res;
    }
}