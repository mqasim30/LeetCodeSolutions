namespace LeetCode.CountDaysWithoutMeetings;

public class Solution
{
    public int CountDays(int days, int[][] meetings)
    {
        var sortedMettings =
            meetings.OrderBy(row => row[0]).ThenBy(row => row[1]).ToArray();

        int d = 0;
        int end = sortedMettings[0][1];
        for (int i = 0; i < sortedMettings.Length; i++)
        {
            if (sortedMettings[i][0] > end)
                d += (sortedMettings[i][0] - end - 1);
            end = Math.Max(end, sortedMettings[i][1]);
        }
        d += (sortedMettings[0][0] - 1);
        d += (days - end);
        return d;
    }
}