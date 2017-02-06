using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Guinea
{
    class ExcelPutter
    {
        public static void put(List<string> putter)
        {
            Excel.Application app = new Excel.Application();
            Excel.Sheets worksheets;
            Excel.Worksheet worksheet;
            Excel.Range range;
            Excel.Workbook book;

            app.Visible = true;

            app.SheetsInNewWorkbook = 1;
            app.Workbooks.Add(Type.Missing);
            worksheets = app.Worksheets;
            worksheet = (Excel.Worksheet)worksheets.get_Item(1);

            for (int i = 0; i < putter.Count; i ++)
            {
                string[] divided = putter[i].Split('|');

                range = worksheet.get_Range("A" + (i + 2).ToString());
                range.Value2 = divided[0];

                range = worksheet.get_Range("B" + (i + 2).ToString());
                range.Value2 = divided[1];

                range = worksheet.get_Range("C" + (i + 2).ToString());
                range.Value2 = divided[2];

            }

            app.DefaultSaveFormat = Excel.XlFileFormat.xlExcel9795;
            book = app.ThisWorkbook;
            book.Save();
            app.Quit();

        }
    }
}
