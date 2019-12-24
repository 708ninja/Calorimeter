using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;

using DevExpress.Spreadsheet;

using Ulee.Controls;
using Ulee.Utils;

namespace Hnc.Calorimeter.Client
{ 
    public partial class CtrlViewReport : UlUserControlEng
    {
        public CtrlViewReport(int handle)
        {
            InitializeComponent();

            this.handle = handle;
            Initialize();
        }

        private int handle;
        private string fName;
        private CalorimeterViewDatabase db;
        private List<string> calorieTags;
        private List<string> thermoTags;
        private WorksheetTagCollection sheetTags;

        private void Initialize()
        {
            reportSheet.LoadDocument(Resource.csExcelOriginReport);

            db = Resource.ViewDB;
            calorieTags = null;
            thermoTags = null;
            sheetTags = null;
        }

        private void CtrlViewReport_Load(object sender, EventArgs e)
        {
            sheetTags = new WorksheetTagCollection(reportSheet.Document);
            sheetTags.SetWorkSheetVisible("Raw Data", false);
            sheetTags.Clear();

            calorieTags = new List<string>();
            calorieTags.Add("324");
            calorieTags.Add("325");
            calorieTags.Add("326");
            calorieTags.Add("327");
            calorieTags.Add("328");
            calorieTags.Add("329");
            calorieTags.Add("330");
            calorieTags.Add("331");
            calorieTags.Add("332");
            calorieTags.Add("333");
            calorieTags.Add("334");
            calorieTags.Add("335");
            calorieTags.Add("336");
            calorieTags.Add("337");
            calorieTags.Add("338");
            calorieTags.Add("339");
            calorieTags.Add("341");
            calorieTags.Add("394");
            calorieTags.Add("342");
            calorieTags.Add("343");
            calorieTags.Add("344");
            calorieTags.Add("345");
            calorieTags.Add("346");
            calorieTags.Add("347");
            calorieTags.Add("348");
            calorieTags.Add("349");
            calorieTags.Add("350");
            calorieTags.Add("351");
            calorieTags.Add("352");
            calorieTags.Add("353");
            calorieTags.Add("354");
            calorieTags.Add("355");
            calorieTags.Add("356");
            calorieTags.Add("357");
            calorieTags.Add("358");
            calorieTags.Add("359");
            calorieTags.Add("360");
            calorieTags.Add("361");
            calorieTags.Add("362");
            calorieTags.Add("363");
            calorieTags.Add("365");
            calorieTags.Add("366");
            calorieTags.Add("367");
            calorieTags.Add("368");
            calorieTags.Add("369");

            thermoTags = new List<string>();
            for (int i = 0; i < 60; i++) thermoTags.Add($"{525 + i}");
        }

        public void Open(Int64 recNo)
        {
            sheetTags.Clear();
            db.Lock();

            try
            {
                Dictionary<string, Cell> sheet;
                DataBookDataSet bookSet = db.DataBookSet;
                DataSheetDataSet sheetSet = db.DataSheetSet;
                DataValueUnitDataSet valueUnitSet = db.DataValueUnitSet;
                DataValueDataSet valueSet = db.DataValueSet;

                bookSet.Select(recNo);

                if (bookSet.IsEmpty() == false)
                {
                    bookSet.Fetch();
                    if (string.IsNullOrWhiteSpace(bookSet.TestName) == true)
                        fName = $"None_Line{bookSet.TestLine + 1}";
                    else
                        fName = $"{bookSet.TestName}_Line{bookSet.TestLine + 1}";

                    sheetSet.Select(bookSet.RecNo);

                    for (int i=0; i<sheetSet.GetRowCount(); i++)
                    {
                        sheetSet.Fetch(i);

                        bool isNozzle = false;
                        if ((sheetSet.IDState.EndsWith("Cooling") == true) ||
                            (sheetSet.IDState.EndsWith("Heating") == true)) isNozzle = true;

                        sheet = sheetTags.Sheets[sheetSet.SheetName];

                        reportSheet.BeginUpdate();

                        try
                        {
                            SetSheetTitle(sheet, bookSet, sheetSet);

                            if (sheetSet.Use == true)
                            {
                                valueUnitSet.Select(sheetSet.RecNo);

                                if (i < 4)
                                {
                                    SetSheetValues(sheet, calorieTags,
                                        bookSet.IntegCount, bookSet.IntegTime, valueUnitSet, valueSet, false, isNozzle);
                                }
                                else
                                {
                                    SetSheetValues(sheet, thermoTags, 
                                        bookSet.IntegCount, bookSet.IntegTime, valueUnitSet, valueSet, true, false);
                                }
                            }
                        }
                        finally
                        {
                            reportSheet.EndUpdate();
                        }

                        Thread.Sleep(1);
                    }
                }
            }
            finally
            {
                db.Unlock();
            }
        }

        public void SaveExcel()
        {
            string excelName = Resource.Settings.Options.ExcelPath + "\\" + fName + "_"
                + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

            try
            {
                reportSheet.SaveDocument(excelName);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
            }
        }

