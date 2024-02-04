using System;

namespace Shiptech.Shared.Abstractions.Exceptions
{
    public abstract class ShiptechException : Exception
    {
        protected ShiptechException(string message) : base(message)
        {
        }
    }
}