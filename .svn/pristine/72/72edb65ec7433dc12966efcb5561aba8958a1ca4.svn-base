using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DevExpress.Spreadsheet;

namespace Hnc.Calorimeter.Client
{
    #region TestReport
    public class TestReport
    {
        public TestReport(TestContext context)
        {
            this.context = context;

            Method = new ConditionMethod();
            Note = new ConditionNote();
            Rated = new ConditionRated();
            ValueSheets = new Dictionary<string, ReportSheet>();
            DataRaw = new DataRawCollection(context);
        }

        private TestContext context;
        
        public Int64 RecNo { get; set; }
        public DateTime RegTime { get; set; }
        public ConditionMethod Method { get; set; }
        public ConditionNote Note { get; set; }
        public ConditionRated Rated { get; set; }
        public Dictionary<string, ReportSheet> ValueSheets { get; set; }
        public DataRawCollection DataRaw { get; set; }

        public void Initialize()
        {
            RecNo = -1;
            RegTime = DateTime.Now;

            ConditionSchedule sch = context.Condition.Schedules[context.Index];
            ReportSheet sheet;

            ConditionMethod method = context.Condition.Method;
            Method.IntegralCount = method.IntegralCount;
            Method.IntegralTime = method.IntegralTime;
            Method.ScanTime = method.ScanTime;
            Method.CoolingCapacity = method.CoolingCapacity;
            Method.HeatingCapacity = method.HeatingCapacity;
            Method.AirFlow = method.AirFlow;
            Method.Enthalpy = method.Enthalpy;
            Method.Pressure = method.Pressure;
            Method.DiffPressure = method.DiffPressure;
            Method.AtmPressure = method.AtmPressure;
            Method.AutoControllerSetting = method.AutoControllerSetting;
            Method.UsePowerMeterIntegral = method.UsePowerMeterIntegral;

            ConditionNote note = context.Condition.Note;
            Note.Company = note.Company;
            Note.Name = note.Name;
            Note.No = note.No;
            Note.Observer = note.Observer;
            Note.Maker = note.Maker;
            Note.Model1 = note.Model1;
            Note.Serial1 = note.Serial1;
            Note.Model2 = note.Model2;
            Note.Serial2 = note.Serial2;
            Note.Model3 = note.Model3;
            Note.Serial3 = note.Serial3;
            Note.ExpDevice = note.ExpDevice;
            Note.Refrigerant = note.Refrigerant;
            Note.RefCharge = note.RefCharge;
            Note.Memo = note.Memo;

            EIndoorMode mode = sch.IndoorMode;
            if (mode == EIndoorMode.NotUsed) mode = EIndoorMode.Cooling;

            EUnitCapacity unitCapa = (mode == EIndoorMode.Cooling) ? method.CoolingCapacity : method.HeatingCapacity;

            context.Value.SetUnitTo(EUnitType.Capacity, (int)unitCapa);
            context.Value.SetUnitTo(EUnitType.EER_COP, (int)unitCapa);

            ConditionRated rated = context.Condition.Rateds[EConditionRated.Total][(int)mode];
            Rated.Capacity = rated.Capacity;
            Rated.PowerInput = rated.PowerInput;
            Rated.EER_COP = rated.EER_COP;
            Rated.Voltage = rated.Voltage;
            Rated.Current = rated.Current;
            Rated.Frequency = rated.Frequency;
            Rated.PM_IDU = rated.PM_IDU;
            Rated.PM_ODU = rated.PM_ODU;
            Rated.Wiring = rated.Wiring;

            lock (ValueSheets)
            {
                string nozzleName;
                string nozzleState = "O,O,O,O";
                List<CoefficientDataRow> coeff = Resource.Settings.Coefficients;

                ValueSheets.Clear();

                nozzleName = $"Nozzle ({coeff[0].Nozzle1:f0}/{coeff[0].Nozzle2:f0}/{coeff[0].Nozzle3:f0}/{coeff[0].Nozzle4:f0})";
                sheet = new ReportCalorieSheet(context, "ID1", "ID11",
                    sch.Indoor1DB, sch.Indoor1WB, sch.Indoor1Use, sch.Indoor1Mode1,
                    sch.OutdoorDB, sch.OutdoorWB, sch.OutdoorUse, sch.OutdoorDpSensor,
                    nozzleName, nozzleState);
                sheet.Use = (sch.Indoor1Use == EIndoorUse.Indoor) ? true : false;
                ValueSheets.Add("ID A #1", sheet);

                nozzleName = $"Nozzle ({coeff[1].Nozzle1:f0}/{coeff[1].Nozzle2:f0}/{coeff[1].Nozzle3:f0}/{coeff[1].Nozzle4:f0})";
                sheet = new ReportCalorieSheet(context, "ID1", "ID12",
                    sch.Indoor1DB, sch.Indoor1WB, sch.Indoor1Use, sch.Indoor1Mode2,
                    sch.OutdoorDB, sch.OutdoorWB, sch.OutdoorUse, sch.OutdoorDpSensor,
                    nozzleName, nozzleState);
                sheet.Use = (sch.Indoor1Use == EIndoorUse.Indoor) ? true : false;
                ValueSheets.Add("ID A #2", sheet);

                nozzleName = $"Nozzle ({coeff[2].Nozzle1:f0}/{coeff[2].Nozzle2:f0}/{coeff[2].Nozzle3:f0}/{coeff[2].Nozzle4:f0})";
                sheet = new ReportCalorieSheet(context, "ID2", "ID21",
                    sch.Indoor2DB, sch.Indoor2WB, sch.Indoor2Use, sch.Indoor2Mode1,
                    sch.OutdoorDB, sch.OutdoorWB, sch.OutdoorUse, sch.OutdoorDpSensor,
                    nozzleName, nozzleState);
                sheet.Use = (sch.Indoor2Use == EIndoorUse.Indoor) ? true : false;
                ValueSheets.Add("ID B #1", sheet);

                nozzleName = $"Nozzle ({coeff[3].Nozzle1:f0}/{coeff[3].Nozzle2:f0}/{coeff[3].Nozzle3:f0}/{coeff[3].Nozzle4:f0})";
                sheet = new ReportCalorieSheet(context, "ID2", "ID22",
                    sch.Indoor2DB, sch.Indoor2WB, sch.Indoor2Use, sch.Indoor2Mode2,
                    sch.OutdoorDB, sch.OutdoorWB, sch.OutdoorUse, sch.OutdoorDpSensor,
                    nozzleName, nozzleState);
                sheet.Use = (sch.Indoor2Use == EIndoorUse.Indoor) ? true : false;
                ValueSheets.Add("ID B #2", sheet);

                sheet = new ReportThermoSheet(context, "ID1", "",
                    sch.Indoor1DB, sch.Indoor1WB, sch.Indoor1Use, sch.Indoor1Mode1,
                    sch.OutdoorDB, sch.OutdoorWB, sch.OutdoorUse, sch.OutdoorDpSensor, "", "");
                if (sheet.Use == true)
                {
                    sheet.Use = (sch.Indoor1Use == EIndoorUse.Indoor) ? true : false;
                }
                ValueSheets.Add("ID A TC", sheet);

                sheet = new ReportThermoSheet(context, "ID2", "",
                    sch.Indoor2DB, sch.Indoor2WB, sch.Indoor2Use, sch.Indoor2Mode1,
                    sch.OutdoorDB, sch.OutdoorWB, sch.OutdoorUse, sch.OutdoorDpSensor, "", "");
                if (sheet.Use == true)
                {
                    sheet.Use = (sch.Indoor2Use == EIndoorUse.Indoor) ? true : false;
                }
                ValueSheets.Add("ID B TC", sheet);

                sheet = new ReportThermoSheet(context, "OD", "",
                    sch.Indoor1DB, sch.Indoor1WB, sch.Indoor1Use, sch.Indoor1Mode1,
                    sch.OutdoorDB, sch.OutdoorWB, sch.OutdoorUse, sch.OutdoorDpSensor, "", "");
                if (sheet.Use == true)
                {
                    sheet.Use = (sch.OutdoorUse == EOutdoorUse.Outdoor) ? true : false;
                }
                ValueSheets.Add("OD TC", sheet);
            }

            DataRaw.Clear();

            foreach (KeyValuePair<string, ValueRow> row in context.Value.Calcurated)
            {
                if (row.Value.Save == true)
                {
                    DataRaw.Rows.Add(row.Key, new DataRaw(-1, row.Value));
                }
            }

            foreach (KeyValuePair<string, ValueRow> row in context.Value.Measured)
            {
                if (row.Value.Save == true)
                {
                    DataRaw.Rows.Add(row.Key, new DataRaw(-1, row.Value));
                }
            }

            DataRaw.Count = DataRaw.Rows.Count / 600;
            if ((DataRaw.Rows.Count % 600) != 0) DataRaw.Count++;
        }

