﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Ulee.Threading;
using Ulee.Device.Connection.Yokogawa;
using Ulee.Utils;

namespace Hnc.Calorimeter.Client
{
    #region enums
    public enum ETestButtonState
    {
        Started,
        Paused,
        Stopped
    }

    public enum ETestMode
    {
        [Description("Cooling")]
        Cooling,
        [Description("Heating")]
        Heating
    }

    public enum EValueState
    {
        None,
        Ok,
        Ng
    }

    public enum EIndoorUse
    {
        [Description("Indoor")]
        Indoor,
        [Description("Not Used")]
        NotUsed
    }

    public enum EIndoorMode
    {
        [Description("Cooling")]
        Cooling,
        [Description("Heating")]
        Heating,
        [Description("Not Used")]
        NotUsed
    }

    public enum EIndoorDuct
    {
        [Description("1")]
        N1,
        [Description("2")]
        N2,
        [Description("3")]
        N3,
        [Description("4")]
        N4,
        [Description("5")]
        N5,
        [Description("Not Used")]
        NotUsed
    }

    public enum EOutdoorUse
    {
        [Description("Outdoor")]
        Outdoor,
        [Description("Not Used")]
        NotUsed
    }

    public enum EEtcUse
    {
        [Description("Use")]
        Use,
        [Description("Not Used")]
        NotUsed
    }

    public enum EAxisAlign
    {
        Left,
        Right
    }
    #endregion

    #region TestContext
    public class TestContext : UlThread
    {
        public TestContext(int handle, IntPtr wndHandle) : base(false)
        {
            TestThread = null;
            State = ETestButtonState.Stopped;

            this.Handle = handle;
            this.WndHandle = wndHandle;

            DB = Resource.TestDB[handle];
            Value = new TestValue();
            Measure = new TestMeasure(Value);
            Condition = new TestCondition(Value);
            Report = new TestReport(this);
        }

        private const long csInvalidTicks = 1000;
        private const float csMinimumTemp = -99.9f;
        private const float csLimitedTemp = -300.0f;

        public int Handle { get; set; }
        public IntPtr WndHandle { get; set; }
        public CalorimeterTestThread TestThread { get; private set; }
        public CalorimeterTestDatabase DB { get; private set;}
        public ETestButtonState State { get; set; }
        public TestCondition Condition { get; set; }
        public TestMeasure Measure { get; set; }
        public TestValue Value { get; set; }
        public TestReport Report { get; set; }

        public int Index { get; set; }

        protected override void Execute()
        {
            long prevTicks = ElapsedMilliseconds;

            while (Terminated == false)
            {
                if (IsTimeoutMilliseconds(prevTicks, csInvalidTicks) == true)
                {
                    prevTicks += csInvalidTicks;
                    DoMeasureCalcurateValues();
                }

                Yield();
            }
        }

        private void DoMeasureCalcurateValues()
        {
            Value.Lock();

            try
            {
                LoadMeasuredValues();
                Calcurate();
            }
            finally
            {
                Value.Unlock();
            }
        }

        public bool IsTestThreadNull { get { return (TestThread == null) ? true : false; } }

        public CalorimeterTestThread TestCreate()
        {
            TestThread = new CalorimeterTestThread(this);

            return TestThread;
        }

        public void TestStart()
        {
            if (TestThread != null)
            {
                TestThread.Start();
            }
        }

        public void TestSuspend()
        {
            if (TestThread != null)
            {
                TestThread.Suspend();
            }
        }

        public void TestResume()
        {
            if (TestThread != null)
            {
                TestThread.Resume();
            }
        }

        public void TestTerminate(ETestMessage msg)
        {
            if (TestThread != null)
            {
                TestThread.Terminate((int)msg, false);
            }
        }

        public void TestReset()
        {
            Index = 0;
            Resource.BusySets[Handle] = false;
            TestThread = null;
        }

