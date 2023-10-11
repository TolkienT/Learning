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

    }
}
