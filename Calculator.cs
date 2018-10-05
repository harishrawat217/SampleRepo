using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculations
{
    public class Calculator

    {
        private Memory memory = new Memory();

        public double Add(double x, double y)
        {
            var result = x + y;
            memory.Store(x, "+", y, result);
            return result;

        }

        public double Divide(double x, double y)
        {
            if (y == 0)
                throw new ArgumentException("MESSAGE_INFINITY");
            var result = x / y;
            memory.Store(x, "/", y, result);

            return result;
        }


        public string Replay()
        {
            return memory.ToString();
        }

        public string ReplayLast(int howMany = 1)
        {
            return memory.ToStringReverse(howMany);
        }
    }

    internal class Memory
    {
        private IList<string> memory = new List<string>();

        internal void Store(double x, string op, double y, double result)
        {
            memory.Add($"{x} {op} {y} = {result}");
        }

        private string Stringify(IList<string> list)
        {
            if (list.Count == 0)
                return "Nothing To Replay";

            return string.Join("; ", list);

        }
        internal String ToString()
        {
            return Stringify(memory);
        }

        internal String ToStringReverse(int howMany)
        {
            return Stringify(memory.Reverse().Take(howMany).ToList());

        }

    }
}