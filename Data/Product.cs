namespace WebAPICore.Data
{    
    public class Product
    {
        public ulong Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public ProductType Type { get; set; }
    }
}