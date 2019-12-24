﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ulee.Utils;

namespace Hnc.Calorimeter.Client
{
    #region Enum
    //public enum EClientState
    //{ Observation, Idle, Preparation, Stabilization, Integration }

    public enum EUserAuthority
    { Maker, Admin, Operator, Viewer }

    public enum EValueType
    { Raw, Real }

    public enum ELogItem
    { Note, Error, Exception }

    public enum ETerminateCode
    { None, ReceivedTerminateCommand, NonAcknowledgement }

    public enum EDataSetMode
    { View, New, Modify }

    public enum ETestState
    {
        Stopped = -1,
        Testing = 0,
        Done = 1
    }
    #endregion

    #region EventHandler
    public delegate void EventVoidHandler(object sender);

    public delegate void EventBoolHandler(object sender, bool arg);

    public delegate void EventByteHandler(object sender, byte arg);

    public delegate void EventInt16Handler(object sender, Int16 arg);

    public delegate void EventInt32Handler(object sender, Int32 arg);

    public delegate void EventInt64Handler(object sender, Int64 arg);

    public delegate void EventFloatHandler(object sender, float arg);

    public delegate void EventDoubleHandler(object sender, double arg);
    #endregion

    class DataBookStateTypeFmt : IFormatProvider, ICustomFormatter
    {
        public DataBookStateTypeFmt()
        {
        }

        public object GetFormat(Type type)
        {
            return this;
        }

        public string Format(string formatString, object arg, IFormatProvider formatProvider)
        {
            int value = Convert.ToInt16(arg);
            string typeString = value.ToString();

            switch (value)
            {
                case -1:
                    typeString = "NG";
                    break;

                case 0:
                    typeString = "Testing";
                    break;

                case 1:
                    typeString = "OK";
                    break;
            }

            return typeString;
        }
    }

    class DataBookLineTypeFmt : IFormatProvider, ICustomFormatter
    {
        public DataBookLineTypeFmt()
        {
        }

        public object GetFormat(Type type)
        {
            return this;
        }

        public string Format(string formatString, object arg, IFormatProvider formatProvider)
        {
            int value = Convert.ToInt16(arg);

            return $"L{value+1}";
        }
    }

    public enum ECoefficient
    {
        [Description("Airflow")]
        Airflow,
        [Description("Cooling Capacity")]
        CoolingCapacity,
        [Description("Heating Capacity")]
        HeatingCapacity,
        [Description("Cooling H.L.K")]
        Cooling_HLK,
        [Description("Heating H.L.K")]
        Heating_HLK,
        [Description("Cooling H.L.K (Duct 1)")]
        Cooling_HLK_Duct1,
        [Description("Heating H.L.K (Duct 1)")]
        Heating_HLK_Duct1,
        [Description("Cooling H.L.K (Duct 2)")]
        Cooling_HLK_Duct2,
        [Description("Heating H.L.K (Duct 2)")]
        Heating_HLK_Duct2,
        [Description("Cooling H.L.K (Duct 3)")]
        Cooling_HLK_Duct3,
        [Description("Heating H.L.K (Duct 3)")]
        Heating_HLK_Duct3,
        [Description("Cooling H.L.K (Duct 4)")]
        Cooling_HLK_Duct4,
        [Description("Heating H.L.K (Duct 4)")]
        Heating_HLK_Duct4,
        [Description("Cooling H.L.K (Duct 5)")]
        Cooling_HLK_Duct5,
        [Description("Heating H.L.K (Duct 5)")]
        Heating_HLK_Duct5,
        [Description("Nozzle Diameter (1)")]
        Nozzle1,
        [Description("Nozzle Diameter (2)")]
        Nozzle2,
        [Description("Nozzle Diameter (3)")]
        Nozzle3,
        [Description("Nozzle Diameter (4)")]
        Nozzle4
    }

    public class CoefficientDataRow
    {
        public CoefficientDataRow()
        {
            Airflow = 0;
            CoolingCapacity = 0;
            HeatingCapacity = 0;
            Cooling_HLK = 0;
            Heating_HLK = 0;
            Cooling_HLK_Duct1 = 0;
            Heating_HLK_Duct1 = 0;
            Cooling_HLK_Duct2 = 0;
            Heating_HLK_Duct2 = 0;
            Cooling_HLK_Duct3 = 0;
            Heating_HLK_Duct3 = 0;
            Cooling_HLK_Duct4 = 0;
            Heating_HLK_Duct4 = 0;
            Cooling_HLK_Duct5 = 0;
            Heating_HLK_Duct5 = 0;
            Nozzle1 = 0;
            Nozzle2 = 0;
            Nozzle3 = 0;
            Nozzle4 = 0;
        }

