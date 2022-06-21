using GameOnlineShop.Data.Models;
using GameShop.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Data
{
    public class AppDBContent : IdentityDbContext<User>
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) { }

        public DbSet<Game> DbGame { get; set; }
        public DbSet<Category> DbCategory { get; set; }
        public DbSet<ShopCartItem> DbShopCartItem { get; set;}
        public DbSet<Order> DbOrder { get; set; }
        public DbSet<OrderDetail> DbOrderDetails { get; set; }
    }
}
