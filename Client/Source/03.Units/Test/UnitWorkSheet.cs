using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DevExpress.Spreadsheet;

namespace Hnc.Calorimeter.Client
{
    public class WorksheetTagCollection
    {
        public WorksheetTagCollection(IWorkbook workbook)
        {
            this.workbook = workbook;
            Sheets = new Dictionary<string, Dictionary<string, Cell>>();
            Initialize();
        }

        private string csHeadTag = "{";
        private string csTailTag = "}";
        private string csEndTag = "{end}";

        private IWorkbook workbook;
        public Dictionary<string, Dictionary<string, Cell>> Sheets { get; private set; }

        public void SetWorkSheetVisible(string key, bool visible)
        {
            workbook.Worksheets[key].Visible = visible;
        }

        public void Clear()
        {
            workbook.BeginUpdate();

            try
            {
                foreach (KeyValuePair<string, Dictionary<string, Cell>> sheet in Sheets)
                {
                    foreach (KeyValuePair<string, Cell> tag in sheet.Value)
                    {
                        tag.Value.Value = "";
                    }
                }
            }
            finally
            {
                workbook.EndUpdate();
            }
        }

        private void Initialize()
        {
            int rowLength, columnLength;

            workbook.BeginUpdate();

            try
            {
                foreach (Worksheet sheet in workbook.Worksheets)
                {
                    rowLength = GetRowLength(sheet, csEndTag);
                    columnLength = GetColumnLength(sheet, csEndTag);

                    Dictionary<string, Cell> tags = new Dictionary<string, Cell>();
                    AddTags(sheet, tags, rowLength, columnLength);
                    Sheets.Add(sheet.Name, tags);
                }
            }
            finally
            {
                workbook.EndUpdate();
            }
        }

        public void Save(string fName)
        {
            try
            {
                workbook.SaveDocument(fName);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
            }
        }

        private void AddTags(Worksheet sheet, Dictionary<string, Cell> tags, int rowLength, int columnLength)
        {
            for (int row = 0; row < rowLength; row++)
            {
                for (int column = 0; column < columnLength; column++)
                {
                    string text = sheet.Cells[row, column].Value.TextValue;

                    if (string.IsNullOrWhiteSpace(text) == false)
                    {
                        text = text.Trim();

                        if (text.Length > 2)
                        {
                            string head = text.Substring(0, 1);
                            string tail = text.Substring(text.Length - 1, 1);

                            if ((head == csHeadTag) && (tail == csTailTag))
                            {
                                tags.Add(text, sheet.Cells[row, column]);
                            }
                        }
                    }
                }
            }
        }

        private int GetRowLength(Worksheet sheet, string text, int length = 100)
        {
            for (int i = 0; i < length; i++)
            {
                if (sheet.Cells[i, 0].Value.TextValue == text)
                {
                    sheet.Cells[i, 0].Value = "";

                    return sheet.Cells[i, 0].RowIndex + 1;
                }
            }

            return 0;
        }

        private int GetColumnLength(Worksheet sheet, string text, int length = 100)
        {
            for (int i = 0; i < length; i++)
            {
                if (sheet.Cells[0, i].Value.TextValue == csEndTag)
                {
                    sheet[0, i].Value = "";

                    return sheet[0, i].ColumnIndex + 1;
                }
            }

            return 0;
        }
    }
}
