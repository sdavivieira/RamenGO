namespace RamenGo.Model
{
    public class Order
    {
        public int BrothId { get; set; }
        public int ProteinId { get; set; }
    }
    public class Proteins
    {
        public int Id { get; set; }
        public string ImageInactive { get; set; }
        public string ImageActive { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
    public class Broths
    {
        public int Id { get; set; }
        public string ImageInactive { get; set; }
        public string ImageActive { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
    public class OrderDetails
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
