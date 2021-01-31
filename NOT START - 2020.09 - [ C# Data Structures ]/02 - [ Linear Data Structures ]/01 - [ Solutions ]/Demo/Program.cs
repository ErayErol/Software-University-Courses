using System;
using Problem02.Stack;
using Problem03.Queue;
using Problem04.SinglyLinkedList;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var singly = new SinglyLinkedList<int>();
            singly.AddLast(2);
            singly.AddLast(3);
            singly.AddLast(4);
            singly.AddFirst(1);

            Console.WriteLine(singly.Count);
            Console.WriteLine(singly.RemoveLast());
            Console.WriteLine(singly.Count);

            Console.WriteLine(singly.GetLast());
            Console.WriteLine(singly.GetFirst());

            singly.AddFirst(0);
            Console.WriteLine(singly.RemoveFirst());
        }
    }
}
