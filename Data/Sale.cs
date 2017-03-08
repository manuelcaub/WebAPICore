namespace WebAPICore.Data
{
    public class Sale
    {
        public ulong Id { get; set; }

        public Product Product { get; set; }

        public uint Quantity { get; set; }
    }
}