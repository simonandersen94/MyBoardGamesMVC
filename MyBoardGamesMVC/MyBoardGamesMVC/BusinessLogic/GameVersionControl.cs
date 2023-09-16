using MyBoardGamesMVC.Access.Interfaces;
using MyBoardGamesMVC.BusinessLogic.Interfaces;
using MyBoardGamesMVC.Model;

namespace MyBoardGamesMVC.BusinessLogic {
    public class GameVersionControl : IGameVersionControl {

        private readonly IGameVersionAccess _gameVersionAccess;
        public GameVersionControl(IGameVersionAccess gameVersionAccess) {
            _gameVersionAccess = gameVersionAccess;
        }

        public Task<List<GameVersion>> GetAll() {
            return _gameVersionAccess.GetAll();
        }
    }
}
