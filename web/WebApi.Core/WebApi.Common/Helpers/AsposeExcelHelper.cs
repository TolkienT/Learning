using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Common.Helpers
{
    public class AsposeExcelHelper
    {

        public static Workbook Export(DataTable table)
        {
            try
            {
                Workbook book = new Workbook(); //创建工作簿
                Worksheet sheet = book.Worksheets[0]; //创建工作表
                Cells cells = sheet.Cells; //单元格

                //创建样式
                Aspose.Cells.Style style = book.CreateStyle();
                style.Borders[Aspose.Cells.BorderType.LeftBorder].LineStyle = Aspose.Cells.CellBorderType.Thin; //应用边界线 左边界线  
                style.Borders[Aspose.Cells.BorderType.RightBorder].LineStyle = Aspose.Cells.CellBorderType.Thin; //应用边界线 右边界线  
                style.Borders[Aspose.Cells.BorderType.TopBorder].LineStyle = Aspose.Cells.CellBorderType.Thin; //应用边界线 上边界线  
                style.Borders[Aspose.Cells.BorderType.BottomBorder].LineStyle = Aspose.Cells.CellBorderType.Thin; //应用边界线 下边界线   
                style.HorizontalAlignment = TextAlignmentType.Center; //单元格内容的水平对齐方式文字居中
                style.Font.Name = "宋体"; //字体
                style.Font.IsBold = true; //设置粗体
                style.Font.Size = 11; //设置字体大小
                style.ForegroundColor = System.Drawing.Color.FromArgb(153, 204, 0); //背景色
                style.Pattern = Aspose.Cells.BackgroundType.Solid; //背景样式
                style.IsTextWrapped = true; //单元格内容自动换行

                //表格填充数据
                int Colnum = table.Columns.Count;//表格列数 
                int Rownum = table.Rows.Count;//表格行数 
                                              //生成行 列名行 
                for (int i = 0; i < Colnum; i++)
                {
                    cells[0, i].PutValue(table.Columns[i].ColumnName); //添加表头
                    cells[0, i].SetStyle(style); //添加样式
                                                 //cells.SetColumnWidth(i, data.Columns[i].ColumnName.Length * 2 + 1.5); //自定义列宽
                                                 //cells.SetRowHeight(0, 30); //自定义高
                }
                //生成数据行 
                for (int i = 0; i < Rownum; i++)
                {
                    for (int k = 0; k < Colnum; k++)
                    {
                        cells[1 + i, k].PutValue(table.Rows[i][k].ToString()); //添加数据
                        cells[1 + i, k].SetStyle(style); //添加样式
                    }
                    //cells[1 + i, 5].Formula = "=B" + (2 + i) + "+C" + (2 + i);//给单元格设置计算公式，计算班级总人数
                }
                sheet.AutoFitColumns(); //自适应宽
                GC.Collect();
                return book;
            }
            catch
            {
                return null;
            }
        }


    }
}
