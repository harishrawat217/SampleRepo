using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Mathworks
{
    public class FilterTests
    {
        [Test]
        public void SelectsPrimeNumbers()
        {
            // Given
            IList<int> numbers = new List<int> {1, 2, 3, 4};

            // When
            IList<int> primeNumbers = Filter.SelectPrime(numbers);

            // Then
            Assert.AreEqual(2, primeNumbers.Count);
            Assert.IsTrue(primeNumbers.Contains(2));
            Assert.IsTrue(primeNumbers.Contains(3));
            Assert.IsFalse(primeNumbers.Contains(1));
            Assert.IsFalse(primeNumbers.Contains(4));
        }

        [Test]
        public void DoesNotSelectNegativePrimeNumbers()
        {
            // Given
            IList<int> numbers = new List<int> {-1, 2, -3, 4};

            // When
            IList<int> primeNumbers = Filter.SelectPrime(numbers);

            // Then
            Assert.AreEqual(1, primeNumbers.Count);
            Assert.IsTrue(primeNumbers.Contains(2));
            Assert.IsFalse(primeNumbers.Contains(-1));
            Assert.IsFalse(primeNumbers.Contains(-3));
            Assert.IsFalse(primeNumbers.Contains(4));
        }

        [Test]
        public void SelectsOddNumbers()
        {
            // Given
            IList<int> numbers = new List<int> { -1, 2, 3, 4 };

            // When
            IList<int> oddNumbers = Filter.SelectOdd(numbers);

            // Then
            Assert.AreEqual(2, oddNumbers.Count);
            Assert.IsTrue(oddNumbers.Contains(-1));
            Assert.IsTrue(oddNumbers.Contains(3));
            Assert.IsFalse(oddNumbers.Contains(2));
            Assert.IsFalse(oddNumbers.Contains(4));
        }


        [Test]
        public void SelectsNumbers()
        {
            // Given
            IList<int> numbers = new List<int> { -1, 2, 3, 4 };

            // When
            IList<int> oddNumbers = Filter.Select(numbers,Filter.ODD);

            // Then
            Assert.AreEqual(2, oddNumbers.Count);
            Assert.IsTrue(oddNumbers.Contains(-1));
            Assert.IsTrue(oddNumbers.Contains(3));
            Assert.IsFalse(oddNumbers.Contains(2));
            Assert.IsFalse(oddNumbers.Contains(4));
        }


        [Test]
        public void SelectsOddPrimes()
        {
            // Given
            IList<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            // When
            IList<int> oddPrimes = Filter.Select(numbers, Filter.ODD, Filter.PRIME);

            // Then
            Assert.AreEqual(2, oddPrimes.Count);
            Assert.IsTrue(oddPrimes.Contains(5));
            Assert.IsTrue(oddPrimes.Contains(3));
            Assert.IsFalse(oddPrimes.Contains(1));
            Assert.IsFalse(oddPrimes.Contains(2));
            Assert.IsFalse(oddPrimes.Contains(4));
        }

    }
}