        public void RefreshCondition()
        {
            ConditionSchedule sch = context.Condition.Schedules[context.Index];

            ConditionNote note = context.Condition.Note;
            Note.Company = note.Company;
            Note.Name = note.Name;
            Note.No = note.No;
            Note.Observer = note.Observer;
            Note.Maker = note.Maker;
            Note.Model1 = note.Model1;
            Note.Serial1 = note.Serial1;
            Note.Model2 = note.Model2;
            Note.Serial2 = note.Serial2;
            Note.Model3 = note.Model3;
            Note.Serial3 = note.Serial3;
            Note.ExpDevice = note.ExpDevice;
            Note.Refrigerant = note.Refrigerant;
            Note.RefCharge = note.RefCharge;
            Note.Memo = note.Memo;

            EIndoorMode mode = sch.IndoorMode;
            if (mode == EIndoorMode.NotUsed) mode = EIndoorMode.Cooling;

            ConditionRated rated = context.Condition.Rateds[EConditionRated.Total][(int)mode];
            Rated.Capacity = rated.Capacity;
            Rated.PowerInput = rated.PowerInput;
            Rated.EER_COP = rated.EER_COP;
            Rated.Voltage = rated.Voltage;
            Rated.Current = rated.Current;
            Rated.Frequency = rated.Frequency;
            Rated.PM_IDU = rated.PM_IDU;
            Rated.PM_ODU = rated.PM_ODU;
            Rated.Wiring = rated.Wiring;

            (ValueSheets["ID A #1"] as ReportCalorieSheet).Set(sch.Indoor1DB, sch.Indoor1WB, sch.OutdoorDB, sch.OutdoorWB);
            (ValueSheets["ID A #2"] as ReportCalorieSheet).Set(sch.Indoor1DB, sch.Indoor1WB, sch.OutdoorDB, sch.OutdoorWB);
            (ValueSheets["ID B #1"] as ReportCalorieSheet).Set(sch.Indoor2DB, sch.Indoor2WB, sch.OutdoorDB, sch.OutdoorWB);
            (ValueSheets["ID B #2"] as ReportCalorieSheet).Set(sch.Indoor2DB, sch.Indoor2WB, sch.OutdoorDB, sch.OutdoorWB);
            (ValueSheets["ID A TC"] as ReportThermoSheet).Set(sch.Indoor1DB, sch.Indoor1WB, sch.OutdoorDB, sch.OutdoorWB);
            (ValueSheets["ID A TC"] as ReportThermoSheet).Reinitialize();
            (ValueSheets["ID B TC"] as ReportThermoSheet).Set(sch.Indoor2DB, sch.Indoor2WB, sch.OutdoorDB, sch.OutdoorWB);
            (ValueSheets["ID B TC"] as ReportThermoSheet).Reinitialize();
            (ValueSheets["OD TC"] as ReportThermoSheet).Set(sch.Indoor1DB, sch.Indoor1WB, sch.OutdoorDB, sch.OutdoorWB);
            (ValueSheets["OD TC"] as ReportThermoSheet).Reinitialize();
        }

