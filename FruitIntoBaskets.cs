namespace LeetCode.FruitIntoBaskets;

using System;
using System.Collections.Generic;

public class Solution
{
    public int TotalFruit(int[] fruits)
    {
        int maxFruits = 0;
        int left = 0;
        Dictionary<int, int> basket = new Dictionary<int, int>();

        for (int right = 0; right < fruits.Length; right++)
        {
            // Add the fruit at the right to the basket
            if (!basket.ContainsKey(fruits[right]))
                basket[fruits[right]] = 0;
            basket[fruits[right]]++;

            // Shrink the window if we have more than 2 types of fruits
            while (basket.Count > 2)
            {
                basket[fruits[left]]--;
                if (basket[fruits[left]] == 0)
                    basket.Remove(fruits[left]);
                left++; // move the window from the left
            }

            // Update max fruits collected in a valid window
            maxFruits = Math.Max(maxFruits, right - left + 1);
        }

        return maxFruits;
    }
}