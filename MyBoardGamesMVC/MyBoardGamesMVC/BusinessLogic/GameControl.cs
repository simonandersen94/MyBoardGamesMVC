using MyBoardGamesMVC.BusinessLogic.Interfaces;
using MyBoardGamesMVC.Access.Interfaces;
using MyBoardGamesMVC.Model;
using Microsoft.AspNetCore.Mvc;

namespace MyBoardGamesMVC.BusinessLogic {
    public class GameControl : IGameControl {

        private readonly IGameAccess _gameAccess;
        public GameControl(IGameAccess gameAccess) {
            _gameAccess = gameAccess;
        }

        public Task<List<Game>> GetAll() {
            return _gameAccess.GetAll();
        }

        public Task<MergedGame> GetRandomGAmeByNoOfPlayers(int no) {
            return _gameAccess.GetGameByNumbersOfPlayers(no);
        }

        public Task<int> GetAmountOfGames() {
            return _gameAccess.GetAmountOfGames();
        }
    }
}
