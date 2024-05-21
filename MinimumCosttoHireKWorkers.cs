namespace LeetCode.MinimumCosttoHireKWorkers
{
    public class Solution
    {
        public double MincostToHireWorkers(int[] quality, int[] wage, int k)
        {
            var workers = new double[quality.Length][];

            for (var i = 0; i < quality.Length; ++i)
            {
                workers[i] = [(double)wage[i] / quality[i], quality[i]];
            }

            for (int i = 0; i < workers.Length; i++)
            {
                Console.Write($"{i}. ");
                for (int j = 0; j < workers[i].Length; j++)
                {
                    Console.Write(workers[i][j] + " ");
                }
                Console.WriteLine();
            }

            Array.Sort(workers, (a, b) => a[0].CompareTo(b[0]));

            Console.WriteLine("\nAfter Sorting \n");
            for (int i = 0; i < workers.Length; i++)
            {
                Console.Write($"{i}. ");
                for (int j = 0; j < workers[i].Length; j++)
                {
                    Console.Write(workers[i][j] + " ");
                }
                Console.WriteLine();
            }

            var result = double.MaxValue;
            double sum = 0;
            var pq = new PriorityQueue<double, double>();

            foreach (var worker in workers)
            {
                Console.WriteLine("result = "+ result);
                sum += worker[1];
                Console.WriteLine("sum after adding = " + sum);

                pq.Enqueue(-worker[1], -worker[1]);
                Console.WriteLine("count = "+ pq.Count + " k = "+ k);
                if (pq.Count > k)
                {
                    sum += pq.Dequeue();
                    Console.WriteLine("sum after dequeue = " + sum);
                }

                if (pq.Count == k)
                {
                    Console.WriteLine($"{result}, {sum}, {worker[0]}");
                    result = Math.Min(result, sum * worker[0]);
                }
            }

            return result;
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         int[] quality = [37, 32, 14, 14, 23, 31, 82, 96, 81, 96, 22, 17, 68, 3, 88, 59, 54, 23, 22, 77, 61, 16, 46, 22, 94, 50, 29, 46, 7, 33, 22, 99, 31, 99, 75, 67, 95, 54, 31, 48, 44, 96, 99, 20, 51, 54, 18, 85, 25, 84];
    //         int[] wage = [453, 236, 199, 359, 107, 45, 150, 433, 32, 192, 433, 94, 113, 200, 293, 31, 48, 27, 15, 32, 295, 97, 199, 427, 90, 215, 390, 412, 475, 131, 122, 398, 479, 142, 103, 243, 86, 309, 498, 210, 173, 363, 449, 135, 353, 397, 105, 165, 165, 62];
    //         int k = 20;
    //         Console.WriteLine(solution.MincostToHireWorkers(quality, wage, k));
    //     }
    // }
}