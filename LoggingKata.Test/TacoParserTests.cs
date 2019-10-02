using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Theory]
        [InlineData("33.810924,-86.820487 Taco Bell Warrior", 33.810924, -86.820487, "Taco Bell Warrior")]
        [InlineData("32.326279, -86.325015, Taco Bell Montgomery", 0, 0, "Taco Bell Montgomery")]
        [InlineData("30.533164, -87.262229, Taco Bell Pensacola", 30.533164, -87.262229, "Taco Bell Pensacola")]
        public void ShouldParse(string str, double expectedLat, double expectedLong, string expectedName)
        {
            //Arrange
            TacoParser tacoparser = new TacoParser();
            //Act
            ITrackable actual = tacoparser.Parse(str);
            //Assert
            Assert.Equal(expectedLat, actual.Location.Latitude);
            Assert.Equal(expectedLong, actual.Location.Longitude);
            Assert.Equal(expectedName, actual.Name);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Taco, Bell")]
        [InlineData("-91, 50, Taco Bell Warrior")]
        [InlineData("70, 181, Taco Bell Montgomery")]
        [InlineData("This is not acceptable")]
        [InlineData("Truly a disgrace")]
        public void ShouldFailParse(string str)
        {
            TacoParser tacoparser = new TacoParser();

            ITrackable actual = tacoparser.Parse(str);

            Assert.Null(actual);
        }
    }
}
