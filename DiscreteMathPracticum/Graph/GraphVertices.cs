namespace DiscreteMath;

public sealed class GraphVertices(Graph graph)
{
   private Dictionary<int, IReadOnlyList<int>> Elements => graph.Elements;
   
   public int[] Isolated()
   {
      List<int> isolated = [];
      
      foreach (var (vertex, edges) in Elements)
      {
         if(edges.Count == 0)
            isolated.Add(vertex);
      }
      
      return isolated.ToArray();
   }

   public int[] Leafs()
   {
      List<int> leafs = [];

      var adjacency = new GraphMatrices(graph).Adjacency();

      for (int vertex = 0; vertex < Elements.Count; vertex++)
      {
         var column = Enumerable
            .Range(0, adjacency.GetLength(0))
            .Select(x => adjacency[x, vertex]);

         if (column.Count(i => i == 1) == 1) 
            leafs.Add(vertex);
      }
      
      return leafs.ToArray();
   }
}