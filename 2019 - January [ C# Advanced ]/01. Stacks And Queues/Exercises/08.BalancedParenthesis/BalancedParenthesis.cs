using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParenthesis
{
    class BalancedParenthesis
    {
        static void Main(string[] args)
        {
            var stack = new Stack<char>();
            char[] openParenthases = new[] { '(', '[', '{' };
            bool isValid = true;

            string parenthases = Console.ReadLine();

            for (int i = 0; i < parenthases.Length; i++)
            {
                char currentBracket = parenthases[i];

                if (openParenthases.Contains(currentBracket))
                {
                    stack.Push(currentBracket);
                    continue;
                }

                if (stack.Count == 0)
                {
                    isValid = false;
                    break;
                }

                if (stack.Peek() == '(' && currentBracket == ')')
                {
                    stack.Pop();
                }
                else if (stack.Peek() == '[' && currentBracket == ']')
                {
                    stack.Pop();
                }
                else if (stack.Peek() == '{' && currentBracket == '}')
                {
                    stack.Pop();
                }
            }

            if (isValid && stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}