using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaProducerDemo
{
    public class TruckRealTimeInfo
    {
        /// <summary>
        /// 电池剩余电量
        /// </summary>
        public float batterySOC { get; set; }
        /// <summary>
        /// 车辆id
        /// </summary>
        public string deviceId { get; set; }
        /// <summary>
        /// 车辆朝向
        /// </summary>
        public int direction { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public string lat { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public string lon { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
        public string altitude { get; set; }
        /// <summary>
        /// 是否在线
        /// </summary>
        public int online { get; set; }
        /// <summary>
        /// 当前车速
        /// </summary>
        public double trueSpeed { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string vehicleLn { get; set; }
        /// <summary>
        /// 车辆状态
        /// 2-任务中，3-空闲
        /// </summary>
        public int vehicleState { get; set; }
        /// <summary>
        /// 推送时间
        /// </summary>
        public string timestamp { get; set; }
    }

}