        public void Initialize()
        {
            List<ConditionRated> rateds = null;
            ConditionSchedule sch = Condition.Schedules[Index];

            if (sch.IndoorMode == EIndoorMode.NotUsed)
            {
                Measure.TotalRateds[(int)EMeasTotalRated.TotalCapacity].Row = null;
                Measure.TotalRateds[(int)EMeasTotalRated.TotalPowerInput].Row = null;
                Measure.TotalRateds[(int)EMeasTotalRated.TotalEER_COP].Row = null;

                Measure.TotalRateds[(int)EMeasTotalRated.TotalRatedCapacity].Row = null;
                Measure.TotalRateds[(int)EMeasTotalRated.TotalCapacityRatio].Row = null;
                Measure.TotalRateds[(int)EMeasTotalRated.TotalRatedPowerInput].Row = null;
                Measure.TotalRateds[(int)EMeasTotalRated.TotalPowerInputRatio].Row = null;
                Measure.TotalRateds[(int)EMeasTotalRated.TotalRatedEER_COP].Row = null;
                Measure.TotalRateds[(int)EMeasTotalRated.TotalEER_COPRatio].Row = null;
                Measure.TotalRateds[(int)EMeasTotalRated.TotalRatedCurrent].Row = null;
                Measure.TotalRateds[(int)EMeasTotalRated.TotalCurrentRatio].Row = null;
            }
            else
            {
                rateds = Condition.Rateds[EConditionRated.Total];
                Value.Const["Total.Rated.Capacity"].Value = rateds[(int)sch.IndoorMode].Capacity;
                Value.Const["Total.Rated.Power"].Value = rateds[(int)sch.IndoorMode].PowerInput;
                Value.Const["Total.Rated.EER_COP"].Value = rateds[(int)sch.IndoorMode].EER_COP;
                Value.Const["Total.Rated.Voltage"].Value = rateds[(int)sch.IndoorMode].Voltage;
                Value.Const["Total.Rated.Current"].Value = rateds[(int)sch.IndoorMode].Current;

                try
                {
                    if (string.IsNullOrWhiteSpace(rateds[(int)sch.IndoorMode].Frequency) == true)
                        Value.Const["Total.Rated.Frequency"].Value = 0;
                    else
                        Value.Const["Total.Rated.Frequency"].Value = float.Parse(rateds[(int)sch.IndoorMode].Frequency);
                }
                catch
                {
                    Value.Const["Total.Rated.Frequency"].Value = 0;
                }

                Measure.TotalRateds[(int)EMeasTotalRated.TotalCapacity].Row = Value.Calcurated["Total.Capacity"];
                Measure.TotalRateds[(int)EMeasTotalRated.TotalPowerInput].Row = Value.Calcurated["Total.Power"];
                Measure.TotalRateds[(int)EMeasTotalRated.TotalEER_COP].Row = Value.Calcurated["Total.EER_COP"];

                Measure.TotalRateds[(int)EMeasTotalRated.TotalRatedCapacity].Row = Value.Const["Total.Rated.Capacity"];
                Measure.TotalRateds[(int)EMeasTotalRated.TotalCapacityRatio].Row = Value.Calcurated["Total.Capacity.Ratio"];
                Measure.TotalRateds[(int)EMeasTotalRated.TotalRatedPowerInput].Row = Value.Const["Total.Rated.Power"];
                Measure.TotalRateds[(int)EMeasTotalRated.TotalPowerInputRatio].Row = Value.Calcurated["Total.Power.Ratio"];
                Measure.TotalRateds[(int)EMeasTotalRated.TotalRatedEER_COP].Row = Value.Const["Total.Rated.EER_COP"];
                Measure.TotalRateds[(int)EMeasTotalRated.TotalEER_COPRatio].Row = Value.Calcurated["Total.EER_COP.Ratio"];
                Measure.TotalRateds[(int)EMeasTotalRated.TotalRatedCurrent].Row = Value.Const["Total.Rated.Current"];
                Measure.TotalRateds[(int)EMeasTotalRated.TotalCurrentRatio].Row = Value.Calcurated["Total.Current.Ratio"];
            }

            Measure.TotalRateds[(int)EMeasTotalRated.IDU_PowerInput].Row = Value.Calcurated["Total.IDU.Power"];
            Measure.TotalRateds[(int)EMeasTotalRated.IDU_Voltage].Row = Value.Calcurated["Total.IDU.Voltage"];
            Measure.TotalRateds[(int)EMeasTotalRated.IDU_Current].Row = Value.Calcurated["Total.IDU.Current"];
            Measure.TotalRateds[(int)EMeasTotalRated.IDU_Frequency].Row = Value.Calcurated["Total.IDU.Frequency"];
            Measure.TotalRateds[(int)EMeasTotalRated.IDU_PowerFactor].Row = Value.Calcurated["Total.IDU.Power.Factor"];
            Measure.TotalRateds[(int)EMeasTotalRated.IDU_IntegPowerInput].Row = Value.Calcurated["Total.IDU.Integ.Power"];
            Measure.TotalRateds[(int)EMeasTotalRated.IDU_IntegTime].Row = Value.Calcurated["Total.IDU.Integ.Time"];
            Value.Calcurated["Total.IDU.Integ.Time"].Unit.To = (int)EUnitTime.min;

            Measure.TotalRateds[(int)EMeasTotalRated.ODU_PowerInput].Row = Value.Calcurated["Total.ODU.Power"];
            Measure.TotalRateds[(int)EMeasTotalRated.ODU_Voltage].Row = Value.Calcurated["Total.ODU.Voltage"];
            Measure.TotalRateds[(int)EMeasTotalRated.ODU_Current].Row = Value.Calcurated["Total.ODU.Current"];
            Measure.TotalRateds[(int)EMeasTotalRated.ODU_Frequency].Row = Value.Calcurated["Total.ODU.Frequency"];
            Measure.TotalRateds[(int)EMeasTotalRated.ODU_PowerFactor].Row = Value.Calcurated["Total.ODU.Power.Factor"];
            Measure.TotalRateds[(int)EMeasTotalRated.ODU_IntegPowerInput].Row = Value.Calcurated["Total.ODU.Integ.Power"];
            Measure.TotalRateds[(int)EMeasTotalRated.ODU_IntegTime].Row = Value.Calcurated["Total.ODU.Integ.Time"];
            Value.Calcurated["Total.ODU.Integ.Time"].Unit.To = (int)EUnitTime.min;

            if (sch.IndoorMode == EIndoorMode.NotUsed)
            {
                Measure.Rateds[(int)EMeasRated.Capacity].Row = null;
                Measure.Rateds[(int)EMeasRated.PowerInput].Row = null;
                Measure.Rateds[(int)EMeasRated.EER_COP].Row = null;
                Measure.Rateds[(int)EMeasRated.IDU_Voltage].Row = null;
                Measure.Rateds[(int)EMeasRated.IDU_Current].Row = null;
                Measure.Rateds[(int)EMeasRated.IDU_Frequency].Row = null;
                Measure.Rateds[(int)EMeasRated.IDU_SelectedPM].Row = null;
                Measure.Rateds[(int)EMeasRated.ODU_SelectedPM].Row = null;
                Measure.Rateds[(int)EMeasRated.ODU_Phase].Row = null;
            }
            else
            {
                Measure.Rateds[(int)EMeasRated.Capacity].Row = Value.Const["Total.Rated.Capacity"];
                Measure.Rateds[(int)EMeasRated.PowerInput].Row = Value.Const["Total.Rated.Power"];
                Measure.Rateds[(int)EMeasRated.EER_COP].Row = Value.Const["Total.Rated.EER_COP"];
                Measure.Rateds[(int)EMeasRated.IDU_Voltage].Row = Value.Const["Total.Rated.Voltage"];
                Measure.Rateds[(int)EMeasRated.IDU_Current].Row = Value.Const["Total.Rated.Current"];
                Measure.Rateds[(int)EMeasRated.IDU_Frequency].Row = Value.Const["Total.Rated.Frequency"];
                Measure.Rateds[(int)EMeasRated.IDU_SelectedPM].Value = GetNameIDU(rateds[(int)sch.IndoorMode].PM_IDU);
                Measure.Rateds[(int)EMeasRated.ODU_SelectedPM].Value = GetNameODU(rateds[(int)sch.IndoorMode].PM_ODU);
                Measure.Rateds[(int)EMeasRated.ODU_Phase].Value = EnumHelper.GetNames<EWT330Wiring>()[(int)rateds[(int)sch.IndoorMode].Wiring];
            }

            List<CoefficientDataRow> coeffs = Resource.Settings.Coefficients;
            Measure.Nozzles[(int)EMeasNozzle.Nozzle1].SetDiameter(coeffs[0].Nozzle1, coeffs[1].Nozzle1, coeffs[2].Nozzle1, coeffs[3].Nozzle1);
            Measure.Nozzles[(int)EMeasNozzle.Nozzle2].SetDiameter(coeffs[0].Nozzle2, coeffs[1].Nozzle2, coeffs[2].Nozzle2, coeffs[3].Nozzle2);
            Measure.Nozzles[(int)EMeasNozzle.Nozzle3].SetDiameter(coeffs[0].Nozzle3, coeffs[1].Nozzle3, coeffs[2].Nozzle3, coeffs[3].Nozzle3);
            Measure.Nozzles[(int)EMeasNozzle.Nozzle4].SetDiameter(coeffs[0].Nozzle4, coeffs[1].Nozzle4, coeffs[2].Nozzle4, coeffs[3].Nozzle4);

            if (sch.Indoor1Use == EIndoorUse.NotUsed)
            {
                foreach (EMeasAirSide airSide in Enum.GetValues(typeof(EMeasAirSide)))
               {
                    Measure.AirSides[(int)airSide].Indoor11Enabled = false;
                    Measure.AirSides[(int)airSide].Indoor12Enabled = false;
                }

                foreach (EMeasNozzle nozzle in Enum.GetValues(typeof(EMeasNozzle)))
                {
                    Measure.Nozzles[(int)nozzle].ID11Enabled = false;
                    Measure.Nozzles[(int)nozzle].ID12Enabled = false;
                }
            }
            else
            {
                if (sch.Indoor1Mode == EIndoorMode.NotUsed)
                {
                    foreach (EMeasAirSide airSide in Enum.GetValues(typeof(EMeasAirSide)))
                    {
                        Measure.AirSides[(int)airSide].Indoor11Enabled = false;
                        Measure.AirSides[(int)airSide].Indoor12Enabled = false;
                    }

                    Measure.AirSides[(int)EMeasAirSide.EnteringDB].Indoor11Enabled = true;
                    Measure.AirSides[(int)EMeasAirSide.EnteringWB].Indoor11Enabled = true;
                    Measure.AirSides[(int)EMeasAirSide.EnteringRH].Indoor11Enabled = true;
                    Measure.AirSides[(int)EMeasAirSide.LeavingDB].Indoor11Enabled = true;
                    Measure.AirSides[(int)EMeasAirSide.LeavingWB].Indoor11Enabled = true;
                    Measure.AirSides[(int)EMeasAirSide.LeavingRH].Indoor11Enabled = true;

                    Measure.AirSides[(int)EMeasAirSide.EnteringDB].Indoor12Enabled = true;
                    Measure.AirSides[(int)EMeasAirSide.EnteringWB].Indoor12Enabled = true;
                    Measure.AirSides[(int)EMeasAirSide.EnteringRH].Indoor12Enabled = true;
                    Measure.AirSides[(int)EMeasAirSide.LeavingDB].Indoor12Enabled = true;
                    Measure.AirSides[(int)EMeasAirSide.LeavingWB].Indoor12Enabled = true;
                    Measure.AirSides[(int)EMeasAirSide.LeavingRH].Indoor12Enabled = true;

                    foreach (EMeasNozzle nozzle in Enum.GetValues(typeof(EMeasNozzle)))
                    {
                        Measure.Nozzles[(int)nozzle].ID11Enabled = false;
                        Measure.Nozzles[(int)nozzle].ID12Enabled = false;
                    }
                }
                else
                {
                    if (sch.Indoor1Mode1 == EIndoorMode.NotUsed)
                    {
                        foreach (EMeasAirSide airSide in Enum.GetValues(typeof(EMeasAirSide)))
                        {
                            Measure.AirSides[(int)airSide].Indoor11Enabled = false;
                        }

                        Measure.AirSides[(int)EMeasAirSide.EnteringDB].Indoor11Enabled = true;
                        Measure.AirSides[(int)EMeasAirSide.EnteringWB].Indoor11Enabled = true;
                        Measure.AirSides[(int)EMeasAirSide.EnteringRH].Indoor11Enabled = true;
                        Measure.AirSides[(int)EMeasAirSide.LeavingDB].Indoor11Enabled = true;
                        Measure.AirSides[(int)EMeasAirSide.LeavingWB].Indoor11Enabled = true;
                        Measure.AirSides[(int)EMeasAirSide.LeavingRH].Indoor11Enabled = true;

                        foreach (EMeasNozzle nozzle in Enum.GetValues(typeof(EMeasNozzle)))
                        {
                            Measure.Nozzles[(int)nozzle].ID11Enabled = false;
                        }
                    }
                    else
                    {
                        foreach (EMeasAirSide airSide in Enum.GetValues(typeof(EMeasAirSide)))
                        {
                            Measure.AirSides[(int)airSide].Indoor11Enabled = true;
                        }

                        foreach (EMeasNozzle nozzle in Enum.GetValues(typeof(EMeasNozzle)))
                        {
                            Measure.Nozzles[(int)nozzle].ID11Enabled = true;
                        }
                    }

                    if (sch.Indoor1Mode2 == EIndoorMode.NotUsed)
                    {
                        foreach (EMeasAirSide airSide in Enum.GetValues(typeof(EMeasAirSide)))
                        {
                            Measure.AirSides[(int)airSide].Indoor12Enabled = false;
                        }

                        Measure.AirSides[(int)EMeasAirSide.EnteringDB].Indoor12Enabled = true;
                        Measure.AirSides[(int)EMeasAirSide.EnteringWB].Indoor12Enabled = true;
                        Measure.AirSides[(int)EMeasAirSide.EnteringRH].Indoor12Enabled = true;
                        Measure.AirSides[(int)EMeasAirSide.LeavingDB].Indoor12Enabled = true;
                        Measure.AirSides[(int)EMeasAirSide.LeavingWB].Indoor12Enabled = true;
                        Measure.AirSides[(int)EMeasAirSide.LeavingRH].Indoor12Enabled = true;

                        foreach (EMeasNozzle nozzle in Enum.GetValues(typeof(EMeasNozzle)))
                        {
                            Measure.Nozzles[(int)nozzle].ID12Enabled = false;
                        }
                    }
                    else
                    {
                        foreach (EMeasAirSide airSide in Enum.GetValues(typeof(EMeasAirSide)))
                        {
                            Measure.AirSides[(int)airSide].Indoor12Enabled = true;
                        }

                        foreach (EMeasNozzle nozzle in Enum.GetValues(typeof(EMeasNozzle)))
                        {
                            Measure.Nozzles[(int)nozzle].ID12Enabled = true;
                        }
                    }
                }
            }

            if (sch.Indoor2Use == EIndoorUse.NotUsed)
            {
                foreach (EMeasAirSide airSide in Enum.GetValues(typeof(EMeasAirSide)))
                {
                    Measure.AirSides[(int)airSide].Indoor21Enabled = false;
                    Measure.AirSides[(int)airSide].Indoor22Enabled = false;
                }

                foreach (EMeasNozzle nozzle in Enum.GetValues(typeof(EMeasNozzle)))
                {
                    Measure.Nozzles[(int)nozzle].ID21Enabled = false;
                    Measure.Nozzles[(int)nozzle].ID22Enabled = false;
                }
            }
            else
            {
                if (sch.Indoor2Mode == EIndoorMode.NotUsed)
                {
                    foreach (EMeasAirSide airSide in Enum.GetValues(typeof(EMeasAirSide)))
                    {
                        Measure.AirSides[(int)airSide].Indoor21Enabled = false;
                        Measure.AirSides[(int)airSide].Indoor22Enabled = false;
                    }

                    Measure.AirSides[(int)EMeasAirSide.EnteringDB].Indoor21Enabled = true;
                    Measure.AirSides[(int)EMeasAirSide.EnteringWB].Indoor21Enabled = true;
                    Measure.AirSides[(int)EMeasAirSide.EnteringRH].Indoor21Enabled = true;
                    Measure.AirSides[(int)EMeasAirSide.LeavingDB].Indoor21Enabled = true;
                    Measure.AirSides[(int)EMeasAirSide.LeavingWB].Indoor21Enabled = true;
                    Measure.AirSides[(int)EMeasAirSide.LeavingRH].Indoor21Enabled = true;

                    Measure.AirSides[(int)EMeasAirSide.EnteringDB].Indoor22Enabled = true;
                    Measure.AirSides[(int)EMeasAirSide.EnteringWB].Indoor22Enabled = true;
                    Measure.AirSides[(int)EMeasAirSide.EnteringRH].Indoor22Enabled = true;
                    Measure.AirSides[(int)EMeasAirSide.LeavingDB].Indoor22Enabled = true;
                    Measure.AirSides[(int)EMeasAirSide.LeavingWB].Indoor22Enabled = true;
                    Measure.AirSides[(int)EMeasAirSide.LeavingRH].Indoor22Enabled = true;

                    foreach (EMeasNozzle nozzle in Enum.GetValues(typeof(EMeasNozzle)))
                    {
                        Measure.Nozzles[(int)nozzle].ID21Enabled = false;
                        Measure.Nozzles[(int)nozzle].ID22Enabled = false;
                    }
                }
                else
                {
                    if (sch.Indoor2Mode1 == EIndoorMode.NotUsed)
                    {
                        foreach (EMeasAirSide airSide in Enum.GetValues(typeof(EMeasAirSide)))
                        {
                            Measure.AirSides[(int)airSide].Indoor21Enabled = false;
                        }

                        Measure.AirSides[(int)EMeasAirSide.EnteringDB].Indoor21Enabled = true;
                        Measure.AirSides[(int)EMeasAirSide.EnteringWB].Indoor21Enabled = true;
                        Measure.AirSides[(int)EMeasAirSide.EnteringRH].Indoor21Enabled = true;
                        Measure.AirSides[(int)EMeasAirSide.LeavingDB].Indoor21Enabled = true;
                        Measure.AirSides[(int)EMeasAirSide.LeavingWB].Indoor21Enabled = true;
                        Measure.AirSides[(int)EMeasAirSide.LeavingRH].Indoor21Enabled = true;

                        foreach (EMeasNozzle nozzle in Enum.GetValues(typeof(EMeasNozzle)))
                        {
                            Measure.Nozzles[(int)nozzle].ID21Enabled = false;
                        }
                    }
                    else
                    {
                        foreach (EMeasAirSide airSide in Enum.GetValues(typeof(EMeasAirSide)))
                        {
                            Measure.AirSides[(int)airSide].Indoor21Enabled = true;
                        }

                        foreach (EMeasNozzle nozzle in Enum.GetValues(typeof(EMeasNozzle)))
                        {
                            Measure.Nozzles[(int)nozzle].ID21Enabled = true;
                        }
                    }

                    if (sch.Indoor2Mode2 == EIndoorMode.NotUsed)
                    {
                        foreach (EMeasAirSide airSide in Enum.GetValues(typeof(EMeasAirSide)))
                        {
                            Measure.AirSides[(int)airSide].Indoor22Enabled = false;
                        }

                        Measure.AirSides[(int)EMeasAirSide.EnteringDB].Indoor22Enabled = true;
                        Measure.AirSides[(int)EMeasAirSide.EnteringWB].Indoor22Enabled = true;
                        Measure.AirSides[(int)EMeasAirSide.EnteringRH].Indoor22Enabled = true;
                        Measure.AirSides[(int)EMeasAirSide.LeavingDB].Indoor22Enabled = true;
                        Measure.AirSides[(int)EMeasAirSide.LeavingWB].Indoor22Enabled = true;
                        Measure.AirSides[(int)EMeasAirSide.LeavingRH].Indoor22Enabled = true;

                        foreach (EMeasNozzle nozzle in Enum.GetValues(typeof(EMeasNozzle)))
                        {
                            Measure.Nozzles[(int)nozzle].ID22Enabled = false;
                        }
                    }
                    else
                    {
                        foreach (EMeasAirSide airSide in Enum.GetValues(typeof(EMeasAirSide)))
                        {
                            Measure.AirSides[(int)airSide].Indoor22Enabled = true;
                        }

                        foreach (EMeasNozzle nozzle in Enum.GetValues(typeof(EMeasNozzle)))
                        {
                            Measure.Nozzles[(int)nozzle].ID22Enabled = true;
                        }
                    }
                }
            }

            if (sch.OutdoorUse == EOutdoorUse.NotUsed)
            {
                Measure.Outsides[(int)EMeasOutside.EnteringDB].Value = "-";
                Measure.Outsides[(int)EMeasOutside.EnteringWB].Value = "-";
                Measure.Outsides[(int)EMeasOutside.EnteringDP].Value = "-";
                Measure.Outsides[(int)EMeasOutside.EnteringRH].Value = "-";
            }
            else
            {
                Measure.Outsides[(int)EMeasOutside.EnteringDB].Value = "";
                Measure.Outsides[(int)EMeasOutside.EnteringWB].Value = "";
                Measure.Outsides[(int)EMeasOutside.EnteringDP].Value = "";
                Measure.Outsides[(int)EMeasOutside.EnteringRH].Value = "";
            }

            // Note
            Measure.Notes[(int)EMeasNote.Company].Value = Condition.Note.Company;
            Measure.Notes[(int)EMeasNote.TestName].Value = Condition.Note.Name;
            Measure.Notes[(int)EMeasNote.TestNo].Value = Condition.Note.No;
            Measure.Notes[(int)EMeasNote.Observer].Value = Condition.Note.Observer;
            Measure.Notes[(int)EMeasNote.Maker].Value = Condition.Note.Maker;
            Measure.Notes[(int)EMeasNote.Model1].Value = Condition.Note.Model1;
            Measure.Notes[(int)EMeasNote.SerialNo1].Value = Condition.Note.Serial1;
            Measure.Notes[(int)EMeasNote.Model2].Value = Condition.Note.Model2;
            Measure.Notes[(int)EMeasNote.SerialNo2].Value = Condition.Note.Serial2;
            Measure.Notes[(int)EMeasNote.Model3].Value = Condition.Note.Model3;
            Measure.Notes[(int)EMeasNote.SerialNo3].Value = Condition.Note.Serial3;
            Measure.Notes[(int)EMeasNote.ExpDevice].Value = Condition.Note.ExpDevice;
            Measure.Notes[(int)EMeasNote.Refrigerant].Value = Condition.Note.Refrigerant;
            Measure.Notes[(int)EMeasNote.RefCharge].Value = Condition.Note.RefCharge;
            Measure.Notes[(int)EMeasNote.Memo].Value = Condition.Note.Memo;

            // Method
            Measure.Methods[(int)EMeasMethod.Method].Value = $"{Condition.Method.IntegralTime}min / {Condition.Method.IntegralCount}times";
            Measure.Methods[(int)EMeasMethod.ScanTime].Value = $"{Condition.Method.ScanTime} sec";

            //Indoor1 #1
            Measure.Indoors11[(int)EMeasIndoor.Use].Value = EnumHelper.GetNames<EIndoorUse>()[(int)sch.Indoor1Use];
            Measure.Indoors11[(int)EMeasIndoor.Mode].Value = EnumHelper.GetNames<EIndoorMode>()[(int)sch.Indoor1Mode1];
            Measure.Indoors11[(int)EMeasIndoor.Duct].Value = EnumHelper.GetNames<EIndoorDuct>()[(int)sch.Indoor1Duct1];
            Measure.Indoors11[(int)EMeasIndoor.DB].Value = sch.Indoor1DB.ToString("0.00");
            Measure.Indoors11[(int)EMeasIndoor.DB].Unit = Condition.Method.Temperature.ToDescription();
            Measure.Indoors11[(int)EMeasIndoor.WB].Value = sch.Indoor1WB.ToString("0.00");
            Measure.Indoors11[(int)EMeasIndoor.WB].Unit = Condition.Method.Temperature.ToDescription();

            //Indoor1 #2
            Measure.Indoors12[(int)EMeasIndoor.Use].Value = EnumHelper.GetNames<EIndoorUse>()[(int)sch.Indoor1Use];
            Measure.Indoors12[(int)EMeasIndoor.Mode].Value = EnumHelper.GetNames<EIndoorMode>()[(int)sch.Indoor1Mode2];
            Measure.Indoors12[(int)EMeasIndoor.Duct].Value = EnumHelper.GetNames<EIndoorDuct>()[(int)sch.Indoor1Duct2];
            Measure.Indoors12[(int)EMeasIndoor.DB].Value = sch.Indoor1DB.ToString("0.00");
            Measure.Indoors12[(int)EMeasIndoor.DB].Unit = Condition.Method.Temperature.ToDescription();
            Measure.Indoors12[(int)EMeasIndoor.WB].Value = sch.Indoor1WB.ToString("0.00");
            Measure.Indoors12[(int)EMeasIndoor.WB].Unit = Condition.Method.Temperature.ToDescription();

            //Indoor2 #1
            Measure.Indoors21[(int)EMeasIndoor.Use].Value = EnumHelper.GetNames<EIndoorUse>()[(int)sch.Indoor2Use];
            Measure.Indoors21[(int)EMeasIndoor.Mode].Value = EnumHelper.GetNames<EIndoorMode>()[(int)sch.Indoor2Mode1];
            Measure.Indoors21[(int)EMeasIndoor.Duct].Value = EnumHelper.GetNames<EIndoorDuct>()[(int)sch.Indoor2Duct1];
            Measure.Indoors21[(int)EMeasIndoor.DB].Value = sch.Indoor2DB.ToString("0.00");
            Measure.Indoors21[(int)EMeasIndoor.DB].Unit = Condition.Method.Temperature.ToDescription();
            Measure.Indoors21[(int)EMeasIndoor.WB].Value = sch.Indoor2WB.ToString("0.00");
            Measure.Indoors21[(int)EMeasIndoor.WB].Unit = Condition.Method.Temperature.ToDescription();

            //Indoor2 #2
            Measure.Indoors22[(int)EMeasIndoor.Use].Value = EnumHelper.GetNames<EIndoorUse>()[(int)sch.Indoor2Use];
            Measure.Indoors22[(int)EMeasIndoor.Mode].Value = EnumHelper.GetNames<EIndoorMode>()[(int)sch.Indoor2Mode2];
            Measure.Indoors22[(int)EMeasIndoor.Duct].Value = EnumHelper.GetNames<EIndoorDuct>()[(int)sch.Indoor2Duct2];
            Measure.Indoors22[(int)EMeasIndoor.DB].Value = sch.Indoor2DB.ToString("0.00");
            Measure.Indoors22[(int)EMeasIndoor.DB].Unit = Condition.Method.Temperature.ToDescription();
            Measure.Indoors22[(int)EMeasIndoor.WB].Value = sch.Indoor2WB.ToString("0.00");
            Measure.Indoors22[(int)EMeasIndoor.WB].Unit = Condition.Method.Temperature.ToDescription();

            //Outdoor
            Measure.Outdoors[(int)EMeasOutdoor.Use].Value = EnumHelper.GetNames<EOutdoorUse>()[(int)sch.OutdoorUse];
            Measure.Outdoors[(int)EMeasOutdoor.DPSensor].Value = EnumHelper.GetNames<EEtcUse>()[(int)sch.OutdoorDpSensor];
            Measure.Outdoors[(int)EMeasOutdoor.AutoVoltage].Value = EnumHelper.GetNames<EEtcUse>()[(int)sch.OutdoorAutoVolt];
            Measure.Outdoors[(int)EMeasIndoor.DB].Value = sch.OutdoorDB.ToString("0.00");
            Measure.Outdoors[(int)EMeasIndoor.DB].Unit = Condition.Method.Temperature.ToDescription();
            Measure.Outdoors[(int)EMeasIndoor.WB].Value = sch.OutdoorWB.ToString("0.00");
            Measure.Outdoors[(int)EMeasIndoor.WB].Unit = Condition.Method.Temperature.ToDescription();

            for (int i = 0; i < Condition.TC1.Count; i++)
            {
                if (Condition.TC1[i].Name.Trim() != "")
                {
                    Measure.IndoorTC1[i].Value = "";
                    Measure.IndoorTC1[i].Unit = "";
                    Measure.IndoorTC1[i].Name = Condition.TC1[i].Name.Trim();
                }
                else
                {
                    Measure.IndoorTC1[i].Value = "-";
                    Measure.IndoorTC1[i].Unit = "-";
                    Measure.IndoorTC1[i].Name = "-";
                }
            }

            for (int i = 0; i < Condition.TC2.Count; i++)
            {
                if (Condition.TC2[i].Name.Trim() != "")
                {
                    Measure.IndoorTC2[i].Value = "";
                    Measure.IndoorTC2[i].Unit = "";
                    Measure.IndoorTC2[i].Name = Condition.TC2[i].Name.Trim();
                }
                else
                {
                    Measure.IndoorTC2[i].Value = "-";
                    Measure.IndoorTC2[i].Unit = "-";
                    Measure.IndoorTC2[i].Name = "-";
                }
            }

            for (int i = 0; i < Condition.TC3.Count; i++)
            {
                if (Condition.TC3[i].Name.Trim() != "")
                {
                    Measure.OutdoorTC[i].Value = "";
                    Measure.OutdoorTC[i].Unit = "";
                    Measure.OutdoorTC[i].Name = Condition.TC3[i].Name.Trim();
                }
                else
                {
                    Measure.OutdoorTC[i].Value = "-";
                    Measure.OutdoorTC[i].Unit = "-";
                    Measure.OutdoorTC[i].Name = "-";
                }
            }

            for (int i = 0; i < Condition.Pressures.Count; i++)
            {
                if (Condition.Pressures[i].Name.Trim() != "")
                {
                    Measure.Pressures[i].Value = "";
                    Measure.Pressures[i].Unit = "";
                    Measure.Pressures[i].Name = Condition.Pressures[i].Name.Trim();
                }
                else
                {
                    Measure.Pressures[i].Value = "-";
                    Measure.Pressures[i].Unit = "-";
                    Measure.Pressures[i].Name = "-";
                }
            }

            if (sch.IndoorMode == EIndoorMode.Cooling)
            {
                Value.SetUnitTo(EUnitType.Capacity, (int)Condition.Method.CoolingCapacity);
                Value.SetUnitTo(EUnitType.EER_COP, (int)Condition.Method.CoolingCapacity);
            }
            else
            {
                Value.SetUnitTo(EUnitType.Capacity, (int)Condition.Method.HeatingCapacity);
                Value.SetUnitTo(EUnitType.EER_COP, (int)Condition.Method.HeatingCapacity);
            }
        }

