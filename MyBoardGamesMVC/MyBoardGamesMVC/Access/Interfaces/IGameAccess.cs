using MyBoardGamesMVC.Model;

namespace MyBoardGamesMVC.Access.Interfaces {
    public interface IGameAccess {
        Task<List<Game>> GetAll();
        Task<MergedGame> GetGameByNumbersOfPlayers(int no);
        Task<int> GetAmountOfGames();
    }
}
