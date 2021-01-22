using System;
using System.Collections.Generic;
using System.Linq;


namespace DataStructures
{
    public static class LongestValidParanSubstring
    {


        /// <summary>
        /// Method to get the length of the longest valid (well-formed) parentheses substring using 1 stack 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public static int GetLongestParanthesisSubstring(string inputString)
        {
            Stack<int> stack = new Stack<int>();

            //looping through the characters in the input string
            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] == ')')
                {
                    // pop '(' from stack when there is matching ')' 
                    if (stack.Any() && inputString[stack.Peek()] == '(')
                    {
                        stack.Pop();
                        continue;
                    }
                }

                //push '(' to stack
                stack.Push(i);

            }
            //when the input string is wellformed or string has invalid characters other than '(' or ')'
            if (!stack.Any())
            {
                return inputString.Length;
            }

            int maxlen = 0;
            int position = inputString.Length;
            // compute the difference  of index between '('s in the stack
            while (stack.Any())
            {
                int index = stack.Pop();
                maxlen = Math.Max(maxlen, position - index - 1);
                position = index;
            }

            maxlen = Math.Max(maxlen, position);

            return maxlen;

        }

        /// <summary>
        /// Method to get the length of the longest valid well-formed parentheses substring using 2 stacks  
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int GetValidParanthesisSubstringLen(string inputString)
        {
            Stack<Char> charStk = new Stack<char>();
            Stack<int> index = new Stack<int>();
            index.Push(-1);
            int maxlen = 0;
            //looping through the characters in the input string
            for (int i = 0; i < inputString.Length; i++)
            {
                //opening paranthesis
                if (inputString[i] == '(')
                {
                    charStk.Push('(');
                    index.Push(i);
                }
                else
                { //Closing paranthesis 
                    if (charStk.Count > 0 && charStk.Peek() == '(')
                    {
                        //pop '(' on the top of the char stack along with index
                        charStk.Pop();
                        index.Pop();
                        //Calculate max length
                        maxlen = Math.Max(maxlen, i - index.Peek());
                    }
                    else
                    {  //push ')' when there is no '(' at the top of the stack or when the stack is empty
                        index.Push(i);
                    }
                }

            }

            return maxlen;
        }

    }
}
