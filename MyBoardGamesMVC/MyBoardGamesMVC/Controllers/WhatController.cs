using Microsoft.AspNetCore.Mvc;

namespace MyBoardGamesMVC.Controllers {
    public class WhatController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
