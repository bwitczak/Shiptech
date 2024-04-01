using FluentValidation;
using Shiptech.Application.Commands;
using Shiptech.Application.Queries;
using Shiptech.Application.Services;
using Shiptech.Application.Validators.Consts;

namespace Shiptech.Application.Validators.AssortmentDictionary;

public class GetAssortmentDictionaryValidator : AbstractValidator<GetAssortmentDictionary>
{
    public GetAssortmentDictionaryValidator(IAssortmentDictionaryReadService service)
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("ASSORTMENT_DICTIONARY_400_ID")
            .WithMessage("Identyfikator asortymentu nie może być pusty!")
            .MustAsync(async (x, _) => await service.ExistsById(x))
            .WithMessage(x => $"{x.Id} nie istnieje w bazie!")
            .WithErrorCode("ASSORTMENT_DICTIONARY_404_ID");
    }
}