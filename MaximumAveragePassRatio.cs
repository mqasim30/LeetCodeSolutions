namespace LeetCode.MaximumAveragePassRatio;

using System;
using System.Collections.Generic;

public class Solution
{
    public double MaxAverageRatio(int[][] classes, int extraStudents)
    {
        PriorityQueue<(double gain, int pass, int total), double> maxHeap = new PriorityQueue<(double, int, int), double>(Comparer<double>.Create((a, b) => b.CompareTo(a)));
        double sum = 0.0;

        foreach (var cls in classes)
        {
            int pass = cls[0], total = cls[1];
            sum += (double)pass / total;
            maxHeap.Enqueue((Gain(pass, total), pass, total), Gain(pass, total));
        }

        for (int i = 0; i < extraStudents; i++)
        {
            var top = maxHeap.Dequeue();
            int pass = top.pass, total = top.total;
            sum -= (double)pass / total;
            pass++;
            total++;
            sum += (double)pass / total;
            maxHeap.Enqueue((Gain(pass, total), pass, total), Gain(pass, total));
        }

        return sum / classes.Length;
    }

    private double Gain(int pass, int total)
    {
        return (double)(pass + 1) / (total + 1) - (double)pass / total;
    }
}