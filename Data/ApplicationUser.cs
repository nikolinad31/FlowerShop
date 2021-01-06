using Microsoft.AspNetCore.Identity;

namespace FlowerShop.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FavoriteFlower { get; set; }
    }
}