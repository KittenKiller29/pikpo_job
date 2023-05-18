using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
namespace pikpo_job.rep
{
    class ExcelExp
    {
        public void expUsers(DataTable dt)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            //Книга.
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            //Таблица.
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            ExcelWorkSheet.Columns[1].ColumnWidth = 13;
            ExcelWorkSheet.Columns[2].ColumnWidth = 13;
            ExcelWorkSheet.Columns[3].ColumnWidth = 13;
            Microsoft.Office.Interop.Excel.Range r = ExcelWorkSheet.get_Range("A1", "S" + (dt.Rows.Count + 1).ToString());
            //Оформления
            r.Font.Name = "Calibri";
            r.Cells.Font.Size = 10;
            r.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            ExcelApp.Cells[1, 1] = "Логин";
            ExcelApp.Cells[1, 2] = "Пароль";
            ExcelApp.Cells[1, 3] = "Доступ";
            ExcelApp.Cells[1, 1].Borders.Color = ColorTranslator.ToOle(Color.Black);
            ExcelApp.Cells[1, 2].Borders.Color = ColorTranslator.ToOle(Color.Black);
            ExcelApp.Cells[1, 3].Borders.Color = ColorTranslator.ToOle(Color.Black);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 1; j < dt.Columns.Count; j++)
                {
                    ExcelApp.Cells[i + 2, j] = (dt.Rows[i].ItemArray)[j];
                    ExcelApp.Cells[i + 2, j].Borders.Color = ColorTranslator.ToOle(Color.Black);
                }
            }
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        }
        public void expClients(DataTable dt)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            //Книга.
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            //Таблица.
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            ExcelWorkSheet.Columns[1].ColumnWidth = 13;
            ExcelWorkSheet.Columns[2].ColumnWidth = 13;
            ExcelWorkSheet.Columns[3].ColumnWidth = 13;
            ExcelWorkSheet.Columns[4].ColumnWidth = 13;
            ExcelWorkSheet.Columns[5].ColumnWidth = 13;
            Microsoft.Office.Interop.Excel.Range r = ExcelWorkSheet.get_Range("A1", "S" + (dt.Rows.Count + 1).ToString());
            //Оформления
            r.Font.Name = "Calibri";
            r.Cells.Font.Size = 10;
            r.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            ExcelApp.Cells[1, 1] = "Телефон";
            ExcelApp.Cells[1, 2] = "Имя";
            ExcelApp.Cells[1, 3] = "Привилегии";
            ExcelApp.Cells[1, 4] = "Дата Рождения";
            ExcelApp.Cells[1, 5] = "Email";
            ExcelApp.Cells[1, 1].Borders.Color = ColorTranslator.ToOle(Color.Black);
            ExcelApp.Cells[1, 2].Borders.Color = ColorTranslator.ToOle(Color.Black);
            ExcelApp.Cells[1, 3].Borders.Color = ColorTranslator.ToOle(Color.Black);
            ExcelApp.Cells[1, 4].Borders.Color = ColorTranslator.ToOle(Color.Black);
            ExcelApp.Cells[1, 5].Borders.Color = ColorTranslator.ToOle(Color.Black);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 1; j < dt.Columns.Count; j++)
                {
                    ExcelApp.Cells[i + 2, j] = (dt.Rows[i].ItemArray)[j];
                    ExcelApp.Cells[i + 2, j].Borders.Color = ColorTranslator.ToOle(Color.Black);
                }
            }
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        }
        public void expWares(DataTable dt)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            //Книга.
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            //Таблица.
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            ExcelWorkSheet.Columns[1].ColumnWidth = 13;
            ExcelWorkSheet.Columns[2].ColumnWidth = 13;
            ExcelWorkSheet.Columns[3].ColumnWidth = 13;
            ExcelWorkSheet.Columns[4].ColumnWidth = 13;
            Microsoft.Office.Interop.Excel.Range r = ExcelWorkSheet.get_Range("A1", "S" + (dt.Rows.Count + 1).ToString());
            //Оформления
            r.Font.Name = "Calibri";
            r.Cells.Font.Size = 10;
            r.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            ExcelApp.Cells[1, 1] = "Артикул";
            ExcelApp.Cells[1, 2] = "Наименование";
            ExcelApp.Cells[1, 3] = "Количество";
            ExcelApp.Cells[1, 4] = "Цена";
            ExcelApp.Cells[1, 1].Borders.Color = ColorTranslator.ToOle(Color.Black);
            ExcelApp.Cells[1, 2].Borders.Color = ColorTranslator.ToOle(Color.Black);
            ExcelApp.Cells[1, 3].Borders.Color = ColorTranslator.ToOle(Color.Black);
            ExcelApp.Cells[1, 4].Borders.Color = ColorTranslator.ToOle(Color.Black);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 1; j < dt.Columns.Count; j++)
                {
                    ExcelApp.Cells[i + 2, j] = (dt.Rows[i].ItemArray)[j];
                    ExcelApp.Cells[i + 2, j].Borders.Color = ColorTranslator.ToOle(Color.Black);
                }
            }
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        }
        public void expOrders(DataTable dt)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            //Книга.
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            //Таблица.
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            ExcelWorkSheet.Columns[1].ColumnWidth = 13;
            ExcelWorkSheet.Columns[2].ColumnWidth = 13;
            ExcelWorkSheet.Columns[3].ColumnWidth = 13;
            ExcelWorkSheet.Columns[4].ColumnWidth = 13;
            Microsoft.Office.Interop.Excel.Range r = ExcelWorkSheet.get_Range("A1", "S" + (dt.Rows.Count + 1).ToString());
            //Оформления
            r.Font.Name = "Calibri";
            r.Cells.Font.Size = 10;
            r.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            ExcelApp.Cells[1, 1] = "Телефон";
            ExcelApp.Cells[1, 2] = "Артикул";
            ExcelApp.Cells[1, 3] = "Статус";
            ExcelApp.Cells[1, 4] = "Количество";
            ExcelApp.Cells[1, 1].Borders.Color = ColorTranslator.ToOle(Color.Black);
            ExcelApp.Cells[1, 2].Borders.Color = ColorTranslator.ToOle(Color.Black);
            ExcelApp.Cells[1, 3].Borders.Color = ColorTranslator.ToOle(Color.Black);
            ExcelApp.Cells[1, 4].Borders.Color = ColorTranslator.ToOle(Color.Black);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 1; j < dt.Columns.Count; j++)
                {
                    ExcelApp.Cells[i + 2, j] = (dt.Rows[i].ItemArray)[j];
                    ExcelApp.Cells[i + 2, j].Borders.Color = ColorTranslator.ToOle(Color.Black);
                }
            }
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        }

    }
}
