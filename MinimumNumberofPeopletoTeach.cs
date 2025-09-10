namespace LeetCode.MinimumNumberofPeopletoTeach;

public class Solution
{
    public int MinimumTeachings(int n, int[][] languages, int[][] friendships)
    {
        HashSet<int> cncon = new HashSet<int>();
        foreach (var friendship in friendships)
        {
            HashSet<int> mp = new HashSet<int>();
            bool conm = false;
            foreach (var lan in languages[friendship[0] - 1])
            {
                mp.Add(lan);
            }
            foreach (var lan in languages[friendship[1] - 1])
            {
                if (mp.Contains(lan))
                {
                    conm = true;
                    break;
                }
            }
            if (!conm)
            {
                cncon.Add(friendship[0] - 1);
                cncon.Add(friendship[1] - 1);
            }
        }

        int max_cnt = 0;
        int[] cnt = new int[n + 1];
        foreach (var person in cncon)
        {
            foreach (var lan in languages[person])
            {
                cnt[lan]++;
                max_cnt = Math.Max(max_cnt, cnt[lan]);
            }
        }
        return cncon.Count - max_cnt;
    }
}