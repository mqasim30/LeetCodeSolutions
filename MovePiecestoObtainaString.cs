namespace LeetCode.MovePiecestoObtainaString;
public class Solution
{
    public bool CanChange(string start, string target)
    {
        if (start == target) return true;
        int waitL = 0, waitR = 0;

        for (int i = 0; i < start.Length; i++)
        {
            char curr = start[i];
            char goal = target[i];

            if (curr == 'R')
            {
                if (waitL > 0) return false;
                waitR++;
            }
            if (goal == 'L')
            {
                if (waitR > 0) return false;
                waitL++;
            }
            if (goal == 'R')
            {
                if (waitR == 0) return false;
                waitR--;
            }
            if (curr == 'L')
            {
                if (waitL == 0) return false;
                waitL--;
            }
        }
        return waitL == 0 && waitR == 0;
    }
}