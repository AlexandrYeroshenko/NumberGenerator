using Microsoft.AspNetCore.Mvc;
using RandomizerAPI.Interfaces;

namespace RandomizerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RandomizeController : ControllerBase
    {
        
        private readonly INumberGeneratorService _numberService;

        public RandomizeController(INumberGeneratorService numberService)
        {
            _numberService = numberService;
        }

        [HttpGet(Name = "Randomize")]
        public int Get()
        {
            return _numberService.GenerateRandomNumber();
        }
    }
}