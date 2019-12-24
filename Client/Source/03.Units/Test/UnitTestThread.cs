﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using FirebirdSql.Data.FirebirdClient;

using Ulee.Device.Connection.Yokogawa;
using Ulee.DllImport.Win32;
using Ulee.Threading;
using Ulee.Utils;

namespace Hnc.Calorimeter.Client
{
    public enum ETestMessage
    {
        None,
        Next,
        Reset
    }

    public enum ETestStep
    {
        None,
        Preparation,
        Judgement,
        Integration
    }

    public enum EWorkSheet
    {
        Current = -1,
        Title,
        I1,
        I2,
        I3,
        I4,
        I5,
        I6,
        I7
    }

    public class TestDescriptionArgs : EventArgs
    {
        public TestDescriptionArgs()
        {
            Index = 0;
            Name = "None";
            Step = ETestStep.None;
        }

        public int Index { get; set; }
        public string Name { get; set; }
        public ETestStep Step { get; set; }
        public long ElapsedTime { get; set; }
        public long TotalElapsedTime { get; set; }
        public long PrepareCurTime { get; set; }
        public long PrepareMaxTime { get; set; }
        public long JudgeCurTime { get; set; }
        public long JudgeMaxTime { get; set; }
        public long IntegCurTime { get; set; }
        public long IntegMaxTime { get; set; }
        public int JudgeCount { get; set; }
        public int JudgeMax { get; set; }
        public int RepeatCount { get; set; }
        public int RepeatMax { get; set; }
        public int ScheduleCount { get; set; }
        public int ScheduleMax { get; set; }
    }

    public class TestSpreadSheetArgs : EventArgs
    {
        public TestSpreadSheetArgs()
        {
            Index = EWorkSheet.Title;
            SettingAverage = false;
            Report = null;
        }

        public EWorkSheet Index { get; set; }
        public bool SettingAverage { get; set; }
        public TestReport Report { get; set; }
    }

    public class CalorimeterTestThread : UlThread
    {
        public CalorimeterTestThread(TestContext context) : base(false, true)
        {
            InvalidContext = false;
            this.context = context;
            this.prevRawTicks = 0;
            this.totalWatch = new Stopwatch();
            this.sheetArgs = new TestSpreadSheetArgs();
            this.descArgs = new TestDescriptionArgs();
            this.descArgs.Index = context.Handle;

            Priority = ThreadPriority.Highest;
        }

        private const int csInvalidTime = 1000;
        private const int csOneMiniteMsec = 60000;

        private long prevRawTicks;
        private Stopwatch totalWatch;
        private TestContext context;
        private TestDescriptionArgs descArgs;
        private TestSpreadSheetArgs sheetArgs;

        public bool InvalidContext { get; set; }

        public event EventHandler ClearSpreadSheet = null;
        protected void OnClearSpreadSheet()
        {
            ClearSpreadSheet?.Invoke(null, null);
        }

        public event EventHandler ClearGraph = null;
        protected void OnClearGraph()
        {
            ClearGraph?.Invoke(null, null);
        }


        public event EventHandler SetSpreadSheet = null;
        protected void OnSetSpreadSheet()
        {
            SetSpreadSheet?.Invoke(null, sheetArgs);
        }

        public event EventHandler DispState = null;
        public event EventHandler DispStateMainForm = null;
        protected void OnDispState()
        {
            DispState?.Invoke(null, descArgs);
            DispStateMainForm?.Invoke(null, descArgs);
        }

        public event EventInt64Handler InvalidGraph = null;
        protected void OnInvalidGraph(long ticks)
        {
            InvalidGraph?.Invoke(null, ticks);
        }

        public event EventBoolHandler SetToggleButtonState = null;
        protected void OnSetToggleButtonState(bool enabled)
        {
            SetToggleButtonState?.Invoke(null, enabled);
        }

        public void Lock()
        {
            Monitor.Enter(this);
        }

        public void Unlock()
        {
            Monitor.Exit(this);
        }