        public void RefreshCondition()
        {
            ConditionSchedule sch = Condition.Schedules[Index];

            // Note
            Measure.Notes[(int)EMeasNote.Company].Value = Condition.Note.Company;
            Measure.Notes[(int)EMeasNote.TestName].Value = Condition.Note.Name;
            Measure.Notes[(int)EMeasNote.TestNo].Value = Condition.Note.No;
            Measure.Notes[(int)EMeasNote.Observer].Value = Condition.Note.Observer;
            Measure.Notes[(int)EMeasNote.Maker].Value = Condition.Note.Maker;
            Measure.Notes[(int)EMeasNote.Model1].Value = Condition.Note.Model1;
            Measure.Notes[(int)EMeasNote.SerialNo1].Value = Condition.Note.Serial1;
            Measure.Notes[(int)EMeasNote.Model2].Value = Condition.Note.Model2;
            Measure.Notes[(int)EMeasNote.SerialNo2].Value = Condition.Note.Serial2;
            Measure.Notes[(int)EMeasNote.Model3].Value = Condition.Note.Model3;
            Measure.Notes[(int)EMeasNote.SerialNo3].Value = Condition.Note.Serial3;
            Measure.Notes[(int)EMeasNote.ExpDevice].Value = Condition.Note.ExpDevice;
            Measure.Notes[(int)EMeasNote.Refrigerant].Value = Condition.Note.Refrigerant;
            Measure.Notes[(int)EMeasNote.RefCharge].Value = Condition.Note.RefCharge;
            Measure.Notes[(int)EMeasNote.Memo].Value = Condition.Note.Memo;

            //Indoor1 #1
            Measure.Indoors11[(int)EMeasIndoor.DB].Value = sch.Indoor1DB.ToString("0.00");
            Measure.Indoors11[(int)EMeasIndoor.WB].Value = sch.Indoor1WB.ToString("0.00");

            //Indoor1 #2
            Measure.Indoors12[(int)EMeasIndoor.DB].Value = sch.Indoor1DB.ToString("0.00");
            Measure.Indoors12[(int)EMeasIndoor.WB].Value = sch.Indoor1WB.ToString("0.00");

            //Indoor2 #1
            Measure.Indoors21[(int)EMeasIndoor.DB].Value = sch.Indoor2DB.ToString("0.00");
            Measure.Indoors21[(int)EMeasIndoor.WB].Value = sch.Indoor2WB.ToString("0.00");

            //Indoor2 #2
            Measure.Indoors22[(int)EMeasIndoor.DB].Value = sch.Indoor2DB.ToString("0.00");
            Measure.Indoors22[(int)EMeasIndoor.WB].Value = sch.Indoor2WB.ToString("0.00");

            //Outdoor
            Measure.Outdoors[(int)EMeasIndoor.DB].Value = sch.OutdoorDB.ToString("0.00");
            Measure.Outdoors[(int)EMeasIndoor.WB].Value = sch.OutdoorWB.ToString("0.00");

            for (int i = 0; i < Condition.TC1.Count; i++)
            {
                if (Condition.TC1[i].Name.Trim() != "")
                {
                    Measure.IndoorTC1[i].Value = "";
                    Measure.IndoorTC1[i].Name = Condition.TC1[i].Name.Trim();
                }
                else
                {
                    Measure.IndoorTC1[i].Value = "-";
                    Measure.IndoorTC1[i].Unit = "-";
                    Measure.IndoorTC1[i].Name = "-";
                }
            }

            for (int i = 0; i < Condition.TC2.Count; i++)
            {
                if (Condition.TC2[i].Name.Trim() != "")
                {
                    Measure.IndoorTC2[i].Value = "";
                    Measure.IndoorTC2[i].Name = Condition.TC2[i].Name.Trim();
                }
                else
                {
                    Measure.IndoorTC2[i].Value = "-";
                    Measure.IndoorTC2[i].Name = "-";
                }
            }

            for (int i = 0; i < Condition.TC3.Count; i++)
            {
                if (Condition.TC3[i].Name.Trim() != "")
                {
                    Measure.OutdoorTC[i].Value = "";
                    Measure.OutdoorTC[i].Name = Condition.TC3[i].Name.Trim();
                }
                else
                {
                    Measure.OutdoorTC[i].Value = "-";
                    Measure.OutdoorTC[i].Unit = "-";
                    Measure.OutdoorTC[i].Name = "-";
                }
            }

            for (int i = 0; i < Condition.Pressures.Count; i++)
            {
                if (Condition.Pressures[i].Name.Trim() != "")
                {
                    Measure.Pressures[i].Value = "";
                    Measure.Pressures[i].Name = Condition.Pressures[i].Name.Trim();
                }
                else
                {
                    Measure.Pressures[i].Value = "-";
                    Measure.Pressures[i].Unit = "-";
                    Measure.Pressures[i].Name = "-";
                }
            }
        }

        public void Calcurate()
        {
            InitializeCalc();
            SetPowerMeterValues();
            MainCalc();
            FinalizeCalc();
        }

        private void InitializeCalc()
        {
            SetFixedAtmPressure();
        }

