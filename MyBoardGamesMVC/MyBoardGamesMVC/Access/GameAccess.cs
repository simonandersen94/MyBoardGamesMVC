using Microsoft.AspNetCore.Mvc;
using MyBoardGamesMVC.Access.Interfaces;
using MyBoardGamesMVC.Model;
using Newtonsoft.Json;

namespace MyBoardGamesMVC.Access {
    public class GameAccess : IGameAccess {

        private readonly IServiceConnection _serviceConnection;

        public string UseServiceUrl { get; set; }

        public GameAccess(IConfiguration inConfiguration, IServiceConnection serviceConnection) {
            UseServiceUrl = inConfiguration["ServiceUrlToUse"]!;
            _serviceConnection = serviceConnection;
            _serviceConnection.BaseUrl = UseServiceUrl;
        }

        public async Task<List<Game>> GetAll() {
            List<Game>? foundGames = null;
            _serviceConnection.UseUrl = _serviceConnection.BaseUrl += "games";

            if (_serviceConnection != null) {
                try {
                    var response = await _serviceConnection.CallServiceGet();
                    if (response != null && response.IsSuccessStatusCode) {
                        var content = await response.Content.ReadAsStringAsync();
                        foundGames = JsonConvert.DeserializeObject<List<Game>>(content);
                    } else {
                        foundGames = null;
                    }
                } catch (Exception ex) {
                    await Console.Out.WriteLineAsync(ex.Message);
                    //MAKE LOG FILE !
                }
            }
            return foundGames;
        }

        public async Task<MergedGame> GetGameByNumbersOfPlayers(int no) {
            MergedGame? foundRandomGame = null;
            _serviceConnection.UseUrl = _serviceConnection.BaseUrl += "games/players";

            //if (no > 0) {
            _serviceConnection.UseUrl += $"/{no}";
            //}

            if (_serviceConnection != null) {
                try {
                    var response = await _serviceConnection.CallServiceGet();
                    if (response != null && response.IsSuccessStatusCode) {
                        var content = await response.Content.ReadAsStringAsync();
                        foundRandomGame = JsonConvert.DeserializeObject<MergedGame>(content);
                    } else {
                        foundRandomGame = null;
                    }
                } catch (Exception ex) {
                    await Console.Out.WriteLineAsync(ex.Message);
                    //MAKE LOG FILE !
                }
            }
            return foundRandomGame;
        }

        public async Task<int> GetAmountOfGames() {
            int foundAmount = 0;
            _serviceConnection.UseUrl = _serviceConnection.BaseUrl += "games/amount";

            if (_serviceConnection != null) {
                try {
                    var response = await _serviceConnection.CallServiceGet();
                    if (response != null && response.IsSuccessStatusCode) {
                        var content = await response.Content.ReadAsStringAsync();
                        foundAmount = JsonConvert.DeserializeObject<int>(content);
                    } else {
                        foundAmount = 0;
                    }
                } catch (Exception ex) {
                    await Console.Out.WriteLineAsync(ex.Message);
                    //MAKE LOG FILE !
                }
            }
            return foundAmount;
        }
    }
}