        public void Clear()
        {
            lock (this)
            {
                // Reset PK_RECNO of TB_DATABOOK
                RecNo = -1;

                foreach (KeyValuePair<string, ReportSheet> sheet in ValueSheets)
                {
                    // Reset PK_RECNO of TB_DATASHEET
                    sheet.Value.RecNo = -1;

                    foreach (KeyValuePair<string, ReportRow> row in sheet.Value.Rows)
                    {
                        // Reset PK_RECNO of TB_DATAVALUEUNIT
                        row.Value.RecNo = -1;

                        foreach (ReportCell cell in row.Value.Cells)
                        {
                            cell.Clear();
                        }
                    }
                }

                foreach (KeyValuePair<string, DataRaw> row in DataRaw.Rows)
                {
                    // Reset PK_RECNO of TB_DATARAWUNIT
                    row.Value.RecNo = -1;
                    row.Value.Row.Storage.Reset();
                }
            }
        }

        public void Lock()
        {
            Monitor.Enter(this);
        }

        public void Unlock()
        {
            Monitor.Exit(this);
        }
    }

    public abstract class ReportSheet
    {
        public ReportSheet(TestContext context, string head1, string head2,
            float idDB, float idWB, EIndoorUse idUse, EIndoorMode idMode,
            float odDB, float odWB, EOutdoorUse odUse, EEtcUse odDp, 
            string nozzleName, string nozzleState)
        {
            RecNo = -1;
            IndoorDB = idDB;
            IndoorWB = idWB;
            IndoorUse = idUse;
            IndoorMode = idMode;
            OutdoorDB = odDB;
            OutdoorWB = odWB;
            OutdoorUse = odUse;
            OutdoorDP = odDp;
            NozzleName = nozzleName;
            NozzleState = nozzleState;
            Rows = new Dictionary<string, ReportRow>();

            TcTags = null;

            if (string.IsNullOrWhiteSpace(head2) == true)
            {
                switch (head1)
                {
                    case "ID1":
                        TcTags = context.Condition.TC1;
                        break;

                    case "ID2":
                        TcTags = context.Condition.TC2;
                        break;

                    case "OD":
                        TcTags = context.Condition.TC3;
                        break;
                }
            }

            Initialize(context.Value, head1, head2);
        }

