// See https://aka.ms/new-console-template for more information
using ExcelTest;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;
using System.Data;

#region 第一次处理数据
//Console.WriteLine("Start");

//string fileAPath = "C:\\files\\A.xlsx";
//string fileBPath = "C:\\files\\B.xlsx";
//string fileCPath = "C:\\files\\C.xlsx";

string fileCPath = "C:\\files\\Increment.xlsx";
ExcelHelper.ToExcelIncrement(8986112424808845, fileCPath);

//List<ClassAModel> listA = new();
//List<ClassBModel> listB = new();

//IWorkbook workbook;
//string fileExt = Path.GetExtension(fileAPath).ToLower();
//using (FileStream fs = new FileStream(fileAPath, FileMode.Open, FileAccess.Read))
//{
//    if (fileExt == ".xlsx") { workbook = new XSSFWorkbook(fs); } else if (fileExt == ".xls") { workbook = new HSSFWorkbook(fs); } else { workbook = null; }
//    if (workbook == null)
//    {

//    }
//    ISheet sheet = workbook.GetSheetAt(0);

//    //表头  
//    IRow header = sheet.GetRow(sheet.FirstRowNum);
//    List<int> columns = new List<int>();

//    //数据  
//    for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
//    {
//        var row = sheet.GetRow(i);
//        if (row is not null && !string.IsNullOrWhiteSpace(row.GetCell(1).ToString()))
//        {
//            listA.Add(new ClassAModel()
//            {
//                Number = row.GetCell(0).ToString(),
//                Name = row.GetCell(1).ToString(),
//                ClassName = row.GetCell(3).ToString(),
//                FirstScore = row.GetCell(5).ToString(),
//            });
//        }
//    }
//}

//Console.WriteLine(listA.Count);


//fileExt = Path.GetExtension(fileBPath).ToLower();
//using (FileStream fs = new FileStream(fileBPath, FileMode.Open, FileAccess.Read))
//{
//    if (fileExt == ".xlsx") { workbook = new XSSFWorkbook(fs); } else if (fileExt == ".xls") { workbook = new HSSFWorkbook(fs); } else { workbook = null; }
//    if (workbook == null)
//    {

//    }
//    ISheet sheet = workbook.GetSheetAt(0);

//    //表头  
//    IRow header = sheet.GetRow(sheet.FirstRowNum);
//    List<int> columns = new List<int>();

//    //数据  
//    for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
//    {
//        var row = sheet.GetRow(i);
//        if (row is not null && !string.IsNullOrWhiteSpace(row.GetCell(1).ToString()))
//        {
//            listB.Add(new ClassBModel()
//            {
//                Name = row.GetCell(0).ToString(),
//                LanguageScore = row.GetCell(2).ToString(),
//                MathName = row.GetCell(3).ToString(),
//                EnglishScore = row.GetCell(4).ToString(),
//                TotalA = row.GetCell(5).ToString(),
//                BanjiNumber = row.GetCell(6).ToString(),
//                XuexiaoNumber = row.GetCell(7).ToString(),
//                TotalB = row.GetCell(8).ToString(),

//            });
//        }
//    }
//}

//Console.WriteLine(listB.Count);


//foreach (var item in listA)
//{
//    var model = listB.FirstOrDefault(x => x.Name == item.Name);
//    if (model is null)
//    {
//        Console.WriteLine(item.Name);
//    }
//    else
//    {
//        item.LanguageScore = model.LanguageScore;
//        item.MathName = model.MathName;
//        item.EnglishScore = model.EnglishScore;
//        item.TotalA = model.TotalA;
//        item.TotalB = model.TotalB;
//        item.BanjiNumber = model.BanjiNumber;
//        item.XuexiaoNumber = model.XuexiaoNumber;
//    }
//}

//ExcelHelper.TableToExcel(listA, fileCPath);
#endregion


#region 统计成绩
//Console.WriteLine("Start");

//string studentPath = "C:\\files\\student.xlsx";
//string gradePath = "C:\\files\\grade.xlsx";
//string fileCPath = "C:\\files\\result2.xlsx";

//List<StudentModel> studentList = new();
//List<GradeModel> gradeList = new();

