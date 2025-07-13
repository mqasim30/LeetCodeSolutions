namespace LeetCode.MaximumMatchingofPlayersWithTrainers;

public class Solution
{
    public int MatchPlayersAndTrainers(int[] players, int[] trainers)
    {
        Array.Sort(players);
        Array.Sort(trainers);
        int count = 0;
        int i = 0;
        int j = 0;
        while (i < players.Count() && j < trainers.Count())
        {
            if (players[i] <= trainers[j])
            {
                j++; i++;
                count++;
            }
            else
            {
                j++;
            }
        }
        return count;
    }
}