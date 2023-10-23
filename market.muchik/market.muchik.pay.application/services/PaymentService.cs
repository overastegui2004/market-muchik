using AutoMapper;
using market.muchik.pay.application.dto.Creates;
using market.muchik.pay.application.interfaces;
using market.muchik.pay.domain.entities;
using market.muchik.pay.domain.interfaces;

namespace market.muchik.pay.application.services
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IMapper mapper, IPaymentRepository paymentRepository) 
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
        }

        public bool CreatePayment(CreatePaymentDto createPaymentDto)
        {
            var payment = _mapper.Map<Payment>(createPaymentDto);
            _paymentRepository.Add(payment);
            return _paymentRepository.Save();
        }
    }
}