        protected override void Execute()
        {
            Watch.Stop();
            totalWatch.Stop();

            DateTime endTime;
            TimeSpan elapsedTime;
            ConditionSchedule sch;
            TestValue value = context.Value;
            ConditionMethod method = context.Condition.Method;
            List<ConditionSchedule> schedules = context.Condition.Schedules;

            try
            {
                descArgs.ScheduleCount = 0;
                descArgs.ScheduleMax = schedules.Count;
                descArgs.TotalElapsedTime = 0;

                for (int i = 0; i < schedules.Count; i++)
                {
                    sch = schedules[i];
                    if (sch.Use == false) continue;

                    context.Index = i;
                    context.Initialize();
                    context.Report.Initialize();

                    sheetArgs.Report = context.Report;

                    value.Integral.Initialize(method.ScanTime, method.IntegralTime, sch);

                    descArgs.Name = sch.Name;
                    descArgs.Step = ETestStep.None;
                    descArgs.RepeatMax = sch.Repeat;
                    descArgs.ScheduleCount = i + 1;

                    for (int j = 0; j < sch.Repeat; j++)
                    {
                        value.Integral.Clear();
                        context.Report.Clear();

                        OnClearSpreadSheet();

                        sheetArgs.Index = EWorkSheet.Title;
                        OnSetSpreadSheet();

                        descArgs.RepeatCount = j + 1;
                        descArgs.JudgeMax = sch.NoOfSteady;
                        descArgs.JudgeCount = 0;
                        descArgs.JudgeMaxTime = sch.Judge * csOneMiniteMsec;
                        descArgs.JudgeCurTime = 0;
                        descArgs.IntegMaxTime = method.IntegralTime * method.IntegralCount * csOneMiniteMsec;
                        descArgs.IntegCurTime = 0;
                        OnDispState();

                        InsertDataHead();
                        prevRawTicks = 0;
                        context.Value.Saving = true;
                        OnInvalidGraph(0);
                        Watch.Restart();
                        totalWatch.Start();

                        try
                        {
                            DoPreparation(sch);
                            DoJudgement(sch);
                            DoIntegration(method);
                        }
                        finally
                        {
                            endTime = DateTime.Now;
                            elapsedTime = endTime.Subtract(context.Report.RegTime);

                            totalWatch.Stop();
                            Watch.Stop();
                            context.Value.Saving = false;

                            InsertAllDataRaw();

                            string capacity = GetSheetAverageValue("Total.Capacity");
                            string power = GetSheetAverageValue("Total.Power");
                            string eer_cop = GetSheetAverageValue("Total.EER_COP");

                            UpdateDataBook(endTime, elapsedTime, capacity, power, eer_cop, ETestState.Done);
                            SaveSpreadSheet();

                            OnClearGraph();

                            descArgs.Step = ETestStep.None;
                            OnDispState();
                        }
                    }
                }

                PostMessage(Resource.WM_TEST_NORMAL_TERMINATED);
            }
            catch (UlThreadTerminatedException)
            {
                UpdateDataBook(ETestState.Stopped);
                PostMessage(Resource.WM_TEST_ABNORMAL_TERMINATED);
            }
        }

        private string GetSheetAverageValue(string tag)
        {
            string sValue = "";

            foreach (KeyValuePair<string, ReportSheet> sheet in sheetArgs.Report.ValueSheets)
            {
                if (sheet.Value.Use == false) continue;

                foreach (KeyValuePair<string, ReportRow> row in sheet.Value.Rows)
                {
                    if (row.Key == tag)
                    {
                        if (row.Value.Row == null) break;

                        sValue = $"{row.Value.Row.Unit.Convert(row.Value.Average).ToString(row.Value.Row.Format)} {row.Value.Row.Unit.ToDescription}";
                        goto lbEnd;
                    }
                }
            }

        lbEnd:
            return sValue;
        }

        private void UpdateDataBook(ETestState state)
        {
            if (context.Report.RecNo < 0) return;

            context.DB.Lock();

            try
            {
                FbTransaction trans = context.DB.BeginTrans();

                try
                {
                    DataBookDataSet set = context.DB.DataBookSet;

                    set.RecNo = context.Report.RecNo;
                    set.Update(state, trans);

                    context.DB.CommitTrans();
                }
                catch (Exception e)
                {
                    Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                    context.DB.RollbackTrans();
                }
            }
            finally
            {
                context.DB.Unlock();
            }
        }

        private void UpdateDataBook(DateTime time, TimeSpan elpased, 
            string capacity, string power, string eer_cop, ETestState state)
        {
            if (context.Report.RecNo < 0) return;

            context.DB.Lock();

            try
            {
                FbTransaction trans = context.DB.BeginTrans();

                try
                {
                    DataBookDataSet set = context.DB.DataBookSet;

                    set.RecNo = context.Report.RecNo;
                    set.EndTime = time.ToString(Resource.csDateTimeFormat);
                    set.ElapsedTime = elpased.ToString(@"ddd\.hh\:mm\:ss");
                    set.TotalCapacity = capacity;
                    set.TotalPower = power;
                    set.TotalEER_COP = eer_cop;
                    set.State = state;
                    set.Update(trans);

                    context.DB.CommitTrans();
                }
                catch (Exception e)
                {
                    Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                    context.DB.RollbackTrans();
                }
            }
            finally
            {
                context.DB.Unlock();
            }
        }

