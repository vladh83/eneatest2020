using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Business.Logic;
using Business.Logic.Algorithms;

namespace Business.Logic.Test
{
    class SortedNumbersTests
    {
        SortedNumbers _sn = null;

        [SetUp]
        public void Setup()
        {
            _sn = new SortedNumbers();
        }

        [Test]
        public void TestNull()
        {
            Assert.Throws<Exception>(() =>
            {
                _sn.Run(null);
            });
        }

        [Test]
        public void TestInvalidCharacters()
        {
            Assert.Throws<Exception>(() =>
            {
                _sn.Run("a!1, bc .[22]");
            });
        }

        [Test]
        public void TestEmpty()
        {
            Assert.IsFalse(_sn.Run(""));
        }

        [Test]
        public void TestOneNumber()
        {
            Assert.IsTrue(_sn.Run("99"));
        }

        [Test]
        public void TestSimpleAscending()
        {
            Assert.IsTrue(_sn.Run("7, 10, 215"));
        }

        [Test]
        public void TestSimpleDescending()
        {
            Assert.IsTrue(_sn.Run("3, 2, 1"));
        }

        [Test]
        public void TestSimpleNotOrdered()
        {
            Assert.IsFalse(_sn.Run("77, 11, 215"));
        }

        [Test]
        public void TestComplexAscending()
        {
            Assert.IsTrue(_sn.Run("-23,   192,343,                  515"));
        }

        [Test]
        public void TestComplexDescending()
        {
            Assert.IsTrue(_sn.Run("23,   -24,-9998,                  -9999"));
        }

        [Test]
        public void TestComplexNotOrdered()
        {
            Assert.IsFalse(_sn.Run("23,   -24,-9999,                  -9998"));
        }
    }
}