        public Int64 RecNo { get; set; }
        public float IndoorDB { get; set; }
        public float IndoorWB { get; set; }
        public bool Use { get; set; }
        public EIndoorUse IndoorUse { get; set; }
        public EIndoorMode IndoorMode { get; set; }
        public float OutdoorDB { get; set; }
        public float OutdoorWB { get; set; }
        public EOutdoorUse OutdoorUse { get; set; }
        public EEtcUse OutdoorDP { get; set; }
        public string NozzleName { get; set; }
        public string NozzleState { get; set; }
        public Dictionary<string, ReportRow> Rows { get; set; }
        public bool Enabled
        { get { return (Rows.Count == 0) ? false : true; } }
        public List<MeasureRow> TcTags { get; private set; }

        protected abstract void Initialize(TestValue value, string head1, string head2);

        public virtual void Set(float idDB, float idWB, float odDB, float odWB)
        {
            IndoorDB = idDB;
            IndoorWB = idWB;
            OutdoorDB = odDB;
            OutdoorWB = odWB;
        }

        public void ClearData(int index)
        {
            foreach (KeyValuePair<string, ReportRow> row in Rows)
            {
                row.Value.Cells[index].Raw = float.NaN;
            }
        }

        public void RefreshData(int index)
        {
            foreach (KeyValuePair<string, ReportRow> row in Rows)
            {
                if (row.Value.Row != null)
                    row.Value.Cells[index].Raw = row.Value.Row.Raw;
                else
                    row.Value.Cells[index].Raw = float.NaN;
            }
        }
    }

    public class ReportCalorieSheet : ReportSheet
    {
        public ReportCalorieSheet(TestContext context, string head1, string head2,
            float idDB, float idWB, EIndoorUse idUse, EIndoorMode idMode, float odDB, 
            float odWB, EOutdoorUse odUse, EEtcUse odDp, string nozzleName, string nozzleState)
            : base(context, head1, head2, idDB, idWB, idUse, idMode, 
                  odDB, odWB, odUse, odDp, nozzleName, nozzleState)
        {
        }

