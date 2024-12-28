namespace DiscreteMath.Practicums;

public sealed class FifthPracticum : IPracticum {
   public void Execute() {
      Graph graph = new GraphFactory().Create();
      Console.WriteLine(new GraphMetric(graph).Planar() ? "Planar" : "Not planar");
      Console.ReadLine();
   }
}