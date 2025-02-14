using JT808.Protocol;
using JT808.Protocol.Extensions;
using JT808.Protocol.Extensions.SuBiao;
using JT808.Protocol.Formatters;
using JT808.Protocol.Interfaces;
using JT808.Protocol.MessageBody;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JT808ServerConsole
{
    public class JT808Helper
    {
        public static JT808Serializer JT808Serializer;

        public static void Init()
        {
            
            //ServiceCollection serviceDescriptors = new ServiceCollection();
            //serviceDescriptors.AddJT808Configure()
            //                            .AddSuBiaoConfigure();
            //IJT808Config jT808Config = serviceDescriptors.BuildServiceProvider().GetRequiredService<IJT808Config>();
            JT808Serializer = new JT808Serializer();
        }

        public static byte[] Register(JT808Package package, JT808_0x0100 jT808_0X0100)
        {
            JT808Package jT808Package = new JT808Package
            {
                Header = new JT808Header
                {
                    MsgId = JT808.Protocol.Enums.JT808MsgId._0x8100.ToUInt16Value(),
                    MsgNum = 10,
                    TerminalPhoneNo = package.Header.TerminalPhoneNo,
                },
                Bodies = new JT808_0x8100
                {
                    Code = "123456",
                    JT808TerminalRegisterResult = JT808.Protocol.Enums.JT808TerminalRegisterResult.success,
                    AckMsgNum = package.Header.ManualMsgNum.Value
                }
            };
            var bytes = JT808Serializer.Serialize(jT808Package);

            return bytes;
        }

        public static byte[] Authentication(JT808Package package, JT808_0x0102 jT808_0X0102)
        {
            JT808Package jT808Package = new JT808Package
            {
                Header = new JT808Header
                {
                    MsgId = JT808.Protocol.Enums.JT808MsgId._0x8001.ToUInt16Value(),
                    MsgNum = 00,
                    TerminalPhoneNo = package.Header.TerminalPhoneNo,
                },
                Bodies = new JT808_0x8001
                {
                    AckMsgId = Convert.ToUInt16(JT808.Protocol.Enums.JT808MsgId._0x0102),
                    JT808PlatformResult = JT808.Protocol.Enums.JT808PlatformResult.succeed,
                    MsgNum = package.Header.ManualMsgNum.Value
                }
            };
            var bytes = JT808Serializer.Serialize(jT808Package);

            return bytes;
        }

        public static byte[] Heartbeat(JT808Package package, JT808_0x0002 jT808_0X0002)
        {
            JT808Package jT808Package = new JT808Package
            {
                Header = new JT808Header
                {
                    MsgId = JT808.Protocol.Enums.JT808MsgId._0x8001.ToUInt16Value(),
                    MsgNum = 00,
                    TerminalPhoneNo = package.Header.TerminalPhoneNo,
                },
                Bodies = new JT808_0x8001
                {
                    AckMsgId = Convert.ToUInt16(JT808.Protocol.Enums.JT808MsgId._0x0002),
                    JT808PlatformResult = JT808.Protocol.Enums.JT808PlatformResult.succeed,
                    MsgNum = package.Header.ManualMsgNum.Value
                }
            };
            var bytes = JT808Serializer.Serialize(jT808Package);

            return bytes;
        }



    }
}