        private void MainCalc()
        {
            CalcNozzle();

            ConditionSchedule sch = Condition.Schedules[Index];
            Dictionary<string, ValueRow> inVar = new Dictionary<string, ValueRow>();
            Dictionary<string, ValueRow> outVar = new Dictionary<string, ValueRow>();

            inVar.Clear();
            inVar.Add("Entering DB", Value.Measured["ID11.Entering.DB"]);
            inVar.Add("Entering WB", Value.Measured["ID11.Entering.WB"]);
            inVar.Add("Leaving DB", Value.Measured["ID11.Leaving.DB"]);
            inVar.Add("Leaving WB", Value.Measured["ID11.Leaving.WB"]);
            inVar.Add("Nozzle1", Value.Calcurated["ID11.Nozzle.1"]);
            inVar.Add("Nozzle2", Value.Calcurated["ID11.Nozzle.2"]);
            inVar.Add("Nozzle3", Value.Calcurated["ID11.Nozzle.3"]);
            inVar.Add("Nozzle4", Value.Calcurated["ID11.Nozzle.4"]);
            inVar.Add("Nozzle Diff Pressure", Value.Measured["ID11.Nozzle.Diff.Pressure"]);
            inVar.Add("Atmospheric Pressure", Value.Measured["ID1.Atm.Pressure"]);
            inVar.Add("Static Pressure", Value.Measured["ID11.Static.Pressure"]);
            inVar.Add("Nozzle Inlet Temp", Value.Measured["ID11.Nozzle.Inlet.Temp"]);

            outVar.Clear();
            outVar.Add("Capacity", Value.Calcurated["ID11.Capacity"]);
            outVar.Add("Drain Weight", Value.Calcurated["ID11.Drain.Weight"]);
            outVar.Add("Latent Heat", Value.Calcurated["ID11.Latent.Heat"]);
            outVar.Add("Sensible Heat", Value.Calcurated["ID11.Sensible.Heat"]);
            outVar.Add("Sensible Heat Ratio", Value.Calcurated["ID11.Sensible.Heat.Ratio"]);
            outVar.Add("Heat Leakage", Value.Calcurated["ID11.Heat.Leakage"]);
            outVar.Add("Entering RH", Value.Calcurated["ID11.Entering.RH"]);
            outVar.Add("Leaving RH", Value.Calcurated["ID11.Leaving.RH"]);
            outVar.Add("Entering Enthalpy", Value.Calcurated["ID11.Entering.Enthalpy"]);
            outVar.Add("Leaving Enthalpy", Value.Calcurated["ID11.Leaving.Enthalpy"]);
            outVar.Add("Entering Humidity Ratio", Value.Calcurated["ID11.Entering.Humidity.Ratio"]);
            outVar.Add("Leaving Humidity Ratio", Value.Calcurated["ID11.Leaving.Humidity.Ratio"]);
            outVar.Add("Leaving Specific Heat", Value.Calcurated["ID11.Leaving.Specific.Heat"]);
            outVar.Add("Leaving Specific Volume", Value.Calcurated["ID11.Leaving.Specific.Volume"]);
            outVar.Add("Air Flow [Lev]", Value.Calcurated["ID11.Air.Flow.Lev"]);
            outVar.Add("Air Velocity [Lev]", Value.Calcurated["ID11.Air.Velocity.Lev"]);

            CalcAir(Resource.Settings.Coefficients[0], sch.Indoor1Mode1, sch.Indoor1Duct1, inVar, outVar);

            if (sch.Indoor1Mode1 == EIndoorMode.NotUsed)
            {
                Value.Calcurated["ID11.Capacity.Ratio"].StoredValue = 0;
            }
            else
            {
                int mode = (sch.Indoor1Mode1 == EIndoorMode.Cooling) ? 0 : 1;

                if (Condition.Rateds[EConditionRated.ID11][mode].Capacity == 0)
                {
                    Value.Calcurated["ID11.Capacity.Ratio"].StoredValue = 0;
                }
                else
                {
                    Value.Calcurated["ID11.Capacity.Ratio"].StoredValue =
                        Value.Calcurated["ID11.Capacity"].Value / Condition.Rateds[EConditionRated.ID11][mode].Capacity * 100.0f;
                }
            }

            inVar.Clear();
            inVar.Add("Entering DB", Value.Measured["ID12.Entering.DB"]);
            inVar.Add("Entering WB", Value.Measured["ID12.Entering.WB"]);
            inVar.Add("Leaving DB", Value.Measured["ID12.Leaving.DB"]);
            inVar.Add("Leaving WB", Value.Measured["ID12.Leaving.WB"]);
            inVar.Add("Nozzle1", Value.Calcurated["ID12.Nozzle.1"]);
            inVar.Add("Nozzle2", Value.Calcurated["ID12.Nozzle.2"]);
            inVar.Add("Nozzle3", Value.Calcurated["ID12.Nozzle.3"]);
            inVar.Add("Nozzle4", Value.Calcurated["ID12.Nozzle.4"]);
            inVar.Add("Nozzle Diff Pressure", Value.Measured["ID12.Nozzle.Diff.Pressure"]);
            inVar.Add("Atmospheric Pressure", Value.Measured["ID1.Atm.Pressure"]);
            inVar.Add("Static Pressure", Value.Measured["ID12.Static.Pressure"]);
            inVar.Add("Nozzle Inlet Temp", Value.Measured["ID12.Nozzle.Inlet.Temp"]);

            outVar.Clear();
            outVar.Add("Capacity", Value.Calcurated["ID12.Capacity"]);
            outVar.Add("Drain Weight", Value.Calcurated["ID12.Drain.Weight"]);
            outVar.Add("Latent Heat", Value.Calcurated["ID12.Latent.Heat"]);
            outVar.Add("Sensible Heat", Value.Calcurated["ID12.Sensible.Heat"]);
            outVar.Add("Sensible Heat Ratio", Value.Calcurated["ID12.Sensible.Heat.Ratio"]);
            outVar.Add("Heat Leakage", Value.Calcurated["ID12.Heat.Leakage"]);
            outVar.Add("Entering RH", Value.Calcurated["ID12.Entering.RH"]);
            outVar.Add("Leaving RH", Value.Calcurated["ID12.Leaving.RH"]);
            outVar.Add("Entering Enthalpy", Value.Calcurated["ID12.Entering.Enthalpy"]);
            outVar.Add("Leaving Enthalpy", Value.Calcurated["ID12.Leaving.Enthalpy"]);
            outVar.Add("Entering Humidity Ratio", Value.Calcurated["ID12.Entering.Humidity.Ratio"]);
            outVar.Add("Leaving Humidity Ratio", Value.Calcurated["ID12.Leaving.Humidity.Ratio"]);
            outVar.Add("Leaving Specific Heat", Value.Calcurated["ID12.Leaving.Specific.Heat"]);
            outVar.Add("Leaving Specific Volume", Value.Calcurated["ID12.Leaving.Specific.Volume"]);
            outVar.Add("Air Flow [Lev]", Value.Calcurated["ID12.Air.Flow.Lev"]);
            outVar.Add("Air Velocity [Lev]", Value.Calcurated["ID12.Air.Velocity.Lev"]);

            CalcAir(Resource.Settings.Coefficients[1], sch.Indoor1Mode2, sch.Indoor1Duct2, inVar, outVar);

            if (sch.Indoor1Mode2 == EIndoorMode.NotUsed)
            {
                Value.Calcurated["ID12.Capacity.Ratio"].StoredValue = 0;
            }
            else
            {
                int mode = (sch.Indoor1Mode2 == EIndoorMode.Cooling) ? 0 : 1;

                if (Condition.Rateds[EConditionRated.ID12][mode].Capacity == 0)
                {
                    Value.Calcurated["ID12.Capacity.Ratio"].StoredValue = 0;
                }
                else
                {
                    Value.Calcurated["ID12.Capacity.Ratio"].StoredValue =
                        Value.Calcurated["ID12.Capacity"].Value / Condition.Rateds[EConditionRated.ID12][mode].Capacity * 100.0f;
                }
            }

            inVar.Clear();
            inVar.Add("Entering DB", Value.Measured["ID21.Entering.DB"]);
            inVar.Add("Entering WB", Value.Measured["ID21.Entering.WB"]);
            inVar.Add("Leaving DB", Value.Measured["ID21.Leaving.DB"]);
            inVar.Add("Leaving WB", Value.Measured["ID21.Leaving.WB"]);
            inVar.Add("Nozzle1", Value.Calcurated["ID21.Nozzle.1"]);
            inVar.Add("Nozzle2", Value.Calcurated["ID21.Nozzle.2"]);
            inVar.Add("Nozzle3", Value.Calcurated["ID21.Nozzle.3"]);
            inVar.Add("Nozzle4", Value.Calcurated["ID21.Nozzle.4"]);
            inVar.Add("Nozzle Diff Pressure", Value.Measured["ID21.Nozzle.Diff.Pressure"]);
            inVar.Add("Atmospheric Pressure", Value.Measured["ID2.Atm.Pressure"]);
            inVar.Add("Static Pressure", Value.Measured["ID21.Static.Pressure"]);
            inVar.Add("Nozzle Inlet Temp", Value.Measured["ID21.Nozzle.Inlet.Temp"]);

            outVar.Clear();
            outVar.Add("Capacity", Value.Calcurated["ID21.Capacity"]);
            outVar.Add("Drain Weight", Value.Calcurated["ID21.Drain.Weight"]);
            outVar.Add("Latent Heat", Value.Calcurated["ID21.Latent.Heat"]);
            outVar.Add("Sensible Heat", Value.Calcurated["ID21.Sensible.Heat"]);
            outVar.Add("Sensible Heat Ratio", Value.Calcurated["ID21.Sensible.Heat.Ratio"]);
            outVar.Add("Heat Leakage", Value.Calcurated["ID21.Heat.Leakage"]);
            outVar.Add("Entering RH", Value.Calcurated["ID21.Entering.RH"]);
            outVar.Add("Leaving RH", Value.Calcurated["ID21.Leaving.RH"]);
            outVar.Add("Entering Enthalpy", Value.Calcurated["ID21.Entering.Enthalpy"]);
            outVar.Add("Leaving Enthalpy", Value.Calcurated["ID21.Leaving.Enthalpy"]);
            outVar.Add("Entering Humidity Ratio", Value.Calcurated["ID21.Entering.Humidity.Ratio"]);
            outVar.Add("Leaving Humidity Ratio", Value.Calcurated["ID21.Leaving.Humidity.Ratio"]);
            outVar.Add("Leaving Specific Heat", Value.Calcurated["ID21.Leaving.Specific.Heat"]);
            outVar.Add("Leaving Specific Volume", Value.Calcurated["ID21.Leaving.Specific.Volume"]);
            outVar.Add("Air Flow [Lev]", Value.Calcurated["ID21.Air.Flow.Lev"]);
            outVar.Add("Air Velocity [Lev]", Value.Calcurated["ID21.Air.Velocity.Lev"]);

            CalcAir(Resource.Settings.Coefficients[2], sch.Indoor2Mode1, sch.Indoor2Duct1, inVar, outVar);


            if (sch.Indoor2Mode1 == EIndoorMode.NotUsed)
            {
                Value.Calcurated["ID21.Capacity.Ratio"].StoredValue = 0;
            }
            else
            {
                int mode = (sch.Indoor2Mode1 == EIndoorMode.Cooling) ? 0 : 1;

                if (Condition.Rateds[EConditionRated.ID21][mode].Capacity == 0)
                {
                    Value.Calcurated["ID21.Capacity.Ratio"].StoredValue = 0;
                }
                else
                {
                    Value.Calcurated["ID21.Capacity.Ratio"].StoredValue =
                        Value.Calcurated["ID21.Capacity"].Value / Condition.Rateds[EConditionRated.ID21][mode].Capacity * 100.0f;
                }
            }

            inVar.Clear();
            inVar.Add("Entering DB", Value.Measured["ID22.Entering.DB"]);
            inVar.Add("Entering WB", Value.Measured["ID22.Entering.WB"]);
            inVar.Add("Leaving DB", Value.Measured["ID22.Leaving.DB"]);
            inVar.Add("Leaving WB", Value.Measured["ID22.Leaving.WB"]);
            inVar.Add("Nozzle1", Value.Calcurated["ID22.Nozzle.1"]);
            inVar.Add("Nozzle2", Value.Calcurated["ID22.Nozzle.2"]);
            inVar.Add("Nozzle3", Value.Calcurated["ID22.Nozzle.3"]);
            inVar.Add("Nozzle4", Value.Calcurated["ID22.Nozzle.4"]);
            inVar.Add("Nozzle Diff Pressure", Value.Measured["ID22.Nozzle.Diff.Pressure"]);
            inVar.Add("Atmospheric Pressure", Value.Measured["ID2.Atm.Pressure"]);
            inVar.Add("Static Pressure", Value.Measured["ID22.Static.Pressure"]);
            inVar.Add("Nozzle Inlet Temp", Value.Measured["ID22.Nozzle.Inlet.Temp"]);

            outVar.Clear();
            outVar.Add("Capacity", Value.Calcurated["ID22.Capacity"]);
            outVar.Add("Drain Weight", Value.Calcurated["ID22.Drain.Weight"]);
            outVar.Add("Latent Heat", Value.Calcurated["ID22.Latent.Heat"]);
            outVar.Add("Sensible Heat", Value.Calcurated["ID22.Sensible.Heat"]);
            outVar.Add("Sensible Heat Ratio", Value.Calcurated["ID22.Sensible.Heat.Ratio"]);
            outVar.Add("Heat Leakage", Value.Calcurated["ID22.Heat.Leakage"]);
            outVar.Add("Entering RH", Value.Calcurated["ID22.Entering.RH"]);
            outVar.Add("Leaving RH", Value.Calcurated["ID22.Leaving.RH"]);
            outVar.Add("Entering Enthalpy", Value.Calcurated["ID22.Entering.Enthalpy"]);
            outVar.Add("Leaving Enthalpy", Value.Calcurated["ID22.Leaving.Enthalpy"]);
            outVar.Add("Entering Humidity Ratio", Value.Calcurated["ID22.Entering.Humidity.Ratio"]);
            outVar.Add("Leaving Humidity Ratio", Value.Calcurated["ID22.Leaving.Humidity.Ratio"]);
            outVar.Add("Leaving Specific Heat", Value.Calcurated["ID22.Leaving.Specific.Heat"]);
            outVar.Add("Leaving Specific Volume", Value.Calcurated["ID22.Leaving.Specific.Volume"]);
            outVar.Add("Air Flow [Lev]", Value.Calcurated["ID22.Air.Flow.Lev"]);
            outVar.Add("Air Velocity [Lev]", Value.Calcurated["ID22.Air.Velocity.Lev"]);

            CalcAir(Resource.Settings.Coefficients[3], sch.Indoor2Mode2, sch.Indoor2Duct2, inVar, outVar);

            if (sch.Indoor2Mode2 == EIndoorMode.NotUsed)
            {
                Value.Calcurated["ID22.Capacity.Ratio"].StoredValue = 0;
            }
            else
            {
                int mode = (sch.Indoor2Mode2 == EIndoorMode.Cooling) ? 0 : 1;

                if (Condition.Rateds[EConditionRated.ID22][mode].Capacity == 0)
                {
                    Value.Calcurated["ID22.Capacity.Ratio"].StoredValue = 0;
                }
                else
                {
                    Value.Calcurated["ID22.Capacity.Ratio"].StoredValue =
                        Value.Calcurated["ID22.Capacity"].Value / Condition.Rateds[EConditionRated.ID22][mode].Capacity * 100.0f;
                }
            }

            inVar.Clear();
            inVar.Add("Entering DB", Value.Measured["OD.Entering.DB"]);
            inVar.Add("Entering WB", Value.Measured["OD.Entering.WB"]);
            inVar.Add("Atmospheric Pressure", Value.Measured["ID1.Atm.Pressure"]);

            outVar.Clear();
            outVar.Add("Entering RH", Value.Calcurated["OD.Entering.RH"]);

            CalcAir(null, EIndoorMode.Cooling, EIndoorDuct.NotUsed, inVar, outVar);

            Value.Calcurated["Total.Capacity"].StoredValue =
                (Value.Calcurated["ID11.Capacity"].Raw + Value.Calcurated["ID12.Capacity"].Raw +
                Value.Calcurated["ID21.Capacity"].Raw + Value.Calcurated["ID22.Capacity"].Raw);

            if (Value.Calcurated["Total.Power"].Raw == 0)
            {
                Value.Calcurated["Total.EER_COP"].StoredValue = 0f;
            }
            else
            {
                Value.Calcurated["Total.EER_COP"].StoredValue =
                    Value.Calcurated["Total.Capacity"].Raw / Value.Calcurated["Total.Power"].Raw;
            }
        }

