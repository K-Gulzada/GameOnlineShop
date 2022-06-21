using GameOnlineShop.ViewModels;
using GameShop.Data.Interfaces;
using GameShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GameShop.Data.Repository
{
    public class GamesRepository : IAllGames
    {
        private readonly AppDBContent _content;

        public GamesRepository(AppDBContent _content)
        {
            this._content = _content;
        }
        public IEnumerable<Game> Games => _content.DbGame.Include(c => c.Category);

        public void AddNew(GameViewModel game)
        {
            Game newGame = new Game();
            newGame.Name = game.Name;
            newGame.Desc = game.Desc;
            newGame.Price = game.Price;
            var category = _content.DbCategory.SingleOrDefault(x => x.CategoryName == "Action");
            newGame.Category = category;
            newGame.CategoryId = category.Id;
            newGame.Quantity = game.Quantity;
            newGame.Image = game.Image;
            newGame.IsAvailable = true;

            _content.Add(newGame);
            _content.SaveChanges();
        }

        public Game getGame(int id) => _content.DbGame.FirstOrDefault(p => p.Id == id);
    }
}
