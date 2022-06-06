using System;
using System.Collections.Generic;

namespace MailService
{
    public class ModelResult
    {
        public readonly Dictionary<string, ValueType> Attributes;
        public readonly IEnumerable<Result> Results;

        public ModelResult(Dictionary<string, ValueType> attributes,
            IEnumerable<Result> results)
        {
            Attributes = attributes;
            Results = results;
        }
    }
}