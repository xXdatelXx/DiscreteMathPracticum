namespace DiscreteMath;

public sealed class GraphVertices(Graph graph) {
   private Dictionary<int, List<int>> Elements => graph.Elements;

   public int[] Isolated() {
      List<int> isolated = [];

      foreach ((int vertex, List<int> edges) in Elements)
         if (edges.Count == 0)
            isolated.Add(vertex);

      return isolated.ToArray();
   }

   public int[] Leafs() {
      List<int> leafs = [];

      int[,] adjacency = new GraphMatrices(graph).Adjacency();

      for (int vertex = 0; vertex < Elements.Count; vertex++) {
         IEnumerable<int> column = Enumerable
            .Range(0, adjacency.GetLength(0))
            .Select(x => adjacency[x, vertex]);

         if (column.Count(i => i == 1) == 1)
            leafs.Add(vertex);
      }

      return leafs.ToArray();
   }
}