using Expressions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ExpressionTests
{
    [TestFixture]
    public class ExpressionCreationTests
    {
        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentNullException))]
        public void ThrowsIfArgumentsNull()
        {
            var expression = new RpnExpression(null, new Stack<Operator>());
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentNullException))]
        public void ThrowsIfOperatorsNull()
        {
            var expression = new RpnExpression(new Queue<Argument>(new[] { new Argument() }), null);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentException))]
        public void ThrowsIfArgumentsEmpty()
        {
            var expression = new RpnExpression(new Queue<Argument>(), new Stack<Operator>());
        }
    }
}
