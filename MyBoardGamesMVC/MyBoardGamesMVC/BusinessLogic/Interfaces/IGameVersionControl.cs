using MyBoardGamesMVC.Model;

namespace MyBoardGamesMVC.BusinessLogic.Interfaces {
    public interface IGameVersionControl {
        Task<List<GameVersion>> GetAll();
    }
}
