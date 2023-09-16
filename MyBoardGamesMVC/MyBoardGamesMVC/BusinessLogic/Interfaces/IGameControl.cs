using MyBoardGamesMVC.Model;

namespace MyBoardGamesMVC.BusinessLogic.Interfaces {
    public interface IGameControl {
        Task<List<Game>> GetAll();
        Task<MergedGame> GetRandomGAmeByNoOfPlayers(int no);
        Task<int> GetAmountOfGames();
    }
}
