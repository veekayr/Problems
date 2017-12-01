using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedParanthesis
{
    class Program
    {
        public static bool IsBalancedParenthesis(string str)
        {
            Stack stack = new Stack();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '{' || str[i] == '(' || str[i] == '[')
                {
                    stack.Push(str[i]);
                }
                else if (str[i] == '}' || str[i] == ']' || str[i] == ')') 
                {
                    if(stack.Count == 0)
                    {
                        return false;
                    }
                    char top = (char)stack.Pop();
                    if(!IsMatching(top, str[i]))
                    {
                        return false;
                    }
                }
            }
            if(stack.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        static bool IsMatching(char top, char currentBrace)
        {
            if (top == '(' && currentBrace == ')')
            {
                return true;
            }
            else if (top == '{' && currentBrace == '}')
            {
                return true;
            }
            else if (top == '[' && currentBrace == ']')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            string str = @"{()}[]";
            Console.WriteLine(IsBalancedParenthesis(str) ? "True" : "False");
            Console.Read();
        }
    }
}
