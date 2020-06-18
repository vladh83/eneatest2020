using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Business.Logic.Algorithms;

namespace Business.Logic.Test
{
    class BalancedParanthesesTests
    {
        BalancedParantheses _bp = null;

        [SetUp]
        public void Setup()
        {
            _bp = new BalancedParantheses();
        }

        [Test]
        public void TestNull()
        {
            Assert.Throws<Exception>(() =>
            {
                _bp.Run(null);
            });
        }

        [Test]
        public void TestInvalidCharacters()
        {
            Assert.Throws<Exception>(() =>
            {
                _bp.Run("abc .[]");
            });
        }

        [Test]
        public void TestEmpty()
        {
            Assert.IsFalse(_bp.Run(""));
        }

        [Test]
        public void TestSimpleBalanced()
        {
            Assert.IsTrue(_bp.Run("{[()]}"));
        }

        [Test]
        public void TestComplexBalanced()
        {
            Assert.IsTrue(_bp.Run("[()]{}{[()()]()}"));
        }

        [Test]
        public void TestSimpleNotBalanced()
        {
            Assert.IsFalse(_bp.Run("[{("));
        }

        [Test]
        public void TestComplexNotBalanced()
        {
            Assert.IsFalse(_bp.Run("[()]{]}{[([)()]()}"));
        }
    }
}
