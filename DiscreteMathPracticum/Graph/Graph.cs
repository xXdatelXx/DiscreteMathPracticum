namespace DiscreteMath;

public sealed class Graph
{
   public readonly Dictionary<int, IReadOnlyList<int>> Elements;

   public Graph(Dictionary<int, IReadOnlyList<int>> elements)
   {
      foreach (var (vertex, edges) in elements)
      {
         if (vertex < 0)
            throw new ArgumentOutOfRangeException($"{nameof(vertex)} must be greater than or equal to 0.");
         if (edges.Any(e => e < 0 || e > elements.Count))
            throw new ArgumentOutOfRangeException($"{nameof(edges)} must be in the range of 0..{elements.Count}.");
      }

      Elements = elements;
   }

   public int EdgesCount() =>
      (int)Elements.Sum(i => i.Value.Sum(edge => Elements[edge].Contains(i.Key) ? 0.5f : 1));
}