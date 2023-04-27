using log4net;
using log4net.Config;
using log4net.Repository;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Common.Helpers
{
    public class Log4NetHelper
    {
        /// <summary>
        ///  log4net 仓储库
        /// </summary>
        private static ILoggerRepository _repository;
        private static readonly ConcurrentDictionary<string, ILog> Loggers = new();

        /// <summary>
        /// 读取配置文件，并使其生效。如果未找到配置文件，则抛出异常
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="configFilePath">配置文件全路径</param>
        public static void SetConfig(ILoggerRepository repository, string configFilePath)
        {
            _repository = repository;
            var fileInfo = new FileInfo(configFilePath);
            if (!fileInfo.Exists)
            {
                throw new Exception("未找到配置文件" + configFilePath);
            }
            XmlConfigurator.ConfigureAndWatch(_repository, fileInfo);
        }

        /// <summary>
        /// 获取记录器
        /// </summary>
        /// <param name="source">soruce</param>
        /// <returns></returns>
        private static ILog GetLogger(string source)
        {
            if (Loggers.ContainsKey(source))
            {
                return Loggers[source];
            }
            else
            {
                ILog logger = LogManager.GetLogger(_repository.Name, source);
                Loggers.TryAdd(source, logger);
                return logger;
            }
        }

        public static void Info(string msg)
        {
            ILog logger = GetLogger("Info");
            if (logger.IsInfoEnabled)
            {
                var message = "日志内容：" + msg;
                logger.Info(message);
            }
        }

        /// <summary>
        /// 异常错误信息日志
        /// </summary>
        /// <param name="throwMsg">异常抛出信息</param>
        /// <param name="ex">异常信息</param>
        public static void Error(string throwMsg, Exception ex)
        {
            ILog logger = GetLogger("Error");
            if (logger.IsErrorEnabled)
            {
                var message =
                    $"抛出信息：{throwMsg} \r\n异常类型：{ex.GetType().Name} \r\n异常信息：{ex.Message} \r\n堆栈调用：\r\n{ex.StackTrace}";
                logger.Error(message);
            }
        }

        /// <summary>
        /// 错误信息日志
        /// </summary>
        /// <param name="msg">日志信息</param>
        public static void Error(string msg)
        {
            ILog logger = GetLogger("Debug");
            if (logger.IsErrorEnabled)
            {
                var message = "日志内容：" + msg;
                logger.Error(message);
            }
        }

        /// <summary>
        /// 调试信息日志
        /// </summary>
        /// <param name="msg">日志信息</param>
        public static void Debug(string msg)
        {
            ILog logger = GetLogger("Debug");
            if (logger.IsDebugEnabled)
            {
                var message = "日志内容：" + msg;
                logger.Debug(message);
            }
        }

    }
}
