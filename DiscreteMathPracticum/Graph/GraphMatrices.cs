namespace DiscreteMath;

public sealed class GraphMatrices(Graph graph)
{
   private Dictionary<int, IReadOnlyList<int>> Elements => graph.Elements;

   public int[,] Adjacency()
   {
      var matrix = new int[Elements.Count, Elements.Count];

      foreach (var (vertex, edges) in Elements)
      {
         foreach (var e in edges)
            matrix[vertex - 1, e - 1] = 1;
      }

      return matrix;
   }

   public int[,] Incidence()
   {
      var matrix = new int[Elements.Count, graph.EdgesCount()];

      foreach (var (vertex, edges) in Elements)
      {
         foreach (var e in edges)
         {
            if (e == vertex)
               matrix[e - 1, e - 1] = 2;
            else
            {
               matrix[vertex - 1, e - 1] = matrix[vertex - 1, e - 1] == 0 ? -1 : 1;
               matrix[e - 1, vertex - 1] = 1;
            }
         }
      }

      return matrix;
   }

   public int[,] Distance()
   {
      int[,] matrix = Adjacency();

      for (int i = 0; i < Elements.Count; i++)
      {
         for (int j = 0; j < Elements.Count; j++)
         {
            for (int k = 0; k < Elements.Count; k++)
            {
               if (matrix[j, i] != 0 && matrix[i, k] != 0 && k != j)
               {
                  matrix[j, k] = matrix[j, k] == 0
                     ? matrix[j, i] + matrix[i, k]
                     : Math.Min(matrix[j, k], matrix[j, i] + matrix[i, k]);
               }
            }
         }
      }

      return matrix;
   }

   public int[,] Reachability()
   {
      int[,] matrix = Distance();

      for (var i = 0; i < graph.Elements.Count; i++)
      {
         for (var j = 0; j < graph.Elements.Count; j++)
         {
            matrix[i, j] = matrix[i, j] == 0 ? 0 : 1;
            if (i == j)
               matrix[i, j] = 1;
         }
      }

      return matrix;
   }
}