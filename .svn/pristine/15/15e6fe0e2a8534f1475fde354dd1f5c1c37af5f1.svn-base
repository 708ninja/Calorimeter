using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Hnc.Calorimeter.Client
{
    #region enum
    public enum EMeasTotalRated
    {
        TotalCapacity,
        TotalPowerInput,
        TotalEER_COP,
        None1,
        TotalRatedCapacity,
        TotalCapacityRatio,
        TotalRatedPowerInput,
        TotalPowerInputRatio,
        TotalRatedEER_COP,
        TotalEER_COPRatio,
        TotalRatedCurrent,
        TotalCurrentRatio,
        None2,
        IDU_PowerInput,
        IDU_Voltage,
        IDU_Current,
        IDU_Frequency,
        IDU_PowerFactor,
        IDU_IntegPowerInput,
        IDU_IntegTime,
        None3,
        ODU_PowerInput,
        ODU_Voltage,
        ODU_Current,
        ODU_Frequency,
        ODU_PowerFactor,
        ODU_IntegPowerInput,
        ODU_IntegTime
    }

    public enum EMeasRunState
    {
        Condition,
        RunningStep,
        ElapsedTime,
        TotalElapsed,
        None1,
        Preparation,
        Judgement,
        Integration,
        None2,
        NoOfSteady,
        Repeat,
        Schedule
    }

    public enum EMeasAirSide
    {
        Capacity,
        CapacityRatio,
        SensibleHeat,
        LatentHeat,
        SensibleHeatRatio,
        HeatLeakage,
        DrainWeight,
        None1,
        EnteringDB,
        EnteringWB,
        EnteringRH,
        LeavingDB,
        LeavingWB,
        LeavingRH,
        None2,
        EnteringEnthalpy,
        LeavingEnthalpy,
        EnteringHumidityRatio,
        LeavingHumidityRatio,
        LeavingSpecificHeat,
        LeavingSpecificVolume,
        None3,
        AirFlowLev,
        AirVelocityLev,
        StaticPressure,
        NozzleDiffPressure,
        AtmosphericPressure,
        NozzleInletTemp,
    }

    public enum EMeasNozzle
    {
        Nozzle1,
        Nozzle2,
        Nozzle3,
        Nozzle4
    }

    public enum EMeasOutside
    {
        EnteringDB,
        EnteringWB,
        EnteringRH,
        EnteringDP,
        None1,
        SatDisTemp1,
        SatSucTemp1,
        SatSubCooling1,
        SuperHeat1,
        SatDisTemp2,
        SatSucTemp2,
        SatSubCooling2,
        SuperHeat2
    }

    public enum EMeasMethod
    {
        Method,
        ScanTime
    }

    public enum EMeasNote
    {
        Company,
        TestName,
        TestNo,
        Observer,
        None1,
        Maker,
        Model1,
        SerialNo1,
        Model2,
        SerialNo2,
        Model3,
        SerialNo3,
        ExpDevice,
        Refrigerant,
        RefCharge,
        Memo
    }

    public enum EMeasRated
    {
        Capacity,
        PowerInput,
        EER_COP,
        None1,
        IDU_Voltage,
        IDU_Current,
        IDU_Frequency,
        IDU_SelectedPM,
        ODU_SelectedPM,
        ODU_Phase
    }

    public enum EMeasIndoor
    {
        Use,
        Mode,
        Duct,
        DB,
        WB
    }

    public enum EMeasOutdoor
    {
        Use,
        DPSensor,
        AutoVoltage,
        DB,
        WB
    }
    #endregion

    #region TestMeasure
    public class TestMeasure
    {
        public TestMeasure(TestValue value)
        {
            Control = null;

            TotalRateds = new List<MeasureRow>();
            TotalRateds.Add(new MeasureRow(value.Calcurated["Total.Capacity"], "Total Capacity"));
            TotalRateds.Add(new MeasureRow(value.Calcurated["Total.Power"], "Total Power Input"));
            TotalRateds.Add(new MeasureRow(value.Calcurated["Total.EER_COP"], "EER/COP"));
            TotalRateds.Add(new MeasureRow(null));
            TotalRateds.Add(new MeasureRow(null, "Rated Capacity"));
            TotalRateds.Add(new MeasureRow(null, "Capacity Ratio"));
            TotalRateds.Add(new MeasureRow(null, "Rated Power Input"));
            TotalRateds.Add(new MeasureRow(null, "Power Input Ratio"));
            TotalRateds.Add(new MeasureRow(null, "Rated EER/COP"));
            TotalRateds.Add(new MeasureRow(null, "EER/COP Ratio"));
            TotalRateds.Add(new MeasureRow(null, "Rated Current"));
            TotalRateds.Add(new MeasureRow(null, "Current Ratio"));
            TotalRateds.Add(new MeasureRow(null));
            TotalRateds.Add(new MeasureRow(null, "Power Input(IDU)"));
            TotalRateds.Add(new MeasureRow(null, "Voltage(IDU)"));
            TotalRateds.Add(new MeasureRow(null, "Current(IDU)"));
            TotalRateds.Add(new MeasureRow(null, "Frequency(IDU)"));
            TotalRateds.Add(new MeasureRow(null, "Power Factor(IDU)"));
            TotalRateds.Add(new MeasureRow(null, "Integ Power(IDU)"));
            TotalRateds.Add(new MeasureRow(null, "Integ Time(IDU)"));
            TotalRateds.Add(new MeasureRow(null));
            TotalRateds.Add(new MeasureRow(null, "Power Input(ODU)"));
            TotalRateds.Add(new MeasureRow(null, "Voltage(ODU)"));
            TotalRateds.Add(new MeasureRow(null, "Current(ODU)"));
            TotalRateds.Add(new MeasureRow(null, "Frequency(ODU)"));
            TotalRateds.Add(new MeasureRow(null, "Power Factor(ODU)"));
            TotalRateds.Add(new MeasureRow(null, "Integ Power(ODU)"));
            TotalRateds.Add(new MeasureRow(null, "Integ Time(ODU)"));

            RunStates = new List<MeasureRow>();
            RunStates.Add(new MeasureRow(null, "Condition"));
            RunStates.Add(new MeasureRow(null, "Running Step"));
            RunStates.Add(new MeasureRow(null, "Elapsed Time"));
            RunStates.Add(new MeasureRow(null, "Total Elapsed"));
            RunStates.Add(new MeasureRow(null));
            RunStates.Add(new MeasureRow(null, "Preparation", "00:00:00:00 / 00:00:00:00"));
            RunStates.Add(new MeasureRow(null, "Judgement", "00:00:00:00 / 00:00:00:00"));
            RunStates.Add(new MeasureRow(null, "Integration", "00:00:00:00 / 00:00:00:00"));
            RunStates.Add(new MeasureRow(null));
            RunStates.Add(new MeasureRow(null, "No of Steady"));
            RunStates.Add(new MeasureRow(null, "Repeat"));
            RunStates.Add(new MeasureRow(null, "Schedule"));

            AirSides = new List<MeasureAirSideRow>();
            AirSides.Add(new MeasureAirSideRow("Capacity", value.Calcurated["ID11.Capacity"], value.Calcurated["ID12.Capacity"], value.Calcurated["ID21.Capacity"], value.Calcurated["ID22.Capacity"]));
            AirSides.Add(new MeasureAirSideRow("Capacity Ratio", value.Calcurated["ID11.Capacity.Ratio"], value.Calcurated["ID12.Capacity.Ratio"], value.Calcurated["ID21.Capacity.Ratio"], value.Calcurated["ID22.Capacity.Ratio"]));
            AirSides.Add(new MeasureAirSideRow("Sensible Heat", value.Calcurated["ID11.Sensible.Heat"], value.Calcurated["ID12.Sensible.Heat"], value.Calcurated["ID21.Sensible.Heat"], value.Calcurated["ID22.Sensible.Heat"]));
            AirSides.Add(new MeasureAirSideRow("Latent Heat", value.Calcurated["ID11.Latent.Heat"], value.Calcurated["ID12.Latent.Heat"], value.Calcurated["ID21.Latent.Heat"], value.Calcurated["ID22.Latent.Heat"]));
            AirSides.Add(new MeasureAirSideRow("Sensible Heat Ratio", value.Calcurated["ID11.Sensible.Heat.Ratio"], value.Calcurated["ID12.Sensible.Heat.Ratio"], value.Calcurated["ID21.Sensible.Heat.Ratio"], value.Calcurated["ID22.Sensible.Heat.Ratio"]));
            AirSides.Add(new MeasureAirSideRow("Heat Leakage", value.Calcurated["ID11.Heat.Leakage"], value.Calcurated["ID12.Heat.Leakage"], value.Calcurated["ID21.Heat.Leakage"], value.Calcurated["ID22.Heat.Leakage"]));
            AirSides.Add(new MeasureAirSideRow("Drain Weight", value.Calcurated["ID11.Drain.Weight"], value.Calcurated["ID12.Drain.Weight"], value.Calcurated["ID21.Drain.Weight"], value.Calcurated["ID22.Drain.Weight"]));
            AirSides.Add(new MeasureAirSideRow("", null, null, null, null, true));
            AirSides.Add(new MeasureAirSideRow("Entering DB", value.Measured["ID11.Entering.DB"], value.Measured["ID12.Entering.DB"], value.Measured["ID21.Entering.DB"], value.Measured["ID22.Entering.DB"]));
            AirSides.Add(new MeasureAirSideRow("Entering WB", value.Measured["ID11.Entering.WB"], value.Measured["ID12.Entering.WB"], value.Measured["ID21.Entering.WB"], value.Measured["ID22.Entering.WB"]));
            AirSides.Add(new MeasureAirSideRow("Entering RH", value.Calcurated["ID11.Entering.RH"], value.Calcurated["ID12.Entering.RH"], value.Calcurated["ID21.Entering.RH"], value.Calcurated["ID22.Entering.RH"]));
            AirSides.Add(new MeasureAirSideRow("Leaving DB", value.Measured["ID11.Leaving.DB"], value.Measured["ID12.Leaving.DB"], value.Measured["ID21.Leaving.DB"], value.Measured["ID22.Leaving.DB"]));
            AirSides.Add(new MeasureAirSideRow("Leaving WB", value.Measured["ID11.Leaving.WB"], value.Measured["ID12.Leaving.WB"], value.Measured["ID21.Leaving.WB"], value.Measured["ID22.Leaving.WB"]));
            AirSides.Add(new MeasureAirSideRow("Leaving RH", value.Calcurated["ID11.Leaving.RH"], value.Calcurated["ID12.Leaving.RH"], value.Calcurated["ID21.Leaving.RH"], value.Calcurated["ID22.Leaving.RH"]));
            AirSides.Add(new MeasureAirSideRow("", null, null, null, null, true));
            AirSides.Add(new MeasureAirSideRow("Entering Enthalpy", value.Calcurated["ID11.Entering.Enthalpy"], value.Calcurated["ID12.Entering.Enthalpy"], value.Calcurated["ID21.Entering.Enthalpy"], value.Calcurated["ID22.Entering.Enthalpy"]));
            AirSides.Add(new MeasureAirSideRow("Leaving Enthalpy", value.Calcurated["ID11.Leaving.Enthalpy"], value.Calcurated["ID12.Leaving.Enthalpy"], value.Calcurated["ID21.Leaving.Enthalpy"], value.Calcurated["ID22.Leaving.Enthalpy"]));
            AirSides.Add(new MeasureAirSideRow("Entering Humidity Ratio", value.Calcurated["ID11.Entering.Humidity.Ratio"], value.Calcurated["ID12.Entering.Humidity.Ratio"], value.Calcurated["ID21.Entering.Humidity.Ratio"], value.Calcurated["ID22.Entering.Humidity.Ratio"]));
            AirSides.Add(new MeasureAirSideRow("Leaving Humidity Ratio", value.Calcurated["ID11.Leaving.Humidity.Ratio"], value.Calcurated["ID12.Leaving.Humidity.Ratio"], value.Calcurated["ID21.Leaving.Humidity.Ratio"], value.Calcurated["ID22.Leaving.Humidity.Ratio"]));
            AirSides.Add(new MeasureAirSideRow("Leaving Specific Heat", value.Calcurated["ID11.Leaving.Specific.Heat"], value.Calcurated["ID12.Leaving.Specific.Heat"], value.Calcurated["ID21.Leaving.Specific.Heat"], value.Calcurated["ID22.Leaving.Specific.Heat"]));
            AirSides.Add(new MeasureAirSideRow("Leaving Specific Volume", value.Calcurated["ID11.Leaving.Specific.Volume"], value.Calcurated["ID12.Leaving.Specific.Volume"], value.Calcurated["ID21.Leaving.Specific.Volume"], value.Calcurated["ID22.Leaving.Specific.Volume"]));
            AirSides.Add(new MeasureAirSideRow("", null, null, null, null, true));
            AirSides.Add(new MeasureAirSideRow("Air Flow [Lev]", value.Calcurated["ID11.Air.Flow.Lev"], value.Calcurated["ID12.Air.Flow.Lev"], value.Calcurated["ID21.Air.Flow.Lev"], value.Calcurated["ID22.Air.Flow.Lev"]));
            AirSides.Add(new MeasureAirSideRow("Air Velocity [Lev]", value.Calcurated["ID11.Air.Velocity.Lev"], value.Calcurated["ID12.Air.Velocity.Lev"], value.Calcurated["ID21.Air.Velocity.Lev"], value.Calcurated["ID22.Air.Velocity.Lev"]));
            AirSides.Add(new MeasureAirSideRow("Static Pressure", value.Measured["ID11.Static.Pressure"], value.Measured["ID12.Static.Pressure"], value.Measured["ID21.Static.Pressure"], value.Measured["ID22.Static.Pressure"]));
            AirSides.Add(new MeasureAirSideRow("Nozzle Diff. Pressure", value.Measured["ID11.Nozzle.Diff.Pressure"], value.Measured["ID12.Nozzle.Diff.Pressure"], value.Measured["ID21.Nozzle.Diff.Pressure"], value.Measured["ID22.Nozzle.Diff.Pressure"]));
            AirSides.Add(new MeasureAirSideRow("Atmospheric Pressure", value.Measured["ID1.Atm.Pressure"], value.Measured["ID1.Atm.Pressure"], value.Measured["ID2.Atm.Pressure"], value.Measured["ID2.Atm.Pressure"]));
            AirSides.Add(new MeasureAirSideRow("Nozzle Inlet Temp.", value.Measured["ID11.Nozzle.Inlet.Temp"], value.Measured["ID12.Nozzle.Inlet.Temp"], value.Measured["ID21.Nozzle.Inlet.Temp"], value.Measured["ID22.Nozzle.Inlet.Temp"]));

            List<CoefficientDataRow> coeffs = Resource.Settings.Coefficients;
            Nozzles = new List<MeasureNozzleRow>();
            Nozzles.Add(new MeasureNozzleRow("Nozzle 1", coeffs[0].Nozzle1, value.Calcurated["ID11.Nozzle.1"], coeffs[0].Nozzle2, value.Calcurated["ID12.Nozzle.1"], coeffs[0].Nozzle3, value.Calcurated["ID21.Nozzle.1"], coeffs[0].Nozzle4, value.Calcurated["ID22.Nozzle.1"]));
            Nozzles.Add(new MeasureNozzleRow("Nozzle 2", coeffs[1].Nozzle1, value.Calcurated["ID11.Nozzle.2"], coeffs[1].Nozzle2, value.Calcurated["ID12.Nozzle.2"], coeffs[1].Nozzle3, value.Calcurated["ID21.Nozzle.2"], coeffs[1].Nozzle4, value.Calcurated["ID22.Nozzle.2"]));
            Nozzles.Add(new MeasureNozzleRow("Nozzle 3", coeffs[2].Nozzle1, value.Calcurated["ID11.Nozzle.3"], coeffs[2].Nozzle2, value.Calcurated["ID12.Nozzle.3"], coeffs[2].Nozzle3, value.Calcurated["ID21.Nozzle.3"], coeffs[2].Nozzle4, value.Calcurated["ID22.Nozzle.3"]));
            Nozzles.Add(new MeasureNozzleRow("Nozzle 4", coeffs[3].Nozzle1, value.Calcurated["ID11.Nozzle.4"], coeffs[3].Nozzle2, value.Calcurated["ID12.Nozzle.4"], coeffs[3].Nozzle3, value.Calcurated["ID21.Nozzle.4"], coeffs[3].Nozzle4, value.Calcurated["ID22.Nozzle.4"]));

            Outsides = new List<MeasureRow>();
            Outsides.Add(new MeasureRow(value.Measured["OD.Entering.DB"], "Entering DB"));
            Outsides.Add(new MeasureRow(value.Measured["OD.Entering.WB"], "Entering WB"));
            Outsides.Add(new MeasureRow(value.Calcurated["OD.Entering.RH"], "Entering RH"));
            Outsides.Add(new MeasureRow(value.Measured["OD.Entering.DP"], "Entering DP"));
            Outsides.Add(new MeasureRow(null));
            Outsides.Add(new MeasureRow(value.Calcurated["OD.Sat.Dis.Temp1"], "Sat. Dis. Temp(1)"));
            Outsides.Add(new MeasureRow(value.Calcurated["OD.Sat.Suc.Temp1"], "Sat. Suc. Temp(1)"));
            Outsides.Add(new MeasureRow(value.Calcurated["OD.Sub.Cooling1"], "Sub-Cooling(1)"));
            Outsides.Add(new MeasureRow(value.Calcurated["OD.Super.Heat1"], "Superheat(1)"));
            Outsides.Add(new MeasureRow(value.Calcurated["OD.Sat.Dis.Temp2"], "Sat. Dis. Temp(2)"));
            Outsides.Add(new MeasureRow(value.Calcurated["OD.Sat.Suc.Temp2"], "Sat. Suc. Temp(2)"));
            Outsides.Add(new MeasureRow(value.Calcurated["OD.Sub.Cooling2"], "Sub-Cooling(2)"));
            Outsides.Add(new MeasureRow(value.Calcurated["OD.Super.Heat2"], "Superheat(2)"));

            Methods = new List<MeasureRow>();
            Methods.Add(new MeasureRow(null, "Method", "3min * 3times"));
            Methods.Add(new MeasureRow(null, "Scan Time", "3 sec"));

            Notes = new List<MeasureRow>();
            Notes.Add(new MeasureRow(null, "Company"));
            Notes.Add(new MeasureRow(null, "Test Name"));
            Notes.Add(new MeasureRow(null, "Test No"));
            Notes.Add(new MeasureRow(null, "Observer"));
            Notes.Add(new MeasureRow(null));
            Notes.Add(new MeasureRow(null, "Maker"));
            Notes.Add(new MeasureRow(null, "Model(1)"));
            Notes.Add(new MeasureRow(null, "Serial No(1)"));
            Notes.Add(new MeasureRow(null, "Model(2)"));
            Notes.Add(new MeasureRow(null, "Serial No(2)"));
            Notes.Add(new MeasureRow(null, "Model(3)"));
            Notes.Add(new MeasureRow(null, "Serial No(3)"));
            Notes.Add(new MeasureRow(null, "Exp. Device"));
            Notes.Add(new MeasureRow(null, "Refrigerant"));
            Notes.Add(new MeasureRow(null, "Ref. Charge"));
            Notes.Add(new MeasureRow(null, "Memo"));

            Rateds = new List<MeasureRow>();
            Rateds.Add(new MeasureRow(null, "Rated Capacity"));
            Rateds.Add(new MeasureRow(null, "Rated Power Input"));
            Rateds.Add(new MeasureRow(null, "Rated EER/COP"));
            Rateds.Add(new MeasureRow(null));
            Rateds.Add(new MeasureRow(null, "Voltage"));
            Rateds.Add(new MeasureRow(null, "Current"));
            Rateds.Add(new MeasureRow(null, "Frequency"));
            Rateds.Add(new MeasureRow(null, "Selected PM(IDU)"));
            Rateds.Add(new MeasureRow(null, "Selected PM(ODU)"));
            Rateds.Add(new MeasureRow(null, "Phase(ODU)"));

            Indoors11 = new List<MeasureRow>();
            Indoors11.Add(new MeasureRow(null, "Use", "Indoor"));
            Indoors11.Add(new MeasureRow(null, "Mode", "Use"));
            Indoors11.Add(new MeasureRow(null, "Duct", "Use"));
            Indoors11.Add(new MeasureRow(null, "DB", "0.0"));
            Indoors11.Add(new MeasureRow(null, "WB", "0.0"));

            Indoors12 = new List<MeasureRow>();
            Indoors12.Add(new MeasureRow(null, "Use", "Indoor"));
            Indoors12.Add(new MeasureRow(null, "Mode", "Use"));
            Indoors12.Add(new MeasureRow(null, "Duct", "Use"));
            Indoors12.Add(new MeasureRow(null, "DB", "0.0"));
            Indoors12.Add(new MeasureRow(null, "WB", "0.0"));

            Indoors21 = new List<MeasureRow>();
            Indoors21.Add(new MeasureRow(null, "Use", "Indoor"));
            Indoors21.Add(new MeasureRow(null, "Mode", "Use"));
            Indoors21.Add(new MeasureRow(null, "Duct", "Use"));
            Indoors21.Add(new MeasureRow(null, "DB", "0.0"));
            Indoors21.Add(new MeasureRow(null, "WB", "0.0"));

            Indoors22 = new List<MeasureRow>();
            Indoors22.Add(new MeasureRow(null, "Use", "Indoor"));
            Indoors22.Add(new MeasureRow(null, "Mode", "Use"));
            Indoors22.Add(new MeasureRow(null, "Duct", "Use"));
            Indoors22.Add(new MeasureRow(null, "DB", "0.0"));
            Indoors22.Add(new MeasureRow(null, "WB", "0.0"));

            Outdoors = new List<MeasureRow>();
            Outdoors.Add(new MeasureRow(null, "Use", "Outdoor"));
            Outdoors.Add(new MeasureRow(null, "DP Sensor", "Use"));
            Outdoors.Add(new MeasureRow(null, "Auto Voltage", "Use"));
            Outdoors.Add(new MeasureRow(null, "DB", "0.0"));
            Outdoors.Add(new MeasureRow(null, "WB", "0.0"));

            Pressures = new List<MeasureRow>();
            for (int i = 0; i < Resource.Client.Devices.Recorder.PressureLength; i++)
            {
                Pressures.Add(new MeasureRow(value.Measured[$"Pressure.{i + 1}"], "", "", i + 1));
            }

            int count = Resource.Client.Devices.Recorder.ThermocoupleLength / 3;

            IndoorTC1 = new List<MeasureRow>();
            for (int i = 0; i < count; i++)
            {
                IndoorTC1.Add(new MeasureRow(value.Measured[$"ID1.TC.{i + 1:d3}"], "", "", i + 1));
            }

            IndoorTC2 = new List<MeasureRow>();
            for (int i = 0; i < count; i++)
            {
                IndoorTC2.Add(new MeasureRow(value.Measured[$"ID2.TC.{i + 1:d3}"], "", "", i + 1));
            }

            OutdoorTC = new List<MeasureRow>();
            for (int i = 0; i < count; i++)
            {
                OutdoorTC.Add(new MeasureRow(value.Measured[$"OD.TC.{i + 1:d3}"], "", "", i + 1));
            }
        }

        public CtrlTestMeas Control { get; set; }
        public List<MeasureRow> TotalRateds { get; set; }
        public List<MeasureRow> RunStates { get; set; }
        public List<MeasureAirSideRow> AirSides { get; set; }
        public List<MeasureNozzleRow> Nozzles { get; set; }
        public List<MeasureRow> Outsides { get; set; }
        public List<MeasureRow> Methods { get; set; }
        public List<MeasureRow> Notes { get; set; }
        public List<MeasureRow> Rateds { get; set; }
        public List<MeasureRow> Indoors11 { get; set; }
        public List<MeasureRow> Indoors12 { get; set; }
        public List<MeasureRow> Indoors21 { get; set; }
        public List<MeasureRow> Indoors22 { get; set; }
        public List<MeasureRow> Outdoors { get; set; }
        public List<MeasureRow> IndoorTC1 { get; set; }
        public List<MeasureRow> IndoorTC2 { get; set; }
        public List<MeasureRow> OutdoorTC { get; set; }
        public List<MeasureRow> Pressures { get; set; }
        public Dictionary<string, ValueRow> GraphRows { get; set; }
    }
    #endregion

    #region MeasureRow
    public class MeasureRow
    {
        public MeasureRow(ValueRow row, string head = "", string strValue = "", int no = 0, int recNo = 0)
        {
            this.Row = row;
            this.head = head;
            this.strValue = strValue;
            this.No = no;
            this.RecNo = recNo;
            this.state = EValueState.None;
        }

        private string head;

        public int RecNo { get; set; }

        public int No { get; }

        public ValueRow Row { get; set; }

        public string Name
        {
            get
            {
                if (head.ToLower() != "none") return head;
                if (Row == null) return string.Empty;

                return Row?.Name;
            }
            set
            {
                head = value;
            }
        }

        private string strValue;
        public string Value
        {
            get
            {
                if (string.IsNullOrWhiteSpace(strValue) == false) return strValue;
                if (Row == null) return string.Empty;

                return Row.StringValue;
            }
            set
            {
                strValue = value;
            }
        }

        public string Format
        {
            get
            {
                return Row?.Format;
            }
        }

        private string unit;
        public string Unit
        {
            get
            {
                if (string.IsNullOrWhiteSpace(unit) == false) return unit;
                if (Row == null) return string.Empty;

                return Row.Unit.ToDescription;
            }
            set
            {
                unit = value;
            }
        }

        private EValueState state;
        public EValueState State
        {
            get
            {
                if (Value == "-") return EValueState.None;
                if (Row != null) return Row.State;

                return state;
            }
            set
            {
                state = value;
            }
        }
    }
    #endregion

    #region MeasureAirSideRow
    public class MeasureAirSideRow
    {
        public MeasureAirSideRow(string name, ValueRow id11Row,
            ValueRow id12Row, ValueRow id21Row, ValueRow id22Row, bool empty = false)
        {
            this.Name = name;
            this.ID11Row = id11Row;
            this.ID12Row = id12Row;
            this.ID21Row = id21Row;
            this.ID22Row = id22Row;
            this.empty = empty;

            this.Indoor11Enabled = true;
            this.Indoor12Enabled = true;
            this.Indoor21Enabled = true;
            this.Indoor22Enabled = true;
        }

        private bool empty;

        private string name;
        public string Name
        {
            get
            {
                if (empty == true) return "";
                return name;
            }
            private set
            {
                name = value;
            }
        }

        public ValueRow ID11Row;
        public string Indoor11
        {
            get
            {
                if (empty == true) return "";
                if (ID11Row == null) return "-";
                if (Indoor11Enabled == false) return "-";

                return ID11Row.StringValue;
            }
        }

        public EValueState Indoor11State
        {
            get
            {
                if (Indoor11Enabled == false) return EValueState.None;

                return (ID11Row == null) ? EValueState.None : ID11Row.State;
            }
        }

        public bool Indoor11Enabled { get; set; }

        public ValueRow ID12Row;
        public string Indoor12
        {
            get
            {
                if (empty == true) return "";
                if (ID12Row == null) return "-";
                if (Indoor12Enabled == false) return "-";

                return ID12Row.StringValue;
            }
        }

        public EValueState Indoor12State
        {
            get
            {
                if (Indoor12Enabled == false) return EValueState.None;

                return (ID12Row == null) ? EValueState.None : ID12Row.State;
            }
        }

        public bool Indoor12Enabled { get; set; }

        public ValueRow ID21Row;
        public string Indoor21
        {
            get
            {
                if (empty == true) return "";
                if (ID21Row == null) return "-";
                if (Indoor21Enabled == false) return "-";

                return ID21Row.StringValue;
            }
        }

        public EValueState Indoor21State
        {
            get
            {
                if (Indoor21Enabled == false) return EValueState.None;

                return (ID21Row == null) ? EValueState.None : ID21Row.State;
            }
        }

        public bool Indoor21Enabled { get; set; }

        public ValueRow ID22Row;
        public string Indoor22
        {
            get
            {
                if (empty == true) return "";
                if (ID22Row == null) return "-";
                if (Indoor22Enabled == false) return "-";

                return ID22Row.StringValue;
            }
        }

        public EValueState Indoor22State
        {
            get
            {
                if (Indoor22Enabled == false) return EValueState.None;

                return (ID22Row == null) ? EValueState.None : ID22Row.State;
            }
        }

        public bool Indoor22Enabled { get; set; }

        public string Format
        {
            get
            {
                if (empty == true) return "";
                return ID11Row.Format;
            }
        }

        public string Unit
        {
            get
            {
                if (empty == true) return "";

                string unit = "-";
                if (ID11Row != null) unit = ID11Row.Unit.ToDescription;
                else if (ID12Row != null) unit = ID12Row.Unit.ToDescription;
                else if (ID21Row != null) unit = ID21Row.Unit.ToDescription;
                else if (ID22Row != null) unit = ID22Row.Unit.ToDescription;

                return unit;
            }
        }
    }
    #endregion

    #region MeasureNozzleRow
    public class MeasureNozzleRow
    {
        public MeasureNozzleRow(string name,
            float id11Diameter, ValueRow id11Row,
            float id12Diameter, ValueRow id12Row,
            float id21Diameter, ValueRow id21Row,
            float id22Diameter, ValueRow id22Row)
        {
            Name = name;

            this.id11Diameter = id11Diameter;
            this.id12Diameter = id12Diameter;
            this.id21Diameter = id21Diameter;
            this.id22Diameter = id22Diameter;

            this.ID11Row = id11Row;
            this.ID12Row = id12Row;
            this.ID21Row = id21Row;
            this.ID22Row = id22Row;

            this.ID11Enabled = true;
            this.ID12Enabled = true;
            this.ID21Enabled = true;
            this.ID22Enabled = true;
        }

        public string Name { get; set; }

        public void SetDiameter(float id11, float id12, float id21, float id22)
        {
            this.id11Diameter = id11;
            this.id12Diameter = id12;
            this.id21Diameter = id21;
            this.id22Diameter = id22;
        }

        private float id11Diameter;
        public string ID11Diameter
        {
            get
            {
                if (ID11Enabled == false) return "-";

                return $"{id11Diameter}mm";
            }
        }
        public ValueRow ID11Row { get; set; }
        public int ID11State
        {
            get
            {
                if (ID11Enabled == false) return -1;

                return (ID11Row.Raw < 0.1) ? 0 : 1;
            }
        }
        public bool ID11Enabled { get; set; }

        private float id12Diameter;
        public string ID12Diameter
        {
            get
            {
                if (ID12Enabled == false) return "-";

                return $"{id12Diameter}mm";
            }
        }
        public ValueRow ID12Row { get; set; }
        public int ID12State
        {
            get
            {
                if (ID12Enabled == false) return -1;

                return (ID12Row.Raw < 0.1) ? 0 : 1;
            }
        }
        public bool ID12Enabled { get; set; }

        private float id21Diameter;
        public string ID21Diameter
        {
            get
            {
                if (ID21Enabled == false) return "-";

                return $"{id21Diameter}mm";
            }
        }
        public ValueRow ID21Row { get; set; }
        public int ID21State
        {
            get
            {
                if (ID21Enabled == false) return -1;

                return (ID21Row.Raw < 0.1) ? 0 : 1;
            }
        }
        public bool ID21Enabled { get; set; }

        private float id22Diameter;
        public string ID22Diameter
        {
            get
            {
                if (ID22Enabled == false) return "-";

                return $"{id22Diameter}mm";
            }
        }
        public ValueRow ID22Row { get; set; }
        public int ID22State
        {
            get
            {
                if (ID22Enabled == false) return -1;

                return (ID22Row.Raw < 0.1) ? 0 : 1;
            }
        }
        public bool ID22Enabled { get; set; }
    }
    #endregion

    #region GraphSeriesRow
    public class GraphSeriesRow
    {
        public GraphSeriesRow(bool active, Color color, string name, string value, string unit)
        {
            Checked = active;
            Color = color;
            Name = name;
            Value = value;
            Unit = unit;
        }

        public bool Checked { get; set; }
        public Color Color { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Unit { get; set; }
    }
    #endregion
}
