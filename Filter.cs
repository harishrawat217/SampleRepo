using System;
using System.Collections.Generic;

namespace Mathworks
{

    //Duplication ->
    //*Blatant (dpulicate)
    //*Subtle (Similar)
    //Combinatorial Explosion
    //DRY Principlse-> [Flexibility - Communicability (values)] 
    public static class Filter
    {
        public static readonly Predicate<int> ODD=number => number%2 != 0;
        public static readonly Predicate<int> PRIME = IsPrime;

        public static IList<int> Select(IList<int> numbers, Predicate<int> IsSatisfiedBy)
        {
            IList<int> selected = new List<int>();
            foreach (int number in numbers)
            {
                if (IsSatisfiedBy(number))
                {
                    selected.Add(number);
                }
            }
            return selected;
        }

        public static IList<int> Select(IList<int> numbers, params Predicate<int>[] conditions)
        {
            IList<int> selected = new List<int>();
            foreach (int number in numbers)
            {
                Boolean @select = true;
                foreach (var condition in conditions)
                {
                    @select &= condition(number);
                }

                if (@select)
                {
                        selected.Add(number);
                 }
                
            }
            return selected;
        }

        //public static bool AllConditionsSatisfied(int number)
        //{
        //    Boolean @select = true;
        //    foreach (var condition in conditions)
        //    {
        //        @select &= condition(number);
        //    }

        //    return @select;
        //}
        public static IList<int> SelectPrime(IList<int> numbers)
        {
            IList<int> primeNumbers = new List<int>();
            foreach (int number in numbers)
            {
                if (IsPrime(number))
                {
                    primeNumbers.Add(number);
                }
            }
            return primeNumbers;
        }

        private static bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }
            for (long i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static IList<int> SelectOdd(IList<int> numbers)
        {
            IList<int> oddNumbers = new List<int>();
            foreach (int number in numbers)
            {
                if (IsOdd(number))
                {
                    oddNumbers.Add(number);
                }
            }
            return oddNumbers;
        }



        private static bool IsOdd(int number)
        {
            if (number < 2)
            {
                return false;
            }
            for (long i = 2; i < number; i++)
            {
                if (number % i != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static IList<int> SelectOddPrime(IList<int> numbers)
        {
            IList<int> primeOddNumbers = new List<int>();
            foreach (int number in numbers)
            {
                if (IsPrime(number) && IsOdd(number))
                {
                    primeOddNumbers.Add(number);
                }
            }
            return primeOddNumbers;
        }

    }
}