// See https://aka.ms/new-console-template for more information


using JT808.Protocol.MessageBody;
using JT808.Protocol;
using JT808ServerConsole;
using System;
using System.Collections.Concurrent;
using System.Reflection.PortableExecutable;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using JT808.Protocol.Extensions.SuBiao;
using System.Buffers.Binary;
using JT808.Protocol.Extensions;
using System.Net.Sockets;

JT808Helper.Init();


//if (!string.IsNullOrWhiteSpace(TestDataCls.TestStr))
//{
//    string[] separators = new string[] { "30316364" };
//    string[] list = TestDataCls.TestStr.Split(separators, StringSplitOptions.None);
//    TestDataCls.TestStr = string.Empty;

//    List<VehicleEquipmentAttachDataModel> attachments = new();

//    for (int i = 0; i < list.Length; i++)
//    {
//        string str = list[i];
//        if (string.IsNullOrWhiteSpace(str))
//        {
//            continue;
//        }
//        str = "30316364" + str;
//        var attachBytes = ByteArrayHelper.HexStringToByteArray(str);
//        int index = 0;
//        var subArray = new byte[4];

//        index += 4;

//        subArray = new byte[50];
//        Array.Copy(attachBytes, index, subArray, 0, 50);
//        string fileName = JT808Constants.Encoding.GetString(subArray);
//        index += 50;

//        subArray = new byte[4];
//        Array.Copy(attachBytes, index, subArray, 0, 4);
//        var offset = BinaryPrimitives.ReadUInt32BigEndian(subArray);
//        index += 4;

//        subArray = new byte[4];
//        Array.Copy(attachBytes, index, subArray, 0, 4);
//        var dataLength = BinaryPrimitives.ReadUInt32BigEndian(subArray);
//        index += 4;

//        if (dataLength <= attachBytes.Length - index)
//        {
//            subArray = new byte[dataLength];
//            Array.Copy(attachBytes, index, subArray, 0, dataLength);

//            attachments.Add(new VehicleEquipmentAttachDataModel()
//            {
//                FileName = fileName,
//                Offset = offset,
//                HexStr = ByteArrayHelper.ByteArrayToHex(subArray)
//            });
//        }
//    }
//    if (attachments.Count > 0)
//    {
//        attachments = attachments.OrderBy(x => x.Offset).ToList();
//        string hex = string.Empty;
//        foreach (var attachment in attachments)
//        {
//            hex += attachment.HexStr;
//        }
//        byte[] attachBytes = ByteArrayHelper.HexStringToByteArray(hex);

//        string foldername = $"equipment/attach/{DateTime.Now.ToString("yyyyMMdd")}/images";
//        string folderpath = Path.Combine("C:\\TestData", "upload", foldername);
//        if (!Directory.Exists(folderpath))
//        {
//            Directory.CreateDirectory(folderpath);
//        }
//        string fileName = attachments.First().FileName;
//        var path = Path.Combine(folderpath, fileName);

//        File.WriteAllBytes(path, attachBytes);
//    }
//}




JT808Package testjT808Package = new()
{
    Header = new JT808Header()
    {
        MsgId = JT808.Protocol.Enums.JT808MsgId._0x8300.ToUInt16Value(),
        MsgNum = 0,
        TerminalPhoneNo = ByteArrayHelper.FillZero("10645080158", 12),
    }
};
JT808_0x8300 jT808TextSend = new JT808_0x8300
{
    TextInfo = "*OTA7777175.178.97.207,11009,CK508C45.bin#",
    TextFlag = 0
};
testjT808Package.Bodies = jT808TextSend;

var res = JT808Helper.JT808Serializer.Serialize(testjT808Package);
string testStr111= ByteArrayHelper.ByteArrayToHex(res);
Console.WriteLine(testStr111);




//TcpHelper.AddListener();

//Console.WriteLine("监听服务已启动");

