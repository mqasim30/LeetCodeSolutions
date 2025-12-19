namespace LeetCode.FindAllPeopleWithSecret;

public class Solution
{
    public IList<int> FindAllPeople(int n, int[][] meetings, int firstPerson)
    {
        int[] groups = new int[n];
        List<int> result = new List<int>();

        for (int k = 0; k < n; k++)
        {
            groups[k] = k;
        }
        groups[firstPerson] = 0;

        Array.Sort(meetings, (a, b) => a[2].CompareTo(b[2]));

        List<int> temp = new List<int>();
        int i = 0;
        while (i < meetings.Length)
        {
            int currentTime = meetings[i][2];
            temp.Clear();
            while (i < meetings.Length && meetings[i][2] == currentTime)
            {
                int g1 = Find(groups, meetings[i][0]);
                int g2 = Find(groups, meetings[i][1]);
                groups[Math.Max(g1, g2)] = Math.Min(g1, g2);
                temp.Add(meetings[i][0]);
                temp.Add(meetings[i][1]);
                i++;
            }
            foreach (int item in temp)
            {
                if (Find(groups, item) != 0)
                {
                    groups[item] = item;
                }
            }
        }

        for (int j = 0; j < n; j++)
        {
            if (Find(groups, j) == 0)
            {
                result.Add(j);
            }
        }

        return result;
    }

    private int Find(int[] groups, int index)
    {
        while (index != groups[index])
        {
            index = groups[index];
        }
        return index;
    }
}