        private void FinalizeCalc()
        {
            CalcTotalRatio();
            CalcOutdoorDP();    // DP Sensor 사용시
            //CalcOutdoorRH();  // RH Sensor 사용시

            Value.Calcurated["OD.Sat.Dis.Temp1"].StoredValue = 0;
            Value.Calcurated["OD.Sat.Suc.Temp1"].StoredValue = 0;
            Value.Calcurated["OD.Sub.Cooling1"].StoredValue = 0;
            Value.Calcurated["OD.Super.Heat1"].StoredValue = 0;
            Value.Calcurated["OD.Sat.Dis.Temp2"].StoredValue = 0;
            Value.Calcurated["OD.Sat.Suc.Temp2"].StoredValue = 0;
            Value.Calcurated["OD.Sub.Cooling2"].StoredValue = 0;
            Value.Calcurated["OD.Super.Heat2"].StoredValue = 0;
        }

        private void CalcNozzle()
        {
            UInt16 value = (UInt16)(((UInt16)Value.Measured["PLC1.01"].Raw) >> 12);
            Value.Calcurated["ID11.Nozzle"].StoredValue = value;
            Value.Calcurated["ID11.Nozzle.1"].StoredValue = (UlBits.Get((byte)value, 0) == true) ? 1 : 0;
            Value.Calcurated["ID11.Nozzle.2"].StoredValue = (UlBits.Get((byte)value, 1) == true) ? 1 : 0;
            Value.Calcurated["ID11.Nozzle.3"].StoredValue = (UlBits.Get((byte)value, 2) == true) ? 1 : 0;
            Value.Calcurated["ID11.Nozzle.4"].StoredValue = (UlBits.Get((byte)value, 3) == true) ? 1 : 0;

            value = (UInt16)((((UInt16)Value.Measured["PLC1.02"].Raw) >> 1) & 0x000F);
            Value.Calcurated["ID12.Nozzle"].StoredValue = value;
            Value.Calcurated["ID12.Nozzle.1"].StoredValue = (UlBits.Get((byte)value, 0) == true) ? 1 : 0;
            Value.Calcurated["ID12.Nozzle.2"].StoredValue = (UlBits.Get((byte)value, 1) == true) ? 1 : 0;
            Value.Calcurated["ID12.Nozzle.3"].StoredValue = (UlBits.Get((byte)value, 2) == true) ? 1 : 0;
            Value.Calcurated["ID12.Nozzle.4"].StoredValue = (UlBits.Get((byte)value, 3) == true) ? 1 : 0;

            value = (UInt16)(((((UInt16)Value.Measured["PLC1.03"].Raw) & 0xC000) >> 14) | ((((UInt16)Value.Measured["PLC1.04"].Raw) & 0x0003) << 2));
            Value.Calcurated["ID21.Nozzle"].StoredValue = value;
            Value.Calcurated["ID21.Nozzle.1"].StoredValue = (UlBits.Get((byte)value, 0) == true) ? 1 : 0;
            Value.Calcurated["ID21.Nozzle.2"].StoredValue = (UlBits.Get((byte)value, 1) == true) ? 1 : 0;
            Value.Calcurated["ID21.Nozzle.3"].StoredValue = (UlBits.Get((byte)value, 2) == true) ? 1 : 0;
            Value.Calcurated["ID21.Nozzle.4"].StoredValue = (UlBits.Get((byte)value, 3) == true) ? 1 : 0;

            value = (UInt16)((((UInt16)Value.Measured["PLC1.04"].Raw) >> 3) & 0x000F);
            Value.Calcurated["ID22.Nozzle"].StoredValue = value;
            Value.Calcurated["ID22.Nozzle.1"].StoredValue = (UlBits.Get((byte)value, 0) == true) ? 1 : 0;
            Value.Calcurated["ID22.Nozzle.2"].StoredValue = (UlBits.Get((byte)value, 1) == true) ? 1 : 0;
            Value.Calcurated["ID22.Nozzle.3"].StoredValue = (UlBits.Get((byte)value, 2) == true) ? 1 : 0;
            Value.Calcurated["ID22.Nozzle.4"].StoredValue = (UlBits.Get((byte)value, 3) == true) ? 1 : 0;
        }

        private void CalcTotalRatio()
        {
            // Capacity Ratio
            try
            {
                Value.Calcurated["Total.Capacity.Ratio"].StoredValue =
                    Value.Calcurated["Total.Capacity"].Value / Value.Const["Total.Rated.Capacity"].Raw * 100f;
            }
            catch
            {
                Value.Calcurated["Total.Capacity.Ratio"].StoredValue = 0;
            }

            // Power Input Ratio
            try
            {
                Value.Calcurated["Total.Power.Ratio"].StoredValue =
                    Value.Calcurated["Total.Power"].Raw / Value.Const["Total.Rated.Power"].Raw * 100f;
            }
            catch
            {
                Value.Calcurated["Total.Power.Ratio"].StoredValue = 0;
            }

            // EER/COP Ratio
            try
            {
                Value.Calcurated["Total.EER_COP.Ratio"].StoredValue =
                    Value.Calcurated["Total.EER_COP"].Value / Value.Const["Total.Rated.EER_COP"].Raw * 100f;
            }
            catch
            {
                Value.Calcurated["Total.EER_COP.Ratio"].StoredValue = 0;
            }

            // Current Ratio
            try
            {
                Value.Calcurated["Total.Current.Ratio"].StoredValue =
                    Value.Calcurated["Total.Current"].Raw / Value.Const["Total.Rated.Current"].Raw * 100f;
            }
            catch
            {
                Value.Calcurated["Total.Current.Ratio"].StoredValue = 0;
            }
        }

        private void CalcOutdoorDP()
        {
            ConditionSchedule sch = Condition.Schedules[Index];
            double OD1_EnteringDB = Value.Measured["OD.Entering.DB"].Raw;
            double OD1_EnteringWB = Value.Measured["OD.Entering.WB"].Raw;
            double ID1_AtmosphericPressure = Value.Measured["ID1.Atm.Pressure"].Raw;
            double OD1_EnteringDP = Value.Measured["OD.Entering.DP"].Raw;

            // DP 사용이거나 Outdoor Entering DB가 0도 미만일 경우 측정값 사용. 아닌경우 계산값 사용
            if ((sch.OutdoorDpSensor != EEtcUse.Use) && (OD1_EnteringDB >= 0))
            {
                double epws = AirFormula.GetPws(OD1_EnteringWB);                    // Entering WB 기준 포화수증기압
                double exs = AirFormula.GetXs(ID1_AtmosphericPressure, epws);       // Entering WB 기준 포화절대습도                
                double exw = AirFormula.GetXw(OD1_EnteringDB, OD1_EnteringWB, exs); // Entering 절대습도

                var dp = AirFormula.GetDp(ID1_AtmosphericPressure, OD1_EnteringDB, exw);

                Value.Measured["OD.Entering.DP"].Value = (float)dp;
            }

            if (OD1_EnteringDB < 0)
            {
                var pws = AirFormula.GetPws(OD1_EnteringDP);
                var pws2 = AirFormula.GetPws(OD1_EnteringDB);

                var xs = AirFormula.GetXs(AirFormula.Pb, pws);
                var rh = AirFormula.GetRh(AirFormula.Pb, pws2, xs, 0, OD1_EnteringDB);

                Value.Calcurated["OD.Entering.RH"].Value = (float)rh;
            }
        }

        private void CalcOutdoorRH()
        {
            ConditionSchedule sch = Condition.Schedules[Index];
            double OD1_EnteringDB = Value.Measured["OD.Entering.DB"].Raw;
            double OD1_EnteringWB = Value.Measured["OD.Entering.WB"].Raw;
            double ID1_AtmosphericPressure = Value.Measured["ID1.Atm.Pressure"].Raw;
            double OD1_EnteringRH = Value.Measured["OD.Entering.RH"].Raw;

            // RH 사용이거나 Outdoor Entering DB가 0도 미만일 경우 측정값 사용. 아닌경우 계산값 사용
            if (sch.OutdoorDpSensor == EEtcUse.Use || OD1_EnteringDB < 0)
                Value.Measured["OD.Entering.RH"].Value = (float)OD1_EnteringRH;

            // 노점 온도 계산
            if (OD1_EnteringDB >= 0)
            {
                double epws = AirFormula.GetPws(OD1_EnteringWB);                    // Entering WB 기준 포화수증기압
                double exs = AirFormula.GetXs(ID1_AtmosphericPressure, epws);       // Entering WB 기준 포화절대습도
                double exw = AirFormula.GetXw(OD1_EnteringDB, OD1_EnteringWB, exs); // Entering 절대습도

                var dp = AirFormula.GetDp(ID1_AtmosphericPressure, OD1_EnteringDB, exw);

                Value.Calcurated["OD.Entering.DP"].Value = (float)dp;
            }
            else
            {
                double epws = AirFormula.GetPws(OD1_EnteringDB);         // Entering WB 기준 포화수증기압
                var wb = AirFormula.GetWb(AirFormula.Pb, epws, OD1_EnteringDB, OD1_EnteringRH);

                epws = AirFormula.GetPws(wb);                            // Entering WB 기준 포화수증기압
                double exs = AirFormula.GetXs(AirFormula.Pb, epws);      // Entering WB 기준 포화절대습도                
                double exw = AirFormula.GetXwn(exs, OD1_EnteringDB, wb); // Entering 절대습도

                var dp = AirFormula.GetDp(AirFormula.Pb, OD1_EnteringDB, exw);

                Value.Calcurated["OD.Entering.DP"].Value = (float)dp;
            }
        }

        #region CalcWater
        //private void CalcWater(ModeKind2 mode, UseKind nrGtUse, Dictionary<string, MeasureValue> i, Dictionary<string, MeasureValue> o, bool isLoadSide)
        //{
        //    var waterInletTemp = i["Water Inlet Temperature"].Value;
        //    var waterOutletTemp = i["Water Outlet Temperature"].Value;

        //    var waterFlowRate = i["Water Flow Rate"].Value;
        //    var waterDensity = WaterFormula.GetWaterDensity(waterInletTemp);
        //    var massWaterFlow = WaterFormula.GetMassWaterFlow(waterFlowRate, waterDensity);

        //    var specificHeat = WaterFormula.GetSpecificHeat(waterInletTemp);

        //    var pressureDrop = i["Pressure Drop"].Value;
        //    var pumpPower = 0d;
        //    if (nrGtUse == UseKind.Use)
        //        pumpPower = WaterFormula.GetPumpPower(waterFlowRate, pressureDrop);

        //    var deltaT = 0d;
        //    var netCapacity = 0d;
        //    if (mode == ModeKind2.Cooling)
        //    {
        //        if (isLoadSide == true)
        //        {
        //            deltaT = waterInletTemp - waterOutletTemp;
        //            netCapacity = -pumpPower;
        //        }
        //        // Heat Source
        //        else
        //        {
        //            deltaT = waterOutletTemp - waterInletTemp;
        //            netCapacity = pumpPower;
        //        }
        //    }
        //    // Heating
        //    else
        //    {
        //        if (isLoadSide == true)
        //        {
        //            deltaT = waterOutletTemp - waterInletTemp;
        //            netCapacity = pumpPower;
        //        }
        //        else
        //        {
        //            deltaT = waterInletTemp - waterOutletTemp;
        //            netCapacity = -pumpPower;
        //        }
        //    }

        //    var capacity = massWaterFlow * specificHeat * deltaT * 1000;
        //    netCapacity += capacity;

        //    o["Net Capacity"].Value = netCapacity;
        //    o["Capacity"].Value = capacity;

        //    var waterFlowRateLs = WaterFormula.GetWaterFlowRateToLs(waterFlowRate);
        //    o["Water Flow Rate"].Value = waterFlowRateLs;

        //    o["Specific Heat"].Value = specificHeat;

        //    o["Water Density"].Value = waterDensity;

        //    o["Water Diff. Temperature"].Value = deltaT;

        //    o["Pressure Drop"].Value = WaterFormula.GetPressureDropTokPa(pressureDrop);
        //    o["Pump Power"].Value = pumpPower;
        //}
        #endregion

