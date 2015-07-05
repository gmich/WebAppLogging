using System;

namespace Infrastructure.Logging
{
    /// <summary>
    /// Registers / Deregisters appenders
    /// </summary>
    public interface IDebugHost : IAppender
    {
        void RegisterAppender(IAppender appender);
        void DeregisterAppender(IAppender appender);
    }
}
