namespace _07.Tuple
{
    using System.Text;

    public class MyTyple<K, V>
    {
        public MyTyple(K item1, V item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }

        public K Item1 { get; set; }

        public V Item2 { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Item1} -> {this.Item2}");

            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}