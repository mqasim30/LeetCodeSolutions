namespace LeetCode.MaximumTotalImportanceofRoads;

using System;
using System.Linq;

public class Solution {
    public long MaximumImportance(int n, int[][] roads) {
        int[] degree = new int[n];
        
        foreach (int[] road in roads) {
            degree[road[0]]++;
            degree[road[1]]++;
        }
        
        int[] cities = Enumerable.Range(0, n).ToArray();
        Array.Sort(cities, (a, b) => degree[b].CompareTo(degree[a]));
        
        long totalImportance = 0;
        for (int i = 0; i < n; i++) {
            totalImportance += (long) (n - i) * degree[cities[i]];
        }
        
        return totalImportance;
    }
}
