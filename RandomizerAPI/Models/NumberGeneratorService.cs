using RandomizerAPI.Interfaces;

namespace RandomizerAPI.Models
{
    public class NumberGeneratorService : INumberGeneratorService
    {
        public static readonly int MIN = 1;
        public static readonly int MAX = 100;

        public int GenerateRandomNumber()
        {
            var rnd = new Random();
            return rnd.Next(MIN, MAX);
           
        }
    }
}