        protected override void Initialize(TestValue value, string head1, string head2)
        {
            if (IndoorUse == EIndoorUse.NotUsed) return;

            if (IndoorMode == EIndoorMode.NotUsed)
            {
                Rows.Add("Total.Capacity", new ReportRow("324", null));
                Rows.Add("Total.Power", new ReportRow("325", value.Calcurated["Total.Power"]));
                Rows.Add("Total.EER_COP", new ReportRow("326", null));
                Rows.Add("Total.Capacity.Ratio", new ReportRow("327", null));
                Rows.Add("Total.Power.Ratio", new ReportRow("328", value.Calcurated["Total.Power.Ratio"]));
                Rows.Add("Total.EER_COP.Ratio", new ReportRow("329", null));

                Rows.Add("IDU.Power", new ReportRow("330", value.Calcurated[head1+".IDU.Power"]));
                Rows.Add("IDU.Voltage", new ReportRow("331", value.Calcurated[head1+".IDU.Voltage"]));
                Rows.Add("IDU.Current", new ReportRow("332", value.Calcurated[head1+".IDU.Current"]));
                Rows.Add("IDU.Frequency", new ReportRow("333", value.Calcurated[head1+".IDU.Frequency"]));
                Rows.Add("IDU.Power.Factor", new ReportRow("334", value.Calcurated[head1+".IDU.Power.Factor"]));

                Rows.Add("ODU.Power", new ReportRow("335", value.Calcurated[head1+".ODU.Power"]));
                Rows.Add("ODU.Voltage", new ReportRow("336", value.Calcurated[head1+".ODU.Voltage"]));
                Rows.Add("ODU.Current", new ReportRow("337", value.Calcurated[head1+".ODU.Current"]));
                Rows.Add("ODU.Frequency", new ReportRow("338", value.Calcurated[head1+".ODU.Frequency"]));
                Rows.Add("ODU.Power.Factor", new ReportRow("339", value.Calcurated[head1+".ODU.Power.Factor"]));

                Rows.Add("Capacity", new ReportRow("341", null));
                Rows.Add("Capacity.Ratio", new ReportRow("394", null));
                Rows.Add("Sensible.Heat", new ReportRow("342", null));
                Rows.Add("Latent.Heat", new ReportRow("343", null));
                Rows.Add("Sensible.Heat.Ratio", new ReportRow("344", null));
                Rows.Add("Heat.Leakage", new ReportRow("345", null));
                Rows.Add("Drain.Weight", new ReportRow("346", null));

                Rows.Add("Entering.DB", new ReportRow("347", value.Measured[head2+".Entering.DB"]));
                Rows.Add("Entering.WB", new ReportRow("348", value.Measured[head2+".Entering.WB"]));
                Rows.Add("Entering.RH", new ReportRow("349", value.Calcurated[head2+".Entering.RH"]));
                Rows.Add("Leaving.DB", new ReportRow("350", value.Measured[head2+".Leaving.DB"]));
                Rows.Add("Leaving.WB", new ReportRow("351", value.Measured[head2+".Leaving.WB"]));
                Rows.Add("Leaving.RH", new ReportRow("352", value.Calcurated[head2+".Leaving.RH"]));

                Rows.Add("Entering.Enthalpy", new ReportRow("353", null));
                Rows.Add("Leaving.Enthalpy", new ReportRow("354", null));
                Rows.Add("Entering.Humidity.Ratio", new ReportRow("355", null));
                Rows.Add("Leaving.Humidity.Ratio", new ReportRow("356", null));
                Rows.Add("Leaving.Specific.Heat", new ReportRow("357", null));
                Rows.Add("Leaving.Specific.Volume", new ReportRow("358", null));

                Rows.Add("Air.Flow.Lev", new ReportRow("359", null));
                Rows.Add("Static.Pressure", new ReportRow("360", null));
                Rows.Add("Nozzle.Diff.Pressure", new ReportRow("361", null));
                Rows.Add("Atm.Pressure", new ReportRow("362", null));
                Rows.Add("Nozzle.Inlet.Temp", new ReportRow("363", null));
                Rows.Add("Nozzle", new ReportRow("365", null));
            }
            else
            {
                Rows.Add("Total.Capacity", new ReportRow("324", value.Calcurated["Total.Capacity"]));
                Rows.Add("Total.Power", new ReportRow("325", value.Calcurated["Total.Power"]));
                Rows.Add("Total.EER_COP", new ReportRow("326", value.Calcurated["Total.EER_COP"]));
                Rows.Add("Total.Capacity.Ratio", new ReportRow("327", value.Calcurated["Total.Capacity.Ratio"]));
                Rows.Add("Total.Power.Ratio", new ReportRow("328", value.Calcurated["Total.Power.Ratio"]));
                Rows.Add("Total.EER_COP.Ratio", new ReportRow("329", value.Calcurated["Total.EER_COP.Ratio"]));

                Rows.Add("IDU.Power", new ReportRow("330", value.Calcurated[head1+".IDU.Power"]));
                Rows.Add("IDU.Voltage", new ReportRow("331", value.Calcurated[head1+".IDU.Voltage"]));
                Rows.Add("IDU.Current", new ReportRow("332", value.Calcurated[head1+".IDU.Current"]));
                Rows.Add("IDU.Frequency", new ReportRow("333", value.Calcurated[head1+".IDU.Frequency"]));
                Rows.Add("IDU.Power.Factor", new ReportRow("334", value.Calcurated[head1+".IDU.Power.Factor"]));

                Rows.Add("ODU.Power", new ReportRow("335", value.Calcurated[head1+".ODU.Power"]));
                Rows.Add("ODU.Voltage", new ReportRow("336", value.Calcurated[head1+".ODU.Voltage"]));
                Rows.Add("ODU.Current", new ReportRow("337", value.Calcurated[head1+".ODU.Current"]));
                Rows.Add("ODU.Frequency", new ReportRow("338", value.Calcurated[head1+".ODU.Frequency"]));
                Rows.Add("ODU.Power.Factor", new ReportRow("339", value.Calcurated[head1+".ODU.Power.Factor"]));

                Rows.Add("Capacity", new ReportRow("341", value.Calcurated[head2+".Capacity"]));
                Rows.Add("Capacity.Ratio", new ReportRow("394", value.Calcurated[head2+".Capacity.Ratio"]));
                Rows.Add("Sensible.Heat", new ReportRow("342", value.Calcurated[head2+".Sensible.Heat"]));
                Rows.Add("Latent.Heat", new ReportRow("343", value.Calcurated[head2+".Latent.Heat"]));
                Rows.Add("Sensible.Heat.Ratio", new ReportRow("344", value.Calcurated[head2+".Sensible.Heat.Ratio"]));
                Rows.Add("Heat.Leakage", new ReportRow("345", value.Calcurated[head2+".Heat.Leakage"]));
                Rows.Add("Drain.Weight", new ReportRow("346", value.Calcurated[head2+".Drain.Weight"]));

                Rows.Add("Entering.DB", new ReportRow("347", value.Measured[head2+".Entering.DB"]));
                Rows.Add("Entering.WB", new ReportRow("348", value.Measured[head2+".Entering.WB"]));
                Rows.Add("Entering.RH", new ReportRow("349", value.Calcurated[head2+".Entering.RH"]));
                Rows.Add("Leaving.DB", new ReportRow("350", value.Measured[head2+".Leaving.DB"]));
                Rows.Add("Leaving.WB", new ReportRow("351", value.Measured[head2+".Leaving.WB"]));
                Rows.Add("Leaving.RH", new ReportRow("352", value.Calcurated[head2+".Leaving.RH"]));

                Rows.Add("Entering.Enthalpy", new ReportRow("353", value.Calcurated[head2+".Entering.Enthalpy"]));
                Rows.Add("Leaving.Enthalpy", new ReportRow("354", value.Calcurated[head2+".Leaving.Enthalpy"]));
                Rows.Add("Entering.Humidity.Ratio", new ReportRow("355", value.Calcurated[head2+".Entering.Humidity.Ratio"]));
                Rows.Add("Leaving.Humidity.Ratio", new ReportRow("356", value.Calcurated[head2+".Leaving.Humidity.Ratio"]));
                Rows.Add("Leaving.Specific.Heat", new ReportRow("357", value.Calcurated[head2+".Leaving.Specific.Heat"]));
                Rows.Add("Leaving.Specific.Volume", new ReportRow("358", value.Calcurated[head2+".Leaving.Specific.Volume"]));

                Rows.Add("Air.Flow.Lev", new ReportRow("359", value.Calcurated[head2+".Air.Flow.Lev"]));
                Rows.Add("Static.Pressure", new ReportRow("360", value.Measured[head2+".Static.Pressure"]));
                Rows.Add("Nozzle.Diff.Pressure", new ReportRow("361", value.Measured[head2+".Nozzle.Diff.Pressure"]));
                Rows.Add("Atm.Pressure", new ReportRow("362", value.Measured[head1+".Atm.Pressure"]));
                Rows.Add("Nozzle.Inlet.Temp", new ReportRow("363", value.Measured[head2 + ".Nozzle.Inlet.Temp"]));
                Rows.Add("Nozzle", new ReportRow("365", value.Calcurated[head2 + ".Nozzle"]));
            }

            if (OutdoorUse == EOutdoorUse.Outdoor)
            {
                Rows.Add("OD.Entering.DB", new ReportRow("366", value.Measured["OD.Entering.DB"]));
                Rows.Add("OD.Entering.WB", new ReportRow("367", value.Measured["OD.Entering.WB"]));
                Rows.Add("OD.Entering.RH", new ReportRow("368", value.Calcurated["OD.Entering.RH"]));
                Rows.Add("OD.Entering.DP", new ReportRow("369", value.Measured["OD.Entering.DP"]));
            }
        }
    }

