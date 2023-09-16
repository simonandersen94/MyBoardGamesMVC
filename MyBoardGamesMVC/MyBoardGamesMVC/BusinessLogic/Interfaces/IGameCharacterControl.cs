using MyBoardGamesMVC.Model;

namespace MyBoardGamesMVC.BusinessLogic.Interfaces {
    public interface IGameCharacterControl {
        Task<List<GameCharacter>> GetAll();
    }
}
