using System;

namespace Assessment.Common
{
    public class ProcessResult<T>
    {
        public string Detail { get; set; }
        public bool IsValid { get; set; }
        public T ResultObject { get; set; }
    }
}