//IWorkbook workbook;
//string fileExt = Path.GetExtension(studentPath).ToLower();
//using (FileStream fs = new FileStream(studentPath, FileMode.Open, FileAccess.Read))
//{
//    if (fileExt == ".xlsx") { workbook = new XSSFWorkbook(fs); } else if (fileExt == ".xls") { workbook = new HSSFWorkbook(fs); } else { workbook = null; }
//    if (workbook == null)
//    {

//    }
//    ISheet sheet = workbook.GetSheetAt(0);

//    //表头  
//    IRow header = sheet.GetRow(sheet.FirstRowNum);
//    List<int> columns = new();

//    //数据  
//    for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
//    {
//        var row = sheet.GetRow(i);
//        if (row is not null && !string.IsNullOrWhiteSpace(row.GetCell(1).ToString()))
//        {
//            studentList.Add(new StudentModel()
//            {
//                Order = row.GetCell(0).ToString(),
//                Name = row.GetCell(1).ToString(),
//                Class = row.GetCell(2).ToString(),
//                Remark = row.GetCell(3).ToString()
//            });
//        }
//    }
//}

//Console.WriteLine(studentList.Count);


//fileExt = Path.GetExtension(gradePath).ToLower();
//using (FileStream fs = new FileStream(gradePath, FileMode.Open, FileAccess.Read))
//{
//    if (fileExt == ".xlsx") { workbook = new XSSFWorkbook(fs); } else if (fileExt == ".xls") { workbook = new HSSFWorkbook(fs); } else { workbook = null; }
//    if (workbook == null)
//    {

//    }
//    ISheet sheet = workbook.GetSheetAt(0);

//    //表头  
//    IRow header = sheet.GetRow(sheet.FirstRowNum);
//    List<int> columns = new();

//    //数据  
//    for (int i = sheet.FirstRowNum + 3; i <= sheet.LastRowNum; i++)
//    {
//        var row = sheet.GetRow(i);
//        if (row is not null && !string.IsNullOrWhiteSpace(row.GetCell(1).ToString()))
//        {
//            gradeList.Add(new GradeModel()
//            {
//                Class = row.GetCell(0).ToString(),
//                Name = row.GetCell(1).ToString(),
//                ChineseGrade = row.GetCell(2).ToString(),
//                ChineseOrder = row.GetCell(3).ToString(),
//                ChineseOrderInSchool = row.GetCell(4).ToString(),
//                MathGrade = row.GetCell(5).ToString(),
//                MathOrder = row.GetCell(6).ToString(),
//                MathOrderInSchool = row.GetCell(7).ToString(),
//                EnglishGrade = row.GetCell(8).ToString(),
//                EnglishOrder = row.GetCell(9).ToString(),
//                EnglishOrderInSchool = row.GetCell(10).ToString(),
//                TotalGrade = row.GetCell(11).ToString(),
//                TotalOrder = row.GetCell(12).ToString(),
//                TotalOrderInSchool = row.GetCell(13).ToString()

//            });
//        }
//    }
//}

//Console.WriteLine(gradeList.Count);


//foreach (var item in studentList)
//{
//    var model = gradeList.FirstOrDefault(x => x.Name == item.Name);
//    if (model is null)
//    {
//        Console.WriteLine(item.Name);
//    }
//    else
//    {
//        item.ChineseGrade = model.ChineseGrade;
//        item.ChineseOrder = model.ChineseOrder;
//        item.ChineseOrderInSchool = model.ChineseOrderInSchool;

//        item.MathGrade = model.MathGrade;
//        item.MathOrder = model.MathOrder;
//        item.MathOrderInSchool = model.MathOrderInSchool;

//        item.EnglishGrade = model.EnglishGrade;
//        item.EnglishOrder = model.EnglishOrder;
//        item.EnglishOrderInSchool = model.EnglishOrderInSchool;

//        item.TotalGrade = model.TotalGrade;
//        item.TotalOrder = model.TotalOrder;
//        item.TotalOrderInSchool = model.TotalOrderInSchool;
//    }
//}

//ExcelHelper.TableToExcelTwo(studentList, fileCPath);
#endregion



Console.ReadKey();