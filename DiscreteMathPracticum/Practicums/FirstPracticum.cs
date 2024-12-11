namespace DiscreteMath.Practicums;

public sealed class FirstPracticum : IPracticum
{
   public void Execute()
   {
      var graph = new GraphFactory().Create();

      Console.WriteLine("Exercise 2");
      GraphMatrices matrices = new(graph);

      Console.WriteLine("Incidence matrix:");
      var incidence = matrices.Incidence();
      for (var i = 0; i < incidence.GetLength(0); i++)
      {
         for (var j = 0; j < incidence.GetLength(1); j++)
            Console.Write(incidence[i, j] + " ");
         Console.WriteLine();
      }

      Console.WriteLine("Adjacency matrix:");
      var adjacency = matrices.Adjacency();
      for (var i = 0; i < adjacency.GetLength(0); i++)
      {
         for (var j = 0; j < adjacency.GetLength(1); j++)
            Console.Write(adjacency[i, j] + " ");
         Console.WriteLine();
      }

      Console.WriteLine("Exercise 3");
      GraphVertexPower power = new(graph);
      Console.WriteLine("Full power:");
      Array.ForEach(power.Full(), Console.WriteLine);
      Console.WriteLine("Enter power:");
      Array.ForEach(power.Enter(), Console.WriteLine);
      Console.WriteLine("Exit power:");
      Array.ForEach(power.Exit(), Console.WriteLine);

      Console.WriteLine("Exercise 4");
      GraphVertices vertices = new(graph);
      Console.WriteLine("Isolated:");
      Array.ForEach(vertices.Isolated(), Console.WriteLine);
      Console.WriteLine("Leafs:");
      Array.ForEach(vertices.Leafs(), Console.WriteLine);
   }
}