        public float Airflow { get; set; }
        public float CoolingCapacity { get; set; }
        public float HeatingCapacity { get; set; }
        public float Cooling_HLK { get; set; }
        public float Heating_HLK { get; set; }
        public float Cooling_HLK_Duct1 { get; set; }
        public float Heating_HLK_Duct1 { get; set; }
        public float Cooling_HLK_Duct2 { get; set; }
        public float Heating_HLK_Duct2 { get; set; }
        public float Cooling_HLK_Duct3 { get; set; }
        public float Heating_HLK_Duct3 { get; set; }
        public float Cooling_HLK_Duct4 { get; set; }
        public float Heating_HLK_Duct4 { get; set; }
        public float Cooling_HLK_Duct5 { get; set; }
        public float Heating_HLK_Duct5 { get; set; }
        public float Nozzle1 { get; set; }
        public float Nozzle2 { get; set; }
        public float Nozzle3 { get; set; }
        public float Nozzle4 { get; set; }
    }

    public class CoefficientViewRow
    {
        public CoefficientViewRow(string name="", float id11=0, float id12=0, float id21=0, float id22=0)
        {
            Name = name;
            ID11 = id11;
            ID12 = id12;
            ID21 = id21;
            ID22 = id22;
        }

        public string Name { get; set; }
        public float ID11 { get; set; }
        public float ID12 { get; set; }
        public float ID21 { get; set; }
        public float ID22 { get; set; }
    }

    public class TestOptions
    {
        public TestOptions()
        {
            FixedAtmPressure = false;
            ForcedInteg = false;
            ExcelPath = @"..\..\Excel";
            AutoExcel = false;
            StoppedTestExcel = false;
            Indoor11 = false;
            Indoor12 = false;
            Indoor21 = false;
            Indoor22 = false;
            Indoor1TC = false;
            Indoor2TC = false;
            OutdoorTC = false;
        }

        public bool FixedAtmPressure { get; set; }
        public bool ForcedInteg { get; set; }
        public string ExcelPath { get; set; }
        public bool AutoExcel { get; set; }
        public bool StoppedTestExcel { get; set; }
        public bool Indoor11 { get; set; }
        public bool Indoor12 { get; set; }
        public bool Indoor21 { get; set; }
        public bool Indoor22 { get; set; }
        public bool Indoor1TC { get; set; }
        public bool Indoor2TC { get; set; }
        public bool OutdoorTC { get; set; }
    }

    public class TestSettings
    {
        public TestSettings(UlIniFile ini)
        {
            this.ini = ini;

            Options = new TestOptions();

            Coefficients = new List<CoefficientDataRow>();
            Coefficients.Add(new CoefficientDataRow());
            Coefficients.Add(new CoefficientDataRow());
            Coefficients.Add(new CoefficientDataRow());
            Coefficients.Add(new CoefficientDataRow());
        }

        private UlIniFile ini;

        public TestOptions Options { get; set; }
        public List<CoefficientDataRow> Coefficients { get; set; }

        public void Load()
        {
            string section = "Options";

            Options.FixedAtmPressure = ini.GetBoolean(section, "FixedAtmPressure");
            Options.ForcedInteg = ini.GetBoolean(section, "ForcedInteg");
            Options.ExcelPath = ini.GetString(section, "ExcelPath");
            Options.AutoExcel = ini.GetBoolean(section, "AutoExcel");
            Options.StoppedTestExcel = ini.GetBoolean(section, "StoppedTestExcel");
            Options.Indoor11 = ini.GetBoolean(section, "Indoor11");
            Options.Indoor12 = ini.GetBoolean(section, "Indoor12");
            Options.Indoor21 = ini.GetBoolean(section, "Indoor21");
            Options.Indoor22 = ini.GetBoolean(section, "Indoor22");
            Options.Indoor1TC = ini.GetBoolean(section, "Indoor1TC");
            Options.Indoor2TC = ini.GetBoolean(section, "Indoor2TC");
            Options.OutdoorTC = ini.GetBoolean(section, "OutdoorTC");

            string[] coeffSection = 
            { "Coefficient.ID11", "Coefficient.ID12", "Coefficient.ID21", "Coefficient.ID22" };

            for (int i=0; i<4; i++)
            {
                Coefficients[i].Airflow = (float)ini.GetDouble(coeffSection[i], "Airflow");
                Coefficients[i].CoolingCapacity = (float)ini.GetDouble(coeffSection[i], "CoolingCapacity");
                Coefficients[i].HeatingCapacity = (float)ini.GetDouble(coeffSection[i], "HeatingCapacity");
                Coefficients[i].Cooling_HLK = (float)ini.GetDouble(coeffSection[i], "Cooling_HLK");
                Coefficients[i].Heating_HLK = (float)ini.GetDouble(coeffSection[i], "Heating_HLK");
                Coefficients[i].Cooling_HLK_Duct1 = (float)ini.GetDouble(coeffSection[i], "Cooling_HLK_Duct1");
                Coefficients[i].Heating_HLK_Duct1 = (float)ini.GetDouble(coeffSection[i], "Heating_HLK_Duct1");
                Coefficients[i].Cooling_HLK_Duct2 = (float)ini.GetDouble(coeffSection[i], "Cooling_HLK_Duct2");
                Coefficients[i].Heating_HLK_Duct2 = (float)ini.GetDouble(coeffSection[i], "Heating_HLK_Duct2");
                Coefficients[i].Cooling_HLK_Duct3 = (float)ini.GetDouble(coeffSection[i], "Cooling_HLK_Duct3");
                Coefficients[i].Heating_HLK_Duct3 = (float)ini.GetDouble(coeffSection[i], "Heating_HLK_Duct3");
                Coefficients[i].Cooling_HLK_Duct4 = (float)ini.GetDouble(coeffSection[i], "Cooling_HLK_Duct4");
                Coefficients[i].Heating_HLK_Duct4 = (float)ini.GetDouble(coeffSection[i], "Heating_HLK_Duct4");
                Coefficients[i].Cooling_HLK_Duct5 = (float)ini.GetDouble(coeffSection[i], "Cooling_HLK_Duct5");
                Coefficients[i].Heating_HLK_Duct5 = (float)ini.GetDouble(coeffSection[i], "Heating_HLK_Duct5");
                Coefficients[i].Nozzle1 = (float)ini.GetDouble(coeffSection[i], "Nozzle1");
                Coefficients[i].Nozzle2 = (float)ini.GetDouble(coeffSection[i], "Nozzle2");
                Coefficients[i].Nozzle3 = (float)ini.GetDouble(coeffSection[i], "Nozzle3");
                Coefficients[i].Nozzle4 = (float)ini.GetDouble(coeffSection[i], "Nozzle4");
            }
        }
    }

