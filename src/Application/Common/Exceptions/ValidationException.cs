using System.Text.RegularExpressions;
using FluentValidation.Results;

namespace Shiptech.Application.Common.Exceptions;

public class ValidationException : Exception
{
    public ValidationException()
        : base("One or more validation failures have occurred.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public ValidationException(IEnumerable<ValidationFailure> failures)
        : this()
    {
        Errors = failures
            .GroupBy(e => RemoveArrayIndex(e.PropertyName).ToLower(), e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }

    public IDictionary<string, string[]> Errors { get; }

    private string RemoveArrayIndex(string propertyName)
    {
        // Remove array indices from property names
        return Regex.Replace(propertyName, @"\[\d+\]", string.Empty);
    }
}