        private void CalcAir(
            CoefficientDataRow coefficient,
            EIndoorMode mode,
            EIndoorDuct duct,
            Dictionary<string, ValueRow> i,
            Dictionary<string, ValueRow> o)
        {
            if (mode == EIndoorMode.NotUsed)
            {
                foreach (KeyValuePair<string, ValueRow> row in o)
                {
                    if (row.Value != null)
                    {
                        row.Value.StoredValue = 0;
                    }
                }
                return;
            }

            double etd = i["Entering DB"].Raw;
            double etw = i["Entering WB"].Raw;

            double pb = i["Atmospheric Pressure"].Raw;

            double epds = AirFormula.GetPws(etd);         // Entering DB 기준 포화수증기압
            double epws = AirFormula.GetPws(etw);         // Entering WB 기준 포화수증기압
            double exs = AirFormula.GetXs(pb, epws);      // Entering WB 기준 포화절대습도
            double exw = AirFormula.GetXw(etd, etw, exs); // Entering 절대습도


            // ### 2-1. Entering RH (상대습도)
            o["Entering RH"].StoredValue = (float)AirFormula.GetRh(pb, epds, exw, AirFormula.GetU(exw, exs), etd);

            if (coefficient == null) return;

            double coefCapacity = (mode == EIndoorMode.Cooling) ? coefficient.CoolingCapacity : coefficient.HeatingCapacity;
            double coefAirFlow = coefficient.Airflow;

            double ltd = i["Leaving DB"].Raw;
            double ltw = i["Leaving WB"].Raw;

            double deltaT = etd - ltd;
            if (mode == EIndoorMode.Heating)
                deltaT = -deltaT;
            double qLoss = (float)GetQLoss(coefficient, mode, duct, deltaT);


            // ### 1-1. Capacity (Qac)
            double qac = 0d;

            double[] noz = GetNozzleCheckedList(i, "Nozzle1", "Nozzle2", "Nozzle3", "Nozzle4");
            double[] d = GetNozzleValueList(coefficient, noz.Length);
            //double pn = i["Nozzle Diff Pressure"].Convert((int)EUnitDiffPressure.kg_cm2);
            double pn = i["Nozzle Diff Pressure"].Raw;
            //double pc = i["Static Pressure"].Convert((int)EUnitDiffPressure.kg_cm2);
            double pc = i["Static Pressure"].Raw;
            double rho5 = AirFormula.GetRho5(ltd, ltw, pc, pb);

            double lpds = AirFormula.GetPws(ltd);    // Leaving DB 기준 포화수증기압
            double lpws = AirFormula.GetPws(ltw);    // Leaving WB 기준 포화수증기압
            double lxs = AirFormula.GetXs(pb, lpws); // Leaving WB 기준 포화절대습도
            double lxw = 0d;
            if (mode == EIndoorMode.Heating)
                lxw = exw;
            else
                lxw = AirFormula.GetXw(ltd, ltw, lxs); // Leaving 절대습도

            double nozzleInletTemp = i["Nozzle Inlet Temp"].Raw;
            double nvw = AirFormula.GetVw(AirFormula.GetVd(pb, nozzleInletTemp, lxw), lxw); // Nozzle Inlet Temp. 기준 비체적(습공기)
            double[] vx = AirFormula.GetVx(d, pn, pb, rho5, nozzleInletTemp, nvw);          // Nozzle Inlet 기준 노즐통과풍속

            double vw = AirFormula.GetVw(AirFormula.GetVd(pb, ltd, lxw), lxw);              // Leaving DB 기준 비체적(습공기)
            double yex = AirFormula.GetYex(nozzleInletTemp, ltw, pn, pc, pb);               // Nozzle Inlet 기준 팽창계수
            double ga = AirFormula.GetGa(noz, vx, d, yex, pn, AirFormula.GetVd(pb, nozzleInletTemp, lxw)); // Original 풍량
            ga *= coefAirFlow;

            double vmDry = AirFormula.GetVmDry(ga, vw, nvw, exw);                               // 체적 풍량
            double maDry = AirFormula.GetMaDry(ga, AirFormula.GetVd(pb, nozzleInletTemp, lxw)); // 질량 풍량

            if (mode == EIndoorMode.Cooling)
            {
                double haI = AirFormula.GetHa(etd, exw);
                double haO = AirFormula.GetHa(ltd, lxw);

                qac = AirFormula.GetQacCold(maDry, AirFormula.GetVd(pb, nozzleInletTemp, lxw), exw, haI, haO, qLoss); // 체적 풍량, 출구측, 입구측, 입구측, 출구측, 열손실
            }
            // Heat
            else
            {
                qac = AirFormula.GetQacHeat(maDry, AirFormula.GetVd(pb, nozzleInletTemp, lxw), lxw, etd, ltd, qLoss);
            }
            qac *= coefCapacity; // Capacity 보정계수 적용

            o["Capacity"].StoredValue = (float)qac;


            // ### 1-2. Rated Capacity
            //o["Rated Capacity"].StoredValue = ratedCondition.Capacity;


            // ### 1-3. Capacity Ratio (Capacity / Rated Capacity)
            //o["Capacity Ratio"].StoredValue = qac / ratedCondition.Capacity * 100d;


            // ### 1-8. Drain Weight (Gcw)
            double gcw = 0d;
            if (mode == EIndoorMode.Cooling)
            {
                double xwI = AirFormula.GetXw(etd, etw, exs);
                double xwO = AirFormula.GetXw(ltd, ltw, lxs);

                gcw = AirFormula.GetGcw(maDry, xwI, xwO);
            }
            // Heat
            else
            {
                gcw = 0;
            }
            o["Drain Weight"].StoredValue = (float)gcw;


            // ### 1-5. Latent Heat (Qcc)
            double qcc = 0d;

            if (mode == EIndoorMode.Cooling)
            {
                qcc = AirFormula.GetQcc(qac, gcw);
            }
            // Heat
            else
            {
                qcc = 0;
            }
            o["Latent Heat"].StoredValue = (float)qcc;


            // ### 1-4. Sensible Heat (Qs)
            double qs = 0d;

            if (mode == EIndoorMode.Cooling)
            {
                qs = qac - qcc;
            }
            // Heat
            else
            {
                qs = qac;
            }
            o["Sensible Heat"].StoredValue = (float)qs;


            // ### 1-6. Sensible Heat Ratio (SHR)
            o["Sensible Heat Ratio"].StoredValue = (float)AirFormula.GetShr(qac, qs);


            // ### 1-7. Heat Leakage (Qloss)
            o["Heat Leakage"].StoredValue = (float)qLoss;


            // ### 2-2. Leaving RH (상대습도)
            //o["Leaving RH"].Value = AirFormula.GetRh(pb, lpds, lxw, AirFormula.GetU(lxw, lxs), ltd);
            o["Leaving RH"].StoredValue = (float)AirFormula.GetRh(pb, lpds, AirFormula.GetXw(ltd, ltw, lxs), AirFormula.GetU(lxw, lxs), ltd);


            // ### 2-3. Entering Enthalpy (Ha)
            o["Entering Enthalpy"].StoredValue = (float)AirFormula.GetHa(etd, exw);


            // ### 2-4. Leaving Enthalpy (Ha)
            o["Leaving Enthalpy"].StoredValue = (float)AirFormula.GetHa(ltd, lxw);


            // ### 2-5. Entering Humidity Ratio
            o["Entering Humidity Ratio"].StoredValue = (float)exw;


            // ### 2-6. Leaving Humidity Ratio
            o["Leaving Humidity Ratio"].StoredValue = (float)lxw;


            // ### 2-7. Leaving Specific Heat
            o["Leaving Specific Heat"].StoredValue = (float)AirFormula.GetCp(lxw);


            // ### 2-8. Leaving Specific Volume
            o["Leaving Specific Volume"].StoredValue = (float)AirFormula.GetVw(AirFormula.GetVd(pb, ltd, lxw), lxw);


            // KDN 추가 (18.04.10) {{{
            // ### 2-11. Entering Specific Heat
            //if (o.ContainsKey("Entering Specific Heat") == true)
            //    o["Entering Specific Heat"].StoredValue = (float)AirFormula.GetCp(exw);


            // ### 2-12. Entering Specific Volume
            //if (o.ContainsKey("Entering Specific Volume") == true)
            //    o["Entering Specific Volume"].StoredValue = (float)AirFormula.GetVw(AirFormula.GetVd(pb, etd, exw), exw);


            // ### 2-13. Leaving Density
            //if (o.ContainsKey("Leaving Density") == true)
            //    o["Leaving Density"].StoredValue = (float)(1d / (AirFormula.GetVw(AirFormula.GetVd(pb, ltd, lxw), lxw)));
            // }}}


            // ### 3-1. Air Flow [Lev]
            o["Air Flow [Lev]"].StoredValue = (float)vmDry;


            // ### 3-2. Fan Power
            //var fanpower = 0d;
            //if (fanPowerUse == UseKind.Use)
            //    fanpower = ((vmDry / 60 * 1000) * 10e-3 * (Math.Abs(pc) * 9.80661358d)) / 0.3d;
            //o["Fan Power"].StoredValue = fanpower;


            // ### 3-3. Air Velocity [Lev]


            // ### 10-1. 냉방 시험 시 입구 절대 습도보다 출구 절대 습도가 높을 때
            if (mode == EIndoorMode.Cooling && exw <= lxw)
            {
                //var capacity = qac - Math.Abs(qcc);
                //o["Capacity"].Storage.Set(capacity);
                o["Drain Weight"].Storage.Set(0);
                o["Latent Heat"].Storage.Set(0);
                o["Sensible Heat"].Storage.Set((float)qac);
                o["Sensible Heat Ratio"].Storage.Set(100);
            }


            // ### 열교환기 관련 계산 추가 (2017.08.19)
            // ### 11-1. Capacity (Qac)
            double qLoss2 = (float)GetQLoss(coefficient, mode, duct, deltaT);

            double qac2 = 0d;

            double pb2 = pb - pc / 13.6d;
            double lxs2 = AirFormula.GetXs(pb2, lpws);
            double lxw2 = 0d;
            if (mode == EIndoorMode.Heating)
                lxw2 = exw;
            else
                lxw2 = AirFormula.GetXw(ltd, ltw, lxs2);

            double nvw2 = AirFormula.GetVw(AirFormula.GetVd(pb2, nozzleInletTemp, lxw2), lxw2);
            double[] vx2 = AirFormula.GetVx(d, pn, pb2, rho5, nozzleInletTemp, nvw2);

            double vw2 = AirFormula.GetVw(AirFormula.GetVd(pb, etd, exw), exw);
            double vw3 = AirFormula.GetVw(AirFormula.GetVd(pb2, ltd, lxw2), lxw2);
            double yex2 = AirFormula.GetYex(nozzleInletTemp, ltw, pn, pc, pb2);
            double ga2 = AirFormula.GetGa(noz, vx2, d, yex2, pn, AirFormula.GetVd(pb2, nozzleInletTemp, lxw2));
            ga2 *= coefAirFlow;

            double vmDry2 = AirFormula.GetVmDry(ga2, vw2, nvw2, exw);                               // 체적 풍량.1
            double vmDry3 = AirFormula.GetVmDry(ga2, vw3, nvw2, exw);                               // 체적 풍량.2
            double maDry2 = AirFormula.GetMaDry(ga2, AirFormula.GetVd(pb2, nozzleInletTemp, lxw2)); // 질량 풍량

            if (mode == EIndoorMode.Cooling)
            {
                double haI = AirFormula.GetHa(etd, exw);
                double haO = AirFormula.GetHa(ltd, lxw2);

                qac2 = AirFormula.GetQacCold(maDry2, AirFormula.GetVd(pb2, nozzleInletTemp, lxw2), exw, haI, haO, qLoss2);
            }
            // Heat
            else
            {
                qac2 = AirFormula.GetQacHeat(maDry2, AirFormula.GetVd(pb2, nozzleInletTemp, lxw2), lxw, etd, ltd, qLoss2);
            }
            qac2 *= coefCapacity;

            // o["Capacity"].StoredValue = qac2;


            // ### 11-8. Drain Weight (Gcw2)
            double gcw2 = 0d;
            if (mode == EIndoorMode.Cooling)
            {
                double xwI = AirFormula.GetXw(etd, etw, exs);
                double xwO = AirFormula.GetXw(ltd, ltw, lxs2);

                gcw2 = AirFormula.GetGcw(maDry2, xwI, xwO);
            }
            // Heat
            else
            {
                gcw2 = 0;
            }
            //o["Drain Weight"].StoredValue = gcw2;


            // ### 11-5. Latent Heat (Qcc2)
            double qcc2 = 0d;

            if (mode == EIndoorMode.Cooling)
            {
                qcc2 = AirFormula.GetQcc(qac2, gcw2);
            }
            // Heat
            else
            {
                qcc2 = 0;
            }
            //o["Latent Heat"].StoredValue = qcc2;


            // ### 11-4. Sensible Heat (Qs2)
            double qs2 = 0d;

            if (mode == EIndoorMode.Cooling)
            {
                qs2 = qac2 - qcc2;
            }
            // Heat
            else
            {
                qs2 = qac2;
            }
            //o["Sensible Heat"].Value = qs2;


            // ### 11-6. Sensible Heat Ratio (SHR)
            //o["Sensible Heat Ratio"].StoredValue = AirFormula.GetShr(qac2, qs2);


            // ### 12-2. Leaving RH (상대습도)
            // o["Leaving RH"].StoredValue = AirFormula.GetRh(pb2, lpds, AirFormula.GetXw(ltd, ltw, lxs2), AirFormula.GetU(lxw2, lxs2), ltd);


            // ### 12-4. Leaving Enthalpy (Ha)
            // o["Leaving Enthalpy"].StoredValue = AirFormula.GetHa(ltd, lxw2);


            // ### 12-8. Leaving Specific Heat
            // o["Leaving Specific Heat"].StoredValue = AirFormula.GetCp(lxw2);


            // ### 13-3. Air Velocity [Lev]
            if (o.ContainsKey("Air Velocity [Lev]") == true)
                o["Air Velocity [Lev]"].StoredValue = (float)GetAirVelocity(vx2, noz);
            else
                o["Air Velocity [Lev]"].StoredValue = 0;
        }

