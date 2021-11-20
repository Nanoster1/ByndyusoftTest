using System;
using ByndyusoftTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class TestFunctionsTest
    {
        [TestMethod]
        public void ArrayTest1()
        {
            var inputArr = new double[] {4, 3, 3, 19, 492, 1, -10, 10.5, 12.56, -5};
            var expectedResult = -15;
            var result = TestFunctions.SumTwoMin(inputArr);
            Assert.AreEqual(expectedResult, result);
        }
        
        [TestMethod]
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
        
        [TestMethod]
        public void ArrayTest3()
        {
            var inputArr = new double[15];
            var result = TestFunctions.SumTwoMin(inputArr);
            var expectedResult = 0d;
            Assert.AreEqual(expectedResult, result);
        }
        
        [TestMethod]
        public void ArrayTest4()
        {
            try
            {
                var inputArr = new double[0]; 
                var result = TestFunctions.SumTwoMin(inputArr);
            }
            catch (InvalidOperationException)
            {
                return;
            }
            Assert.Fail();
        }
        
        [TestMethod]
        public void ArrayTest5()
        {
            var inputArr = new double[] {15.5};
            var result = TestFunctions.SumTwoMin(inputArr);
            var expectedResult = 15.5;
            Assert.AreEqual(expectedResult, result);
        }
        
        [TestMethod]
        public void EnumerableTest1()
        {
            var inputArr = new double[] {4, 3, 3, 19, 492, 1, -10, 10.5, 12.56, -5};
            var result = inputArr.SumTwoMin(x => x);
            var expectedResult = -15;
            Assert.AreEqual(expectedResult, result);
        }
        
        [TestMethod]
        public void EnumerableTest2()
        {
            try
            {
                var inputArr = new double[] {4, 3, 3, 19, 492, 1, -10};
                var result = inputArr.SumTwoMin(null);
            }
            catch (ArgumentNullException)
            {
                return;
            }
            Assert.Fail();
        }
        
        [TestMethod]
        public void EnumerableTest3()
        {
            var inputArr = new double[15];
            var result = inputArr.SumTwoMin(x => x);
            var expectedResult = 0d;
            Assert.AreEqual(expectedResult, result);
        }
        
        [TestMethod]
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
        
        [TestMethod]
        public void EnumerableTest5()
        {
            try
            {
                var inputArr = new double[0];
                var result = inputArr.SumTwoMin(x => x);
            }
            catch (InvalidOperationException)
            {
                return;
            }
            
            Assert.Fail();
        }
        
        [TestMethod]
        public void EnumerableTest6()
        {
            var inputArr = new double[] {15.5};
            var result = inputArr.SumTwoMin(x => x);
            var expectedResult = 15.5;
            Assert.AreEqual(expectedResult, result);
        }
    }
}