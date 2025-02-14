using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest
{
    public class ExcelHelper
    {
        public static void TableToExcel(List<ClassAModel> list, string file)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("sheet");
            IRow rows = null;

            IRow Title = sheet.CreateRow(0);
            Title.CreateCell(0).SetCellValue("序号");
            Title.CreateCell(1).SetCellValue("姓名");
            Title.CreateCell(2).SetCellValue("班级");
            Title.CreateCell(3).SetCellValue("初始数学分");


            Title.CreateCell(4).SetCellValue("语文");
            Title.CreateCell(5).SetCellValue("数学");
            Title.CreateCell(6).SetCellValue("英语");

            Title.CreateCell(7).SetCellValue("总分");
            Title.CreateCell(8).SetCellValue("折算后班名次");
            Title.CreateCell(9).SetCellValue("折算后校名次");
            Title.CreateCell(10).SetCellValue("原总分");

            for (int i = 1; i <= list.Count; i++)
            {
                rows = sheet.CreateRow(i);
                var entity = list[i - 1];
                rows.CreateCell(0).SetCellValue(entity.Number);
                rows.CreateCell(1).SetCellValue(entity.Name);
                rows.CreateCell(2).SetCellValue(entity.ClassName);
                rows.CreateCell(3).SetCellValue(entity.FirstScore);


                rows.CreateCell(4).SetCellValue(entity.LanguageScore);
                rows.CreateCell(5).SetCellValue(entity.MathName);
                rows.CreateCell(6).SetCellValue(entity.EnglishScore);

                rows.CreateCell(7).SetCellValue(entity.TotalA);
                rows.CreateCell(8).SetCellValue(entity.BanjiNumber);
                rows.CreateCell(9).SetCellValue(entity.XuexiaoNumber);
                rows.CreateCell(10).SetCellValue(entity.TotalB);
            }

            //转为字节数组  
            MemoryStream stream = new MemoryStream();
            workbook.Write(stream);
            var buf = stream.ToArray();
            //保存为Excel文件  
            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fs.Write(buf, 0, buf.Length);
                fs.Flush();
            }
        }

        public static void TableToExcelTwo(List<StudentModel> list, string file)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("sheet");
            IRow rows = null;

            IRow Title = sheet.CreateRow(0);
            Title.CreateCell(0).SetCellValue("序号");
            Title.CreateCell(1).SetCellValue("姓名");
            Title.CreateCell(2).SetCellValue("班级");
            Title.CreateCell(3).SetCellValue("备注");


            Title.CreateCell(4).SetCellValue("语文成绩");
            Title.CreateCell(5).SetCellValue("语文联考排名");
            Title.CreateCell(6).SetCellValue("语文校次");

            Title.CreateCell(7).SetCellValue("数学成绩");
            Title.CreateCell(8).SetCellValue("数学联考排名");
            Title.CreateCell(9).SetCellValue("数学校次");

            Title.CreateCell(10).SetCellValue("英语成绩");
            Title.CreateCell(11).SetCellValue("英语联考排名");
            Title.CreateCell(12).SetCellValue("英语校次");

            Title.CreateCell(13).SetCellValue("总分成绩");
            Title.CreateCell(14).SetCellValue("总分联考排名");
            Title.CreateCell(15).SetCellValue("总分校次");

            for (int i = 1; i <= list.Count; i++)
            {
                rows = sheet.CreateRow(i);
                var entity = list[i - 1];
                rows.CreateCell(0).SetCellValue(entity.Order);
                rows.CreateCell(1).SetCellValue(entity.Name);
                rows.CreateCell(2).SetCellValue(entity.Class);
                rows.CreateCell(3).SetCellValue(entity.Remark);


                rows.CreateCell(4).SetCellValue(entity.ChineseGrade);
                rows.CreateCell(5).SetCellValue(entity.ChineseOrder);
                rows.CreateCell(6).SetCellValue(entity.ChineseOrderInSchool);

                rows.CreateCell(7).SetCellValue(entity.MathGrade);
                rows.CreateCell(8).SetCellValue(entity.MathOrder);
                rows.CreateCell(9).SetCellValue(entity.MathOrderInSchool);

                rows.CreateCell(10).SetCellValue(entity.EnglishGrade);
                rows.CreateCell(11).SetCellValue(entity.EnglishOrder);
                rows.CreateCell(12).SetCellValue(entity.EnglishOrderInSchool);

                rows.CreateCell(13).SetCellValue(entity.TotalGrade);
                rows.CreateCell(14).SetCellValue(entity.TotalOrder);
                rows.CreateCell(15).SetCellValue(entity.TotalOrderInSchool);
            }

            //转为字节数组  
            MemoryStream stream = new MemoryStream();
            workbook.Write(stream);
            var buf = stream.ToArray();
            //保存为Excel文件  
            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fs.Write(buf, 0, buf.Length);
                fs.Flush();
            }
        }

        public static void ToExcelIncrement(long num, string file)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("sheet");
            IRow rows = null;

            for (int i = 0; i < 400; i++)
            {
                rows = sheet.CreateRow(i);
                rows.CreateCell(0).SetCellValue(num + i + "");
            }

            //转为字节数组  
            MemoryStream stream = new MemoryStream();
            workbook.Write(stream);
            var buf = stream.ToArray();
            //保存为Excel文件  
            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fs.Write(buf, 0, buf.Length);
                fs.Flush();
            }
        }

    }
}
