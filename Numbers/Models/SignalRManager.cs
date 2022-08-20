using Microsoft.AspNetCore.SignalR;
using Numbers.Hubs;
using Numbers.Interfaces;

namespace Numbers.Models
{
    public class SignalRManager: ISignalRManager
    {
        private readonly IHubContext<NumberGeneratorHub> _hub;
        private readonly ILogger<SignalRManager> _logger;
        private static Timer? _timer;

        public static readonly int MIN = 1;
        public static readonly int MAX = 100;
        public static readonly int DURATION = 5;

        public SignalRManager(ILogger<SignalRManager> logger, IHubContext<NumberGeneratorHub> hub)
        {
            _hub = hub;
            _logger = logger;
        }

        public void StartTimer()
        {
            try
            {
                if (_timer is null)
                {
                    var startTimeSpan = TimeSpan.Zero;
                    var periodTimeSpan = TimeSpan.FromSeconds(DURATION);

                    _timer = new System.Threading.Timer((e) =>
                    {
                        SendRandomToClient();
                    }, null, startTimeSpan, periodTimeSpan);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SignalRManager StartTimer");
            }
        }

        void SendRandomToClient()
        {
            var rnd = new Random();
            _hub.Clients.All.SendAsync("pushInfo", rnd.Next(MIN, MAX));
        }
    }
}
