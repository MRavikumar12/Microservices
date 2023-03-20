namespace Payment_MDB_API.Models
{
    public class PaymentStoreSetting
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string PaymentCollectionName { get; set; } = null!;
    }
}
