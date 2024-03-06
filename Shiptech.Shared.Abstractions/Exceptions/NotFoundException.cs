namespace Shiptech.Shared.Abstractions.Exceptions;

public abstract class NotFoundException : BaseException
{
    private readonly string? _field;
    private readonly string _value;
    
    protected NotFoundException(string value) : base($"Not found: given ID:{value} not exists in database")
    {
        _value = value;
    }
    
    protected NotFoundException(string field, string value) : base($"Not found: given '{field}:{value}' not exists in database")
    {
        _field = field;
        _value = value;
    }
}