        private void PostMessage(int msg, int wParam=0, int lParam=0)
        {
            Win32.PostMessage(context.WndHandle, msg, (IntPtr)wParam, (IntPtr)lParam);
        }

        private void DoPreparation(ConditionSchedule sch)
        {
            bool repeat = true;
            descArgs.Step = ETestStep.Preparation;

            while (repeat == true)
            {
                try
                {
                    descArgs.Step = ETestStep.Preparation;
                    descArgs.PrepareMaxTime = sch.PreRun * csOneMiniteMsec;
                    descArgs.PrepareCurTime = 0;
                    OnDispState();

                    Preparation();
                    repeat = false;
                }
                catch (UlThreadTerminatedException e) 
                {
                    ClearCurrentValues();

                    switch ((ETestMessage)e.Code)
                    {
                        case ETestMessage.None:
                            throw e;

                        case ETestMessage.Next:
                            repeat = false;
                            break;

                        case ETestMessage.Reset:
                            repeat = true;
                            break;
                    }
                }
            }
        }

        private void Preparation()
        {
            long ticks;
            long maxTicks = descArgs.PrepareMaxTime;
            long prevTicks = ElapsedMilliseconds;
            long startTicks = prevTicks;

            int scanCount = 0;

            while (Terminated == false)
            {
                ticks = ElapsedMilliseconds;

                if (IsTimeoutMilliseconds(prevTicks, csInvalidTime) == true)
                {
                    prevTicks += csInvalidTime;
                    descArgs.ElapsedTime = ticks - startTicks;
                    descArgs.TotalElapsedTime = totalWatch.ElapsedMilliseconds;
                    descArgs.PrepareCurTime = descArgs.ElapsedTime;
                    OnDispState();

                    DispCurrentValues();

                    scanCount++;
                    if (scanCount >= context.Condition.Method.ScanTime)
                    {
                        OnInvalidGraph(ticks);
                        scanCount = 0;
                    }

                    DecideJudgement();
                }

                if (IsTimeoutMilliseconds(startTicks, maxTicks) == true)
                {
                    descArgs.PrepareCurTime = maxTicks;
                    break;
                }

                SaveDataRaw();
                RefreshContext();
                maxTicks = descArgs.PrepareMaxTime;
                Yield();
            }
        }

        private void DoJudgement(ConditionSchedule sch)
        {
            bool repeat = true;

            try
            {
                while (repeat == true)
                {
                    try
                    {
                        descArgs.Step = ETestStep.Judgement;
                        descArgs.JudgeMax = sch.NoOfSteady;
                        descArgs.JudgeCount = 0;
                        descArgs.JudgeMaxTime = sch.Judge * csOneMiniteMsec;
                        descArgs.JudgeCurTime = 0;
                        OnDispState();

                        Judgement();
                        repeat = false;
                    }
                    catch (UlThreadTerminatedException e)
                    {
                        ClearCurrentValues();

                        switch ((ETestMessage)e.Code)
                        {
                            case ETestMessage.None:
                                throw e;

                            case ETestMessage.Next:
                                repeat = false;
                                break;

                            case ETestMessage.Reset:
                                repeat = true;
                                break;
                        }
                    }

                }
            }
            finally
            {
                context.Value.Integral.Clear("Judge");
            }
        }

