using System;
using ByndyusoftTest;
using NUnit.Framework;

namespace NUnitTests
{
    public class TestFunctionsTests
    {
        private double[] _inputArr;
        private double[] _emptyInputArr;
        private double[] _defaultArr;
        private double[] _oneNumArr;
        
        [SetUp]
        public void Setup()
        {
            _inputArr = new [] {4, 3, 3, 19, 492, 1, -10, 10.5, 12.56, -5};
            _emptyInputArr = Array.Empty<double>();
            _defaultArr = new double[15];
            _oneNumArr = new double[] {15.0};
        }

        [Test]
        public void ArrayTest1()
        {
            var expectedResult = -15;
            var result = TestFunctions.SumTwoMin(_inputArr);
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test]
        public void ArrayTest2()
        {
            try
            {
                var result = TestFunctions.SumTwoMin(null);
            }
            catch (ArgumentNullException)
            {
                return;
            }
            Assert.Fail();
        }
        
        [Test]
        public void ArrayTest3()
        {
            var result = TestFunctions.SumTwoMin(_defaultArr);
            var expectedResult = _defaultArr[0];
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test]
        public void ArrayTest4()
        {
            try
            {
                var inputArr = _emptyInputArr; 
                var result = TestFunctions.SumTwoMin(inputArr);
            }
            catch (InvalidOperationException)
            {
                return;
            }
            Assert.Fail();
        }
        
        [Test]
        public void ArrayTest5()
        {
            var result = TestFunctions.SumTwoMin(_oneNumArr);
            var expectedResult = _oneNumArr[0];
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test]
        public void EnumerableTest1()
        {
            var inputArr = _inputArr;
            var result = inputArr.SumTwoMin(x => x);
            var expectedResult = -15;
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test]
        public void EnumerableTest2()
        {
            try
            {
                var result = _inputArr.SumTwoMin(null);
            }
            catch (ArgumentNullException)
            {
                return;
            }
            Assert.Fail();
        }
        
        [Test]
        public void EnumerableTest3()
        {
            var result = _defaultArr.SumTwoMin(x => x);
            var expectedResult = _defaultArr[0];
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test]
        public void EnumerableTest4()
        {
            try
            {
                double[] inputArr = null;
                var result = inputArr.SumTwoMin(x => x);
            }
            catch (ArgumentNullException)
            {
                return;
            }
            
            Assert.Fail();
        }
        
        [Test]
        public void EnumerableTest5()
        {
            try
            {
                var result = _emptyInputArr.SumTwoMin(x => x);
            }
            catch (InvalidOperationException)
            {
                return;
            }
            
            Assert.Fail();
        }
        
        [Test]
        public void EnumerableTest6()
        {
            var result = _oneNumArr.SumTwoMin(x => x);
            var expectedResult = _oneNumArr[0];
            Assert.AreEqual(expectedResult, result);
        }
    }
}