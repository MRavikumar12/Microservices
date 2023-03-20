using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Payment_MDB_API.Models;

namespace Payment_MDB_API.Services
{
    public class PaymentService
    {
        private readonly IMongoCollection<Payment> _payments;

        public PaymentService(IOptions<PaymentStoreSetting> paymentStoreSettings)
        {
            var mongoClient=new MongoClient(paymentStoreSettings.Value.ConnectionString);

            var mongoDb = mongoClient.GetDatabase(paymentStoreSettings.Value.DatabaseName);

            _payments = mongoDb.GetCollection<Payment>(paymentStoreSettings.Value.PaymentCollectionName);
        }

        public async Task<List<Payment>>GetPayments()=>
            await _payments.Find(_=>true).ToListAsync();

        public async Task<Payment>GetPaymentById(string id)=>
            await _payments.Find(x=>x.id==id).FirstOrDefaultAsync();

        public async Task CreatePayment(Payment payment)=>
            await _payments.InsertOneAsync(payment);

        public async Task UpdatePayment(string id, Payment payment) =>
            await _payments.ReplaceOneAsync(x => x.id == id,payment);

        public async Task DeletePayment(string id)=>
            await _payments.DeleteOneAsync(x=>x.id== id);
    }
}