#region MyRegion
string hexStr = "7E02000026123456789012007D02000000010000000200BA7F0E07E4F11C0028003C00001810151010100104000000640202007D01137E";
string jt0100 = "7E01000026016053137272000100000000455656494E5441373030000000000000000000000000000000333133373237320000567E";
string jt102 = "7E0102000C01605313727200023031363035333133373237322F7E";
string jt002 = "7E00020004016053137272001F00500F4E297E";
string teststr = "7e0200004d018025493764005000000000000000010000000000000000000001360000241111142707642f0000000700020100000000001f00000000000000000000241111142707000030313830323534241111142707000400e97e";
string test9208 = "7e92080051018025493763000c0c3232302e3234302e34392e352af82af830313830323534241030103604000400303030303030303030303030303138353134353239383933383733303038363400000000000000000000000000000000797e";
string testStr = "7e0200004b01074508042901c100000000000c000202a6948f0568012c034300000000240814140517010400004fc130010f310113e102007d012a020000eb19000800233030302e3030000801043030302e3030000300d400437e";

string str1210 = "7e1210011501802549376300700180254937630030313830323534241030135951000400303030303030303030303030303138353138323632373335313738313738353600043230305f30305f303030305f30305f30303030303030303030303030313835313832363237333531373831373835362e6a7067000712403230305f30305f303030305f30315f30303030303030303030303030313835313832363237333531373831373835362e6a7067000739043230305f30305f303030305f30325f30303030303030303030303030313835313832363237333531373831373835362e6a706700072ee63230325f30305f303030305f30335f30303030303030303030303030313835313832363237333531373831373835362e6d70340011386ff27e";


//teststr = str1210.Replace(" ", "");
var bytes = ByteArrayHelper.HexStringToByteArray(teststr);

var jT808Package = JT808Helper.JT808Serializer.Deserialize(bytes);


if (jT808Package.Header.MsgId == Convert.ToUInt16(JT808.Protocol.Enums.JT808MsgId._0x0200))
{
    JT808_0x0200 jT808_0x0200 = (JT808_0x0200)jT808Package.Bodies;

    //double lat = (double)jT808_0x0200.Lat / (double)1000000;
    //double lng = (double)jT808_0x0200.Lng / (double)1000000;
    //var direction = jT808_0x0200.Direction;
    //var altitude = jT808_0x0200.Altitude;
    //var time = jT808_0x0200.GPSTime;


    if (jT808_0x0200.UnknownLocationAttachData is not null)
    {
        if (jT808_0x0200.UnknownLocationAttachData.TryGetValue(0x65, out byte[]? addtionalInfo))
        {
            if (addtionalInfo is not null && addtionalInfo.Length > 2)
            {
                var length = addtionalInfo[1];
                if (addtionalInfo.Length != length + 2)
                {
                    Console.WriteLine("附加信息格式存在问题");
                }
                else
                {
                    byte[] subArray = new byte[4];
                    Array.Copy(addtionalInfo, 2, subArray, 0, 4);
                    var alarmId = (subArray[0] << 24) |
                       (subArray[1] << 16) |
                       (subArray[2] << 8) |
                       subArray[3];

                    var alarmFlag = (int)addtionalInfo[4 + 2];
                    var alarmType = (int)addtionalInfo[5 + 2];
                    var alarmLevel = (int)addtionalInfo[6 + 2];
                    //疲劳程度
                    var fatigueLevel = (int)addtionalInfo[7 + 2];
                    var speed = (int)addtionalInfo[12 + 2];

                    subArray = new byte[2];
                    Array.Copy(addtionalInfo, 13 + 2, subArray, 0, 2);
                    var altitude = (subArray[0] << 8) | subArray[1];

                    subArray = new byte[6];
                    Array.Copy(addtionalInfo, 23 + 2, subArray, 0, 6);

                    string timeStr = "20" + subArray[0].ToString("x2") + "-" + subArray[1].ToString("x2") + "-" + subArray[2].ToString("x2") + " " + subArray[3].ToString("x2") + ":" + subArray[4].ToString("x2") + ":" + subArray[5].ToString("x2");
                    DateTime time = DateTime.Parse(timeStr);

                    subArray = new byte[16];
                    Array.Copy(addtionalInfo, 31 + 2, subArray, 0, 16);

                }




            }
        }
        else if (jT808_0x0200.UnknownLocationAttachData.TryGetValue(0x64, out byte[]? addtionalInfo0x64))
        {
            if (addtionalInfo0x64 is not null && addtionalInfo0x64.Length > 2)
            {
                var length = addtionalInfo0x64[1];
                if (addtionalInfo0x64.Length != length + 2)
                {
                    Console.WriteLine("附加信息格式存在问题");
                }
                else
                {

                    byte[] subArray = new byte[4];
                    Array.Copy(addtionalInfo0x64, 2, subArray, 0, 4);
                    var alarmId = (subArray[0] << 24) |
                       (subArray[1] << 16) |
                       (subArray[2] << 8) |
                       subArray[3];

                    var alarmFlag = (int)addtionalInfo0x64[4 + 2];
                    var alarmType = (int)addtionalInfo0x64[5 + 2];
                    var alarmLevel = (int)addtionalInfo0x64[6 + 2];
                    //前车车速
                    var frontCarSpeed = (int)addtionalInfo0x64[7 + 2];
                    var frontDistance = (int)addtionalInfo0x64[8 + 2];
                    var deviationType = (int)addtionalInfo0x64[9 + 2];

                    var speed = (int)addtionalInfo0x64[12 + 2];

                    subArray = new byte[2];
                    Array.Copy(addtionalInfo0x64, 13 + 2, subArray, 0, 2);
                    var altitude = (subArray[0] << 8) | subArray[1];

                    subArray = new byte[6];
                    Array.Copy(addtionalInfo0x64, 23 + 2, subArray, 0, 6);

                    DateTime time = JT808DataHelper.GetDateTimeByBytes(subArray);

                    //报警标识
                    var alarmMarkArray = new byte[16];
                    Array.Copy(addtionalInfo0x64, 31 + 2, alarmMarkArray, 0, 16);


                }
            }
        }
    }


    //jT808Package.Bodies

    Console.WriteLine();
}
//else if (jT808Package.Header.MsgId == Convert.ToUInt16(JT808.Protocol.Enums.JT808MsgId._0x0100))
//{
//    JT808_0x0100 jT808_0x0100 = (JT808_0x0100)jT808Package.Bodies;

