using RSA.Domain;
using RSA.Services.Interface;

namespace RSA.Services
{
    public class LogService : ILogService
    {
        public void LogRegister(LogDomain logDomain)
        {
            string path = @"logRegister.txt";
            var logLine = (logDomain.logType.ToString() + "|" + logDomain.when.ToString() + "|" + logDomain.id.ToString() + "| Encrypted? " + logDomain.encrypted.ToString() + Environment.NewLine);
            File.AppendAllText(path, logLine);
        }
    }
}