    public class ChamberParams
    {
        public ChamberParams()
        {
            Indoor1Use = EIndoorUse.Indoor;
            Indoor1Mode1 = EIndoorMode.Cooling;
            Indoor1Duct1 = EIndoorDuct.N1;
            Indoor1Mode2 = EIndoorMode.Cooling;
            Indoor1Duct2 = EIndoorDuct.N1;

            Indoor2Use = EIndoorUse.Indoor;
            Indoor2Mode1 = EIndoorMode.Cooling;
            Indoor2Duct1 = EIndoorDuct.N1;
            Indoor2Mode2 = EIndoorMode.Cooling;
            Indoor2Duct2 = EIndoorDuct.N1;

            OutdoorUse = EOutdoorUse.Outdoor;
            OutdoorDpSensor = EEtcUse.Use;
            OutdoorAutoVolt = EEtcUse.Use;
        }

        public EIndoorUse Indoor1Use { get; set; }
        public EIndoorMode Indoor1Mode1 { get; set; }
        public EIndoorDuct Indoor1Duct1 { get; set; }
        public EIndoorMode Indoor1Mode2 { get; set; }
        public EIndoorDuct Indoor1Duct2 { get; set; }
        public EIndoorUse Indoor2Use { get; set; }
        public EIndoorMode Indoor2Mode1 { get; set; }
        public EIndoorDuct Indoor2Duct1 { get; set; }
        public EIndoorMode Indoor2Mode2 { get; set; }
        public EIndoorDuct Indoor2Duct2 { get; set; }
        public EOutdoorUse OutdoorUse { get; set; }
        public EEtcUse OutdoorDpSensor { get; set; }
        public EEtcUse OutdoorAutoVolt { get; set; }
    }

    public class YAxisRow
    {
        public YAxisRow(int recNo, int axisNo, bool active, EAxisAlign align, string name, 
            string desc, string unit, float visualMin, float visualMax, float wholeMin, float wholeMax)
        {
            RecNo = recNo;
            AxisNo = axisNo;
            Checked = active;
            Align = align;
            Name = name;
            Description = desc;
            Unit = unit;
            DescriptionUnit = $"{Description}({Unit})";
            VisualMin = visualMin;
            VisualMax = visualMax;
            WholeMin = wholeMin;
            WholeMax = wholeMax;
        }

        public int RecNo { get; set; }
        public int AxisNo { get; set; }
        public bool Checked { get; set; }
        public EAxisAlign Align { get; set; }
        public string Name { get; set; }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                DescriptionUnit = $"{description}({unit})";
            }
        }

        private string unit;
        public string Unit
        {
            get { return unit; }
            set
            {
                unit = value;
                DescriptionUnit = $"{description}({unit})";
            }
        }

        public string DescriptionUnit { get; set; }
        public float VisualMin { get; set; }
        public float VisualMax { get; set; }
        public float WholeMin { get; set; }
        public float WholeMax { get; set; }
    }

    public class SeriesRow
    {
        public SeriesRow(int recNo, bool active, string name,
            string value, string unitType, string unitFrom, Color color)
        {
            RecNo = recNo;
            Checked = active;
            Name = name;
            Value = value;
            CursorA = "0";
            CursorB = "0";
            Diff = "0";
            Min = "0";
            Max = "0";
            Avg = "0";
            UnitType = unitType;
            UnitFrom = unitFrom;
            Color = color;
        }

        public int RecNo { get; set; }
        public bool Checked { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string CursorA { get; set; }
        public string CursorB { get; set; }
        public string Diff { get; set; }
        public string Min { get; set; }
        public string Max { get; set; }
        public string Avg { get; set; }
        public string UnitType { get; set; }
        public string UnitFrom { get; set; }
        public Color Color { get; set; }
    }
}