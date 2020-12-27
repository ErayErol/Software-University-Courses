using System;
using System.Collections.Generic;
using System.Linq;

namespace Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int songsCount = int.Parse(Console.ReadLine());

            List<Song> songList = new List<Song>();

            for (int i = 0; i < songsCount; i++)
            {
                var input = Console
                    .ReadLine()
                    .Split("_")
                    .ToList();

                string typeList = input[0];
                string songName = input[1];
                string songTime = input[2];

                Song song = new Song();

                song.typeList = typeList;
                song.name = songName;
                song.time = songTime;

                songList.Add(song);
            }

            string command = Console.ReadLine();
            if (command == "all")
            {
                foreach (Song item in songList)
                {
                    Console.WriteLine(item.name);
                }
            }
            else
            {
                foreach (Song item in songList.Where(x => x.typeList == command).ToList())
                {
                    Console.WriteLine(item.name);
                }
            }
        }
    }

    public class Song
    {
        public string typeList { get; set; }
        public string name { get; set; }
        public string time { get; set; }
    }
}
