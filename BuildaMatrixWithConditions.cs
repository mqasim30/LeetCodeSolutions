namespace LeetCode.BuildaMatrixWithConditions;

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[][] BuildMatrix(int k, int[][] rowConditions, int[][] colConditions) {
        List<int> row_sorting = TopoSort(rowConditions, k);
        List<int> col_sorting = TopoSort(colConditions, k);
        if (row_sorting.Count == 0 || col_sorting.Count == 0)
            return new int[0][];

        Dictionary<int, int[]> value_position = new Dictionary<int, int[]>();
        for (int n = 1; n <= k; ++n) {
            value_position.Add(n, new int[2]);
        }
        for (int ind = 0; ind < row_sorting.Count; ++ind) {
            value_position[row_sorting[ind]][0] = ind;
        }
        for (int ind = 0; ind < col_sorting.Count; ++ind) {
            value_position[col_sorting[ind]][1] = ind;
        }

        int[][] res = new int[k][];
        for (int i = 0; i < k; ++i) {
            res[i] = new int[k];
        }
        for (int value = 1; value <= k; ++value) {
            int row = value_position[value][0];
            int column = value_position[value][1];
            res[row][column] = value;
        }

        return res;
    }

    private bool Dfs(int src, Dictionary<int, List<int>> graph, HashSet<int> visited, HashSet<int> cur_path, List<int> res) {
        if (cur_path.Contains(src)) return false;
        if (visited.Contains(src)) return true; 
        visited.Add(src);
        cur_path.Add(src);

        foreach (int neighbor in graph.ContainsKey(src) ? graph[src] : new List<int>()) {
            if (!Dfs(neighbor, graph, visited, cur_path, res)) 
                return false;
        }

        cur_path.Remove(src);
        res.Add(src);
        return true;
    }
    private List<int> TopoSort(int[][] edges, int k) {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        foreach (int[] edge in edges) {
            if (!graph.ContainsKey(edge[0])) {
                graph.Add(edge[0], new List<int>());
            }
            graph[edge[0]].Add(edge[1]);
        }

        HashSet<int> visited = new HashSet<int>();
        HashSet<int> cur_path = new HashSet<int>();
        List<int> res = new List<int>();

        for (int src = 1; src <= k; ++src) {
            if (!Dfs(src, graph, visited, cur_path, res))
                return new List<int>();
        }

        res.Reverse();
        return res;
    }
}