namespace WebAPICore.Data
{
    public class Purchase
    {
        public ulong Id { get; set; }

        public uint Quantity { get; set; }

        public Product Product { get; set; }
    }
}