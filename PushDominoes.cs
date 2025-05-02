namespace LeetCode.PushDominoes;
public class Solution
{
    public string PushDominoes(string dominoes)
    {
        var n = dominoes.Length;
        var right = -1;
        var charArray = dominoes.ToCharArray();

        for (var i = 0; i < n; ++i)
        {
            switch (charArray[i])
            {
                case 'L' when right == -1:
                    {
                        for (var j = i - 1; j >= 0 && charArray[j] == '.'; --j)
                        {
                            charArray[j] = 'L';
                        }

                        break;
                    }
                case 'L':
                    {
                        for (int j = right + 1, k = i - 1; j < k; ++j, --k)
                        {
                            charArray[j] = 'R';
                            charArray[k] = 'L';
                        }

                        right = -1;
                        break;
                    }
                case 'R':
                    {
                        if (right != -1)
                        {
                            for (var j = right + 1; j < i; ++j)
                            {
                                charArray[j] = 'R';
                            }
                        }

                        right = i;
                        break;
                    }
            }
        }

        if (right != -1)
        {
            for (var j = right + 1; j < n; ++j)
            {
                charArray[j] = 'R';
            }
        }

        return new string(charArray);
    }
}