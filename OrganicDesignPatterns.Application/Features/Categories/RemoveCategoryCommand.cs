using MediatR;
using OrganicDesignPatterns.Domain.Interfaces;

namespace OrganicDesignPatterns.Application.Features.Categories.Commands;

public class RemoveCategoryCommand : IRequest<bool>
{
    public int Id { get; set; }

    public RemoveCategoryCommand(int id)
    {
        Id = id;
    }
}

public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.Categories.GetByIdAsync(request.Id);

        if (category is null)
        {
            return false;
        }

        _unitOfWork.Categories.Delete(category);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}