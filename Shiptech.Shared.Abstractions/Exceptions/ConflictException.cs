namespace Shiptech.Shared.Abstractions.Exceptions;

public abstract class ConflictException : BaseException
{
    private readonly string? _field;
    private readonly string _value;
    
    protected ConflictException(string value) : base($"Already exists: given 'ID:{value}' exists in database")
    {
        _value = value;
    }
    
    protected ConflictException(string field, string value) : base($"Already exists: given '{field}:{value}' exists in database")
    {
        _value = value;
        _field = field;
    }
}