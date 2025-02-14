using JT808.Protocol.Extensions;
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
    /// <summary>
    /// 文件上传完成消息
    /// </summary>
    public class JT808_0x1212 : JT808MessagePackFormatter<JT808_0x1212>, JT808Bodies, IJT808Analyze
    {
        /// <summary>
        /// 文件上传完成消息
        /// </summary>
        public string Description => "文件上传完成消息";
        /// <summary>
        /// 
        /// </summary>
        public bool SkipSerialization => false;
        /// <summary>
        /// 文件名称长度
        /// </summary>
        public byte FileNameLength { get; set; }
        /// <summary>
        /// 文件名称
        /// 形如：文件类型_通道号_报警类型_序号_报警编号.后缀名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件类型
        /// </summary>
        public byte FileType { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public uint FileSize { get; set; }
        /// <summary>
        /// 文件上传完成消息
        /// </summary>
        public ushort MsgId => 0x1212;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="writer"></param>
        /// <param name="config"></param>
        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x1212 value = new JT808_0x1212();
            value.FileNameLength = reader.ReadByte();
            writer.WriteNumber($"[{value.FileNameLength.ReadNumber()}]文件名称长度", value.FileNameLength);
            string fileNameHex = reader.ReadVirtualArray(value.FileNameLength).ToArray().ToHexString();
            value.FileName = reader.ReadString(value.FileNameLength);
            writer.WriteString($"[{fileNameHex}]文件名称", value.FileName);
            value.FileType = reader.ReadByte();
            writer.WriteNumber($"[{value.FileType.ReadNumber()}]文件类型", value.FileType);
            value.FileSize = reader.ReadUInt32();
            writer.WriteNumber($"[{value.FileSize.ReadNumber()}]文件大小", value.FileSize);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public override JT808_0x1212 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x1212 value = new JT808_0x1212();
            value.FileNameLength = reader.ReadByte();
            value.FileName = reader.ReadString(value.FileNameLength);
            value.FileType = reader.ReadByte();
            value.FileSize = reader.ReadUInt32();
            return value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        public override void Serialize(ref JT808MessagePackWriter writer, JT808_0x1212 value, IJT808Config config)
        {
            writer.Skip(1, out int FileNameLengthPosition);
            writer.WriteString(value.FileName);
            writer.WriteByteReturn((byte)(writer.GetCurrentPosition() - FileNameLengthPosition - 1), FileNameLengthPosition);
            writer.WriteByte(value.FileType);
            writer.WriteUInt32(value.FileSize);
        }

        public static JT808_0x1212 DeserializeBytes(byte[] bytes)
        {
            int index = 0;
            var subArray = new byte[7];

            JT808_0x1212 value = new JT808_0x1212();

            value.FileNameLength = bytes[index];
            index += 1;

            subArray = new byte[value.FileNameLength];
            Array.Copy(bytes, index, subArray, 0, value.FileNameLength);
            value.FileName = JT808Constants.Encoding.GetString(subArray);
            index += value.FileNameLength;

            value.FileType = bytes[index];
            index += 1;

            subArray = new byte[4];
            Array.Copy(bytes, index, subArray, 0, 4);
            value.FileSize = BinaryPrimitives.ReadUInt32BigEndian(subArray);
            index += 4;

            return value;
        }
    }
}
