using System;

namespace Logger.Models.Contracts
{
    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        ErrorLevel Level { get; }
    }
}