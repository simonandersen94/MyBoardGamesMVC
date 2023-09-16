using MyBoardGamesMVC.Access;
using MyBoardGamesMVC.Access.Interfaces;
using MyBoardGamesMVC.BusinessLogic.Interfaces;
using MyBoardGamesMVC.Model;

namespace MyBoardGamesMVC.BusinessLogic {
    public class GameCharacterControl : IGameCharacterControl {

        private readonly IGameCharacterAccess _gameCharacterAccess;
        public GameCharacterControl(IGameCharacterAccess gameCharacterAccess) {
            _gameCharacterAccess = gameCharacterAccess;
        }
        public Task<List<GameCharacter>> GetAll() {
            return _gameCharacterAccess.GetAll();
        }
    }
}
