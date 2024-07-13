namespace LeetCode.RobotCollisions;

public class Solution
{
    public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions)
    {
        IList<int> results = new List<int>();
        Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < positions.Length; i++)
        {
            keyValuePairs.Add(positions[i], i);
        }
        Array.Sort(positions);
        foreach (var item in positions)
        {
            int i = keyValuePairs[item];
            if (directions[i] == 'R')
            {
                stack.Push(i);
            }
            else
            {
                while (stack.Count > 0 && healths[i] > 0)
                {
                    int j = stack.Pop();

                    if (healths[i] > healths[j])
                    {
                        healths[j] = 0;
                        healths[i] -= 1;
                    }
                    else if (healths[i] < healths[j])
                    {
                        healths[i] = 0;
                        healths[j] -= 1;
                        stack.Push(j);
                        break;
                    }
                    else
                    {
                        healths[i] = healths[j] = 0;
                    }
                }
            }
        }
        for (int i = 0; i < healths.Length; i++)
        {
            if (healths[i] > 0)
            {
                results.Add(healths[i]);
            }
        }
        return results;
    }
}

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         int[] positions = [5, 4, 3, 2, 1], healths = [2, 17, 9, 15, 10];
//         string directions = "LLLLL";
//         solution.SurvivedRobotsHealths(positions, healths, directions);
//     }
// }