using Travelling_salesman_problem;

using Travelling_salesman_problem;

class Program
{
    static void PrintAdjacencyMatrix(Graph graph)
    {
        int n = graph.VerticesCount;

        Console.WriteLine("Матриця суміжності:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int weight = graph.GetWeight(i, j);
                string value = weight == int.MaxValue ? "∞" : weight.ToString();
                Console.Write($"{value,6} "); 
            }
            Console.WriteLine();
        }
    }

    static void Main(string[] args)
    {
        
        int n = 20;  
        double fully = 1.0; 
        var graph = GraphGenerator.GenerateRandomGraph(n, fully, useMatrix: true);
        
        Console.WriteLine($"Кількість вершин: {graph.VerticesCount}");
       
        if (graph is AdjacencyMatrix)
        {
            Console.WriteLine($"Кількість ребер: {(graph as AdjacencyMatrix).EdgesCount()}");
        }
        else if (graph is AdjacencyList)
        {
            Console.WriteLine($"Кількість ребер: {(graph as AdjacencyList).EdgesCount()}");
        }
        
        PrintAdjacencyMatrix(graph);
        
        var (cost, path) = TSPSolve.Solve(graph);
        
        Console.WriteLine("Жадібний алгоритм (найближчий сусід):");
        Console.WriteLine(string.Join(" -> ", path));
        Console.WriteLine($"Загальна довжина шляху: {cost:F2}");
    }

}
