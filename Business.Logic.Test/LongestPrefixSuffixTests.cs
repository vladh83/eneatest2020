using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Business.Logic;
using Business.Logic.Algorithms;

namespace Business.Logic.Test
{
    class LongestPrefixSuffixTests
    {
        LongestPrefixSuffix _lps = null;

        [SetUp]
        public void Setup()
        {
            _lps = new LongestPrefixSuffix();
        }

        [Test]
        public void TestNull()
        {
            Assert.Throws<Exception>(() =>
            {
                _lps.Run(null);
            });
        }

        [Test]
        public void TestEmpty()
        {
            Assert.AreEqual(_lps.Run(""), 0);
        }

        [Test]
        public void TestSingle()
        {
            Assert.AreEqual(_lps.Run("a"), 0);
        }

        [Test]
        public void TestSimple()
        {
            Assert.AreEqual(_lps.Run("aa"), 1);
        }

        [Test]
        public void TestOverlap()
        {
            Assert.AreEqual(_lps.Run("aaaaa"), 2);
        }

        [Test]
        public void TestComplex()
        {
            Assert.AreEqual(_lps.Run("aabcdaabc"), 4);
        }
    }
}
