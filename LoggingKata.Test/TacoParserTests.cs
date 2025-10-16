using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual); // goal for this test is to make sure null value is not returned

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("32.614768, -85.433999, Taco Bell Auburn...", -85.433999)]
        [InlineData("34.730369, -86.586104, Taco Bell Huntsville...", -86.586104)]
        [InlineData("30.694357, -88.043054, Taco Bell Mobile...", -88.043054)]
        [InlineData("33.520661, -86.802490, Taco Bell Birmingham...", -86.802490)]
        [InlineData("33.209841, -87.569173, Taco Bell Tuscaloosa...", -87.569173)]
        [InlineData("31.223230, -85.390488, Taco Bell Dothan...", -85.390488)]
        [InlineData("34.802868, -87.677251, Taco Bell Florence...", -87.677251)]
        [InlineData("32.366805, -86.299969, Taco Bell Montgomery...", -86.299969)]
        [InlineData("34.746483, -92.289597, Taco Bell Little Rock...", -92.289597)]
        //Add additional inline data. Refer to your CSV file. GOAL is to make sure the long stored in csv is the same as 
        //   a location returned by itrackable from the parse method.
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete the test with Arrange, Act, Assert steps below.
            //       Note: "line" string represents input data we will Parse 
            //       to extract the Longitude.  
            //       Each "line" from your .csv file
            //       represents a TacoBell location

            //Arrange - write the code needed in order to call the method being tested
            var tacoParser = new TacoParser(); //contains parser method ... parse method returns an object
            //Act
            var actual = tacoParser.Parse(line).Location.Longitude;
            //Assert
            Assert.Equal(expected, actual);
        }


        //TODO: Create a test called ShouldParseLatitude
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("32.614768, -85.433999, Taco Bell Auburn...", 32.614768)]
        [InlineData("34.730369, -86.586104, Taco Bell Huntsville...", 34.730369)]
        [InlineData("30.694357, -88.043054, Taco Bell Mobile...", 30.694357)]
        [InlineData("33.520661, -86.802490, Taco Bell Birmingham...", 33.520661)]
        [InlineData("33.209841, -87.569173, Taco Bell Tuscaloosa...", 33.209841)]
        [InlineData("31.223230, -85.390488, Taco Bell Dothan...", 31.223230)]
        [InlineData("34.802868, -87.677251, Taco Bell Florence...", 34.802868)]
        [InlineData("32.366805, -86.299969, Taco Bell Montgomery...", 32.366805)]
        [InlineData("34.746483, -92.289597, Taco Bell Little Rock...", 34.746483)]
        public void ShouldParseLatitude(string line, double expected)
        {
            var tacoParserInstance = new TacoParser();

            var actual = tacoParserInstance.Parse(line).Location.Latitude;

            Assert.Equal(expected, actual);
        }

    }
}
