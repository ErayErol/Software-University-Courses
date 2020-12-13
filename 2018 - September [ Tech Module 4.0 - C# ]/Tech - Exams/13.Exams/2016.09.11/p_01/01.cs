using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int allPicturesTaken = int.Parse(Console.ReadLine());
            int filterPictures = int.Parse(Console.ReadLine());
            int filterFactor = int.Parse(Console.ReadLine());
            int uploadTime = int.Parse(Console.ReadLine());
            long usefulPictures = (long)Math.Ceiling(allPicturesTaken * (filterFactor / 100.0));
            long filterTime = (long)allPicturesTaken * filterPictures;
            long alltime = filterTime + (usefulPictures * uploadTime);

            TimeSpan time = TimeSpan.FromSeconds(alltime);
            Console.WriteLine($"{time.Days:D1}:{time.Hours:D2}:{time.Minutes:D2}:{time.Seconds:D2}");
        }
    }
}
