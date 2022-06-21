using Microsoft.AspNetCore.Http;

namespace GameOnlineShop.ViewModels
{
    public class GameViewModel
    {
        public string Name { get; set; }
        public string Desc { get; set; } 
        public string Image { get; set; }
        public IFormFile ImageFile { get; set; }
        public bool IsAvailable { get; set; } = true;
        public int Quantity { get; set; }
        public ushort Price { get; set; }
        public int CategoryId { get; set; }
        public virtual CategoryViewModel Category { get; set; }  // category the game belongs to
    }
}
