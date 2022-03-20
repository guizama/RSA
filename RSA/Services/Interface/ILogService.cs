using RSA.Domain;

namespace RSA.Services.Interface
{
    public interface ILogService
    {
        void LogRegister(LogDomain logDomain);
    }
}
