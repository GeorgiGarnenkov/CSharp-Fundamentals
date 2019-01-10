using System;
using System.Collections.Generic;
using System.Text;
using Logger.Models.Contracts;

namespace Logger.Models
{
    public class Error : IError
    {
        public Error(DateTime dateTime, ErrorLevel level, string message)
        {
            this.DateTime = dateTime;
            this.Message = message;
            this.Level = level;
        }

        public DateTime DateTime { get; }

        public string Message { get; }

        public ErrorLevel Level { get; }
    }
}
