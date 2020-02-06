using ArtimeticExpressionCaclulator;
using System;
using Xunit;

namespace ArtimeticExpressionsCaclulatorTests
{
    public class ExpressionsProcessorTests
    {
        ExpressionsProcessor processor = new ExpressionsProcessor(new Operands());
        [Fact]
        public void ValidInput()
        {
            var input = "1/2 * 3_3/4";       
            var output = processor.Process(input);
            Assert.Equal("1_7/8", output);



        }

        [Fact]
        public void ValidInput_Improper_Fraction()
        {
            var input = "2_3/8 + 9/8";
            var output = processor.Process(input);
            Assert.Equal("3_1/2", output);

        }

        [Fact]
        public void ValidInput_WholeNumber()
        {
            var input = "3 * 4";
            var output = processor.Process(input);
            Assert.Equal("12", output);
        }

        [Fact]
        public void ValidInput_Longer_expression()
        {
            var input = "3 * 4 + 2_3/8 + 9/8";
            var output = processor.Process(input);
            Assert.Equal("15_1/2", output);
        }

        [Fact]
        public void In_ValidInput_Longer_expression()
        {
            var input = "3  4 2_3/8 9/8";
            Assert.Throws<ArgumentException>(() => processor.Process(input));

        }
        [Fact]
        public void InValidInput_Empty()
        {
            var input = "";
            var output = processor.Process(input);
            Assert.Null(output);
        }

        [Fact]
        public void InValidInput_Non_number()
        {
            var input = "a + c";        
            Assert.Throws<ArgumentException>(() => processor.Process(input));
        }

    }
}
