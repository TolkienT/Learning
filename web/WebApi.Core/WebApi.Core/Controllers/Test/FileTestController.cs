using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.OpenXml4Net.OPC.Internal;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using WebApi.Model.Enums;
using WebApi.Model.Models;

namespace WebApi.Core.Controllers.Test
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileTestController : ControllerBase
    {
        [HttpGet]
        [Route("ImageShow")]
        public async Task<object> ImageShow()
        {
            try
            {
                string path = "/home/ubuntu/coding/files/image/KochouShinobu.jpeg";

                using (var fs = new FileStream(path, FileMode.Open))
                {
                    string fileName = Path.GetFileName(fs.Name);
                    var bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, bytes.Length);
                    return new FileContentResult(bytes, FileHelper.GetFilename(fileName));
                    //return new FileContentResult(bytes, "application/octet-stream")
                    //{
                    //    FileDownloadName = fileName
                    //};
                }
            }
            catch (Exception ex)
            {
                return new HttpResultModel()
                {
                    Success = false,
                    Status = HttpResultStatus.Error,
                    Message = "获取图片失败,失败原因:" + ex.Message
                };
            }
        }

        [HttpGet]
        [Route("FileDowload")]
        public async Task<object> FileDowload()
        {
            try
            {
                string path = "/home/ubuntu/coding/files/image/KochouShinobu.jpeg";

                using (var fs = new FileStream(path, FileMode.Open))
                {
                    string fileName = Path.GetFileName(fs.Name);
                    var bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, bytes.Length);
                    return new FileContentResult(bytes, "application/octet-stream")
                    {
                        FileDownloadName = fileName
                    };
                }
            }
            catch (Exception ex)
            {
                return new HttpResultModel()
                {
                    Success = false,
                    Status = HttpResultStatus.Error,
                    Message = "获取图片失败,失败原因:" + ex.Message
                };
            }
        }


        [HttpGet]
        [Route("TestExcelExport")]
        public async Task<ActionResult> TestExcelExport()
        {

            HSSFWorkbook workbook = new HSSFWorkbook();

            //创建一个Sheet
            ISheet sheet = workbook.CreateSheet("Sheet1");
            sheet.DefaultRowHeight = 300;
            //创建标题
            IRow rowTitle = sheet.CreateRow(0);
            rowTitle.Height = 500;
            ICellStyle styleTitle = workbook.CreateCellStyle();
            styleTitle.Alignment = HorizontalAlignment.Center;
            styleTitle.VerticalAlignment = VerticalAlignment.Center;
            IFont fontTitle = workbook.CreateFont();
            fontTitle.FontName = "宋体";
            fontTitle.FontHeightInPoints = 18;
            styleTitle.SetFont(fontTitle);
            ICell cellTitle = rowTitle.CreateCell(0);
            cellTitle.SetCellValue("商品列表");
            cellTitle.CellStyle = styleTitle;
            sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 5));  //合并单元格
                                                                      //创建表格样式
            IFont font = workbook.CreateFont();
            font.FontName = "宋体";
            font.FontHeightInPoints = 10;
            ICellStyle style = workbook.CreateCellStyle(); ;
            style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            style.BottomBorderColor = HSSFColor.Black.Index;
            style.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            style.LeftBorderColor = HSSFColor.Black.Index;
            style.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            style.RightBorderColor = HSSFColor.Black.Index;
            style.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            style.TopBorderColor = HSSFColor.Black.Index;
            style.Alignment = HorizontalAlignment.Center;
            style.SetFont(font);
            //创建表头
            IRow rowHead = sheet.CreateRow(1);
            rowHead.CreateCell(0).SetCellValue("序号");
            rowHead.GetCell(0).CellStyle = style;
            sheet.SetColumnWidth(0, 256 * 5);

            rowHead.CreateCell(1).SetCellValue("商品名称");
            rowHead.GetCell(1).CellStyle = style;
            sheet.SetColumnWidth(1, 256 * 25);

            rowHead.CreateCell(2).SetCellValue("商品品牌");
            rowHead.GetCell(2).CellStyle = style;
            sheet.SetColumnWidth(2, 256 * 20);

            rowHead.CreateCell(3).SetCellValue("商品价格");
            rowHead.GetCell(3).CellStyle = style;
            sheet.SetColumnWidth(3, 256 * 15);

            rowHead.CreateCell(4).SetCellValue("数量");
            rowHead.GetCell(4).CellStyle = style;
            sheet.SetColumnWidth(3, 256 * 10);

            rowHead.CreateCell(5).SetCellValue("总金额");
            rowHead.GetCell(5).CellStyle = style;
            sheet.SetColumnWidth(3, 256 * 15);

            //获取商品列表数据
            List<TestProductModel> dataList = new();
            dataList.Add(new TestProductModel()
            {
                ProductName = "测试名称",
                ProductBrand = "测试品牌",
                ProductPrice = 0.123M,
                Quantity = 20
            });
            dataList.Add(new TestProductModel()
            {
                ProductName = "测试名称2",
                ProductBrand = "测试品牌2",
                ProductPrice = 0.1231M,
                Quantity = 200
            });
            //绑定表内容
            int rowindex = 2;
            int xh = 1;
            foreach (var item in dataList)
            {
                IRow rowContent = sheet.CreateRow(rowindex);
                rowContent.CreateCell(0).SetCellValue(xh);
                rowContent.GetCell(0).CellStyle = style;

                rowContent.CreateCell(1).SetCellValue(item.ProductName);
                rowContent.GetCell(1).CellStyle = style;

                rowContent.CreateCell(2).SetCellValue(item.ProductBrand);
                rowContent.GetCell(2).CellStyle = style;

                rowContent.CreateCell(3).SetCellValue(item.ProductPrice.ToString());
                rowContent.GetCell(3).CellStyle = style;

                rowContent.CreateCell(4).SetCellValue(item.Quantity.ToString());
                rowContent.GetCell(4).CellStyle = style;
                //设置函数，计算总金额
                rowContent.CreateCell(5).SetCellFormula(String.Format("$D{0}*$E{0}", rowindex + 1));
                rowContent.GetCell(5).CellStyle = style;

                rowindex++;
                xh++;
            }
            //输出 
            MemoryStream ms = new();
            workbook.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            return File(ms, "application/xlsx", "商品列表.xlsx");
        }


        [HttpPost]
        [Route("TestExcelImport")]
        public async Task<HttpResultModel<string>> TestExcelImport(IFormFile file, [FromForm] string id)
        {
            string fileName = file.FileName;
            MemoryStream ms = new MemoryStream();
            await file.CopyToAsync(ms);
            ms.Seek(0, SeekOrigin.Begin);
            IWorkbook book;
            if (fileName.EndsWith(".xlsx"))
            {
                book = new XSSFWorkbook(ms);

            }
            else
            {
                book = new HSSFWorkbook(ms);
            }

            var sheet = book.GetSheet("汇总表");
            //ISheet sheet = book.GetSheetAt(0);

            int CountRow = sheet.LastRowNum;
            if (CountRow == 0)
            {
                return new HttpResultModel<string>("Success", "Excel列表数据为空");

            }

            for (int i = 1; i < CountRow; i++)
            {
                var row = sheet.GetRow(i);
                if (row.GetCell(0) is not null && row.GetCell(0).ToString().Trim().Length > 0)
                {
                    string columnOneValue = row.GetCell(0).ToString();
                }
                if (row.GetCell(1) is not null && row.GetCell(1).ToString().Trim().Length > 0)
                {
                    string columnTwoValue = row.GetCell(1).ToString();
                }
            }

            return new HttpResultModel<string>("Success");
        }
    }
}
