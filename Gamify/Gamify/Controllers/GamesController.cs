using Gamify.Models;
using Gamify.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Gamify.Controllers
{
    public class GamesController : Controller
    {
        private ApplicationDbContext _context;

        public GamesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageGames))
            {
                return View("List");
            }
            else
            {
                return View("ReadOnlyList");
            }
        }

        public ActionResult GameDetails(int id)
        {
            var game = _context.Games.Include(g => g.Genre).SingleOrDefault(g => g.Id == id);

            if (game == null)
                return HttpNotFound();

            return View(game);
        }

        [Authorize(Roles = RoleName.CanManageGames)]
        public ActionResult NewGame()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new GameFormViewModel()
            {
                Genres = genres
            };

            return View("GameForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageGames)]
        public ActionResult SaveGame(Game game)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new GameFormViewModel
                {
                    Genres = _context.Genres.ToList()
                };

                return View("GameForm", viewModel);
            }

            if (game.Id == 0)
            {
                game.DateAdded = DateTime.Now;
                game.NumberAvailable = game.NumberInStock;
                _context.Games.Add(game);
            }
            else
            {
                var gameInDb = _context.Games.Single(g => g.Id == game.Id);

                gameInDb.Name = game.Name;
                gameInDb.ReleaseDate = game.ReleaseDate;
                gameInDb.GenreId = game.GenreId;
                gameInDb.NumberInStock = game.NumberInStock;
                gameInDb.NumberAvailable = game.NumberInStock;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Games");
        }

        [Authorize(Roles = RoleName.CanManageGames)]
        public ActionResult EditGame(int id)
        {
            var game = _context.Games.SingleOrDefault(g => g.Id == id);

            if (game == null)
            {
                return HttpNotFound();
            }

            var viewModel = new GameFormViewModel(game)
            {
                Genres = _context.Genres.ToList()
            };

            return View("GameForm", viewModel);
        }

        // GET: Games/Random
        public ActionResult Random()
        {
            var game = new Game() { Name = "Prey" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
            };

            var viewModel = new RandomGameViewModel
            {
                Game = game,
                Customers = customers
            };
            return View(viewModel);
        }
    }
}