    public class ReportThermoSheet : ReportSheet
    {
        public ReportThermoSheet(TestContext context, string head1, string head2,
            float idDB, float idWB, EIndoorUse idUse, EIndoorMode idMode, float odDB, 
            float odWB, EOutdoorUse odUse, EEtcUse odDp, string nozzleName, string nozzleState)
            : base(context, head1, head2, idDB, idWB, idUse, idMode, 
                  odDB, odWB, odUse, odDp, nozzleName, nozzleState)
        {
            this.context = context;
            this.head1 = head1;
            this.head2 = head2;
        }

        private TestContext context;
        private string head1;
        private string head2;

        protected override void Initialize(TestValue value, string head1, string head2)
        {
            if (IsTcTagsEmpty() == true)
            {
                Use = false;
                return;
            }

            if (head1.Substring(0, 2) == "ID")
            {
                if (IndoorUse == EIndoorUse.NotUsed) return;
            }
            else
            {
                if (OutdoorUse == EOutdoorUse.NotUsed) return;
            }

            Use = true;
            for (int i = 0; i < 60; i++)
            {
                if (string.IsNullOrWhiteSpace(TcTags[i].Name) == true)
                {
                    Rows.Add($"TC {i + 1:d2}", new ReportRow($"{525 + i}", null));
                }
                else
                {
                    Rows.Add($"TC {i + 1:d2}", new ReportRow($"{525 + i}", value.Measured[head1 + $".TC.{i + 1:d3}"], TcTags[i].Name));
                }
            }
        }

