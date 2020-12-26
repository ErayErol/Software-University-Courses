using System;
using System.Text;

namespace HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string heading = Console.ReadLine();
            string content = Console.ReadLine();

            var sb = new StringBuilder();
            sb.AppendLine("<h1>");
            sb.AppendLine($"    {heading}");
            sb.AppendLine("</h1>");

            sb.AppendLine("<article>");
            sb.AppendLine($"    {content}");
            sb.AppendLine("</article>");

            string comments;
            while ((comments = Console.ReadLine()) != "end of comments")
            {
                sb.AppendLine("<div>");
                sb.AppendLine($"    {comments}");
                sb.AppendLine("</div>");
            }

            Console.WriteLine(sb);
        }
    }
}
