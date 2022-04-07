// http://dotnetpattern.com/nunit-testfixture-example-usage

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CB_Base.Tests
{
    [TestFixture(5)]
    public class TestingFw
    {
        int IdMaterial = 0;

        public TestingFw(int idMaterial)
        {
            IdMaterial = idMaterial;
        }

        [TestCase(2, ExpectedResult = 3)]
        [TestCase(3, ExpectedResult = 2)]
        // When_StateUnderTest_Expect_ExpectedBehavior
        public int Restar_Bien(int numResta)
        {
            return IdMaterial - numResta;
        }
    }
}