        public void Reinitialize()
        {
            if (IsTcTagsEmpty() == true)
            {
                Use = false;
                return;
            }

            if (head1.Substring(0, 2) == "ID")
            {
                if (IndoorUse == EIndoorUse.NotUsed) return;
            }
            else
            {
                if (OutdoorUse == EOutdoorUse.NotUsed) return;
            }

            Use = true;
            Rows.Clear();

            for (int i = 0; i < 60; i++)
            {
                if (string.IsNullOrWhiteSpace(TcTags[i].Name) == true)
                {
                    Rows.Add($"TC {i + 1:d2}", new ReportRow($"{525 + i}", null));
                }
                else
                {
                    Rows.Add($"TC {i + 1:d2}", new ReportRow($"{525 + i}", context.Value.Measured[head1 + $".TC.{i + 1:d3}"], TcTags[i].Name));
                }
            }
        }

        private bool IsTcTagsEmpty()
        {
            bool empty = true;

            foreach (MeasureRow row in TcTags)
            {
                if (string.IsNullOrWhiteSpace(row.Name) == false)
                {
                    empty = false;
                    break;
                }
            }

            return empty;
        }
    }

    public class ReportRow
    {
        public ReportRow(string tag, ValueRow row, string alias="", int count = 7)
        {
            RecNo = -1;
            Tag = tag;
            Row = row;
            Alias = alias;

            if (count > 7) count = 7;
            count++;

            float value = (Row == null) ? float.NaN : 0;
            string format = (Row == null) ? "" : Row.Format;

            Cells = new List<ReportCell>();
            for (int i = 0; i < count; i++)
            {
                Cells.Add(new ReportCell($"{Tag}-{i + 1}", value, format));
            }
        }

