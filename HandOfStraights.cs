namespace LeetCode.HandOfStraights;
public class Solution
{
    public bool IsNStraightHand(int[] hand, int groupSize)
    {
        if (hand.Length % groupSize != 0)
        {
            return false;
        }

        Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
        foreach (var item in hand)
        {
            if (keyValuePairs.ContainsKey(item))
            {
                keyValuePairs[item] += 1;
            }
            else
            {
                keyValuePairs[item] = 1;
            }
        }

        var sortedDict = keyValuePairs.OrderBy(keyValuePair => keyValuePair.Key).ToDictionary();

        while (sortedDict.Count() != 0)
        {
            int smallestElement = sortedDict.First().Key;
            for (int currCard = smallestElement; currCard < smallestElement + groupSize; currCard++)
            {
                if (!sortedDict.ContainsKey(currCard))
                {
                    return false;
                }

                sortedDict[currCard] -= 1;
                if (sortedDict[currCard] == 0)
                {
                    sortedDict.Remove(currCard);
                }
            }
        }

        return true;
    }
}
// public class Program
// {
//     static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         int[] hand = [1, 2, 3, 6, 2, 3, 4, 7, 9];
//         int groupSize = 3;
//         Console.WriteLine(solution.IsNStraightHand(hand, groupSize));
//     }
// }
