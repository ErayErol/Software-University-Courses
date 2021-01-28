using System;
using Problem01.List;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IAbstractList<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list.RemoveAt(4);
        }
    }
}
