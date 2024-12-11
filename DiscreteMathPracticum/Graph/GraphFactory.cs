namespace DiscreteMath;

public sealed class GraphFactory
{
   public Graph Create()
   {
      int vertexCount = 0;
      Console.Write("Write number of vertexes: ");
      while (int.TryParse(Console.ReadLine(), out vertexCount) && vertexCount > 0)
         Console.WriteLine("Error: Please try again!.");

      Dictionary<int, List<int>> graphDictionary = new();

      for (int i = 1; i <= vertexCount; i++)
      {
         while (true)
         {
            Console.Write($"Write vertexes that chain with {i}, with space: ");
            string? input = Console.ReadLine();
            try
            {
               List<int> edges = input!
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
}