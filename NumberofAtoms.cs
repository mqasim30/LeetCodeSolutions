namespace LeetCode.NumberofAtoms;
using System;
using System.Collections.Generic;
using System.Text;

public class Solution
{
    public string CountOfAtoms(string formula)
    {
        int n = formula.Length;
        Dictionary<string, int> resultCounter = new Dictionary<string, int>();
        Stack<Dictionary<string, int>> parenthesisStack = new Stack<Dictionary<string, int>>();
        int curInd = 0;

        while (curInd < n)
        {
            char curChar = formula[curInd];

            if (curChar == '(')
            {
                curInd++;
                parenthesisStack.Push(new Dictionary<string, int>());
                continue;
            }

            if (curChar == ')')
            {
                StringBuilder multStr = new StringBuilder();
                curInd++;

                while (curInd < n && char.IsDigit(formula[curInd]))
                {
                    multStr.Append(formula[curInd]);
                    curInd++;
                }

                int mult = multStr.Length == 0 ? 1 : int.Parse(multStr.ToString());
                Dictionary<string, int> lastCounter = parenthesisStack.Pop();
                Dictionary<string, int> target = parenthesisStack.Count == 0 ? resultCounter : parenthesisStack.Peek();

                foreach (var entry in lastCounter)
                {
                    if (target.ContainsKey(entry.Key))
                    {
                        target[entry.Key] += entry.Value * mult;
                    }
                    else
                    {
                        target[entry.Key] = entry.Value * mult;
                    }
                }
                continue;
            }

            StringBuilder curElem = new StringBuilder();
            StringBuilder curCounterStr = new StringBuilder();
            Dictionary<string, int> targetDict = parenthesisStack.Count == 0 ? resultCounter : parenthesisStack.Peek();

            while (curInd < n && formula[curInd] != '(' && formula[curInd] != ')')
            {
                if (char.IsLetter(formula[curInd]))
                {
                    if (char.IsUpper(formula[curInd]) && curElem.Length > 0)
                    {
                        string elemStr = curElem.ToString();
                        int count = curCounterStr.Length == 0 ? 1 : int.Parse(curCounterStr.ToString());
                        if (targetDict.ContainsKey(elemStr))
                        {
                            targetDict[elemStr] += count;
                        }
                        else
                        {
                            targetDict[elemStr] = count;
                        }
                        curElem = new StringBuilder();
                        curCounterStr = new StringBuilder();
                    }
                    curElem.Append(formula[curInd]);
                }
                else
                {
                    curCounterStr.Append(formula[curInd]);
                }
                curInd++;
            }

            string finalElemStr = curElem.ToString();
            int finalCount = curCounterStr.Length == 0 ? 1 : int.Parse(curCounterStr.ToString());
            if (targetDict.ContainsKey(finalElemStr))
            {
                targetDict[finalElemStr] += finalCount;
            }
            else
            {
                targetDict[finalElemStr] = finalCount;
            }
        }

        List<string> parts = new List<string>();
        foreach (var entry in resultCounter)
        {
            parts.Add(entry.Key + (entry.Value == 1 ? "" : entry.Value.ToString()));
        }
        parts.Sort();

        StringBuilder result = new StringBuilder();
        foreach (string part in parts)
        {
            result.Append(part);
        }

        return result.ToString();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        string formula = "K4(ON(SO3)2)2";
        Console.WriteLine(solution.CountOfAtoms(formula));
    }
}

