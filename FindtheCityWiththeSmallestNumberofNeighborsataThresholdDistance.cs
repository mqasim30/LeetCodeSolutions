namespace LeetCode.FindtheCityWiththeSmallestNumberofNeighborsataThresholdDistance;
public class Solution
{
    public class CityGraph
    {
        private int _numberOfCities;
        public int[][] _distanceMatrix;

        public CityGraph(int[][] roads, int numberOfCities)
        {
            _numberOfCities = numberOfCities;
            _distanceMatrix = new int[_numberOfCities][];

            for (int i = 0; i < _numberOfCities; i++)
            {
                _distanceMatrix[i] = new int[_numberOfCities];
            }

            InitializeDistanceMatrix();

            foreach (var road in roads)
            {
                int cityA = road[0];
                int cityB = road[1];
                int distance = road[2];

                _distanceMatrix[cityA][cityB] = distance;
                _distanceMatrix[cityB][cityA] = distance;
            }
        }

        private void InitializeDistanceMatrix()
        {
            for (int i = 0; i < _numberOfCities; i++)
            {
                for (int j = 0; j < _numberOfCities; j++)
                {
                    if (i == j)
                        _distanceMatrix[i][j] = 0; 
                    else
                        _distanceMatrix[i][j] = int.MaxValue;
                }
            }
        }
        public void CalculateShortestDistances()
        {
            for (int intermediateCity = 0; intermediateCity < _numberOfCities; intermediateCity++)
            {
                for (int startCity = 0; startCity < _numberOfCities; startCity++)
                {
                    for (int endCity = 0; endCity < _numberOfCities; endCity++)
                    {
                        _distanceMatrix[startCity][endCity] = Math.Min(_distanceMatrix[startCity][endCity], _distanceMatrix[startCity][intermediateCity] + _distanceMatrix[intermediateCity][endCity]);
                    }
                }
            }
        }
    }

    public int FindTheCity(int numberOfCities, int[][] roads, int distanceThreshold)
    {

        CityGraph cityGraph = new CityGraph(roads, numberOfCities);
        cityGraph.CalculateShortestDistances();

        int resultCity = 0;
        int minReachableCities = int.MaxValue;

        for (int currentCity = 0; currentCity < numberOfCities; currentCity++)
        {
            int reachableCities = 0;

            for (int otherCity = 0; otherCity < numberOfCities; otherCity++)
            {
                if (cityGraph._distanceMatrix[currentCity][otherCity] <= distanceThreshold)
                {
                    reachableCities++;
                }
            }

            if (reachableCities <= minReachableCities)
            {
                resultCity = currentCity;
                minReachableCities = reachableCities;
            }
        }

        return resultCity;
    }
}
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         int n = 4;
//         int[][] edges = [[0, 1, 3], [1, 2, 1], [1, 3, 4], [2, 3, 1]];
//         int distanceThreshold = 4;
//         Console.WriteLine(solution.FindTheCity(n, edges, distanceThreshold));
//     }
// }