        private void Judgement()
        {
            long ticks;
            long maxTicks = descArgs.JudgeMaxTime;
            long prevTicks = ElapsedMilliseconds;
            long prevJudgeTicks = prevTicks;
            long startTicks = prevTicks;

            int scanCount = 0;

            while (Terminated == false)
            {
                ticks = ElapsedMilliseconds;

                if (IsTimeoutMilliseconds(prevTicks, csInvalidTime) == true)
                {
                    prevTicks += csInvalidTime;
                    descArgs.ElapsedTime = ticks - startTicks;
                    descArgs.TotalElapsedTime = totalWatch.ElapsedMilliseconds;
                    descArgs.JudgeCurTime = descArgs.ElapsedTime;
                    OnDispState();

                    DispCurrentValues();

                    scanCount++;
                    if (scanCount >= context.Condition.Method.ScanTime)
                    {
                        OnInvalidGraph(ticks);
                        scanCount = 0;
                    }

                    if (context.Value.Integral.IgnoreJudgement == false)
                    {
                        DecideJudgement();
                    }
                }

                if (IsTimeoutMilliseconds(prevJudgeTicks, csOneMiniteMsec) == true)
                {
                    prevJudgeTicks += csOneMiniteMsec;

                    if (context.Value.Integral.IgnoreJudgement == false)
                    {
                        if (IsSteadyAll() == true) descArgs.JudgeCount++;
                        if (descArgs.JudgeCount >= descArgs.JudgeMax) break;
                    }
                }

                if (IsTimeoutMilliseconds(startTicks, maxTicks) == true)
                {
                    if (context.Value.Integral.IgnoreJudgement == true)
                    {
                        descArgs.JudgeCurTime = maxTicks;
                        break;
                    }

                    if (Resource.Settings.Options.ForcedInteg == true)
                    {
                        descArgs.JudgeCurTime = maxTicks;
                        break;
                    }
                    else
                    {
                        throw new UlThreadTerminatedException((int)ETestMessage.Reset);
                    }
                }

                SaveDataRaw();
                RefreshContext();
                maxTicks = descArgs.JudgeMaxTime;
                Yield();
            }
        }

        private bool IsSteadyAll()
        {
            IntegralValues values = context.Value.Integral["Judge"];

            foreach (KeyValuePair<string, IntegralValue> row in values.Values)
            {
                if (row.Value.State == EValueState.Ng) return false;
            }

            return true;
        }

        private void DoIntegration(ConditionMethod method)
        {
            bool repeat = true;

            OnSetToggleButtonState(false);

            while (repeat == true)
            {
                try
                {
                    context.Value.Integral.Clear();

                    descArgs.Step = ETestStep.Integration;
                    descArgs.IntegMaxTime = method.IntegralTime * method.IntegralCount * csOneMiniteMsec;
                    descArgs.IntegCurTime = 0;
                    OnDispState();

                    Integration(method);
                    repeat = false;
                }
                catch (UlThreadTerminatedException e)
                {
                    ClearValues((int)sheetArgs.Index - 1);

                    switch ((ETestMessage)e.Code)
                    {
                        case ETestMessage.None:
                            throw e;

                        case ETestMessage.Next:
                            repeat = false;
                            break;

                        case ETestMessage.Reset:
                            repeat = true;
                            break;
                    }
                }
            }

            OnSetToggleButtonState(true);
        }

        private void Integration(ConditionMethod method)
        {
            long ticks;
            long maxTicks = descArgs.IntegMaxTime;
            long prevTicks = ElapsedMilliseconds;
            long integPrevTicks = prevTicks;
            long startTicks = prevTicks;
            long integTime = method.IntegralTime * csOneMiniteMsec;

            int scanCount = 0;
            int integCount = 0;
            int integMaxCount = method.IntegralCount;
            bool needInsert = true;

            while (Terminated == false)
            {
                ticks = ElapsedMilliseconds;

                if (needInsert == true)
                {
                    needInsert = false;
                    InsertDataSheet();
                }

                if (IsTimeoutMilliseconds(prevTicks, csInvalidTime) == true)
                {
                    prevTicks += csInvalidTime;
                    descArgs.ElapsedTime = ticks - startTicks;
                    descArgs.TotalElapsedTime = totalWatch.ElapsedMilliseconds;
                    descArgs.IntegCurTime = descArgs.ElapsedTime;
                    OnDispState();

                    scanCount++;
                    if (scanCount >= context.Condition.Method.ScanTime)
                    {
                        OnInvalidGraph(ticks);
                        scanCount = 0;
                    }

                    DispValues(integCount);
                    Integrate();
                }

                if (IsTimeoutMilliseconds(integPrevTicks, integTime) == true)
                {
                    SetIntegralValuesToReport(integCount);
                    DispIntegralValues(integCount);
                    InsertDataValue(integCount);

                    integPrevTicks += integTime;
                    integCount++;
                }

                if (IsTimeoutMilliseconds(startTicks, maxTicks) == true)
                {
                    descArgs.IntegCurTime = maxTicks;
                    break;
                }

                SaveDataRaw();
                Yield();
            }
        }

        private void DecideJudgement()
        {
            TestValue value = context.Value;

            value.Lock();
            try
            {
                value.Integral.IntegrateSheet("Judge");
            }
            finally
            {
                value.Unlock();
            }
        }

        private void Integrate()
        {
            TestValue value = context.Value;

            value.Lock();
            try
            {
                value.Integral.Integrate("Judge");
            }
            finally
            {
                value.Unlock();
            }
        }

