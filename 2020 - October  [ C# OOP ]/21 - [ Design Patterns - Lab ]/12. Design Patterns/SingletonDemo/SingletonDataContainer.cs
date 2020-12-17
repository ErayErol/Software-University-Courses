namespace SingletonDemo
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class SingletonDataContainer : ISingletonContainer
    {
        private Dictionary<string, int> _capitals = new Dictionary<string, int>();

        private SingletonDataContainer()
        {
            Console.WriteLine("Initializing singleton object");

            var elements = File.ReadAllLines("capitals.txt");
            for (int i = 0; i < elements.Length; i += 2)
            {
                _capitals.Add(elements[i], int.Parse(elements[i + 1]));
            }
        }

        public int GetPopulation(string name)
        {
            return _capitals[name];
        }

        private static SingletonDataContainer instance = new SingletonDataContainer();

        public static SingletonDataContainer Instance => instance;
    }
}