namespace LeetCode.DividePlayersIntoTeamsofEqualSkill;

public class Solution
{
    public long DividePlayers(int[] skill)
    {
        long totalSkill = 0;
        foreach (int s in skill)
        {
            totalSkill += s;
        }

        int n = skill.Length;

        if (totalSkill % (n / 2) != 0)
        {
            return -1;
        }

        long targetSkill = totalSkill / (n / 2);

        Dictionary<int, int> skillCount = new Dictionary<int, int>();
        long totalChemistry = 0;

        foreach (int s in skill)
        {

            int complement = (int)(targetSkill - s);

            if (skillCount.ContainsKey(complement) && skillCount[complement] > 0)
            {
                totalChemistry += (long)s * complement;

                skillCount[complement]--;
            }
            else
            {

                if (!skillCount.ContainsKey(s))
                {
                    skillCount[s] = 0;
                }
                skillCount[s]++;
            }
        }

        foreach (var count in skillCount.Values)
        {
            if (count > 0)
            {
                return -1;
            }
        }

        return totalChemistry;
    }
}