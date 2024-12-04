namespace DiscreteMath;

public sealed class GraphMetric(Graph graph)
{
   public int Diameter()
   {
      int[,] distanceMatrix = new GraphMatrices(graph).Distance();

      int diameter = distanceMatrix
         .Cast<int>()
         .Aggregate(0, (current, i) => current < i ? i : current);

      return diameter;
   }

   public int Eccentricities(int vertex)
   {
      int[,] distanceMatrix = new GraphMatrices(graph).Distance();

      return Enumerable
         .Range(0, distanceMatrix.GetLength(1))
         .Select(x => distanceMatrix[vertex, x])
         .Where(x => x > 0).Max();
   }
   
   public int Radius()
   {
      int[,] distanceMatrix = new GraphMatrices(graph).Distance();
      List<int> eccentricities = [];

      for (int i = 0; i < distanceMatrix.GetLength(0); i++) 
         eccentricities.Add(Eccentricities(i));

      return eccentricities.Min();
   }

   public int[] Center()
   {
      int[,] distanceMatrix = new GraphMatrices(graph).Distance();
      int radius = Radius();
      List<int> center = [];

      for (int i = 0; i < distanceMatrix.GetLength(0); i++)
      {
         if (radius == Eccentricities(i))
            center.Add(i + 1);
      }

      return center.ToArray();
   }

   public Dictionary<int, List<int>> Tiers(int vertex)
   {
      int[,] distanceMatrix = new GraphMatrices(graph).Distance();

      int[] row = Enumerable.Range(0, distanceMatrix.GetLength(1))
         .Select(x => distanceMatrix[vertex, x]).ToArray();

      var tiers = row
         .Select((distance, index) => new { Distance = distance, Vertex = index + 1 })
         .Where(x => x.Distance != 0)
         .GroupBy(x => x.Distance)
         .ToDictionary(
            g => g.Key,
            g => g.Select(i => i.Vertex).ToList()
         );

      return tiers;
   }

   public List<List<int>> Cycle()
   {
      HashSet<int> visited = [];
      Stack<int> stack = new();
      List<List<int>> cycles = [];

      foreach (var vertex in graph.Elements.Keys)
      {
         if (!visited.Contains(vertex))
            DFS(vertex);
      }

      return cycles;

      void DFS(int current)
      {
         if (stack.Contains(current))
         {
            var cycle = stack
               .Reverse()
               .SkipWhile(v => v != current)
               .ToList();

            // Example 1 -> 2 -> 1
            if (cycle.Count < 3)
               return;

            cycle.Add(current);
            cycles.Add(cycle);

            return;
         }

         if (visited.Contains(current))
            return;

         visited.Add(current);
         stack.Push(current);

         if (graph.Elements.TryGetValue(current, out var neighbors))
         {
            foreach (var neighbor in neighbors)
               DFS(neighbor);
         }

         stack.Pop();
      }
   }
}