using System.Transactions;
using MediatR;
using Shiptech.Application.Common.Interfaces.Database;

namespace Shiptech.Application.Common.Behaviours;

public class TransactionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly IApplicationDbContext _context;

    public TransactionBehaviour(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!typeof(TRequest).Name.EndsWith("Command"))
        {
            return await next();
        }

        using (TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled))
        {
            TResponse response = await next();
            await _context.SaveChangesAsync(cancellationToken);

            transaction.Complete();
            return response;
        }
    }
}