//    var res = JT808Helper.Register(jT808Package, jT808_0x0100);
//    var hex = ByteArrayHelper.ByteArrayToHex(res);

//}
//else if (jT808Package.Header.MsgId == Convert.ToUInt16(JT808.Protocol.Enums.JT808MsgId._0x0102))
//{
//    JT808_0x0102 jT808_0x0102 = (JT808_0x0102)jT808Package.Bodies;

//    var res = JT808Helper.Authentication(jT808Package, jT808_0x0102);
//    var hex = ByteArrayHelper.ByteArrayToHex(res);
//}
//else if (jT808Package.Header.MsgId == Convert.ToUInt16(JT808.Protocol.Enums.JT808MsgId._0x0002))
//{
//    JT808_0x0002 jT808_0x0002 = (JT808_0x0002)jT808Package.Bodies;

//    var res = JT808Helper.Heartbeat(jT808Package, jT808_0x0002);
//    var hex = ByteArrayHelper.ByteArrayToHex(res);
//}
//else if (jT808Package.Header.MsgId == 0x9208)
//{
//    var sub = new byte[jT808Package.Header.MessageBodyProperty.DataLength];
//    Array.Copy(bytes, bytes.Length - jT808Package.Header.MessageBodyProperty.DataLength - 2, sub, 0, jT808Package.Header.MessageBodyProperty.DataLength);

//    var res = JT808_0x9208.DeserializeBytes(sub);
//    //var alarmHexStr = ByteArrayHelper.ByteArrayToHex(res.AlarmCodeArray);
//    //var a = Convert.ToInt64(alarmHexStr);



//}
//else if (jT808Package.Header.MsgId == 0x1210)
//{
//    var sub = new byte[jT808Package.Header.MessageBodyProperty.DataLength];
//    Array.Copy(bytes, bytes.Length - jT808Package.Header.MessageBodyProperty.DataLength - 2, sub, 0, jT808Package.Header.MessageBodyProperty.DataLength);

//    var res = JT808_0x1210.DeserializeBytes(sub);
//}

//Console.WriteLine(1111);


//#endregion



//#region Test

