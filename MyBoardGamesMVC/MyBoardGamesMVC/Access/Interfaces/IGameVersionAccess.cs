using MyBoardGamesMVC.Model;

namespace MyBoardGamesMVC.Access.Interfaces {
    public interface IGameVersionAccess {
        Task<List<GameVersion>> GetAll();
        List<GameVersion> GetVersionByGameId();
    }
}
