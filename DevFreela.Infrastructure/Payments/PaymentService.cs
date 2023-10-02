using System.Net.Mime;
using System.Text;
using System.Text.Json;
using DevFreela.Core.DTOs;
using DevFreela.Core.Services;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Infrastructure.Payments;

public class PaymentService : IPaymentService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _paymentsBaseUrl;
    private readonly IMessageBusService _messageBusService;
    private const string QUEUE_NAME = "Payments";


    public PaymentService(
        IHttpClientFactory httpClientFactory,
        IMessageBusService messageBusService,
        IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _messageBusService = messageBusService;
        _paymentsBaseUrl = configuration.GetSection("Services:Payments").Value;
    }

    public async Task<bool> ProcessPaymentByHttpRequest(PaymentInfoDTO paymentInfoDTO)
    {
        var url = $"{_paymentsBaseUrl}/api/payments";
        var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDTO);

        var paymentInfoContent = new StringContent(
            content: paymentInfoJson,
            encoding: Encoding.UTF8,
            mediaType: MediaTypeNames.Application.Json
        );

        var httpClient = _httpClientFactory.CreateClient("payments");

        var response = await httpClient.PostAsync(url, paymentInfoContent);

        return response.IsSuccessStatusCode;
    }

    public void ProcessPaymentByMessageBroker(PaymentInfoDTO paymentInfoDTO)
    {
        var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDTO);

        var paymentInfoBytes = Encoding.UTF8.GetBytes(paymentInfoJson);

        _messageBusService.Publish(QUEUE_NAME, paymentInfoBytes);
    }
}