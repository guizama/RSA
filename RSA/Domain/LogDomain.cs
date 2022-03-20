using System.Runtime.Serialization;
using static RSA.Enums.Enums;

namespace RSA.Domain
{
    public class LogDomain
    {
        public LogType logType { get; set; }
        public DateTime when { get; set; }
        public int id { get; set; }
        public bool encrypted { get; set; }
    }
}
