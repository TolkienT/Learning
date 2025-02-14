using JT808.Protocol.MessageBody;
using JT808.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JT808ServerConsole
{
    public class TestJt808Package
    {
        public static void Test0x0100()
        {
            JT808Serializer jt808Serializer = new JT808Serializer();
            JT808Package jT808_0X0100 = new JT808Package
            {
                Header = new JT808Header
                {
                    MsgId = Convert.ToUInt16(JT808.Protocol.Enums.JT808MsgId._0x0100),
                    ManualMsgNum = 10,
                    TerminalPhoneNo = "010445080529",
                },
                Bodies = new JT808_0x0100
                {
                    AreaID = 40,
                    CityOrCountyId = 50,
                    MakerId = "1234",
                    PlateColor = 1,
                    PlateNo = "粤A12345",
                    TerminalId = "CHI123",
                    TerminalModel = "smallchi123"
                }
            };
            var data = jt808Serializer.Serialize(jT808_0X0100);
            var hex = ByteArrayHelper.ByteArrayToHex(data);
            Console.WriteLine(hex);
        }


        public static void Test0x0102()
        {
            JT808Serializer jt808Serializer = new JT808Serializer();
            JT808Package jT808LoginRequest = new JT808Package
            {
                Header = new JT808Header
                {
                    MsgId = Convert.ToUInt16(JT808.Protocol.Enums.JT808MsgId._0x0102),
                    ManualMsgNum = 12345,
                    TerminalPhoneNo = "010445080529",
                },
                Bodies = new JT808_0x0102
                {
                    Code = "123456"
                }
            };
            var data = jt808Serializer.Serialize(jT808LoginRequest);
            var hex = ByteArrayHelper.ByteArrayToHex(data);
            Console.WriteLine(hex);
        }

        public static void Test0x0002()
        {
            JT808Serializer jt808Serializer = new JT808Serializer();
            JT808Package jT808Package = new JT808Package
            {
                Header = new JT808Header
                {
                    MsgId = Convert.ToUInt16(JT808.Protocol.Enums.JT808MsgId._0x0002),
                    ManualMsgNum = 10,
                    TerminalPhoneNo = "010445080529",
                }
            };
            var data = jt808Serializer.Serialize(jT808Package);
            var hex = ByteArrayHelper.ByteArrayToHex(data);
            Console.WriteLine(hex);
        }


        public static void Test0x0200()
        {
            JT808Serializer jt808Serializer = new JT808Serializer();
            JT808Package jT808Package = new JT808Package();
            jT808Package.Header = new JT808Header
            {
                MsgId = Convert.ToUInt16(JT808.Protocol.Enums.JT808MsgId._0x0200),
                ManualMsgNum = 10,
                TerminalPhoneNo = "010445080529"
            };
            JT808_0x0200 jT808UploadLocationRequest = new JT808_0x0200
            {
                AlarmFlag = 1,
                Altitude = 40,
                GPSTime = DateTime.Now,
                Lat = 12222222,
                Lng = 132444444,
                Speed = 60,
                Direction = 0,
                StatusFlag = 2,
                BasicLocationAttachData = new Dictionary<byte, JT808_0x0200_BodyBase>()
            };

            jT808Package.Bodies = jT808UploadLocationRequest;
            var data = jt808Serializer.Serialize(jT808Package);
            var hex = ByteArrayHelper.ByteArrayToHex(data);
            Console.WriteLine(hex);
        }






    }
}
