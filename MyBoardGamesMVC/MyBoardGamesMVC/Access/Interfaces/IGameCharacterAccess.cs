using MyBoardGamesMVC.Model;

namespace MyBoardGamesMVC.Access.Interfaces {
    public interface IGameCharacterAccess {
        Task<List<GameCharacter>> GetAll();
        List<GameCharacter> GetCharactersByVersionId();
    }
}
