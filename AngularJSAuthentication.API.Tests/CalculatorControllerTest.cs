using System;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace AngularJSAuthentication.API.Tests
{
    [TestFixture]
    public class CalculatorControllerTest
    {
        [TestCase]
        public void AddTest()
        {
            MathsHelper helper = new MathsHelper();
            int result = helper.Add(20, 10);
            Assert.AreEqual(30, result);
        }

        [TestCase]
        public void SubtractTest()
        {
            MathsHelper helper = new MathsHelper();
            int result = helper.Sub(20, 10);
            Assert.AreEqual(10, result);
        }

        [TestCase]
        public void DivTest()
        {
            MathsHelper helper = new MathsHelper();
            int result = helper.Div(20, 10);
            Assert.AreEqual(10, result);
        }
    }

    public class MathsHelper
    {
        public MathsHelper() { }
        public int Add(int a, int b)
        {
            int x = a + b;
            return x;
        }

        public int Sub(int a, int b)
        {
            int x = a - b;
            return x;
        }

        public int Div(int a, int b)
        {
            int x = a - b;
            return x;
        }
    }
}
