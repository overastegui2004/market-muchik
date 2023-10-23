using market.muchik.pay.domain.entities;
using market.muchik.pay.domain.interfaces;
using market.muchik.pay.infrastructure.context;

namespace market.muchik.pay.infrastructure.repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(PaymentContext context) : base(context) { }
    }
}