        private double[] GetNozzleValueList(CoefficientDataRow coefficient, int count)  // 노즐경 리스트
        {
            // mm -> m 단위 변환
            var list = new double[]
            {
                (double)coefficient.Nozzle1 / 1000d,
                (double)coefficient.Nozzle2 / 1000d,
                (double)coefficient.Nozzle3 / 1000d,
                (double)coefficient.Nozzle4 / 1000d,
            };

            var result = new double[count];
            Array.Copy(list, result, count);

            return result;
        }

        private double[] GetNozzleCheckedList(Dictionary<string, ValueRow> i, params string[] nozzleNames)  // 노즐 선택 여부 확인
        {
            var result = new List<double>();

            for (var idx = 0; idx < nozzleNames.Length; idx++)
            {
                var nozzleName = nozzleNames[idx];
                var value = i[nozzleName];

                if (value == null) continue;

                result.Add(value.Value);
            }

            return result.ToArray();
        }

        private double GetAirVelocity(double[] vx2, double[] nozzleOnOffList)
        {
            for (var i = 0; i < 4; i++)
            {
                vx2[i] *= nozzleOnOffList[i];
            }

            var count = 0;
            foreach (var v in nozzleOnOffList)
            {
                if (v > 0d) count++;
            }

            if (count == 0) return 0d;

            var sum = vx2.Sum();
            return sum / count;
        }

        private double GetQLoss(CoefficientDataRow coefficient, EIndoorMode mode, EIndoorDuct duct, double deltaT)
        {
            double[] hlks;
            var count = 0;

            if (duct == EIndoorDuct.NotUsed)
                count = 1;
            else
                count = (int)duct + 1 + 1;

            var result = 0d;

            if (mode == EIndoorMode.Cooling)
            {
                hlks = new double[]
                {
                    (double)coefficient.Cooling_HLK,
                    (double)coefficient.Cooling_HLK_Duct1,
                    (double)coefficient.Cooling_HLK_Duct2,
                    (double)coefficient.Cooling_HLK_Duct3,
                    (double)coefficient.Cooling_HLK_Duct4,
                    (double)coefficient.Cooling_HLK_Duct5
                };
            }
            else
            {
                hlks = new double[]
                {
                    (double)coefficient.Heating_HLK,
                    (double)coefficient.Heating_HLK_Duct1,
                    (double)coefficient.Heating_HLK_Duct2,
                    (double)coefficient.Heating_HLK_Duct3,
                    (double)coefficient.Heating_HLK_Duct4,
                    (double)coefficient.Heating_HLK_Duct5
                };
            }

            for (var i = 0; i < count; i++)
                result += AirFormula.GetQLoss(hlks[i], deltaT);

            return result;
        }

        private void SetFixedAtmPressure()
        {
            if (Resource.Settings.Options.FixedAtmPressure == true)
            {
                Value.Measured["ID1.Atm.Pressure"].Value = (float)AirFormula.Pb;
                Value.Measured["ID2.Atm.Pressure"].Value = (float)AirFormula.Pb;
            }
        }