        private void ClearValues(int index)
        {
            sheetArgs.Report.Lock();

            try
            {
                foreach (KeyValuePair<string, ReportSheet> sheet in sheetArgs.Report.ValueSheets)
                {
                    sheet.Value.ClearData(index);
                }
            }
            finally
            {
                sheetArgs.Report.Unlock();
            }

            sheetArgs.Index = (EWorkSheet)index + 1;
            sheetArgs.SettingAverage = false;
            OnSetSpreadSheet();
        }

        private void DispValues(int index)
        {
            sheetArgs.Report.Lock();

            try
            {
                foreach (KeyValuePair<string, ReportSheet> sheet in sheetArgs.Report.ValueSheets)
                {
                    sheet.Value.RefreshData(index);
                }
            }
            finally
            {
                sheetArgs.Report.Unlock();
            }

            sheetArgs.Index = (EWorkSheet)index + 1;
            sheetArgs.SettingAverage = false;
            OnSetSpreadSheet();
        }

        private void DispIntegralValues(int index)
        {
            sheetArgs.Index = (EWorkSheet)index + 1;
            sheetArgs.SettingAverage = true;
            OnSetSpreadSheet();
        }

        private void ClearCurrentValues()
        {
            sheetArgs.Report.Lock();

            try
            {
                foreach (KeyValuePair<string, ReportSheet> sheet in sheetArgs.Report.ValueSheets)
                {
                    sheet.Value.ClearData(0);
                }
            }
            finally
            {
                sheetArgs.Report.Unlock();
            }

            sheetArgs.Index = EWorkSheet.Current;
            sheetArgs.SettingAverage = false;
            OnSetSpreadSheet();
        }

        private void DispCurrentValues()
        {
            sheetArgs.Report.Lock();

            try
            {
                foreach (KeyValuePair<string, ReportSheet> sheet in sheetArgs.Report.ValueSheets)
                {
                    sheet.Value.RefreshData(0);
                }
            }
            finally
            {
                sheetArgs.Report.Unlock();
            }

            sheetArgs.Index = EWorkSheet.Current;
            sheetArgs.SettingAverage = false;
            OnSetSpreadSheet();
        }

        private void SetIntegralValuesToReport(int index)
        {
            TestValue value = context.Value;
            Dictionary<string, ReportSheet> reportSheet = sheetArgs.Report.ValueSheets;

            value.Lock();
            sheetArgs.Report.Lock();

            try
            {
                foreach (KeyValuePair<string, IntegralValues> integSheet in value.Integral.Sheets)
                {
                    if (integSheet.Key == "Judge") continue;
                    if (reportSheet[integSheet.Key].Use == false) continue;

                    foreach (KeyValuePair<string, IntegralValue> integValue in integSheet.Value.Values)
                    {
                        if (reportSheet[integSheet.Key].Rows[integValue.Key].Row == null)
                        {
                            reportSheet[integSheet.Key].Rows[integValue.Key].Cells[index].Raw = float.NaN;
                        }
                        else
                        {
                            reportSheet[integSheet.Key].Rows[integValue.Key].Cells[index].Raw =
                                integValue.Value.AverageSum;
                        }
                    }
                }
            }
            finally
            {
                sheetArgs.Report.Unlock();
                value.Unlock();
            }
        }

        private void RefreshContext()
        {
            if (InvalidContext == false) return;

            try
            {
                ConditionSchedule sch = context.Condition.Schedules[context.Index];
                ConditionMethod method = context.Condition.Method;

                context.RefreshCondition();
                context.Report.RefreshCondition();
                context.Value.Integral.Initialize(method.ScanTime, method.IntegralTime, sch);

                sheetArgs.Index = EWorkSheet.Title;
                OnSetSpreadSheet();

                descArgs.Name = sch.Name;
                descArgs.RepeatMax = sch.Repeat;
                descArgs.PrepareMaxTime = sch.PreRun * csOneMiniteMsec;
                descArgs.JudgeMaxTime = sch.Judge * csOneMiniteMsec;
                descArgs.JudgeMax = sch.NoOfSteady;

                OnDispState();
            }
            finally
            {
                InvalidContext = false;
            }
        }

        private void SaveDataRaw()
        {
            if (IsTimeoutMilliseconds(prevRawTicks, csInvalidTime) == true)
            {
                prevRawTicks += csInvalidTime;

                if (context.Report.DataRaw.HalfFull == true)
                {
                    InsertHalfFullDataRaw();
                }
            }
        }

