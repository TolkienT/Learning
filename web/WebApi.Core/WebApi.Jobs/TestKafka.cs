using Confluent.Kafka;
using Quartz.Util;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Jobs
{
    public class TestKafka
    {
        #region 变量
        /// <summary>
        /// 产品Key
        /// </summary>
        private const string PRODUCT_KEY = "";

        /// <summary>
        /// 产品查询Key
        /// </summary>
        private const string QUERY_KEY = "";

        /// <summary>
        /// 产品查询secret
        /// </summary>
        private const string QUERY_SECRET = "";

        /// <summary>
        /// kafka认证所需的用户名
        /// USER_NAME == productKey
        /// </summary>
        private const string USER_NAME = PRODUCT_KEY;

        /// <summary>
        /// kafka认证所需的密码
        /// </summary>
        private static string PASSWORD = string.Empty;
        //private static string PASSWORD = EncryptUtil.EncryptPassword(USER_NAME, QUERY_KEY, QUERY_SECRET);

        /// <summary>
        /// 数据加解密所需的密码
        /// </summary>
        private const string DATA_SECRET = "";

        /// <summary>
        /// kafka服务器
        /// </summary>
        private const string KAFKA_SERVERS = "";

        /// <summary>
        /// kafka group
        /// </summary>
        private const string GROUP = "";

        /// <summary>
        /// 设备数据 topic
        /// </summary>
        private const string DATA_TOPIC = PRODUCT_KEY;



        #endregion



        public static async Task InitConsume()
        {
            var conf = new ConsumerConfig
            {
                BootstrapServers = KAFKA_SERVERS,
                GroupId = GROUP,
                ClientId = USER_NAME,
                SecurityProtocol = SecurityProtocol.SaslPlaintext,
                SaslMechanism = SaslMechanism.Plain,
                SaslUsername = USER_NAME,
                SaslPassword = PASSWORD
            };

            await ConsumeRfid(conf);
        }

        static async Task ConsumeRfid(ConsumerConfig conf)
        {
            using (var c = new ConsumerBuilder<string, string>(conf)
            .SetKeyDeserializer(Deserializers.Utf8)
            .SetValueDeserializer(Deserializers.Utf8)
            .SetErrorHandler((_, e) =>
            {
                //LoggerCollection.WeightReceiveLogger.Error("连接出错：" + e.Reason);
            })
             .SetStatisticsHandler((_, json) =>
             {
                 //LoggerCollection.WeightReceiveLogger.Info($" - {DateTime.Now:yyyy-MM-dd HH:mm:ss} > 消息监听中..");
             })
            .SetPartitionsAssignedHandler((c, partitions) =>
            {
                string partitionsStr = string.Join(", ", partitions);
                //Loghelper.WeightReceiveLogger.Info($" - 分配的 kafka 分区: {partitionsStr}");
            })
            .Build())
            {
                c.Subscribe(DATA_TOPIC);

                try
                {
                    while (true)
                    {
                        try
                        {
                            var cr = c.Consume(500);

                            if (cr != null)
                            {
                                string msg = cr.Message.Value;
                            }
                        }
                        catch (Exception ex)
                        {
                            //LoggerCollection.WeightReceiveLogger.Error("获取地磅数据失败：" + ex.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    //LoggerCollection.WeightReceiveLogger.Error("获取地磅数据失败：" + ex.ToString());

                    c.Close();
                }
                //await Task.Delay(TimeSpan.FromSeconds(SysPara.WEIGH_BRIDGE_RECONNECT_TIME_SPAN));
                //LoggerCollection.WeightReceiveLogger.Info("重新连接地磅");
                await ConsumeRfid(conf);
            }
        }


    }
}
