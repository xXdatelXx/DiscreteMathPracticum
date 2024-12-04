namespace DiscreteMath.Practicums;

public sealed class SecondPracticum : IPracticum
{
   public void Execute() => 
      Exercise(UserInput());

   //Read graph from user input
   //TODO rewrite
   private Graph UserInput()
   {
      int vertexCount = 0;
      while (true)
      {
         Console.Write("Write number of vertexes: ");
         if (int.TryParse(Console.ReadLine(), out vertexCount) && vertexCount > 0)
            break;

         Console.WriteLine("Error: Please try again!.");
      }

      var graphDictionary = new Dictionary<int, IReadOnlyList<int>>();

      for (int i = 1; i <= vertexCount; i++)
      {
         while (true)
         {
            Console.Write($"Write vertexes that chain with {i}, with space: ");
            var input = Console.ReadLine();
            try
            {
               var edges = input!
                  .Split([' ', ','], StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToList();

               if (edges.Any(i => i > vertexCount))
                  throw new Exception();

               graphDictionary[i] = edges;
               break;
            }
            catch
            {
               Console.WriteLine("Error: Please try again!.");
            }
         }
      }
      
      return new Graph(graphDictionary);
   }
   
   //Complete practicum
   private void Exercise(Graph graph)
   {
      GraphMetric metric = new(graph);
   
      Console.WriteLine($"Diameter: {metric.Diameter()}");
      Console.WriteLine($"Radius: {metric.Radius()}");
   
      Console.WriteLine("Center:");
      metric.Center().ToList().ForEach(Console.Write);
      Console.WriteLine();
   
      Console.WriteLine("Tiers:");
      for (int i = 0; i < graph.Elements.Count; i++)
      {
         Console.WriteLine($"Tiers for: {i + 1}");
         var tiers = metric.Tiers(i);
         foreach (var (vertex, tier) in tiers)
         {
            Console.Write($"Tear {vertex}, Elements: ");
            tier.ForEach(Console.Write);
            Console.WriteLine();
         }
      }
   
      GraphMatrices matrices = new(graph);
   
      Console.WriteLine("Distance matrix:");
      var distance = matrices.Distance();
      for (int i = 0; i < distance.GetLength(0); i++)
      {
         for (int j = 0; j < distance.GetLength(1); j++)
            Console.Write(distance[i, j]);
   
         Console.WriteLine();
      }
   
      Console.WriteLine("Reachability matrix:");
      var reachability = matrices.Reachability();
      for (int i = 0; i < reachability.GetLength(0); i++)
      {
         for (int j = 0; j < reachability.GetLength(1); j++)
            Console.Write(reachability[i, j]);
   
         Console.WriteLine();
      }
   
      var cycles = new GraphMetric(graph).Cycle();
   
      Console.WriteLine("Cycles:");
      foreach (var cycle in cycles)
         Console.WriteLine(string.Join(" -> ", cycle));
   }
}