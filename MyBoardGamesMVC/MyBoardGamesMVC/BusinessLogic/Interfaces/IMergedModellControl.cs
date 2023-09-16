using MyBoardGamesMVC.Model;

namespace MyBoardGamesMVC.BusinessLogic.Interfaces {
    public interface IMergedModellControl {
        Task<MergedModel> Get();
    }
}
