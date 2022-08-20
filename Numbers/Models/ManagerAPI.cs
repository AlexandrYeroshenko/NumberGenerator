using Numbers.Interfaces;
using System.Net.Http.Headers;

namespace Numbers.Models
{
    public class ManagerAPI : IManagerAPI
    {
        private readonly IConfiguration _configuraion;
        private readonly ILogger<ManagerAPI> _logger;

        public ManagerAPI(ILogger<ManagerAPI> logger,IConfiguration configuration)
        {
            _logger = logger;
            _configuraion = configuration;
        }

        /// <summary>
        /// Call GenerateRandomNumber from RandomizerAPI
        /// </summary>
        /// <returns>Random number</returns>
        public async Task<int> GetRandomNumberAsync()
        {
            int result = -1;
            try
            {
                var RandomizerAPIUrl = _configuraion["RandomizerAPI"];

                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(RandomizerAPIUrl);
                    httpClient.DefaultRequestHeaders.Accept.Clear();

                    using (var response = await httpClient.GetAsync("Randomize"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var randomNumString = await response.Content.ReadAsStringAsync();
                            result = int.Parse(randomNumString);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetRandomNumberAsync");
            }

            return result;
        }
    }
}