//JT808Package package9208 = new JT808Package
//{
//    //0x9208
//    Header = new JT808Header
//    {
//        MsgId = 0x9208,
//        MsgNum = (ushort)0,
//        TerminalPhoneNo = ByteArrayHelper.FillZero("12345678910", 12),
//    },
//    Bodies = new JT808_0x9208
//    {
//        AttachmentServerIP = "220.240.49.5",
//        AttachmentServerIPTcpPort = 11001,
//        AttachmentServerIPUdpPort = 11001,
//        AlarmIdentification = new AlarmIdentificationProperty()
//        {
//            AttachCount = 4,
//            SN = 0,
//            Retain = 0,
//            TerminalID = "0180254",
//            Time = new DateTime(2024, 10, 31, 0, 0, 0)
//        },
//        AlarmId = ByteArrayHelper.FillZero("1851444666466254848", 32),
//        Retain = new byte[16]
//    }
//};
//var bytes9208 = JT808Helper.JT808Serializer.Serialize(package9208);
//var subArr = new byte[package9208.Header.MessageBodyProperty.DataLength];
//Array.Copy(bytes9208, bytes9208.Length - package9208.Header.MessageBodyProperty.DataLength - 2, subArr, 0, package9208.Header.MessageBodyProperty.DataLength);
//var model9208 = JT808_0x9208.DeserializeBytes(subArr);

//var JT808_0x9208Body = (JT808_0x9208)package9208.Bodies;

//var attachList = new List<AttachProperty>();
//attachList.Add(new AttachProperty()
//{
//    FileNameLength = (byte)JT808Constants.Encoding.GetBytes("001.png").Length,
//    FileName = "001.png",
//    FileSize = 3000

//});
//attachList.Add(new AttachProperty()
//{
//    FileNameLength = (byte)JT808Constants.Encoding.GetBytes("002.png").Length,
//    FileName = "002.png",
//    FileSize = 3000

//});
//attachList.Add(new AttachProperty()
//{
//    FileNameLength = (byte)JT808Constants.Encoding.GetBytes("003.png").Length,
//    FileName = "003.png",
//    FileSize = 3000

//});
//attachList.Add(new AttachProperty()
//{
//    FileNameLength = (byte)JT808Constants.Encoding.GetBytes("004.png").Length,
//    FileName = "004.png",
//    FileSize = 3000

//});
//JT808Package package1210 = new JT808Package
//{
//    //0x9208
//    Header = new JT808Header
//    {
//        MsgId = 0x1210,
//        MsgNum = (ushort)0,
//        TerminalPhoneNo = ByteArrayHelper.FillZero("12345678910", 12),
//    },
//    Bodies = new JT808_0x1210
//    {
//        TerminalId = JT808_0x9208Body.AlarmIdentification.TerminalID,
//        AlarmIdentification = new AlarmIdentificationProperty()
//        {
//            AttachCount = 4,
//            SN = 0,
//            Retain = 0,
//            TerminalID = "0180254",
//            Time = new DateTime(2024, 10, 31, 0, 0, 0)
//        },
//        AlarmId = ByteArrayHelper.FillZero("1851444666466254848", 32),
//        InfoType = 0x00,
//        AttachCount = 4,
//        AttachInfos = attachList
//    }
//};

//var bytes1210 = JT808Helper.JT808Serializer.Serialize(package1210);
//subArr = new byte[package1210.Header.MessageBodyProperty.DataLength];
//Array.Copy(bytes1210, bytes1210.Length - package1210.Header.MessageBodyProperty.DataLength - 2, subArr, 0, package1210.Header.MessageBodyProperty.DataLength);
//var model1210 = JT808_0x1210.DeserializeBytes(subArr);



//JT808Package package1211 = new JT808Package
//{
//    //0x9208
//    Header = new JT808Header
//    {
//        MsgId = 0x1211,
//        MsgNum = (ushort)0,
//        TerminalPhoneNo = ByteArrayHelper.FillZero("12345678910", 12),
//    },
//    Bodies = new JT808_0x1211
//    {
//        FileNameLength = (byte)JT808Constants.Encoding.GetBytes("003.png").Length,
//        FileName = "001.png",
//        FileType = 0x00,
//        FileSize = 3000
//    }
//};
//var bytes1211 = JT808Helper.JT808Serializer.Serialize(package1211);
//subArr = new byte[package1211.Header.MessageBodyProperty.DataLength];
//Array.Copy(bytes1211, bytes1211.Length - package1211.Header.MessageBodyProperty.DataLength - 2, subArr, 0, package1211.Header.MessageBodyProperty.DataLength);
//var model1211 = JT808_0x1211.DeserializeBytes(subArr);


