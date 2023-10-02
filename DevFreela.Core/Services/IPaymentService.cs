using DevFreela.Core.DTOs;

namespace DevFreela.Core.Services;

public interface IPaymentService
{
    Task<bool> ProcessPaymentByHttpRequest(PaymentInfoDTO paymentInfoDTO);
    void ProcessPaymentByMessageBroker(PaymentInfoDTO paymentInfoDTO);
}