using MyBoardGamesMVC.BusinessLogic.Interfaces;
using MyBoardGamesMVC.Model;

namespace MyBoardGamesMVC.BusinessLogic {
    public class MergedModelControl : IMergedModellControl {

        private readonly IGameControl _gameControl;
        private readonly IGameVersionControl _gameVersionControl;
        private readonly IGameCharacterControl _characterControl;
        public MergedModelControl(IGameControl gameControl, IGameVersionControl gameVersionControl, IGameCharacterControl characterControl) {
            _gameControl = gameControl;
            _gameVersionControl = gameVersionControl;
            _characterControl = characterControl;
        }

        public async Task<MergedModel> Get() {
            List<GameVersion> foundVersions = await _gameVersionControl.GetAll();
            List<GameCharacter> foundCharacters = await _characterControl.GetAll();
            List<Game> foundGames = await _gameControl.GetAll();
            foundVersions = foundVersions.OrderBy(x => x.Game.GameId).ToList();
            foundGames = foundGames.OrderBy(x => x.GameId).ToList();
            MergedModel mergedModel = new MergedModel();
            mergedModel.Characters = foundCharacters;
            mergedModel.Versions = foundVersions;
            mergedModel.Games = foundGames;
            return mergedModel;
        }
    }
}