//JT808Package package1212 = new JT808Package
//{
//    //0x9208
//    Header = new JT808Header
//    {
//        MsgId = 0x1212,
//        MsgNum = (ushort)0,
//        TerminalPhoneNo = ByteArrayHelper.FillZero("12345678910", 12),
//    },
//    Bodies = new JT808_0x1212
//    {
//        FileNameLength = (byte)JT808Constants.Encoding.GetBytes("003.png").Length,
//        FileName = "001.png",
//        FileType = 0x00,
//        FileSize = 3000
//    }
//};
//var bytes1212 = JT808Helper.JT808Serializer.Serialize(package1212);
//subArr = new byte[package1212.Header.MessageBodyProperty.DataLength];
//Array.Copy(bytes1212, bytes1212.Length - package1212.Header.MessageBodyProperty.DataLength - 2, subArr, 0, package1212.Header.MessageBodyProperty.DataLength);
//var model1212 = JT808_0x1212.DeserializeBytes(subArr);


//////不需要补传
////JT808Package package9212 = new JT808Package
////{
////    //0x9208
////    Header = new JT808Header
////    {
////        MsgId = 0x9212,
////        MsgNum = (ushort)0,
////        TerminalPhoneNo = ByteArrayHelper.FillZero("12345678910", 12),
////    },
////    Bodies = new JT808_0x9212
////    {
////        FileNameLength = (byte)JT808Constants.Encoding.GetBytes("003.png").Length,
////        FileName = "001.png",
////        FileType = 0x00,
////        UploadResult = 0x00,
////        DataPackageCount = 0x00,
////        DataPackages = new List<DataPackageProperty>()
////    }
////};

////var bytes9212 = JT808Helper.JT808Serializer.Serialize(package9212);
////subArr = new byte[package9212.Header.MessageBodyProperty.DataLength];
////Array.Copy(bytes9212, bytes9212.Length - package9212.Header.MessageBodyProperty.DataLength - 2, subArr, 0, package9212.Header.MessageBodyProperty.DataLength);
////var model9212 = JT808_0x9212.DeserializeBytes(subArr);

//List<DataPackageProperty> dataPackages = new();
//dataPackages.Add(new DataPackageProperty()
//{
//    Offset = 2000,
//    Length = 3000
//});
//dataPackages.Add(new DataPackageProperty()
//{
//    Offset = 5000,
//    Length = 6000
//});
////需要补传
//JT808Package package9212 = new JT808Package
//{
//    //0x9208
//    Header = new JT808Header
//    {
//        MsgId = 0x9212,
//        MsgNum = (ushort)0,
//        TerminalPhoneNo = ByteArrayHelper.FillZero("12345678910", 12),
//    },
//    Bodies = new JT808_0x9212
//    {
//        FileNameLength = (byte)JT808Constants.Encoding.GetBytes("003.png").Length,
//        FileName = "001.png",
//        FileType = 0x00,
//        UploadResult = 0x01,
//        DataPackageCount = 0x02,
//        DataPackages = dataPackages
//    }
//};



//var bytes9212 = JT808Helper.JT808Serializer.Serialize(package9212);
//var pack9212 = JT808Helper.JT808Serializer.Deserialize(bytes9212);
//subArr = new byte[package9212.Header.MessageBodyProperty.DataLength];
//Array.Copy(bytes9212, bytes9212.Length - package9212.Header.MessageBodyProperty.DataLength - 2, subArr, 0, package9212.Header.MessageBodyProperty.DataLength);
//var model9212 = JT808_0x9212.DeserializeBytes(subArr);

////package9212 = new()
////{
////    //0x9208
////    Header = new JT808Header
////    {
////        MsgId = 0x9212,
////        MsgNum = (ushort)0,
////        TerminalPhoneNo = ByteArrayHelper.FillZero("12345678910", 12),
////    },
////    Bodies =new JT808.Protocol.Extensions.SuBiao.MessageBody.JT808_0x9212
////    {
////        FileNameLength = (byte)JT808Constants.Encoding.GetBytes("003.png").Length,
////        FileName = "001.png",
////        FileType = 0x00,
////        UploadResult = 0x01,
////        DataPackageCount = 0x02,
////        DataPackages = dataPackages
////    }
////};

//Console.ReadKey();




#endregion