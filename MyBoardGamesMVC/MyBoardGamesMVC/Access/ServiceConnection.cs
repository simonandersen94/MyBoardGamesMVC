using MyBoardGamesMVC.Access.Interfaces;
using System.Net.Http;

namespace MyBoardGamesMVC.Access {
    public class ServiceConnection : IServiceConnection {
        public HttpClient HttpEnabler { get; init; }
        public string? BaseUrl { get; set; }
        public string? UseUrl { get; set; }

        public ServiceConnection() {
            HttpEnabler = new HttpClient();
        }

        public async Task<HttpResponseMessage?> CallServiceGet() {
            HttpResponseMessage? hrm = null;
            if (UseUrl != null) {
                hrm = await HttpEnabler.GetAsync(UseUrl);
            }
            return hrm;
        }
    }
}
