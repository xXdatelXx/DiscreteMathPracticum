namespace DiscreteMath.Practicums;

public sealed class SecondPracticum : IPracticum
{
   public void Execute()
   {
      var graph = new GraphFactory().Create();

      GraphMetric metric = new(graph);

      Console.WriteLine($"Diameter: {metric.Diameter()}");
      Console.WriteLine($"Radius: {metric.Radius()}");

      Console.WriteLine("Center:");
      metric.Center().ToList().ForEach(Console.Write);
      Console.WriteLine();

      Console.WriteLine("Tiers:");
      for (var i = 0; i < graph.Elements.Count; i++)
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
      for (var i = 0; i < distance.GetLength(0); i++)
      {
         for (var j = 0; j < distance.GetLength(1); j++)
            Console.Write(distance[i, j]);

         Console.WriteLine();
      }

      Console.WriteLine("Reachability matrix:");
      var reachability = matrices.Reachability();
      for (var i = 0; i < reachability.GetLength(0); i++)
      {
         for (var j = 0; j < reachability.GetLength(1); j++)
            Console.Write(reachability[i, j]);

         Console.WriteLine();
      }

      var cycles = new GraphMetric(graph).Cycle();

      Console.WriteLine("Cycles:");
      foreach (var cycle in cycles)
         Console.WriteLine(string.Join(" -> ", cycle));
   }
}