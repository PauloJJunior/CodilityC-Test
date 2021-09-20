using System;
using System.Collections.Generic;

namespace CodilityCSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var Solution = new Solution();
            int r;
            string S;



            S = "4 5 6 - 7 +";
            r = Solution.solution(S);
            Console.WriteLine(r.ToString());
            S = "";

            S = "13 DUP 4 POP 5 DUP + DUP + -";
            r = Solution.solution(S);
            Console.WriteLine(r.ToString());
            S = "";


        }



    }

    public class Solution
    {
        public int solution(string S)
        {


            string[] SplitString = S.Split(' ');

            List<int> stack = new List<int>();

            for (int i = 0; i < SplitString.Length; i++)
            {
                int n;
                bool result = Int32.TryParse(SplitString[i], out n);
                if (result && n > 0) stack.Add(n);
                else if (result && n < 0) return -1;
                else
                {
                    if (SplitString[i] == "POP")
                    {
                        stack.RemoveAt(stack.Count - 1);
                    }
                    else if (SplitString[i] == "DUP")
                    {
                        stack.Add(stack[stack.Count - 1]);
                    }
                    else if (SplitString[i] == "+")
                    {

                        try
                        {
                            int r = stack[stack.Count - 1] + stack[stack.Count - 2];
                            stack.RemoveAt(stack.Count - 1);
                            stack.RemoveAt(stack.Count - 1);
                            stack.Add(r);
                        }
                        catch (OverflowException)
                        {
                            return -1;
                        }
                    }
                    else if (SplitString[i] == "-")
                    {

                        int r = stack[stack.Count - 1] - stack[stack.Count - 2];

                        if (r < 0) return -1;
                        else
                        {
                            stack.RemoveAt(stack.Count - 1);
                            stack.RemoveAt(stack.Count - 1);
                            stack.Add(r);
                        }

                    }
                }
            }

            if (stack.Count < 0) return -1;
            else return stack[stack.Count - 1];


        }
    }
}
