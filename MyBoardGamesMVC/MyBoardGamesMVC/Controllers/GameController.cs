using Microsoft.AspNetCore.Mvc;
using MyBoardGamesMVC.BusinessLogic.Interfaces;
using MyBoardGamesMVC.Model;
using System.Dynamic;

namespace MyBoardGamesMVC.Controllers {
    public class GameController : Controller {

        private readonly IGameVersionControl _gameVersionControl;
        private readonly IGameControl _gameControl;

        public GameController(IGameVersionControl gameVersionControl, IGameControl gameControl) {
            _gameVersionControl = gameVersionControl;
            _gameControl = gameControl;
        }

        public async Task<IActionResult> Index() {
            List<GameVersion> foundVersions = await _gameVersionControl.GetAll();
            foundVersions = foundVersions.OrderBy(x => x.Game.GameId).ToList();
            return View(foundVersions);
        }

        public async Task<IActionResult> RandomGame([FromQuery] int no) {
            MergedGame foundRandomGame = await _gameControl.GetRandomGAmeByNoOfPlayers(no);
            return View(foundRandomGame);
        }
    }
}
