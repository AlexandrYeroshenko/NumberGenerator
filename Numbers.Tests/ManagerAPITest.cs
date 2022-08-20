using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Numbers.Interfaces;
using Numbers.Models;

namespace Numbers.Tests
{
    public class ManagerAPITest
    {

        ILogger<ManagerAPI> _logger;

        public ManagerAPITest()
        {
            _logger = MockLogger();
        }

        ILogger<ManagerAPI> MockLogger()
        {
            var mock = new Mock<ILogger<ManagerAPI>>();
            ILogger<ManagerAPI> logger = mock.Object;
            return logger;
        }

        IConfiguration MockConfig(string key, string value)
        {
            var inMemorySettings = new Dictionary<string, string> {
                {key, value}
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            return configuration;
        }



        [Fact]
        public void CheckBadRequest()
        {
            var config = MockConfig("RandomizerAPI","");

            var apiManager = new ManagerAPI(_logger, config);
            var task = apiManager.GetRandomNumberAsync();
            task.Wait();

            Assert.True(task.Result == -1);

        }

        [Fact]
        public void CheckGoodRequest()
        {
            var config = MockConfig("RandomizerAPI", "http://18.193.80.174:5000/");

            var apiManager = new ManagerAPI(_logger, config);
            var task = apiManager.GetRandomNumberAsync();
            task.Wait();

            Assert.True(task.Result > 0);

        }
    }
}