using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Projects.Commands.FinishProject;

public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, bool>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IPaymentService _paymentService;
    private readonly IUnitOfWork _unitOfWork;

    public FinishProjectCommandHandler(
        IProjectRepository projectRepository, 
        IPaymentService paymentService, 
        IUnitOfWork unitOfWork)
    {
        _projectRepository = projectRepository;
        _paymentService = paymentService;
        _unitOfWork = unitOfWork;
    }


    public async Task<bool> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(request.Id);

        var paymentInfoDto = new PaymentInfoDTO(
            request.Id,
            request.CreditCardNumber,
            request.Cvv,
            request.ExpiresAt,
            request.FullName,
            project.TotalCost
        );

        _paymentService.ProcessPaymentByMessageBroker(paymentInfoDto);

        project.SetPaymentPending();

        await _unitOfWork.CompleteAsync();

        return true;
    }
}