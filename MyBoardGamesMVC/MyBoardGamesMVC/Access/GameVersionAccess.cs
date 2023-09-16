using MyBoardGamesMVC.Access.Interfaces;
using MyBoardGamesMVC.Model;
using Newtonsoft.Json;

namespace MyBoardGamesMVC.Access {
    public class GameVersionAccess : IGameVersionAccess {

        private readonly IServiceConnection _serviceConnection;

        public string UseServiceUrl { get; set; }

        public GameVersionAccess(IConfiguration inConfiguration, IServiceConnection serviceConnection) {
            UseServiceUrl = inConfiguration["ServiceUrlToUse"]!;
            _serviceConnection = serviceConnection;
            _serviceConnection.BaseUrl = UseServiceUrl;
        }

        public async Task<List<GameVersion>> GetAll() {
            List<GameVersion>? foundGameVersions = null;
            _serviceConnection.UseUrl = _serviceConnection.BaseUrl += "versions";

            if (_serviceConnection != null) {
                try {
                    var response = await _serviceConnection.CallServiceGet();
                    if (response != null && response.IsSuccessStatusCode) {
                        var content = await response.Content.ReadAsStringAsync();
                        foundGameVersions = JsonConvert.DeserializeObject<List<GameVersion>>(content);
                    } else {
                        foundGameVersions = null;
                    }
                } catch (Exception ex) {
                    await Console.Out.WriteLineAsync(ex.Message);
                    //MAKE LOG FILE !
                }
            }
            return foundGameVersions;
        }

        public List<GameVersion> GetVersionByGameId() {
            throw new NotImplementedException();
        }
    }
}