        private void SaveSpreadSheet()
        {
            if (Resource.Settings.Options.AutoExcel == true)
            {
                string fName;

                if (string.IsNullOrWhiteSpace(context.Condition.Schedules[context.Index].Name) == true)
                {
                    fName = $"None_Line{context.Handle + 1}";
                }
                else
                {
                    fName = $"{context.Condition.Schedules[context.Index].Name}_Line{context.Handle + 1}";
                }

                fName = Resource.Settings.Options.ExcelPath + "\\" + fName + "_"
                    + context.Report.RegTime.ToString("yyyyMMddHHmmss") + ".xlsx";

                try
                {
                    context.Measure.Control.Workbook.SaveDocument(fName);
                }
                catch (Exception e)
                {
                    Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                }
            }
        }

        private void InsertDataValue(int index)
        {
            TestValue value = context.Value;

            context.DB.Lock();

            try
            {
                value.Lock();
                sheetArgs.Report.Lock();

                FbTransaction trans = context.DB.BeginTrans();

                try
                {
                    foreach (KeyValuePair<string, ReportSheet> sheet in sheetArgs.Report.ValueSheets)
                    {
                        if (sheet.Value.Use == false) continue;

                        foreach (KeyValuePair<string, ReportRow> row in sheet.Value.Rows)
                        {
                            SetDataValue(index, row.Value);
                            context.DB.DataValueSet.Insert(trans);
                        }
                    }

                    context.DB.CommitTrans();
                }
                catch (Exception e)
                {
                    Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                    context.DB.RollbackTrans();
                }
                finally
                {
                    sheetArgs.Report.Unlock();
                    value.Unlock();
                }
            }
            finally
            {
                context.DB.Unlock();
            }
        }

        private void InsertHalfFullDataRaw()
        {
            DataRaw raw = null;
            context.DB.Lock();

            try
            {
                context.Report.Lock();

                FbTransaction trans = context.DB.BeginTrans();

                try
                {
                    for (int i = 0; i < context.Report.DataRaw.Count; i++)
                    {
                        raw = context.Report.DataRaw.HalfFullDataRaw;
                        if (raw == null) break;

                        ValueStorageRaw storageRaw = raw.Row.Storage.HalfFullValues;

                        if (raw.RecNo < 0)
                        {
                            InsertDataRawUnit(trans, context.DB.DataRawUnitSet, raw);
                        }

                        InsertDataRaw(trans, context.DB.DataRawSet, storageRaw, raw.RecNo);
                    }

                    context.DB.CommitTrans();
                }
                catch (Exception e)
                {
                    Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                    context.DB.RollbackTrans();
                }
                finally
                {
                    context.Report.Unlock();
                }
            }
            finally
            {
                context.DB.Unlock();
            }
        }

        private void InsertAllDataRaw()
        {
            DataRaw raw = null;
            context.DB.Lock();

            try
            {
                context.Value.Lock();
                context.Report.Lock();

                FbTransaction trans = context.DB.BeginTrans();

                try
                {
                    ValueStorageRaw storageRaw;

                    foreach (KeyValuePair<string, DataRaw> dataRaw in context.Report.DataRaw.Rows)
                    {
                        raw = dataRaw.Value;

                        if (raw.Row.Storage.HalfFull == true)
                        {
                            storageRaw = raw.Row.Storage.HalfFullValues;

                            if (raw.RecNo < 0)
                            {
                                InsertDataRawUnit(trans, context.DB.DataRawUnitSet, raw);
                            }

                            InsertDataRaw(trans, context.DB.DataRawSet, storageRaw, raw.RecNo);
                        }

                        storageRaw = raw.Row.Storage.CurrentValues;
                        if (storageRaw != null)
                        {
                            if (raw.RecNo < 0)
                            {
                                InsertDataRawUnit(trans, context.DB.DataRawUnitSet, raw);
                            }

                            InsertDataRaw(trans, context.DB.DataRawSet, storageRaw, raw.RecNo);
                        }

                        Win32.SwitchToThread();
                    }

                    context.DB.CommitTrans();
                }
                catch (Exception e)
                {
                    Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                    context.DB.RollbackTrans();
                }
                finally
                {
                    context.Report.Unlock();
                    context.Value.Unlock();
                }
            }
            finally
            {
                context.DB.Unlock();
            }
        }

        private void InsertDataRawUnit(FbTransaction trans, DataRawUnitDataSet set, DataRaw raw)
        {
            raw.RecNo = context.DB.GetGenNo("GN_DATARAWUNIT");

            set.RecNo = raw.RecNo;
            set.DataBookNo = context.Report.RecNo;
            set.DataName = raw.Row.Name;
            set.UnitType = (int)raw.Row.Unit.Type;
            set.UnitFrom = (int)raw.Row.Unit.From;
            set.UnitTo = (int)raw.Row.Unit.To;
            set.Insert(trans);
        }

