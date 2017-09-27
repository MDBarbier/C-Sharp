using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ExcelExportTest
{
    /// <summary>
    /// 
    /// This class uses the Open XML SDK to create Excel files dynamically
    /// 
    /// To use:
    /// 
    /// 1. Call "CreateSpreadsheet" passing in a filepath (with xlsx extension) and the desired sheet name to create a new workbook
    /// 2. Call "EditWorkbook" passing in the filepath and a dynamic containing the data you want written. The data shouls be a a list of objects, but the properties
    ///    can be whatever you need. For each item in the list a row will be written, and the properties the object has will be written to the cells of the row (in the
    ///    order the properties appear in the object).
    ///    
    /// Notes:
    ///   - EditWorkbook starts at index 1 e.g. the first row in the workbook, this class cannot currently add data to existing workbook
    ///   - Supports string and numeric data types
    /// </summary>
    class ExcelFunctions
    {
        private static string[] headerColumns = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ" };

        //Adds a row at the specified index containing the supplied dynamic object as cell values
        private static Row CreateContentRow(int index, dynamic data)
        {
            List<string> inputs = new List<string>();

            foreach (var prop in data.GetType().GetProperties())
            {
                inputs.Add(prop.GetValue(data, null).ToString());
            }

            var inputarray = inputs.ToArray();


            //Create the new row.
            Row r = new Row();
            r.RowIndex = (UInt32)index;

            //Create the cells that contain the data.
            for (int i = 0; i < inputarray.Length; i++)
            {
                //check if input is numeric
                int result;
                bool intParseResult = int.TryParse(inputarray[i], out result);

                Cell c = new Cell();

                if (intParseResult)
                {
                    c.CellReference = headerColumns[i] + index;
                    CellValue v = new CellValue();
                    v.Text = inputarray[i];
                    c.AppendChild(v);
                }
                else
                {
                    c.CellReference = headerColumns[i] + index;
                    c = CreateTextCell(headerColumns[i], inputarray[i], index);
                }

                r.AppendChild(c);
            }

            return r;
        }

        //Sets up an existing excel workbook for editing with the supplied data
        public static void EditWorkbook(string filename, dynamic data)
        {
            //Open the copied template workbook. 
            using (SpreadsheetDocument myWorkbook = SpreadsheetDocument.Open(filename, true))
            {
                //Access the main Workbook part, which contains all references.
                WorkbookPart workbookPart = myWorkbook.WorkbookPart;
                //Get the first worksheet. 
                WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                // The SheetData object will contain all the data.
                SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                foreach (var item in data)
                {
                    sheetData.Append(CreateContentRow(data.IndexOf(item) + 1, item));
                }

                // Save the new worksheet.
                worksheetPart.Worksheet.Save();
            }
        }

        private static Cell CreateTextCell(string header, string text, int index)
        {
            //Create a new inline string cell.
            Cell c = new Cell();
            c.DataType = CellValues.InlineString;
            c.CellReference = header + index;
            //Add text to the text cell.
            InlineString inlineString = new InlineString();
            Text t = new Text();
            t.Text = text;
            inlineString.AppendChild(t);
            c.AppendChild(inlineString);
            return c;
        }

        public static void CreateSpreadsheet(string filepath, string worksheetName)
        {
            SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(filepath, SpreadsheetDocumentType.Workbook);

            // Add a WorkbookPart to the document.
            WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
            workbookpart.Workbook = new Workbook();

            // Add a WorksheetPart to the WorkbookPart.
            WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            // Add Sheets to the Workbook.
            Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.
                AppendChild<Sheets>(new Sheets());

            // Append a new worksheet and associate it with the workbook.
            Sheet sheet = new Sheet()
            {
                Id = spreadsheetDocument.WorkbookPart.
                GetIdOfPart(worksheetPart),
                SheetId = 1,
                Name = worksheetName
            };
            sheets.Append(sheet);

            workbookpart.Workbook.Save();

            // Close the document.
            spreadsheetDocument.Close();
        }
    }
}
