using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SharpTestsEx;

namespace StrongChess.Model.Tests.Units
{
    [TestFixture]
    public class MoveTests
    {
        [Test]
        public void IsValid_FromToEquals_ReturnsFalse()
        {
            var m = new Move();
            m.IsValid.Should().Be(false);
        }
    }
}
