using RandomizerAPI.Interfaces;
using RandomizerAPI.Models;

namespace RandomizerAPI.Tests
{
    public class NumberGeneratorServiceTest
    {
        private readonly INumberGeneratorService _numberService;

        public NumberGeneratorServiceTest()
        {
            _numberService = new NumberGeneratorService();
        }

        [Fact]
        public void CheckRandomIsWorking()
        {
            Assert.True(_numberService.GenerateRandomNumber() > NumberGeneratorService.MIN);
        }

        [Fact]
        public void RangeIsCorrect()
        {
            var value = _numberService.GenerateRandomNumber();
            Assert.True(value >= NumberGeneratorService.MIN && value <= NumberGeneratorService.MAX);
        }
    }
}