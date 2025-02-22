﻿using JT808.Protocol;
using JT808.Protocol.Enums;
using JT808.Protocol.Extensions;
using JT808.Protocol.Formatters;
using JT808.Protocol.Interfaces;
using JT808.Protocol.MessageBody;
using JT808.Protocol.MessagePack;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JT808ServerConsole
{
    public class JT808_0x9208 : JT808MessagePackFormatter<JT808_0x9208>, JT808Bodies, IJT808Analyze, IJT808_2019_Version
    {
        public bool SkipSerialization => false;

        public ushort MsgId => 0x9208;

        public string Description => "报警附件上传指令";

        /// <summary>
        /// 服务IP地址长度
        /// </summary>
        public byte AttachmentServerIPLength { get; set; }
        /// <summary>
        /// 服务IP地址
        /// </summary>
        public string AttachmentServerIP { get; set; }
        /// <summary>
        /// TCP端口
        /// </summary>
        public ushort AttachmentServerIPTcpPort { get; set; }
        /// <summary>
        /// UDP端口
        /// </summary>
        public ushort AttachmentServerIPUdpPort { get; set; }
        /// <summary>
        /// 报警标识号
        /// </summary>
        public AlarmIdentificationProperty AlarmIdentification { get; set; }
        /// <summary>
        /// 平台给报警分配的唯一编号
        /// 32
        /// </summary>
        public string AlarmId { get; set; }
        /// <summary>
        /// 预留
        /// </summary>
        public byte[] Retain { get; set; } = new byte[16];

        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x9208 value = new JT808_0x9208();
            value.AttachmentServerIPLength = reader.ReadByte();
            writer.WriteNumber($"[{value.AttachmentServerIPLength.ReadNumber()}]服务IP地址长度", value.AttachmentServerIPLength);
            string attachmentServerIPHex = reader.ReadVirtualArray(value.AttachmentServerIPLength).ToArray().ToHexString();
            value.AttachmentServerIP = reader.ReadString(value.AttachmentServerIPLength);
            writer.WriteString($"[{AttachmentServerIP}]服务IP地址", value.AttachmentServerIP);
            value.AttachmentServerIPTcpPort = reader.ReadUInt16();
            writer.WriteNumber($"[{value.AttachmentServerIPTcpPort.ReadNumber()}]TCP端口", value.AttachmentServerIPTcpPort);
            value.AttachmentServerIPUdpPort = reader.ReadUInt16();
            writer.WriteNumber($"[{value.AttachmentServerIPUdpPort.ReadNumber()}]UDP端口", value.AttachmentServerIPUdpPort);
            value.AlarmIdentification = new AlarmIdentificationProperty();
            string terminalIDHex = reader.ReadVirtualArray(7).ToArray().ToHexString();
            value.AlarmIdentification.TerminalID = reader.ReadString(7);
            value.AlarmIdentification.Time = reader.ReadDateTime_yyMMddHHmmss();
            value.AlarmIdentification.SN = reader.ReadByte();
            value.AlarmIdentification.AttachCount = reader.ReadByte();
            value.AlarmIdentification.Retain = reader.ReadByte();
            writer.WriteString($"[{terminalIDHex}]终端ID", value.AlarmIdentification.TerminalID);
            writer.WriteString($"[{value.AlarmIdentification.Time.ToString("yyMMddHHmmss")}]日期时间", value.AlarmIdentification.Time.ToString("yyyy-MM-dd HH:mm:ss"));
            writer.WriteNumber($"[{value.AlarmIdentification.SN.ReadNumber()}]序号", value.AlarmIdentification.SN);
            writer.WriteNumber($"[{value.AlarmIdentification.AttachCount.ReadNumber()}]附件数量", value.AlarmIdentification.AttachCount);
            writer.WriteNumber($"[{value.AlarmIdentification.Retain.ReadNumber()}]预留", value.AlarmIdentification.Retain);
            string alarmIdHex = reader.ReadVirtualArray(32).ToArray().ToHexString();
            value.AlarmId = reader.ReadString(32);
            writer.WriteString($"[{alarmIdHex}]平台给报警分配的唯一编号", value.AlarmId);
            string retainHex = reader.ReadVirtualArray(16).ToArray().ToHexString();
            writer.WriteString($"预留", retainHex);
        }

        public override JT808_0x9208 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x9208 value = new JT808_0x9208();
            value.AttachmentServerIPLength = reader.ReadByte();
            value.AttachmentServerIP = reader.ReadString(value.AttachmentServerIPLength);
            value.AttachmentServerIPTcpPort = reader.ReadUInt16();
            value.AttachmentServerIPUdpPort = reader.ReadUInt16();
            value.AlarmIdentification = new AlarmIdentificationProperty
            {
                TerminalID = reader.ReadString(7),
                Time = reader.ReadDateTime_yyMMddHHmmss(),
                SN = reader.ReadByte(),
                AttachCount = reader.ReadByte(),
                Retain = reader.ReadByte()
            };
            value.AlarmId = reader.ReadString(32);
            value.Retain = reader.ReadArray(16).ToArray();
            return value;
        }

        public override void Serialize(ref JT808MessagePackWriter writer, JT808_0x9208 value, IJT808Config config)
        {
            writer.Skip(1, out int AttachmentServerIPLengthPosition);
            writer.WriteString(value.AttachmentServerIP);
            writer.WriteByteReturn((byte)(writer.GetCurrentPosition() - AttachmentServerIPLengthPosition - 1), AttachmentServerIPLengthPosition);
            writer.WriteUInt16(value.AttachmentServerIPTcpPort);
            writer.WriteUInt16(value.AttachmentServerIPUdpPort);
            if (value.AlarmIdentification == null)
            {
                throw new NullReferenceException($"{nameof(AlarmIdentificationProperty)}不为空");
            }
            writer.WriteString(value.AlarmIdentification.TerminalID);
            writer.WriteDateTime_yyMMddHHmmss(value.AlarmIdentification.Time);
            writer.WriteByte(value.AlarmIdentification.SN);
            writer.WriteByte(value.AlarmIdentification.AttachCount);
            writer.WriteByte(value.AlarmIdentification.Retain);
            writer.WriteString(value.AlarmId);
            writer.WriteArray(value.Retain);
        }

        public static JT808_0x9208 DeserializeBytes(byte[] bytes)
        {
            int index = 0;
            var subArray = new byte[2];

            JT808_0x9208 value = new JT808_0x9208();
            value.AttachmentServerIPLength = bytes[index];
            index += 1;

            subArray = new byte[value.AttachmentServerIPLength];
            Array.Copy(bytes, index, subArray, 0, value.AttachmentServerIPLength);
            value.AttachmentServerIP = JT808Constants.Encoding.GetString(subArray);
            index += value.AttachmentServerIPLength;

            subArray = new byte[2];
            Array.Copy(bytes, index, subArray, 0, 2);
            value.AttachmentServerIPTcpPort = BinaryPrimitives.ReadUInt16BigEndian(subArray);
            index += 2;

            subArray = new byte[2];
            Array.Copy(bytes, index, subArray, 0, 2);
            value.AttachmentServerIPUdpPort = BinaryPrimitives.ReadUInt16BigEndian(subArray);
            index += 2;

            subArray = new byte[7];
            Array.Copy(bytes, index, subArray, 0, 7);
            value.AlarmIdentification = new AlarmIdentificationProperty
            {
                TerminalID = JT808Constants.Encoding.GetString(subArray)
            };
            index += 7;

            subArray = new byte[6];
            Array.Copy(bytes, index, subArray, 0, 6);
            value.AlarmIdentification.Time = JT808DataHelper.GetDateTimeByBytes(subArray);
            index += 6;

            value.AlarmIdentification.SN = bytes[index];
            index += 1;

            value.AlarmIdentification.AttachCount = bytes[index];
            index += 1;

            value.AlarmIdentification.Retain = bytes[index];
            index += 1;

            subArray = new byte[32];
            Array.Copy(bytes, index, subArray, 0, 32);
            value.AlarmId = JT808Constants.Encoding.GetString(subArray);
            index += 32;

            subArray = new byte[16];
            Array.Copy(bytes, index, subArray, 0, 16);
            value.Retain = subArray;
            index += 16;

            return value;
        }
    }
}
