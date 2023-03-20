using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Payment_MDB_API.Models
{
    public class Payment
    {

        [BsonRepresentation(BsonType.ObjectId)]

        public string? id { get; set; }
        [BsonElement("ProductName")]
        public string ProductName { get; set; }
        public string CompanyName { get; set; }
        public string ProductPrice { get; set; }
        public string DeliveryAdderss { get; set; }
        public string PaymentType { get; set; }




    }
}
