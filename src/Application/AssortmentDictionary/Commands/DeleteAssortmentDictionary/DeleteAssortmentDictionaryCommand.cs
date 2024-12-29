using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;

namespace Shiptech.Application.AssortmentDictionary.Commands.DeleteAssortmentDictionary;

public record DeleteAssortmentDictionaryCommand(Ulid Id) : IRequest
{
}

public class DeleteAssortmentDictionaryCommandValidator : AbstractValidator<DeleteAssortmentDictionaryCommand>
{
    public DeleteAssortmentDictionaryCommandValidator(IAssortmentDictionaryService service)
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("DELETE_ASSORTMENT_DICTIONARY_400_ID")
            .WithMessage("Identyfikator asortymentu nie może być pusty!")
            .MustAsync(async (x, _) => await service.ExistsById(x))
            .WithMessage(x => $"{x.Id} nie istnieje w bazie!")
            .WithErrorCode("DELETE_ASSORTMENT_DICTIONARY_404_ID");
    }
}

public class DeleteAssortmentDictionaryCommandHandler : IRequestHandler<DeleteAssortmentDictionaryCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteAssortmentDictionaryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteAssortmentDictionaryCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.AssortmentDictionary? assortmentDictionary = await _context.AssortmentDictionaries
            .AsNoTracking()
            .SingleAsync(x => x.Id == request.Id, cancellationToken);

        _context.AssortmentDictionaries.Remove(assortmentDictionary);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
