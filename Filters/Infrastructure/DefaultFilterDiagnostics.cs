using System.Collections.Generic;

namespace Filters.Infrastructure
{
    public class DefaultFilterDiagnostics : IFilterDiagnostics
    {
        private List<string> messages = new List<string>();
        public IEnumerable<string> Messages => messages;
        public void AddMessage(string message) => messages.Add(message);
    }
}
