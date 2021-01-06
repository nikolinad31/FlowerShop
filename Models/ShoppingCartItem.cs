namespace FlowerShop.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public Flower Flower { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
    }