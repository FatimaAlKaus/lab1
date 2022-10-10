using NumberTypeQualifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NumberTypeQualifierTests
{
    public class TestTypeDefender
    {
        [Fact]
        public void TestDetermineTypeWithInvalidParameters()
        {
            //Arrange
            int negativeNumber = -1;
            int evenNumber = 2;

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => TypeDefender.DetermineType(negativeNumber));
            Assert.Throws<ArgumentException>(() => TypeDefender.DetermineType(evenNumber));
        }

        [Fact]
        public void TableTesttDetermineTypeValues()
        {
            //Arrange
            var tests = new List<Tuple<int, string, bool>>()
            {
                new Tuple<int,string,bool>(49, TypeDefender.Type2+" и " + TypeDefender.Type5, true),
                new Tuple<int,string,bool>(29, TypeDefender.Type2+" и " + TypeDefender.Type4, true),
                new Tuple<int,string,bool>(13, TypeDefender.Type2+" и " + TypeDefender.Type5, true),
                new Tuple<int,string,bool>(133,TypeDefender.Type2+" и " + TypeDefender.Type5, true),
                new Tuple<int,string,bool>(1,  TypeDefender.Type2+" и " + TypeDefender.Type5, true),
            };

            //Act
            foreach (var test in tests)
            {
                if (test.Item3)
                {
                    Assert.Equal(test.Item2, TypeDefender.DetermineType(test.Item1));
                }
                else
                {
                    Assert.NotEqual(test.Item2, TypeDefender.DetermineType(test.Item1));
                }
            }
        }
    }
}
