using MediatR;
using OrganicDesignPatterns.Domain.Interfaces;

namespace OrganicDesignPatterns.Application.Features.Products.Commands;

public class RemoveProductCommand : IRequest<bool>
{
    public int Id { get; set; }

    public RemoveProductCommand(int id)
    {
        Id = id;
    }
}

public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.Id);

        if (product is null)
        {
            return false;
        }

        _unitOfWork.Products.Delete(product);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}