        private void InsertDataRaw(FbTransaction trans, DataRawDataSet set, ValueStorageRaw storageRaw, Int64 rawUnitNo)
        {
            set.RecNo = context.DB.GetGenNo("GN_DATARAW");
            set.DataRawUnitNo = rawUnitNo;
            set.RegTime = storageRaw.RegTime.ToString(Resource.csDateTimeFormat);
            set.ScanTime = context.Report.Method.ScanTime;
            set.DataRaw = ExtractDataRaw(storageRaw.RawValues, set.ScanTime);
            set.Insert(trans);
        }

        private void InsertDataHead()
        {
            context.DB.Lock();

            try
            {
                context.Report.Lock();
                FbTransaction trans = context.DB.BeginTrans();

                try
                {
                    SetDataBook();
                    context.DB.DataBookSet.Insert(trans);
                    context.DB.CommitTrans();
                }
                catch (Exception e)
                {
                    Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                    context.DB.RollbackTrans();
                }
                finally
                {
                    context.Report.Unlock();
                }
            }
            finally
            {
                context.DB.Unlock();
            }
        }

        private void InsertDataSheet()
        {
            context.DB.Lock();

            try
            {
                context.Report.Lock();
                FbTransaction trans = context.DB.BeginTrans();

                try
                {
                    foreach (KeyValuePair<string, ReportSheet> sheet in context.Report.ValueSheets)
                    {
                        try
                        {
                            SetDataSheet(context.Report.RecNo, sheet.Key, sheet.Value);
                            context.DB.DataSheetSet.Insert(trans);
                        }
                        catch (Exception e)
                        {
                            Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                            throw e;
                        }

                        int i = 0;
                        string name;
                        foreach (KeyValuePair<string, ReportRow> row in sheet.Value.Rows)
                        {
                            if (row.Value != null)
                            {
                                try
                                {
                                    if (sheet.Value.TcTags != null)
                                    {
                                        name = sheet.Value.TcTags[i].Name;
                                    }
                                    else
                                    {
                                        name = row.Key;
                                    }

                                    SetDataValueUnit(sheet.Value.RecNo, name, row.Value);
                                    context.DB.DataValueUnitSet.Insert(trans);
                                }
                                catch (Exception e)
                                {
                                    Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                                    throw e;
                                }
                            }

                            i++;
                        }
                    }

                    context.DB.CommitTrans();
                }
                catch (Exception e)
                {
                    Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                    context.DB.RollbackTrans();
                }
                finally
                {
                    context.Report.Unlock();
                }
            }
            finally
            {
                context.DB.Unlock();
            }
        }

        private void UpdateDataSheet()
        {
            context.DB.Lock();

            try
            {
                context.Report.Lock();
                FbTransaction trans = context.DB.BeginTrans();

                try
                {
                    DataSheetDataSet set = context.DB.DataSheetSet;

                    foreach (KeyValuePair<string, ReportSheet> sheet in context.Report.ValueSheets)
                    {
                        try
                        {
                            set.RecNo = sheet.Value.RecNo;
                            set.IDTemp = $"{sheet.Value.IndoorDB:f2} / {sheet.Value.IndoorWB:f2} ℃";
                            set.ODTemp = $"{sheet.Value.OutdoorDB:f2} / {sheet.Value.OutdoorWB:f2} ℃";
                            context.DB.DataSheetSet.UpdateTemp(trans);
                        }
                        catch (Exception e)
                        {
                            Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                            throw e;
                        }
                    }

                    context.DB.CommitTrans();
                }
                catch (Exception e)
                {
                    Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                    context.DB.RollbackTrans();
                }
                finally
                {
                    context.Report.Unlock();
                }
            }
            finally
            {
                context.DB.Unlock();
            }
        }