        private void SetPowerMeterValues()
        {
            string iduHead;
            string oduHead;
            EIndoorMode mode;
            EConditionRated rated;
            float totalPower = 0;
            float totalCurrent = 0;
            ConditionSchedule sch = Condition.Schedules[Index];

            iduHead = GetHeadIDU(EConditionRated.Total, EIndoorMode.Cooling);
            oduHead = GetHeadODU(EConditionRated.Total, EIndoorMode.Cooling);

            if (iduHead == "None")
            {
                Value.Calcurated["Total.IDU.Power"].StoredValue = 0;
                Value.Calcurated["Total.IDU.Voltage"].StoredValue = 0;
                Value.Calcurated["Total.IDU.Current"].StoredValue = 0;
                Value.Calcurated["Total.IDU.Frequency"].StoredValue = 0;
                Value.Calcurated["Total.IDU.Power.Factor"].StoredValue = 0;
                Value.Calcurated["Total.IDU.Integ.Power"].StoredValue = 0;
                Value.Calcurated["Total.IDU.Integ.Time"].StoredValue = 0;
            }
            else
            {
                Value.Calcurated["Total.IDU.Power"].StoredValue = Value.Measured[iduHead + "R.W"].Raw;
                Value.Calcurated["Total.IDU.Voltage"].StoredValue = Value.Measured[iduHead + "R.V"].Raw;
                Value.Calcurated["Total.IDU.Current"].StoredValue = Value.Measured[iduHead + "R.A"].Raw;
                Value.Calcurated["Total.IDU.Frequency"].StoredValue = Value.Measured[iduHead + "R.Hz"].Raw;
                Value.Calcurated["Total.IDU.Power.Factor"].StoredValue = Value.Measured[iduHead + "R.PF"].Raw * 100.0f;
                Value.Calcurated["Total.IDU.Integ.Power"].StoredValue = Value.Measured[iduHead + "R.Wh"].Raw;
                Value.Calcurated["Total.IDU.Integ.Time"].StoredValue = Value.Measured[iduHead + "Time"].Raw;
            }

            if (oduHead == "None")
            {
                Value.Calcurated["Total.ODU.Power"].StoredValue = 0;
                Value.Calcurated["Total.ODU.Voltage"].StoredValue = 0;
                Value.Calcurated["Total.ODU.Current"].StoredValue = 0;
                Value.Calcurated["Total.ODU.Frequency"].StoredValue = 0;
                Value.Calcurated["Total.ODU.Power.Factor"].StoredValue = 0;
                Value.Calcurated["Total.ODU.Integ.Power"].StoredValue = 0;
                Value.Calcurated["Total.ODU.Integ.Time"].StoredValue = 0;
            }
            else
            {
                switch (GetWiringODU(EConditionRated.Total, EIndoorMode.Cooling))
                {
                    case EWT330Wiring.P1W3:
                        Value.Calcurated["Total.ODU.Power"].StoredValue = Value.Measured[oduHead + "R.W"].Raw;
                        Value.Calcurated["Total.ODU.Voltage"].StoredValue = Value.Measured[oduHead + "R.V"].Raw;
                        Value.Calcurated["Total.ODU.Current"].StoredValue = Value.Measured[oduHead + "R.A"].Raw;
                        Value.Calcurated["Total.ODU.Frequency"].StoredValue = Value.Measured[oduHead + "R.Hz"].Raw;
                        Value.Calcurated["Total.ODU.Power.Factor"].StoredValue = Value.Measured[oduHead + "R.PF"].Raw * 100.0f;
                        Value.Calcurated["Total.ODU.Integ.Power"].StoredValue = Value.Measured[oduHead + "R.Wh"].Raw;
                        Value.Calcurated["Total.ODU.Integ.Time"].StoredValue = Value.Measured[oduHead + "Time"].Raw;
                        break;

                    case EWT330Wiring.P3W3:
                        Value.Calcurated["Total.ODU.Power"].StoredValue = Value.Measured[oduHead + "Sigma.W"].Raw;
                        Value.Calcurated["Total.ODU.Voltage"].StoredValue = Value.Measured[oduHead + "Sigma.V"].Raw;
                        Value.Calcurated["Total.ODU.Current"].StoredValue = Value.Measured[oduHead + "Sigma.A"].Raw;
                        Value.Calcurated["Total.ODU.Frequency"].StoredValue = Value.Measured[oduHead + "Sigma.Hz"].Raw;
                        Value.Calcurated["Total.ODU.Power.Factor"].StoredValue = Value.Measured[oduHead + "Sigma.PF"].Raw * 100.0f;
                        Value.Calcurated["Total.ODU.Integ.Power"].StoredValue = Value.Measured[oduHead + "Sigma.Wh"].Raw;
                        Value.Calcurated["Total.ODU.Integ.Time"].StoredValue = Value.Measured[oduHead + "Time"].Raw;
                        break;

                    case EWT330Wiring.P3W4:
                        Value.Calcurated["Total.ODU.Power"].StoredValue = Value.Measured[oduHead + "Sigma.W"].Raw;
                        Value.Calcurated["Total.ODU.Voltage"].StoredValue = Value.Measured[oduHead + "Sigma.V"].Raw;
                        Value.Calcurated["Total.ODU.Current"].StoredValue = Value.Measured[oduHead + "Sigma.A"].Raw;
                        Value.Calcurated["Total.ODU.Frequency"].StoredValue = Value.Measured[oduHead + "Sigma.Hz"].Raw;
                        Value.Calcurated["Total.ODU.Power.Factor"].StoredValue = Value.Measured[oduHead + "Sigma.PF"].Raw * 100.0f;
                        Value.Calcurated["Total.ODU.Integ.Power"].StoredValue = Value.Measured[oduHead + "Sigma.Wh"].Raw;
                        Value.Calcurated["Total.ODU.Integ.Time"].StoredValue = Value.Measured[oduHead + "Time"].Raw;
                        break;
                }
            }

            if (sch.Indoor1Use == EIndoorUse.NotUsed)
            {
                Value.Calcurated["ID1.IDU.Power"].StoredValue = 0;
                Value.Calcurated["ID1.IDU.Voltage"].StoredValue = 0;
                Value.Calcurated["ID1.IDU.Current"].StoredValue = 0;
                Value.Calcurated["ID1.IDU.Frequency"].StoredValue = 0;
                Value.Calcurated["ID1.IDU.Power.Factor"].StoredValue = 0;
                Value.Calcurated["ID1.IDU.Integ.Power"].StoredValue = 0;
                Value.Calcurated["ID1.IDU.Integ.Time"].StoredValue = 0;

                Value.Calcurated["ID1.ODU.Power"].StoredValue = 0;
                Value.Calcurated["ID1.ODU.Voltage"].StoredValue = 0;
                Value.Calcurated["ID1.ODU.Current"].StoredValue = 0;
                Value.Calcurated["ID1.ODU.Frequency"].StoredValue = 0;
                Value.Calcurated["ID1.ODU.Power.Factor"].StoredValue = 0;
                Value.Calcurated["ID1.ODU.Integ.Power"].StoredValue = 0;
                Value.Calcurated["ID1.ODU.Integ.Time"].StoredValue = 0;
            }
            else
            {
                if (sch.Indoor1Mode1 != EIndoorMode.NotUsed)
                {
                    mode = sch.Indoor1Mode1;
                    rated = EConditionRated.ID11;
                }
                else if (sch.Indoor1Mode2 != EIndoorMode.NotUsed)
                {
                    mode = sch.Indoor1Mode2;
                    rated = EConditionRated.ID12;
                }
                else
                {
                    mode = EIndoorMode.Cooling;
                    rated = EConditionRated.ID11;
                }

                iduHead = GetHeadIDU(rated, mode);
                oduHead = GetHeadODU(rated, mode);

                if (iduHead == "None")
                {
                    Value.Calcurated["ID1.IDU.Power"].StoredValue = 0;
                    Value.Calcurated["ID1.IDU.Voltage"].StoredValue = 0;
                    Value.Calcurated["ID1.IDU.Current"].StoredValue = 0;
                    Value.Calcurated["ID1.IDU.Frequency"].StoredValue = 0;
                    Value.Calcurated["ID1.IDU.Power.Factor"].StoredValue = 0;
                    Value.Calcurated["ID1.IDU.Integ.Power"].StoredValue = 0;
                    Value.Calcurated["ID1.IDU.Integ.Time"].StoredValue = 0;
                }
                else
                {
                    Value.Calcurated["ID1.IDU.Power"].StoredValue = Value.Measured[iduHead + "R.W"].Raw;
                    Value.Calcurated["ID1.IDU.Voltage"].StoredValue = Value.Measured[iduHead + "R.V"].Raw;
                    Value.Calcurated["ID1.IDU.Current"].StoredValue = Value.Measured[iduHead + "R.A"].Raw;
                    Value.Calcurated["ID1.IDU.Frequency"].StoredValue = Value.Measured[iduHead + "R.Hz"].Raw;
                    Value.Calcurated["ID1.IDU.Power.Factor"].StoredValue = Value.Measured[iduHead + "R.PF"].Raw * 100.0f;
                    Value.Calcurated["ID1.IDU.Integ.Power"].StoredValue = Value.Measured[iduHead + "R.Wh"].Raw;
                    Value.Calcurated["ID1.IDU.Integ.Time"].StoredValue = Value.Measured[iduHead + "Time"].Raw;
                }

                if (oduHead == "None")
                {
                    Value.Calcurated["ID1.ODU.Power"].StoredValue = 0;
                    Value.Calcurated["ID1.ODU.Voltage"].StoredValue = 0;
                    Value.Calcurated["ID1.ODU.Current"].StoredValue = 0;
                    Value.Calcurated["ID1.ODU.Frequency"].StoredValue = 0;
                    Value.Calcurated["ID1.ODU.Power.Factor"].StoredValue = 0;
                    Value.Calcurated["ID1.ODU.Integ.Power"].StoredValue = 0;
                    Value.Calcurated["ID1.ODU.Integ.Time"].StoredValue = 0;
                }
                else
                {
                    switch (GetWiringODU(rated, mode))
                    {
                        case EWT330Wiring.P1W3:
                            Value.Calcurated["ID1.ODU.Power"].StoredValue = Value.Measured[oduHead + "R.W"].Raw;
                            Value.Calcurated["ID1.ODU.Voltage"].StoredValue = Value.Measured[oduHead + "R.V"].Raw;
                            Value.Calcurated["ID1.ODU.Current"].StoredValue = Value.Measured[oduHead + "R.A"].Raw;
                            Value.Calcurated["ID1.ODU.Frequency"].StoredValue = Value.Measured[oduHead + "R.Hz"].Raw;
                            Value.Calcurated["ID1.ODU.Power.Factor"].StoredValue = Value.Measured[oduHead + "R.PF"].Raw * 100.0f;
                            Value.Calcurated["ID1.ODU.Integ.Power"].StoredValue = Value.Measured[oduHead + "R.Wh"].Raw;
                            Value.Calcurated["ID1.ODU.Integ.Time"].StoredValue = Value.Measured[oduHead + "Time"].Raw;
                            break;

                        case EWT330Wiring.P3W3:
                            Value.Calcurated["ID1.ODU.Power"].StoredValue = Value.Measured[oduHead + "Sigma.W"].Raw;
                            Value.Calcurated["ID1.ODU.Voltage"].StoredValue = Value.Measured[oduHead + "Sigma.V"].Raw;
                            Value.Calcurated["ID1.ODU.Current"].StoredValue = Value.Measured[oduHead + "Sigma.A"].Raw;
                            Value.Calcurated["ID1.ODU.Frequency"].StoredValue = Value.Measured[oduHead + "Sigma.Hz"].Raw;
                            Value.Calcurated["ID1.ODU.Power.Factor"].StoredValue = Value.Measured[oduHead + "Sigma.PF"].Raw * 100.0f;
                            Value.Calcurated["ID1.ODU.Integ.Power"].StoredValue = Value.Measured[oduHead + "Sigma.Wh"].Raw;
                            Value.Calcurated["ID1.ODU.Integ.Time"].StoredValue = Value.Measured[oduHead + "Time"].Raw;
                            break;

                        case EWT330Wiring.P3W4:
                            Value.Calcurated["ID1.ODU.Power"].StoredValue = Value.Measured[oduHead + "Sigma.W"].Raw;
                            Value.Calcurated["ID1.ODU.Voltage"].StoredValue = Value.Measured[oduHead + "Sigma.V"].Raw;
                            Value.Calcurated["ID1.ODU.Current"].StoredValue = Value.Measured[oduHead + "Sigma.A"].Raw;
                            Value.Calcurated["ID1.ODU.Frequency"].StoredValue = Value.Measured[oduHead + "Sigma.Hz"].Raw;
                            Value.Calcurated["ID1.ODU.Power.Factor"].StoredValue = Value.Measured[oduHead + "Sigma.PF"].Raw * 100.0f;
                            Value.Calcurated["ID1.ODU.Integ.Power"].StoredValue = Value.Measured[oduHead + "Sigma.Wh"].Raw;
                            Value.Calcurated["ID1.ODU.Integ.Time"].StoredValue = Value.Measured[oduHead + "Time"].Raw;
                            break;
                    }
                }

                totalPower += Value.Calcurated["ID1.IDU.Power"].Raw;
                totalPower += Value.Calcurated["ID1.ODU.Power"].Raw;

                totalCurrent += Value.Calcurated["ID1.IDU.Current"].Raw;
                totalCurrent += Value.Calcurated["ID1.ODU.Current"].Raw;
            }

            if (sch.Indoor2Use == EIndoorUse.NotUsed)
            {
                Value.Calcurated["ID2.IDU.Power"].StoredValue = 0;
                Value.Calcurated["ID2.IDU.Voltage"].StoredValue = 0;
                Value.Calcurated["ID2.IDU.Current"].StoredValue = 0;
                Value.Calcurated["ID2.IDU.Frequency"].StoredValue = 0;
                Value.Calcurated["ID2.IDU.Power.Factor"].StoredValue = 0;
                Value.Calcurated["ID2.IDU.Integ.Power"].StoredValue = 0;
                Value.Calcurated["ID2.IDU.Integ.Time"].StoredValue = 0;

                Value.Calcurated["ID2.ODU.Power"].StoredValue = 0;
                Value.Calcurated["ID2.ODU.Voltage"].StoredValue = 0;
                Value.Calcurated["ID2.ODU.Current"].StoredValue = 0;
                Value.Calcurated["ID2.ODU.Frequency"].StoredValue = 0;
                Value.Calcurated["ID2.ODU.Power.Factor"].StoredValue = 0;
                Value.Calcurated["ID2.ODU.Integ.Power"].StoredValue = 0;
                Value.Calcurated["ID2.ODU.Integ.Time"].StoredValue = 0;
            }
            else
            {
                if (sch.Indoor2Mode1 != EIndoorMode.NotUsed)
                {
                    mode = sch.Indoor2Mode1;
                    rated = EConditionRated.ID21;
                }
                else if (sch.Indoor2Mode2 != EIndoorMode.NotUsed)
                {
                    mode = sch.Indoor2Mode2;
                    rated = EConditionRated.ID22;
                }
                else
                {
                    mode = EIndoorMode.Cooling;
                    rated = EConditionRated.ID21;
                }

                iduHead = GetHeadIDU(rated, mode);
                oduHead = GetHeadODU(rated, mode);

                if (iduHead == "None")
                {
                    Value.Calcurated["ID2.IDU.Power"].StoredValue = 0;
                    Value.Calcurated["ID2.IDU.Voltage"].StoredValue = 0;
                    Value.Calcurated["ID2.IDU.Current"].StoredValue = 0;
                    Value.Calcurated["ID2.IDU.Frequency"].StoredValue = 0;
                    Value.Calcurated["ID2.IDU.Power.Factor"].StoredValue = 0;
                    Value.Calcurated["ID2.IDU.Integ.Power"].StoredValue = 0;
                    Value.Calcurated["ID2.IDU.Integ.Time"].StoredValue = 0;
                }
                else
                {
                    Value.Calcurated["ID2.IDU.Power"].StoredValue = Value.Measured[iduHead + "R.W"].Raw;
                    Value.Calcurated["ID2.IDU.Voltage"].StoredValue = Value.Measured[iduHead + "R.V"].Raw;
                    Value.Calcurated["ID2.IDU.Current"].StoredValue = Value.Measured[iduHead + "R.A"].Raw;
                    Value.Calcurated["ID2.IDU.Frequency"].StoredValue = Value.Measured[iduHead + "R.Hz"].Raw;
                    Value.Calcurated["ID2.IDU.Power.Factor"].StoredValue = Value.Measured[iduHead + "R.PF"].Raw * 100.0f;
                    Value.Calcurated["ID2.IDU.Integ.Power"].StoredValue = Value.Measured[iduHead + "R.Wh"].Raw;
                    Value.Calcurated["ID2.IDU.Integ.Time"].StoredValue = Value.Measured[iduHead + "Time"].Raw;
                }

                if (oduHead == "None")
                {
                    Value.Calcurated["ID2.ODU.Power"].StoredValue = 0;
                    Value.Calcurated["ID2.ODU.Voltage"].StoredValue = 0;
                    Value.Calcurated["ID2.ODU.Current"].StoredValue = 0;
                    Value.Calcurated["ID2.ODU.Frequency"].StoredValue = 0;
                    Value.Calcurated["ID2.ODU.Power.Factor"].StoredValue = 0;
                    Value.Calcurated["ID2.ODU.Integ.Power"].StoredValue = 0;
                    Value.Calcurated["ID2.ODU.Integ.Time"].StoredValue = 0;
                }
                else
                {
                    switch (GetWiringODU(rated, mode))
                    {
                        case EWT330Wiring.P1W3:
                            Value.Calcurated["ID2.ODU.Power"].StoredValue = Value.Measured[oduHead + "R.W"].Raw;
                            Value.Calcurated["ID2.ODU.Voltage"].StoredValue = Value.Measured[oduHead + "R.V"].Raw;
                            Value.Calcurated["ID2.ODU.Current"].StoredValue = Value.Measured[oduHead + "R.A"].Raw;
                            Value.Calcurated["ID2.ODU.Frequency"].StoredValue = Value.Measured[oduHead + "R.Hz"].Raw;
                            Value.Calcurated["ID2.ODU.Power.Factor"].StoredValue = Value.Measured[oduHead + "R.PF"].Raw * 100.0f;
                            Value.Calcurated["ID2.ODU.Integ.Power"].StoredValue = Value.Measured[oduHead + "R.Wh"].Raw;
                            Value.Calcurated["ID2.ODU.Integ.Time"].StoredValue = Value.Measured[oduHead + "Time"].Raw;
                            break;

                        case EWT330Wiring.P3W3:
                            Value.Calcurated["ID2.ODU.Power"].StoredValue = Value.Measured[oduHead + "Sigma.W"].Raw;
                            Value.Calcurated["ID2.ODU.Voltage"].StoredValue = Value.Measured[oduHead + "Sigma.V"].Raw;
                            Value.Calcurated["ID2.ODU.Current"].StoredValue = Value.Measured[oduHead + "Sigma.A"].Raw;
                            Value.Calcurated["ID2.ODU.Frequency"].StoredValue = Value.Measured[oduHead + "Sigma.Hz"].Raw;
                            Value.Calcurated["ID2.ODU.Power.Factor"].StoredValue = Value.Measured[oduHead + "Sigma.PF"].Raw * 100.0f;
                            Value.Calcurated["ID2.ODU.Integ.Power"].StoredValue = Value.Measured[oduHead + "Sigma.Wh"].Raw;
                            Value.Calcurated["ID2.ODU.Integ.Time"].StoredValue = Value.Measured[oduHead + "Time"].Raw;
                            break;

                        case EWT330Wiring.P3W4:
                            Value.Calcurated["ID2.ODU.Power"].StoredValue = Value.Measured[oduHead + "Sigma.W"].Raw;
                            Value.Calcurated["ID2.ODU.Voltage"].StoredValue = Value.Measured[oduHead + "Sigma.V"].Raw;
                            Value.Calcurated["ID2.ODU.Current"].StoredValue = Value.Measured[oduHead + "Sigma.A"].Raw;
                            Value.Calcurated["ID2.ODU.Frequency"].StoredValue = Value.Measured[oduHead + "Sigma.Hz"].Raw;
                            Value.Calcurated["ID2.ODU.Power.Factor"].StoredValue = Value.Measured[oduHead + "Sigma.PF"].Raw * 100.0f;
                            Value.Calcurated["ID2.ODU.Integ.Power"].StoredValue = Value.Measured[oduHead + "Sigma.Wh"].Raw;
                            Value.Calcurated["ID2.ODU.Integ.Time"].StoredValue = Value.Measured[oduHead + "Time"].Raw;
                            break;
                    }
                }

                totalPower += Value.Calcurated["ID2.IDU.Power"].Raw;
                totalPower += Value.Calcurated["ID2.ODU.Power"].Raw;

                totalCurrent += Value.Calcurated["ID2.IDU.Current"].Raw;
                totalCurrent += Value.Calcurated["ID2.ODU.Current"].Raw;
            }

            Value.Calcurated["Total.Power"].StoredValue = totalPower;
            Value.Calcurated["Total.Current"].StoredValue = totalCurrent;
        }

        private string GetHeadIDU(EConditionRated rated, EIndoorMode mode)
        {
            int i = 0;
            int j = 0;
            int pmNo = Condition.Rateds[rated][(int)mode].PM_IDU;
            string sRet = "None";

            foreach (PowerMeterRow<float> row in Resource.Client.Devices.PowerMeter.Rows)
            {
                if (row.Phase == EWT330Phase.P1)
                {
                    if (j == pmNo)
                    {
                        sRet = $"PM{i + 1}.";
                        break;
                    }
                    else
                    {
                        j++;
                    }
                }

                i++;
            }

            return sRet;
        }

        private string GetHeadODU(EConditionRated rated, EIndoorMode mode)
        {
            int i = 0;
            int j = 0;
            int pmNo = Condition.Rateds[rated][(int)mode].PM_ODU;
            string sRet = "None";

            foreach (PowerMeterRow<float> row in Resource.Client.Devices.PowerMeter.Rows)
            {
                if (row.Phase == EWT330Phase.P3)
                {
                    if (j == pmNo)
                    {
                        sRet = $"PM{i + 1}.";
                        break;
                    }
                    else
                    {
                        j++;
                    }
                }

                i++;
            }

            return sRet;
        }

        private EWT330Wiring GetWiringODU(EConditionRated rated, EIndoorMode mode)
        {
            return Condition.Rateds[rated][(int)mode].Wiring;
        }

        private string GetNameIDU(int index)
        {
            int i = 0;
            int j = 0;
            string sRet = "None";

            foreach (PowerMeterRow<float> row in Resource.Client.Devices.PowerMeter.Rows)
            {
                if (row.Phase == EWT330Phase.P1)
                {
                    if (j == index)
                    {
                        sRet = row.Name;
                        break;
                    }
                    else
                    {
                        j++;
                    }
                }

                i++;
            }

            return sRet;
        }

        private string GetNameODU(int index)
        {
            int i = 0;
            int j = 0;
            string sRet = "None";

            foreach (PowerMeterRow<float> row in Resource.Client.Devices.PowerMeter.Rows)
            {
                if (row.Phase == EWT330Phase.P3)
                {
                    if (j == index)
                    {
                        sRet = row.Name;
                        break;
                    }
                    else
                    {
                        j++;
                    }
                }

                i++;
            }

            return sRet;
        }

        private void LoadMeasuredValues()
        {
            int i = 0;
            int j = 0;
            
            Resource.Client.Listener.Lock();

            try
            {
                foreach (KeyValuePair<string, ValueRow> row in Value.Measured)
                {
                    if (i < Resource.Client.Listener.FValues.Length)
                    {
                        row.Value.StoredValue = Resource.Client.Listener.FValues[i++];
                    }
                    else
                    {
                        row.Value.StoredValue = Resource.Client.Listener.NValues[j++];
                    }

                    if (row.Value.Unit.Type == EUnitType.Temperature)
                    {
                        if (row.Value.Value < csLimitedTemp)
                        {
                            row.Value.Value = csMinimumTemp;
                        }
                    }
                }
            }
            finally
            {
                Resource.Client.Listener.Unlock();
            }
        }
    }
    #endregion
}