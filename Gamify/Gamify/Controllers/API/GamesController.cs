using AutoMapper;
using Gamify.Dtos;
using Gamify.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Gamify.Controllers.API
{
    public class GamesController : ApiController
    {
        private ApplicationDbContext _context;
    
        public GamesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/games
        public IEnumerable<GameDto> GetGames(string query = null)
        {
            var gamesQuery = _context.Games
                .Include(g => g.Genre).Where(g => g.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
            {
                gamesQuery = gamesQuery.Where(g => g.Name.Contains(query));
            }

            return gamesQuery
                .ToList()
                .Select(Mapper.Map<Game, GameDto>);
        }

        //GET /api/games/1
        public IHttpActionResult GetGame(int id)
        {
            var game = _context.Games.SingleOrDefault(g => g.Id == id);
    
            if (game == null)
            {
                return NotFound();
            }
    
            return Ok(Mapper.Map<Game, GameDto>(game));
        }
    
        //POST /api/games
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageGames)]
        public IHttpActionResult CreateGame(GameDto gameDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
    
            var game = Mapper.Map<GameDto, Game>(gameDto);
    
            _context.Games.Add(game);
            _context.SaveChanges();
    
            gameDto.Id = game.Id;
    
            return Created(new Uri(Request.RequestUri + "/" + game.Id), gameDto);
        }
    
        //POST /api/games/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageGames)]
        public IHttpActionResult UpdateGame(int id, GameDto gameDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
    
            var gameInDb = _context.Games.SingleOrDefault(g => g.Id == id);
    
            if (gameInDb == null)
            {
                return NotFound();
            }
    
            Mapper.Map(gameDto, gameInDb);
    
            _context.SaveChanges();
    
            return Ok();
    
        }
    
        //DELETE /api/customers/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageGames)]
        public IHttpActionResult DeleteGame(int id)
        {
            var gameInDb = _context.Games.SingleOrDefault(g => g.Id == id);
    
            if (gameInDb == null)
            {
                return NotFound();
            }
    
            _context.Games.Remove(gameInDb);
            _context.SaveChanges();
    
            return Ok();
        }
    
    
    }
}