        private void SetDataBook()
        {
            ValueRow row;
            ConditionNote note = context.Report.Note;
            ConditionRated rated = context.Report.Rated;
            ConditionMethod method = context.Report.Method;
            DataBookDataSet set = context.DB.DataBookSet;
            context.Report.RecNo = context.DB.GetGenNo("GN_DATABOOK");
            context.Report.RegTime = DateTime.Now;

            set.RecNo = context.Report.RecNo;
            set.UserNo = Resource.UserNo;
            set.BeginTime = context.Report.RegTime.ToString(Resource.csDateTimeFormat);
            set.EndTime = set.BeginTime;
            set.ElapsedTime = "00 00:00:00";
            set.TestLine = context.Handle;
            set.IntegCount = method.IntegralCount;
            set.IntegTime = method.IntegralTime;
            set.ScanTime = method.ScanTime;
            set.Company = note.Company;
            set.TestName = note.Name;
            set.TestNo = note.No;
            set.Observer = note.Observer;
            set.Maker = note.Maker;
            set.Model1 = note.Model1;
            set.Serial1 = note.Serial1;
            set.Model2 = note.Model2;
            set.Serial2 = note.Serial2;
            set.Model3 = note.Model3;
            set.Serial3 = note.Serial3;
            set.ExpDevice = note.ExpDevice;
            set.Refrige = note.Refrigerant;
            set.RefCharge = note.RefCharge;
            row = context.Value.Calcurated["Total.Capacity"];
            set.Capacity = $"{rated.Capacity.ToString(row.Format)} {row.Unit.ToDescription}";
            row = context.Value.Calcurated["Total.Power"];
            set.PowerInput = $"{rated.PowerInput.ToString(row.Format)} {row.Unit.ToDescription}";
            row = context.Value.Calcurated["Total.EER_COP"];
            set.EER_COP = $"{rated.EER_COP.ToString(row.Format)} {row.Unit.ToDescription}";
            set.PowerSource = $"{rated.Voltage}V / {rated.Current}A / {rated.Frequency}Hz / {EnumHelper.GetNames<EWT330Wiring>()[(int)rated.Wiring]}";
            set.TotalCapacity = "0.0 kcal/h";
            set.TotalPower = "0.0 W";
            set.TotalEER_COP = "0.0 kcal/hW";
            set.Memo = note.Memo;
            set.State = ETestState.Testing;
        }

        private void SetDataSheet(Int64 dataBookNo, string key, ReportSheet sheet)
        {
            DataSheetDataSet set = context.DB.DataSheetSet;
            sheet.RecNo = context.DB.GetGenNo("GN_DATASHEET");

            set.RecNo = sheet.RecNo;
            set.DataBookNo = dataBookNo;
            set.SheetName = key;
            set.Use = sheet.Use;
            set.IDTemp = $"{sheet.IndoorDB:f2} / {sheet.IndoorWB:f2} ℃";

            if (sheet.IndoorUse == EIndoorUse.NotUsed)
                set.IDState = $"{sheet.IndoorUse.ToDescription()}";
            else
                set.IDState = $"{sheet.IndoorUse.ToDescription()}, {sheet.IndoorMode.ToDescription()}";

            set.ODTemp = $"{sheet.OutdoorDB:f2} / {sheet.OutdoorWB:f2} ℃";

            if (sheet.OutdoorDP == EEtcUse.Use)
                set.ODState = $"{sheet.OutdoorUse}, DP Used";
            else
                set.ODState = $"{sheet.OutdoorUse}";

            set.NozzleName = sheet.NozzleName;
            set.NozzleState = sheet.NozzleState;
        }

        private void SetDataValueUnit(Int64 sheetNo, string key, ReportRow row)
        {
            DataValueUnitDataSet set = context.DB.DataValueUnitSet;
            row.RecNo = context.DB.GetGenNo("GN_DATAVALUEUNIT");

            set.RecNo = row.RecNo;
            set.DataSheetNo = sheetNo;
            set.ValueName = key;

            if (row.Row == null)
            {
                set.UnitType = 0;
                set.UnitFrom = 0;
                set.UnitTo = 0;
                set.Format = "0.0";
            }
            else
            {
                set.UnitType = (int)row.Row.Unit.Type;
                set.UnitFrom = (int)row.Row.Unit.From;
                set.UnitTo = (int)row.Row.Unit.To;
                set.Format = row.Row.Format;
            }
        }

        private void SetDataValue(int index, ReportRow row)
        {
            DataValueDataSet set = context.DB.DataValueSet;

            set.RecNo = context.DB.GetGenNo("GN_DATAVALUE");
            set.DataValueUnitNo = row.RecNo;
            set.DataNo = index;
            set.DataValue = row.Cells[index].Raw;
        }

        private float[] ExtractDataRaw(float[] raws, int count)
        {
            int loopCount = raws.Length / count;

            if ((raws.Length % count) != 0) loopCount++;

            float[] newRaws = new float[loopCount];

            for (int i = 0; i < loopCount; i++)
            {
                newRaws[i] = raws[i * count];
            }

            return newRaws;
        }
    }
}