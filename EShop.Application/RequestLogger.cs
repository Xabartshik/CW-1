using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application
{
    public interface IRequestLogger
    {
        void LogRequest(string action);
        List<string> GetLogs();
    }

    public class RequestLogger : IRequestLogger
    {
        private readonly List<string> _logs = new List<string>();
        private readonly string _instanceId = Guid.NewGuid().ToString()[..8];

        public void LogRequest(string action)
        {
            _logs.Add($"[{_instanceId}] {DateTime.Now:HH:mm:ss} - {action}");
        }

        public List<string> GetLogs()
        {
            return _logs.ToList();
        }
    }
}
