using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculations;
using NUnit.Framework;
using Specification = NUnit.Framework.TestAttribute;

namespace CalculatorSpecs
{
    public class CalculatorSpecs

    {
        private Calculator calculator;

        [SetUp]
        public void CreateCalculator()
        {
            calculator = new Calculator();
        }
        [Specification]
        public void AddsTwoNumbers()
        {
            //Given
      
            //When
            //Then

            Assert.That(calculator.Add(2.0, 3.0), Is.EqualTo(5.0));
            Assert.That(calculator.Add(3.0, 3.0), Is.EqualTo(6.0));
        }

        [Specification]
        public void DividesTwoNumbersWith6DigitsPrecision()
        {
            //Given
          

            //When
            //Then

            Assert.That(calculator.Divide(2.0, 3.0), Is.EqualTo(0.6666666666).Within(0.0000001));

        }

        [Specification]
        public void DivisionByZeroResultsInInifinity() 
        {
            try
            {
                calculator.Divide(2.0, 0);
                Assert.Fail("Should Not Divide by Zero");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("MESSAGE_INFINITY", e.Message);
            }
        }

        [Specification]
        public void ReplaysAddOperation()
        {
            //given
            calculator.Add(2, 3);
            //When
            string result = calculator.Replay();
            Assert.That(result, Is.EqualTo("2 + 3 = 5"));
        }
        [Specification]
        public void ReplaysDivision()
        {
            //given
            calculator.Divide(6, 3);
            //When
            string result = calculator.Replay();
            Assert.That(result, Is.EqualTo("6 / 3 = 2"));
        }

        [Specification]
        public void ReplaysAllOperations()
        {
            //given
            calculator.Add(2, 3);
            calculator.Divide(6, 3);

            //When
            string result = calculator.Replay();
            Assert.That(result, Is.EqualTo("2 + 3 = 5; 6 / 3 = 2"));

        }

        [Specification]
        public void ReplaysNothingWhenNoOperationsArePerformed()
        {
            string result = calculator.Replay();
            Assert.That(result, Is.EqualTo("Nothing To Replay"));

        }

        [Specification]
        public void ReplaysLastOperation()
        {
            //given
            calculator.Divide(6, 3);
            //When
            string result = calculator.ReplayLast();

            Assert.That(result, Is.EqualTo("6 / 3 = 2"));

        }

        [Specification]
        public void ReplaysLast2Operations()
        {
            //given
            calculator.Add(2, 3);
            calculator.Divide(6, 3);

            //When
            string result = calculator.ReplayLast(2);
            Assert.That(result, Is.EqualTo("6 / 3 = 2; 2 + 3 = 5"));
        }

        [Specification]
        public void DoesNotReplayInReverseWhenNoOperationIsPerformed()
        {
            string result = calculator.ReplayLast();
            Assert.That(result, Is.EqualTo("Nothing To Replay"));

        }

        [Specification]
        public void ReplaysAllInReverseWhenAskedForMoreOperationsThanPerformed()
        {
            //given
            calculator.Add(2, 3);
            calculator.Divide(6, 3);

            //When
            string result = calculator.ReplayLast(12);
            Assert.That(result, Is.EqualTo("6 / 3 = 2; 2 + 3 = 5"));

        }
    }
}
