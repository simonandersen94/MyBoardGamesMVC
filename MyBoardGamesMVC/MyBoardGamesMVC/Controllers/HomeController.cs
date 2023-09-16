using Microsoft.AspNetCore.Mvc;
using MyBoardGamesMVC.BusinessLogic.Interfaces;

namespace MyBoardGamesMVC.Controllers {
    public class HomeController : Controller {

        private readonly IGameControl _gameControl;

        public HomeController(IGameControl gameControl) {
            _gameControl = gameControl;
        }
        public async Task<ActionResult> Index() {
            int foundAmount = await _gameControl.GetAmountOfGames();
            ViewData["amountOfGames"] = foundAmount;
            return View();
        }
    }
}