        private void SetSheetTitle(Dictionary<string, Cell> sheet, DataBookDataSet bookSet, DataSheetDataSet sheetSet)
        {
            sheetTags.SetWorkSheetVisible(sheetSet.SheetName, sheetSet.Use);

            if (sheetSet.Use == true)
            {
                sheet["{300}"].Value = bookSet.Company;
                sheet["{302}"].Value = bookSet.TestName;
                sheet["{304}"].Value = bookSet.TestNo;
                sheet["{306}"].Value = bookSet.Observer;
                sheet["{308}"].Value = bookSet.Maker;
                sheet["{310}"].Value = bookSet.Model1;
                sheet["{312}"].Value = bookSet.Serial1;
                sheet["{314}"].Value = bookSet.Model2;
                sheet["{316}"].Value = bookSet.Serial2;

                string str = bookSet.Model3 + " / " + bookSet.Serial3;
                if (str.Trim() == "/")
                    sheet["{318}"].Value = "";
                else
                    sheet["{318}"].Value = str;

                sheet["{320}"].Value = sheetSet.IDTemp;
                sheet["{322}"].Value = sheetSet.IDState;

                sheet["{301}"].Value = bookSet.Capacity;
                sheet["{303}"].Value = bookSet.PowerInput;
                sheet["{305}"].Value = bookSet.EER_COP;
                sheet["{307}"].Value = bookSet.PowerSource;
                sheet["{309}"].Value = bookSet.ExpDevice;
                sheet["{311}"].Value = bookSet.Refrige;
                sheet["{313}"].Value = bookSet.RefCharge;
                sheet["{315}"].Value = bookSet.BeginTime;
                sheet["{321}"].Value = sheetSet.ODTemp;
                sheet["{323}"].Value = sheetSet.ODState;
                sheet["{299}"].Value = "";

                if (sheetSet.SheetName.EndsWith("TC") == false)
                {
                    sheet["{365}"].Value = sheetSet.NozzleName;
                }
            }
        }

        private void SetSheetValues(Dictionary<string, Cell> sheet, List<string> cellTags, int integCount,
            int integTime, DataValueUnitDataSet valueUnitSet, DataValueDataSet valueSet, bool isThermo, bool isNozzle=false)
        {
            string tag, state = "";
            float average = 0;
            int valueCount = 0;
            int valueUnitCount = valueUnitSet.GetRowCount();
            UnitConvert unit = new UnitConvert(EUnitType.None, 0, 0);

            for (int i = 0; i < valueUnitCount; i++)
            {
                valueUnitSet.Fetch(i);

                unit.Type = (EUnitType)valueUnitSet.UnitType;
                unit.From = valueUnitSet.UnitFrom;
                unit.To = valueUnitSet.UnitTo;

                if (isThermo == true)
                {
                    tag = $"{{{cellTags[i]}-N}}";
                    sheet[tag].Value = valueUnitSet.ValueName;
                }

                tag = $"{{{cellTags[i]}}}";

                if (cellTags[i] != "365")
                {
                    if (valueUnitSet.UnitType == 0)
                        sheet[tag].Value = "";
                    else
                        sheet[tag].Value = unit.ToDescription;
                }

                average = 0;
                valueSet.Select(valueUnitSet.RecNo);
                valueCount = valueSet.GetRowCount();

                for (int j = 0; j < valueCount; j++)
                {
                    valueSet.Fetch(j);

                    tag = $"{{{cellTags[i]}-{valueSet.DataNo+1}}}";

                    if (valueUnitSet.UnitType == 0)
                    {
                        if ((cellTags[i] == "365") && (isNozzle == true))
                        {
                            state = GetNozzleState((byte)valueSet.DataValue);
                            sheet[tag].Value = state;
                        }
                        else
                        {
                            sheet[tag].Value = "";
                            average = float.NaN;
                            break;
                        }
                    }
                    else
                    {
                        if (float.IsNaN(valueSet.DataValue) == true)
                        {
                            sheet[tag].Value = "";
                            average = float.NaN;
                            break;
                        }
                        else
                        {
                            if (string.IsNullOrWhiteSpace(valueUnitSet.Format) == false)
                            {
                                sheet[tag].NumberFormat = valueUnitSet.Format;
                            }

                            sheet[tag].Value = unit.Convert(valueSet.DataValue);
                            average += valueSet.DataValue;
                        }
                    }
                }

                tag = $"{{{cellTags[i]}-0}}";

                if (cellTags[i] == "365")
                {
                    if (isNozzle == true)
                        sheet[tag].Value = state;
                    else
                        sheet[tag].Value = "";
                }
                else
                { 
                    if ((valueUnitSet.UnitType == 0) || (valueCount == 0))
                    {
                        sheet[tag].Value = "";
                    }
                    else
                    {
                        if (float.IsNaN(average) == true)
                        {
                            sheet[tag].Value = "";
                        }
                        else
                        {
                            average = average / valueCount;
                            sheet[tag].Value = unit.Convert(average);
                        }
                    }
                }
            }

            sheet["{min-0}"].Value = "Average";
            for (int i=0; i<integCount; i++)
            {
                tag = $"{{min-{i+1}}}";
                sheet[tag].Value = $"{(i+1)*integTime} min";
            }
        }

        private string GetNozzleState(byte nozzleValue)
        {
            string state = "";

            for (int i = 0; i < 4; i++)
            {
                state += (UlBits.Get(nozzleValue, i) == true) ? "O," : "X,";
            }

            return state.Substring(0, 7);
        }
    }
}
