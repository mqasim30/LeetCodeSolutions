namespace LeetCode.CombinationSumII;


public class Solution
{
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        IList<IList<int>> result = new List<IList<int>>();
        Array.Sort(candidates);
        FindCombinations(0, candidates, target, result, new List<int>());
        return result;
    }

    private void FindCombinations(int index, int[] candidates, int target, IList<IList<int>> result, IList<int> currentCombination)
    {
        if (target == 0)
        {
            result.Add(new List<int>(currentCombination));
            return;
        }

        for (int i = index; i < candidates.Length; i++)
        {
            if (i > index && candidates[i] == candidates[i - 1]) continue;
            if (candidates[i] > target) break;

            currentCombination.Add(candidates[i]);
            FindCombinations(i + 1, candidates, target - candidates[i], result, currentCombination);
            currentCombination.RemoveAt(currentCombination.Count - 1);
        }
    }
}
