// See https://aka.ms/new-console-template for more information
using ExcelTest;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;
using System.Data;

Console.WriteLine("Start");

string fileAPath = "C:\\files\\A.xlsx";
string fileBPath = "C:\\files\\B.xlsx";
string fileCPath = "C:\\files\\C.xlsx";

List<ClassAModel> listA = new();
List<ClassBModel> listB = new();

IWorkbook workbook;
string fileExt = Path.GetExtension(fileAPath).ToLower();
using (FileStream fs = new FileStream(fileAPath, FileMode.Open, FileAccess.Read))
{
    if (fileExt == ".xlsx") { workbook = new XSSFWorkbook(fs); } else if (fileExt == ".xls") { workbook = new HSSFWorkbook(fs); } else { workbook = null; }
    if (workbook == null)
    {

    }
    ISheet sheet = workbook.GetSheetAt(0);

    //表头  
    IRow header = sheet.GetRow(sheet.FirstRowNum);
    List<int> columns = new List<int>();
    //for (int i = 0; i < header.LastCellNum; i++)
    //{
    //    object obj = GetValueType(header.GetCell(i));
    //    if (obj == null || obj.ToString() == string.Empty)
    //    {
    //        dt.Columns.Add(new DataColumn("Columns" + i.ToString()));
    //    }
    //    else
    //        dt.Columns.Add(new DataColumn(obj.ToString()));
    //    columns.Add(i);
    //}

    //数据  
    for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
    {
        var row = sheet.GetRow(i);
        if (row is not null && !string.IsNullOrWhiteSpace(row.GetCell(1).ToString()))
        {
            listA.Add(new ClassAModel()
            {
                Number = row.GetCell(0).ToString(),
                Name = row.GetCell(1).ToString(),
                ClassName = row.GetCell(3).ToString(),
                FirstScore = row.GetCell(5).ToString(),
            });
        }
    }
}

Console.WriteLine(listA.Count);


fileExt = Path.GetExtension(fileBPath).ToLower();
using (FileStream fs = new FileStream(fileBPath, FileMode.Open, FileAccess.Read))
{
    if (fileExt == ".xlsx") { workbook = new XSSFWorkbook(fs); } else if (fileExt == ".xls") { workbook = new HSSFWorkbook(fs); } else { workbook = null; }
    if (workbook == null)
    {

    }
    ISheet sheet = workbook.GetSheetAt(0);

    //表头  
    IRow header = sheet.GetRow(sheet.FirstRowNum);
    List<int> columns = new List<int>();

    //数据  
    for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
    {
        var row = sheet.GetRow(i);
        if (row is not null && !string.IsNullOrWhiteSpace(row.GetCell(1).ToString()))
        {
            listB.Add(new ClassBModel()
            {
                Name = row.GetCell(0).ToString(),
                LanguageScore = row.GetCell(2).ToString(),
                MathName = row.GetCell(3).ToString(),
                EnglishScore = row.GetCell(4).ToString(),
                TotalA = row.GetCell(5).ToString(),
                BanjiNumber = row.GetCell(6).ToString(),
                XuexiaoNumber = row.GetCell(7).ToString(),
                TotalB = row.GetCell(8).ToString(),

            });
        }
    }
}

Console.WriteLine(listB.Count);


foreach (var item in listA)
{
    var model = listB.FirstOrDefault(x => x.Name == item.Name);
    if (model is null)
    {
        Console.WriteLine(item.Name);
    }
    else
    {
        item.LanguageScore = model.LanguageScore;
        item.MathName = model.MathName;
        item.EnglishScore = model.EnglishScore;
        item.TotalA = model.TotalA;
        item.TotalB = model.TotalB;
        item.BanjiNumber = model.BanjiNumber;
        item.XuexiaoNumber = model.XuexiaoNumber;
    }
}

ExcelHelper.TableToExcel(listA, fileCPath);




Console.ReadKey();