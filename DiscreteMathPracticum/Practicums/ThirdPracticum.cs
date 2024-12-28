namespace DiscreteMath.Practicums;

public sealed class ThirdPracticum : IPracticum
{
   public void Execute()
   {
      Graph graph = new GraphFactory().Create();
      int start;

      Console.WriteLine("Write number of start vertex: ");
      while (int.TryParse(Console.ReadLine(), out start) && start < 0)
         Console.WriteLine("Error: try again");

      Console.WriteLine("DFS:");
      new GraphSearchAlgorithm(graph)
         .DFS(start)
         .ToList()
         .ForEach(Console.Write);

      Console.WriteLine("\nBFS:");
      new GraphSearchAlgorithm(graph)
         .BFS(start)
         .ToList()
         .ForEach(Console.Write);
   }
}