        public Int64 RecNo { get; set; }
        public string Tag { get; }
        public ValueRow Row { get; }
        public string Alias { get; }
        public List<ReportCell> Cells { get; }
        public float Average
        {
            get
            {
                if (Row == null) return float.NaN;

                int i = 0;
                float sum = 0;

                foreach (ReportCell cell in Cells)
                {
                    if (cell.Raw == 0.0) break;
                    if (float.IsNaN(cell.Raw) == true) break;
                    if (string.IsNullOrWhiteSpace(cell.Value) == true) break;

                    sum += cell.Raw;
                    i++;
                }

                return (i == 0) ? 0 : (sum / i);
            }
        }
        public int Count { get { return Cells.Count; } }
    }

    public class ReportCell
    {
        public ReportCell(string tag, float value, string format, string strValue = "")
        {
            Tag = tag;
            Raw = value;
            Format = format;
            StrValue = strValue;
        }

        public string Tag { get; }
        public float Raw { get; set; }
        public string Value
        {
            get
            {
                if (StrValue != "") return StrValue;
                if (Format == "") return "";
                if (float.IsNaN(Raw) == true) return "";

                return Raw.ToString(Format);
            }
        }
        public string Format { get; }
        public string StrValue { get; set; }

        public void Clear()
        {
            Raw = 0;
            StrValue = "";
        }
    }

    public class DataRawCollection
    {
        public DataRawCollection(TestContext context)
        {
            this.Count = 1;
            this.Rows = new Dictionary<string, DataRaw>();
            this.context = context;
        }

        private TestContext context;

        public int Count { get; set; }
        public Dictionary<string, DataRaw> Rows { get; private set; }

        public bool HalfFull
        {
            get
            {
                bool state = false;
                context.Value.Lock();

                try
                {
                    foreach (KeyValuePair<string, DataRaw> dataRaw in Rows)
                    {
                        if (dataRaw.Value.Row.Storage.HalfFull == true)
                        {
                            state = true;
                            break;
                        }
                    }
                }
                finally
                {
                    context.Value.Unlock();
                }

                return state;
            }
        }

        public DataRaw HalfFullDataRaw
        {
            get
            {
                DataRaw raw = null;
                context.Value.Lock();

                try
                {
                    foreach (KeyValuePair<string, DataRaw> dataRaw in Rows)
                    {
                        if (dataRaw.Value.Row.Storage.HalfFull == true)
                        {
                            raw = dataRaw.Value;
                            break;
                        }
                    }
                }
                finally
                {
                    context.Value.Unlock();
                }

                return raw;
            }
        }

        public void Clear()
        {
            Count = 1;
            Rows.Clear();
        }
    }

    public class DataRaw
    {
        public DataRaw(Int64 recNo=-1, ValueRow row=null)
        {
            RecNo = recNo;
            Row = row;
        }

        public Int64 RecNo { get; set; }
        public ValueRow Row { get; set; }
    }
    #endregion
}
