using MyBoardGamesMVC.Access.Interfaces;
using MyBoardGamesMVC.Model;
using Newtonsoft.Json;

namespace MyBoardGamesMVC.Access {
    public class GameCharacterAccess : IGameCharacterAccess {

        private readonly IServiceConnection _serviceConnection;

        public string UseServiceUrl { get; set; }

        public GameCharacterAccess(IConfiguration inConfiguration, IServiceConnection serviceConnection) {
            UseServiceUrl = inConfiguration["ServiceUrlToUse"]!;
            _serviceConnection = serviceConnection;
            _serviceConnection.BaseUrl = UseServiceUrl;
        }

        public async Task<List<GameCharacter>> GetAll() {
            List<GameCharacter>? foundGameCharacters = null;
            _serviceConnection.UseUrl = _serviceConnection.BaseUrl += "characters";

            if (_serviceConnection != null) {
                try {
                    var response = await _serviceConnection.CallServiceGet();
                    if (response != null && response.IsSuccessStatusCode) {
                        var content = await response.Content.ReadAsStringAsync();
                        foundGameCharacters = JsonConvert.DeserializeObject<List<GameCharacter>>(content);
                    } else {
                        foundGameCharacters = null;
                    }
                } catch (Exception ex) {
                    await Console.Out.WriteLineAsync(ex.Message);
                    //MAKE LOG FILE !
                }
            }
            return foundGameCharacters;
        }

        public List<GameCharacter> GetCharactersByVersionId() {
            throw new NotImplementedException();
        }
    }
}
