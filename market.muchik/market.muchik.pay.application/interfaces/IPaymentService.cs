using market.muchik.pay.application.dto.Creates;

namespace market.muchik.pay.application.interfaces
{
    public interface IPaymentService
    {
        bool CreatePayment(CreatePaymentDto createPaymentDto);
    }
}
