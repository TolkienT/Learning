﻿using JT808.Protocol.Extensions;
using JT808.Protocol.Formatters;
using JT808.Protocol.Interfaces;
using JT808.Protocol.MessagePack;
using JT808.Protocol;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JT808ServerConsole
{
    public class JT808_0x1210 : JT808MessagePackFormatter<JT808_0x1210>, JT808Bodies, IJT808Analyze, IJT808_2019_Version
    {
        public bool SkipSerialization => false;

        public ushort MsgId => 0x1210;

        public string Description => "报警附件信息消息";

        /// <summary>
        /// 终端ID
        /// 7 个字节，由大写字母和数字组成，此终端ID 由制造商自行定义，位数不足时，后补“0x00”
        /// </summary>
        public string TerminalId { get; set; }
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
        /// 信息类型
        /// 0x00：正常报警文件信息
        /// 0x01：补传报警文件信息
        /// </summary>
        public byte InfoType { get; set; }
        /// <summary>
        /// 附件数量
        /// </summary>
        public byte AttachCount { get; set; }
        /// <summary>
        /// 附件信息列表
        /// </summary>
        public List<AttachProperty> AttachInfos { get; set; }

        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x1210 value = new JT808_0x1210();
            string makerIdHex = reader.ReadVirtualArray(7).ToArray().ToHexString();
            value.TerminalId = reader.ReadString(7);
            writer.WriteString($"[{makerIdHex}]终端ID", value.TerminalId);
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
            value.InfoType = reader.ReadByte();
            writer.WriteNumber($"[{value.InfoType.ReadNumber()}]信息类型", value.InfoType);
            value.AttachCount = reader.ReadByte();
            writer.WriteNumber($"[{value.AttachCount.ReadNumber()}]附件数量", value.AttachCount);
            if (value.AttachCount > 0)
            {
                writer.WriteStartArray("附件信息列表");
                for (int i = 0; i < value.AttachCount; i++)
                {
                    writer.WriteStartObject();
                    AttachProperty attachProperty = new AttachProperty();
                    attachProperty.FileNameLength = reader.ReadByte();
                    writer.WriteNumber($"[{attachProperty.FileNameLength.ReadNumber()}]文件名称长度", attachProperty.FileNameLength);
                    string fileNameHex = reader.ReadVirtualArray(attachProperty.FileNameLength).ToArray().ToHexString();
                    attachProperty.FileName = reader.ReadString(attachProperty.FileNameLength);
                    writer.WriteString($"[{fileNameHex}]文件名称", attachProperty.FileName);
                    attachProperty.FileSize = reader.ReadUInt32();
                    writer.WriteNumber($"[{attachProperty.FileSize.ReadNumber()}]文件大小", attachProperty.FileSize);
                    writer.WriteEndObject();
                }
                writer.WriteEndArray();
            }
        }

        public override JT808_0x1210 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x1210 value = new JT808_0x1210();
            value.TerminalId = reader.ReadString(7);
            value.AlarmIdentification = new AlarmIdentificationProperty
            {
                TerminalID = reader.ReadString(7),
                Time = reader.ReadDateTime_yyMMddHHmmss(),
                SN = reader.ReadByte(),
                AttachCount = reader.ReadByte(),
                Retain = reader.ReadByte()
            };
            value.AlarmId = reader.ReadString(32);
            value.InfoType = reader.ReadByte();
            value.AttachCount = reader.ReadByte();
            if (value.AttachCount > 0)
            {
                value.AttachInfos = new List<AttachProperty>();
                for (int i = 0; i < value.AttachCount; i++)
                {
                    AttachProperty attachProperty = new AttachProperty();
                    attachProperty.FileNameLength = reader.ReadByte();
                    attachProperty.FileName = reader.ReadString(attachProperty.FileNameLength);
                    attachProperty.FileSize = reader.ReadUInt32();
                    value.AttachInfos.Add(attachProperty);
                }
            }
            return value;
        }

        public override void Serialize(ref JT808MessagePackWriter writer, JT808_0x1210 value, IJT808Config config)
        {
            writer.WriteString(value.TerminalId.PadRight(7, '\0'));
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
            writer.WriteByte(value.InfoType);
            if (value.AttachInfos != null && value.AttachInfos.Count > 0)
            {
                writer.WriteByte((byte)value.AttachInfos.Count);
                foreach (var item in value.AttachInfos)
                {
                    writer.Skip(1, out int FileNameLengthPosition);
                    writer.WriteString(item.FileName);
                    writer.WriteByteReturn((byte)(writer.GetCurrentPosition() - FileNameLengthPosition - 1), FileNameLengthPosition);
                    writer.WriteUInt32(item.FileSize);
                }
            }
            else
            {
                writer.WriteByte(0);
            }
        }

        public static JT808_0x1210 DeserializeBytes(byte[] bytes)
        {
            int index = 0;
            var subArray = new byte[7];

            JT808_0x1210 value = new JT808_0x1210();

            Array.Copy(bytes, index, subArray, 0, 7);
            value.TerminalId = JT808Constants.Encoding.GetString(subArray);
            index += 7;

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

            value.InfoType = bytes[index];
            index += 1;

            value.AttachCount = bytes[index];
            index += 1;

            if (value.AttachCount > 0)
            {
                value.AttachInfos = new List<AttachProperty>();
                for (int i = 0; i < value.AttachCount; i++)
                {
                    AttachProperty attachProperty = new AttachProperty();
                    attachProperty.FileNameLength = bytes[index];
                    index += 1;

                    subArray = new byte[attachProperty.FileNameLength];
                    Array.Copy(bytes, index, subArray, 0, attachProperty.FileNameLength);
                    attachProperty.FileName = JT808Constants.Encoding.GetString(subArray);
                    index += attachProperty.FileNameLength;

                    subArray = new byte[4];
                    Array.Copy(bytes, index, subArray, 0, 4);
                    attachProperty.FileSize = BinaryPrimitives.ReadUInt32BigEndian(subArray);
                    index += 4;

                    value.AttachInfos.Add(attachProperty);
                }
            }

            return value;
        }
    }

}
