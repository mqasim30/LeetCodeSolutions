namespace LeetCode.KthSmallestPrimeFraction
{
    public class Solution
    {
        class Fraction
        {
            public int Numerator { get; }
            public int Denominator { get; }
            public Fraction(int numerator, int denominator)
            {
                Numerator = numerator;
                Denominator = denominator;
            }
            public double Value => (double)Numerator / Denominator;
        }
        public int[] KthSmallestPrimeFraction(int[] arr, int k)
        {
            int[] result = new int[2];
            if (k == 1)
            {
                result[0] = arr[0];
                result[1] = arr[arr.Length - 1];
                return result;
            }

            SortedSet<Fraction> fractions = new SortedSet<Fraction>(Comparer<Fraction>.Create((a, b) => a.Value.CompareTo(b.Value)));
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    fractions.Add(new Fraction(arr[i], arr[j]));
                }
            }

            for (int i = 0; i < k - 1; i++)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                fractions.Remove(fractions.Min);
#pragma warning restore CS8604 // Possible null reference argument.
            }

            var answer = fractions.Min;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            result[0] = answer.Numerator;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            result[1] = answer.Denominator;

            return result;
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         int[] numbers = [1, 2, 3, 5];
    //         int[] result = solution.KthSmallestPrimeFraction(numbers, 3);
    //         foreach (var item in result)
    //         {
    //             Console.WriteLine(item);
    //         }
    //     }
    // }
}