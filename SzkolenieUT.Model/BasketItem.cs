namespace SzkolenieUT.Model
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal NetPrice { get; set; }
        public decimal Tax { get; set; }
        
        public int Count { get; set; }
    }
}
