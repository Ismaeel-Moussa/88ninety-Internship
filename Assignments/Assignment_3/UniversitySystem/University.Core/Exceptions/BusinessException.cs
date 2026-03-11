

namespace University.Core.Exceptions
{
    public class BusinessException : Exception
    {
        public Dictionary<string, List<string>> Errors { get; set; }

        public BusinessException(string message) : base(message)
        {
            Errors = [];
        }

        public BusinessException(Dictionary<string, List<string>> errors)
        {
            Errors = errors ?? [];
        }
    }
}
