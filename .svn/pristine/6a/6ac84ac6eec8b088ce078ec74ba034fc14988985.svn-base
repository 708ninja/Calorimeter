using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;

using FirebirdSql.Data.FirebirdClient;

using Ulee.Database.Firebird;
using Ulee.Device.Connection.Yokogawa;

namespace Hnc.Calorimeter.Client
{
    public class CalorimeterTestDatabase : UlFirebird
    {
        public CalorimeterTestDatabase(FbServerType type = FbServerType.Default) : base(type)
        {
            UserSet = new UserDataSet(connect, null, null);
            AllParamSet = new AllParamDataSet(connect, null, null);
            ScheduleParamSet = new ScheduleParamDataSet(connect, null, null);
            NoteParamSet = new NoteParamDataSet(connect, null, null);
            MethodParamSet = new MethodParamDataSet(connect, null, null);
            RatedParamSet = new RatedParamDataSet(connect, null, null);
            ThermoPressParamSet = new ThermoPressParamDataSet(connect, null, null);
            NoteParamConfigSet = new NoteParamDataSet(connect, null, null);
            DataBookSet = new DataBookDataSet(connect, null, null);
            DataSheetSet = new DataSheetDataSet(connect, null, null);
            DataValueUnitSet = new DataValueUnitDataSet(connect, null, null);
            DataValueSet = new DataValueDataSet(connect, null, null);
            DataRawUnitSet = new DataRawUnitDataSet(connect, null, null);
            DataRawSet = new DataRawDataSet(connect, null, null);
            XAxisSettingSet = new XAxisSettingDataSet(connect, null, null);
            YAxisSettingSet = new YAxisSettingDataSet(connect, null, null);
            SeriesSettingSet = new SeriesSettingDataSet(connect, null, null);
        }

        public FbConnection Connect { get { return connect; } }

        public UserDataSet UserSet { get; private set; }
        public AllParamDataSet AllParamSet { get; private set; }
        public ScheduleParamDataSet ScheduleParamSet { get; private set; }
        public NoteParamDataSet NoteParamSet { get; private set; }
        public MethodParamDataSet MethodParamSet { get; private set; }
        public RatedParamDataSet RatedParamSet { get; private set; }
        public ThermoPressParamDataSet ThermoPressParamSet { get; private set; }
        public NoteParamDataSet NoteParamConfigSet { get; private set; }
        public DataBookDataSet DataBookSet { get; private set; }
        public DataSheetDataSet DataSheetSet { get; private set; }
        public DataValueUnitDataSet DataValueUnitSet { get; private set; }
        public DataValueDataSet DataValueSet { get; private set; }
        public DataRawUnitDataSet DataRawUnitSet { get; private set; }
        public DataRawDataSet DataRawSet { get; private set; }
        public XAxisSettingDataSet XAxisSettingSet { get; private set; }
        public YAxisSettingDataSet YAxisSettingSet { get; private set; }
        public SeriesSettingDataSet SeriesSettingSet { get; private set; }
    }

    public class CalorimeterViewDatabase : UlFirebird
    {
        public CalorimeterViewDatabase(FbServerType type = FbServerType.Default) : base(type)
        {
            DataBookSet = new DataBookDataSet(connect, null, null);
            DataSheetSet = new DataSheetDataSet(connect, null, null);
            DataValueUnitSet = new DataValueUnitDataSet(connect, null, null);
            DataValueSet = new DataValueDataSet(connect, null, null);
            DataRawUnitSet = new DataRawUnitDataSet(connect, null, null);
            DataRawSet = new DataRawDataSet(connect, null, null);
            YAxisSettingSet = new YAxisSettingDataSet(connect, null, null);
            SeriesSettingSet = new SeriesSettingDataSet(connect, null, null);
        }

        public FbConnection Connect { get { return connect; } }

        public DataBookDataSet DataBookSet { get; private set; }
        public DataSheetDataSet DataSheetSet { get; private set; }
        public DataValueUnitDataSet DataValueUnitSet { get; private set; }
        public DataValueDataSet DataValueSet { get; private set; }
        public DataRawUnitDataSet DataRawUnitSet { get; private set; }
        public DataRawDataSet DataRawSet { get; private set; }
        public YAxisSettingDataSet YAxisSettingSet { get; private set; }
        public SeriesSettingDataSet SeriesSettingSet { get; private set; }
    }

    public class CalorimeterConfigDatabase : UlFirebird
    {
        public CalorimeterConfigDatabase(FbServerType type = FbServerType.Default) : base(type)
        {
            UserSet = new UserDataSet(connect, null, null);
            AllParamSet = new AllParamDataSet(connect, null, null);
            ScheduleParamSet = new ScheduleParamDataSet(connect, null, null);
            NoteParamSet = new NoteParamDataSet(connect, null, null);
            MethodParamSet = new MethodParamDataSet(connect, null, null);
            RatedParamSet = new RatedParamDataSet(connect, null, null);
            ThermoPressParamSet = new ThermoPressParamDataSet(connect, null, null);
            NoteParamConfigSet = new NoteParamDataSet(connect, null, null);
        }

        public FbConnection Connect { get { return connect; } }

        public UserDataSet UserSet { get; private set; }
        public AllParamDataSet AllParamSet { get; private set; }
        public ScheduleParamDataSet ScheduleParamSet { get; private set; }
        public NoteParamDataSet NoteParamSet { get; private set; }
        public MethodParamDataSet MethodParamSet { get; private set; }
        public RatedParamDataSet RatedParamSet { get; private set; }
        public ThermoPressParamDataSet ThermoPressParamSet { get; private set; }
        public NoteParamDataSet NoteParamConfigSet { get; private set; }

        public void DeleteAllParam(int paramNo)
        {
            NoteParamSet.Select(paramNo);
            NoteParamSet.Fetch();
            int noteNo = NoteParamSet.RecNo;

            BeginTrans();

            try
            {
                ThermoPressParamSet.NoteNo = noteNo;
                ThermoPressParamSet.Delete(Trans);
                RatedParamSet.NoteNo = noteNo;
                RatedParamSet.Delete(Trans);
                MethodParamSet.NoteNo = noteNo;
                MethodParamSet.Delete(Trans);
                NoteParamSet.Delete(paramNo, Trans);
                ScheduleParamSet.Delete(paramNo, Trans);
                AllParamSet.RecNo = paramNo;
                AllParamSet.Delete(Trans);

                CommitTrans();
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans();
            }
        }

        public void DeleteNoteParam()
        {
            int recNo = NoteParamSet.RecNo;

            BeginTrans();

            try
            {
                ThermoPressParamSet.NoteNo = recNo;
                ThermoPressParamSet.Delete(Trans);
                RatedParamSet.NoteNo = recNo;
                RatedParamSet.Delete(Trans);
                NoteParamSet.Delete(Trans);

                CommitTrans();
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans();
            }
        }
    }

    //public class TestDataSets
    //{
    //    public TestDataSets(FbConnection connect)
    //    {
    //        DataBookSet = new DataBookDataSet(connect, null, null);
    //        DataSheetSet = new DataSheetDataSet(connect, null, null);
    //        DataValueUnitSet = new DataValueUnitDataSet(connect, null, null);
    //        DataValueSet = new DataValueDataSet(connect, null, null);
    //        DataRawUnitSet = new DataRawUnitDataSet(connect, null, null);
    //        DataRawSet = new DataRawDataSet(connect, null, null);
    //        YAxisSettingSet = new YAxisSettingDataSet(connect, null, null);
    //        SeriesSettingSet = new SeriesSettingDataSet(connect, null, null);
    //    }

    //    public DataBookDataSet DataBookSet { get; private set; }
    //    public DataSheetDataSet DataSheetSet { get; private set; }
    //    public DataValueUnitDataSet DataValueUnitSet { get; private set; }
    //    public DataValueDataSet DataValueSet { get; private set; }
    //    public DataRawUnitDataSet DataRawUnitSet { get; private set; }
    //    public DataRawDataSet DataRawSet { get; private set; }
    //    public YAxisSettingDataSet YAxisSettingSet { get; private set; }
    //    public SeriesSettingDataSet SeriesSettingSet { get; private set; }
    //}

    //public class ConfigDataSets
    //{
    //    public ConfigDataSets(FbConnection connect)
    //    {
    //        ScheduleParamSet = new ScheduleParamDataSet(connect, null, null);
    //        NoteParamSet = new NoteParamDataSet(connect, null, null);
    //        MethodParamSet = new MethodParamDataSet(connect, null, null);
    //        RatedParamSet = new RatedParamDataSet(connect, null, null);
    //        ThermoPressParamSet = new ThermoPressParamDataSet(connect, null, null);
    //    }

    //    public ScheduleParamDataSet ScheduleParamSet { get; private set; }
    //    public NoteParamDataSet NoteParamSet { get; private set; }
    //    public MethodParamDataSet MethodParamSet { get; private set; }
    //    public RatedParamDataSet RatedParamSet { get; private set; }
    //    public ThermoPressParamDataSet ThermoPressParamSet { get; private set; }
    //}

    public class UserDataSet : UlDataSet
    {
        public int RecNo { get; set; }
        public string Name { get; set; }
        public EUserAuthority Authority { get; set; }
        public string Passwd { get; set; }
        public string Memo { get; set; }

        public UserDataSet(FbConnection connect, FbCommand command, FbDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select()
        {
            SetTrans(null);
            command.CommandText = "select * from TB_USER where pk_recno>0 order by pk_recno asc";
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Select(int recno)
        {
            SetTrans(null);
            command.CommandText = $"select * from TB_USER where pk_recno={recno} order by pk_recno asc";
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Select(string name)
        {
            SetTrans(null);
            command.CommandText = $"select * from TB_USER where name='{name}' order by pk_recno asc";
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public int GetRecNo(string name)
        {
            Select(name);
            Fetch();

            return RecNo;
        }

        public string GetName(int recno)
        {
            Select(recno);
            Fetch();

            return Name;
        }

        public void Insert(FbTransaction trans = null)
        {
            string sql = $"insert into TB_USER values ({RecNo}, '{Name}', {(int)Authority}, '{Passwd}', '{Memo}')";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Update(FbTransaction trans = null)
        {
            string sql =
                $"update TB_USER set name='{Name}', authority={(int)Authority}, passwd='{Passwd}', memo='{Memo}' where pk_recno={RecNo}";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Delete(FbTransaction trans = null)
        {
            string sql = $" delete from TB_USER where pk_recno={RecNo} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Fetch(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                Fetch(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                RecNo = -1;
                Name = "";
                Authority = EUserAuthority.Viewer;
                Passwd = "";
                Memo = "";
            }
        }

        public void Fetch(DataRow row)
        {
            RecNo = Convert.ToInt32(row["pk_recno"]);
            Name = Convert.ToString(row["name"]);
            Authority = (EUserAuthority)Convert.ToInt32(row["authority"]);
            Passwd = Convert.ToString(row["passwd"]);
            Memo = Convert.ToString(row["memo"]);
        }
    }

    public class AllParamDataSet : UlDataSet
    {
        public int RecNo { get; set; }
        public int UserNo { get; set; }
        public string UserName { get; set; }
        public string RegTime { get; set; }
        public string Memo { get; set; }

        public AllParamDataSet(FbConnection connect, FbCommand command, FbDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select()
        {
            SetTrans(null);
            command.CommandText = 
                  " select t1.*, t2.name as username from TB_ALLPARAM t1 " 
                + " join TB_USER t2 on t2.pk_recno=T1.fk_userno "
                + " where t1.pk_recno>=0 "
                + " order by t1.pk_recno asc ";
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(FbTransaction trans = null)
        {
            string sql = $" insert into TB_ALLPARAM values ({RecNo}, {UserNo}, '{RegTime}', '{Memo}') ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Delete(FbTransaction trans = null)
        {
            string sql = $"delete from TB_ALLPARAM where pk_recno={RecNo}";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Fetch(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                Fetch(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                RecNo = -1;
                UserNo = 0;
                RegTime = "";
                Memo = "";
            }
        }

        public void Fetch(DataRow row)
        {
            RecNo = Convert.ToInt32(row["pk_recno"]);
            UserNo = Convert.ToInt32(row["fk_userno"]);
            UserName = Convert.ToString(row["username"]);
            RegTime = Convert.ToString(row["regtime"]);
            Memo = Convert.ToString(row["memo"]);
        }
    }

    public class NoteParamDataSet : UlDataSet
    {
        public NoteParamDataSet(FbConnection connect, FbCommand command, FbDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public int RecNo { get; set; }
        public int ParamNo { get; set; }
        public string Company { get; set; }
        public string TestName { get; set; }
        public string TestNo { get; set; }
        public string Observer { get; set; }
        public string Maker { get; set; }
        public string Model1 { get; set; }
        public string Serial1 { get; set; }
        public string Model2 { get; set; }
        public string Serial2 { get; set; }
        public string Model3 { get; set; }
        public string Serial3 { get; set; }
        public string ExpDevice { get; set; }
        public string Refrig { get; set; }
        public string RefCharge { get; set; }
        public string Memo { get; set; }
        public EUnitCapacity CoolUnit { get; set; }
        public EUnitCapacity HeatUnit { get; set; }

        public void Select(int paramNo=-1)
        {
            SetTrans(null);
            command.CommandText =
                  $" select * from TB_CONDITION_NOTEPARAM "
                + $" where fk_paramno={paramNo} "
                + $" order by maker, model1, serial1 asc ";
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void SelectRecNo(int recNo)
        {
            SetTrans(null);
            command.CommandText =
                  $" select * from TB_CONDITION_NOTEPARAM "
                + $" where pk_recno={recNo} ";
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Select(string maker, int paramNo=-1)
        {
            SetTrans(null);
            command.CommandText = 
                  $" select * from TB_CONDITION_NOTEPARAM "
                + $" where fk_paramno={paramNo} and maker like '{maker}%' " 
                + $" order by maker, model1, serial1 asc ";
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void SelectDistinct(int paramNo = -1)
        {
            SetTrans(null);
            command.CommandText =
                  $" select distinct(maker) from TB_CONDITION_NOTEPARAM "
                + $" where fk_paramno={paramNo} ";
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void SelectDistinct(string maker, int paramNo = -1)
        {
            SetTrans(null);
            command.CommandText =
                  $" select distinct(model1) from TB_CONDITION_NOTEPARAM "
                + $" where fk_paramno={paramNo} and maker='{maker}' ";
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void SelectDistinct(string maker, string model, int paramNo = -1)
        {
            SetTrans(null);
            command.CommandText =
                  $" select pk_recno, serial1 from TB_CONDITION_NOTEPARAM "
                + $" where fk_paramno={paramNo} and maker='{maker}' and model1='{model}' ";
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Select(string maker, string model, string serial, int paramNo = -1)
        {
            SetTrans(null);
            command.CommandText =
                  $" select * from TB_CONDITION_NOTEPARAM "
                + $" where fk_paramno={paramNo} and maker='{maker}' "
                + $" and model1='{model}' and serial1='{serial}' ";
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(FbTransaction trans = null)
        {
            string sql = $" insert into TB_CONDITION_NOTEPARAM values ( "
                + $" {RecNo}, {ParamNo}, '{Company}', '{TestName}', '{TestNo}', '{Observer}', "
                + $" '{Maker}', '{Model1}', '{Serial1}', '{Model2}', '{Serial2}', '{Model3}', '{Serial3}', "
                + $" '{ExpDevice}', '{Refrig}', '{RefCharge}', '{Memo}', {(int)CoolUnit}, {(int)HeatUnit}) ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Update(FbTransaction trans = null)
        {
            string sql = $" update TB_CONDITION_NOTEPARAM set company='{Company}', testname='{TestName}', "
                + $" testno='{TestNo}', Observer='{Observer}', maker='{Maker}', model1='{Model1}', serial1='{Serial1}', "
                + $" model2='{Model2}', serial2='{Serial2}', model3='{Model3}', serial3='{Serial3}', expdevice='{ExpDevice}', "
                + $" refrige='{Refrig}', refcharge='{RefCharge}', memo='{Memo}', coolunit={(int)CoolUnit}, heatunit={(int)HeatUnit} "
                + $" where pk_recno={RecNo} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Delete(FbTransaction trans = null)
        {
            string sql = $"delete from TB_CONDITION_NOTEPARAM where pk_recno={RecNo}";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Delete(int paramNo, FbTransaction trans = null)
        {
            string sql = $"delete from TB_CONDITION_NOTEPARAM where fk_paramno={paramNo}";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Fetch(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                Fetch(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                RecNo = -1;
                ParamNo = 0;
                Company = "";
                TestName = "";
                TestNo = "";
                Observer = "";
                Maker = "";
                Model1 = "";
                Serial1 = "";
                Model2 = "";
                Serial2 = "";
                Model3 = "";
                Serial3 = "";
                ExpDevice = "";
                Refrig = "";
                RefCharge = "";
                Memo = "";
                CoolUnit = EUnitCapacity.kcal;
                HeatUnit = EUnitCapacity.Btu;
            }
        }

        public void Fetch(DataRow row)
        {
            RecNo = Convert.ToInt32(row["pk_recno"]);
            ParamNo = Convert.ToInt32(row["fk_paramno"]);
            Company = Convert.ToString(row["company"]);
            TestName = Convert.ToString(row["testname"]);
            TestNo = Convert.ToString(row["testno"]);
            Observer = Convert.ToString(row["observer"]);
            Maker = Convert.ToString(row["maker"]);
            Model1 = Convert.ToString(row["model1"]);
            Serial1 = Convert.ToString(row["serial1"]);
            Model2 = Convert.ToString(row["model2"]);
            Serial2 = Convert.ToString(row["serial2"]);
            Model3 = Convert.ToString(row["model3"]);
            Serial3 = Convert.ToString(row["serial3"]);
            ExpDevice = Convert.ToString(row["expdevice"]);
            Refrig = Convert.ToString(row["refrige"]);
            RefCharge = Convert.ToString(row["refcharge"]);
            Memo = Convert.ToString(row["memo"]);
            CoolUnit = (EUnitCapacity)Convert.ToInt32(row["coolunit"]);
            HeatUnit = (EUnitCapacity)Convert.ToInt32(row["heatunit"]);
        }

        public void FetchMaker(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                FetchMaker(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                RecNo = -1;
                Maker = "";
            }
        }

        public void FetchMaker(DataRow row)
        {
            RecNo = -1;
            Maker = Convert.ToString(row["maker"]);
            Model1 = "";
            Serial1 = "";
        }

        public void FetchModel1(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                FetchModel1(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                RecNo = -1;
                Model1 = "";
            }
        }

        public void FetchModel1(DataRow row)
        {
            RecNo = -1;
            Maker = "";
            Model1 = Convert.ToString(row["model1"]);
            Serial1 = "";
        }

        public void FetchSerial1(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                FetchSerial1(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                RecNo = -1;
                Serial1 = "";
            }
        }

        public void FetchSerial1(DataRow row)
        {
            RecNo = Convert.ToInt32(row["pk_recno"]);
            Maker = "";
            Model1 = "";
            Serial1 = Convert.ToString(row["serial1"]);
        }
    }

    public class MethodParamDataSet : UlDataSet
    {
        public MethodParamDataSet(FbConnection connect, FbCommand command, FbDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public int RecNo { get; set; }
        public int NoteNo { get; set; }
        public int IntegCount { get; set; }
        public int IntegTime { get; set; }
        public int ScanTime { get; set; }
        public EUnitCapacity CoolCapacityUnit { get; set; }
        public EUnitCapacity HeatCapacityUnit { get; set; }
        public EUnitAirFlow AirFlowUnit { get; set; }
        public EUnitEnthalpy EnthalpyUnit { get; set; }
        public EUnitPressure PressureUnit { get; set; }
        public EUnitTemperature TemperatureUnit { get; set; }
        public EUnitDiffPressure DiffPressureUnit { get; set; }
        public EUnitAtmPressure AtmPressureUnit { get; set; }
        public bool AutoSetController { get; set; }
        public bool UsePowerMeter { get; set; }

        public void Select(int noteNo)
        {
            SetTrans(null);
            command.CommandText =
                  $" select * from TB_CONDITION_METHODPARAM "
                + $" where fk_noteno={noteNo} ";
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(FbTransaction trans = null)
        {
            int auto = (AutoSetController == false) ? 0 : 1;
            int use = (UsePowerMeter == false) ? 0 : 1;
            string sql = $" insert into TB_CONDITION_METHODPARAM values ( "
                + $" {RecNo}, {NoteNo}, {IntegCount}, {IntegTime}, {ScanTime}, "
                + $" {(int)CoolCapacityUnit}, {(int)HeatCapacityUnit}, {(int)AirFlowUnit}, {(int)EnthalpyUnit}, "
                + $" {(int)PressureUnit}, {(int)TemperatureUnit}, {(int)DiffPressureUnit}, {(int)AtmPressureUnit}, "
                + $" {auto}, {use})";


            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Delete(FbTransaction trans = null)
        {
            string sql = $" delete from TB_CONDITION_METHODPARAM where fk_noteno={NoteNo} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Fetch(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                Fetch(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                RecNo = 0;
                NoteNo = 0;
                IntegCount = 0;
                IntegTime = 0;
                ScanTime = 0;
                CoolCapacityUnit = EUnitCapacity.W;
                HeatCapacityUnit = EUnitCapacity.W;
                AirFlowUnit = EUnitAirFlow.CMM;
                EnthalpyUnit = EUnitEnthalpy.W;
                PressureUnit = EUnitPressure.Bar;
                TemperatureUnit = EUnitTemperature.Celsius;
                DiffPressureUnit = EUnitDiffPressure.mmAq;
                AtmPressureUnit = EUnitAtmPressure.mmAq;
                AutoSetController = false;
                UsePowerMeter = false;
            }
        }

        public void Fetch(DataRow row)
        {
            RecNo = Convert.ToInt32(row["pk_reco"]);
            NoteNo = Convert.ToInt32(row["fk_noteno"]);
            IntegCount = Convert.ToInt32(row["integcount"]); 
            IntegTime = Convert.ToInt32(row["integtime"]);
            ScanTime = Convert.ToInt32(row["scantime"]);
            CoolCapacityUnit = (EUnitCapacity)Convert.ToInt32(row["coolcapa"]);
            HeatCapacityUnit = (EUnitCapacity)Convert.ToInt32(row["heatcapa"]);
            AirFlowUnit = (EUnitAirFlow)Convert.ToInt32(row["airflow"]);
            EnthalpyUnit = (EUnitEnthalpy)Convert.ToInt32(row["enthalpy"]);
            PressureUnit = (EUnitPressure)Convert.ToInt32(row["press"]);
            TemperatureUnit = (EUnitTemperature)Convert.ToInt32(row["temp"]);
            DiffPressureUnit = (EUnitDiffPressure)Convert.ToInt32(row["diffpress"]);
            AtmPressureUnit = (EUnitAtmPressure)Convert.ToInt32(row["atmpress"]);
            AutoSetController = (Convert.ToInt32(row["autoset"]) == 0) ? false : true;
            UsePowerMeter = (Convert.ToInt32(row["usepm"]) == 0) ? false : true;
        }
    }

    public class RatedParamDataSet : UlDataSet
    {
        public RatedParamDataSet(FbConnection connect, FbCommand command, FbDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public int RecNo { get; set; }
        public int NoteNo { get; set; }
        public EConditionRated PageNo { get; set; }
        public ETestMode Mode { get; set; }
        public float Capacity { get; set; }
        public float Power { get; set; }
        public float EER_COP { get; set; }
        public float Volt { get; set; }
        public float Amp { get; set; }
        public string Freq { get; set; }
        public int PM_IDU { get; set; }
        public int PM_ODU { get; set; }
        public EWT330Wiring Phase { get; set; }

        public void Select(int noteno, EConditionRated pageno)
        {
            SetTrans(null);
            command.CommandText 
                = " select * from TB_CONDITION_RATEDPARAM "
                + $" where fk_noteno={noteno} and pageno={(int)pageno} "
                + $" order by mode asc ";
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(FbTransaction trans = null)
        {
            string sql = $" insert into TB_CONDITION_RATEDPARAM values ( "
                + $" {RecNo}, {NoteNo}, {(int)PageNo}, {(int)Mode}, {Capacity}, {Power}, "
                + $" {EER_COP}, {Volt}, {Amp}, '{Freq}', {PM_IDU}, {PM_ODU}, {(int)Phase}) ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Update(FbTransaction trans = null)
        {
            string sql = $" update TB_CONDITION_RATEDPARAM set "
                + $" capacity={Capacity}, power={Power}, eer_cop={EER_COP}, volt={Volt}, "
                + $" amp={Amp}, freq='{Freq}', pm_idu={PM_IDU}, pm_odu={PM_ODU}, phase={(int)Phase} "
                + $" where pk_recno={RecNo} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Delete(FbTransaction trans = null)
        {
            string sql = $" delete from TB_CONDITION_RATEDPARAM where fk_noteno={NoteNo} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Fetch(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                Fetch(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                RecNo = 0;
                NoteNo = 0;
                PageNo = EConditionRated.Total;
                Mode = ETestMode.Cooling;
                Capacity = 0;
                Power = 0;
                EER_COP = 0;
                Volt = 0;
                Amp = 0;
                Freq = "";
                PM_IDU = 0;
                PM_ODU = 0;
                Phase = EWT330Wiring.P3W4;
            }
        }

        public void Fetch(DataRow row)
        {
            RecNo = Convert.ToInt32(row["pk_recno"]);
            NoteNo = Convert.ToInt32(row["fk_noteno"]);
            PageNo = (EConditionRated)Convert.ToInt32(row["pageno"]);
            Mode = (ETestMode)Convert.ToInt32(row["mode"]);
            Capacity = Convert.ToSingle(row["capacity"]);
            Power = Convert.ToSingle(row["power"]);
            EER_COP = Convert.ToSingle(row["eer_cop"]);
            Volt = Convert.ToSingle(row["volt"]);
            Amp = Convert.ToSingle(row["amp"]);
            Freq = Convert.ToString(row["freq"]);
            PM_IDU = Convert.ToInt32(row["pm_idu"]);
            PM_ODU = Convert.ToInt32(row["pm_odu"]);
            Phase = (EWT330Wiring)Convert.ToInt32(row["phase"]);
        }
    }

    public class ThermoPressParamDataSet : UlDataSet
    {
        public ThermoPressParamDataSet(FbConnection connect, FbCommand command, FbDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public int RecNo { get; set; }
        public int NoteNo { get; set; }
        public int ChType { get; set; }
        public int ChNo { get; set; }
        public string Name { get; set; }

        public void Select(int noteno, int chType)
        {
            SetTrans(null);
            command.CommandText = " select * from TB_CONDITION_THERMOPRESSPARAM "
                + $" where fk_noteno={noteno} and chtype={chType} order by chno asc ";
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(FbTransaction trans = null)
        {
            string sql = $" insert into TB_CONDITION_THERMOPRESSPARAM values "
                + $" ({RecNo}, {NoteNo}, {ChType}, {ChNo}, '{Name}') ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Update(FbTransaction trans = null)
        {
            string sql = $" update TB_CONDITION_THERMOPRESSPARAM "
                + $" set name='{Name}' where pk_recno={RecNo} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Delete(FbTransaction trans = null)
        {
            string sql = $" delete from TB_CONDITION_THERMOPRESSPARAM where fk_noteno={NoteNo} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Fetch(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                Fetch(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                RecNo = 0;
                NoteNo = 0;
                ChType = 0;
                ChNo = 0;
                Name = "";
            }
        }

        public void Fetch(DataRow row)
        {
            RecNo = Convert.ToInt32(row["pk_recno"]);
            NoteNo = Convert.ToInt32(row["fk_noteno"]);
            ChType = Convert.ToInt32(row["chtype"]);
            ChNo = Convert.ToInt32(row["chno"]);
            Name = Convert.ToString(row["name"]);
        }
    }

    public class ScheduleParamDataSet : UlDataSet
    {
        public ScheduleParamDataSet(FbConnection connect, FbCommand command, FbDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public int RecNo { get; set; }
        public int ParamNo { get; set; }
        public string Standard { get; set; }
        public string Name { get; set; }
        public int NoOfSteady { get; set; }
        public int Preparation { get; set; }
        public int Judgement { get; set; }
        public int Repeat { get; set; }

        // Indoor 1
        public EIndoorUse ID1Use { get; set; }
        public EIndoorMode ID1Mode1 { get; set; }
        public EIndoorDuct ID1Duct1 { get; set; }
        public EIndoorMode ID1Mode2 { get; set; }
        public EIndoorDuct ID1Duct2 { get; set; }
        public float ID1EdbSetup { get; set; }
        public float ID1EdbAvg { get; set; }
        public float ID1EdbDev { get; set; }
        public float ID1EwbSetup { get; set; }
        public float ID1EwbAvg { get; set; }
        public float ID1EwbDev { get; set; }
        public float ID1Ldb1Dev { get; set; }
        public float ID1Lwb1Dev { get; set; }
        public float ID1Af1Dev { get; set; }
        public float ID1Ldb2Dev { get; set; }
        public float ID1Lwb2Dev { get; set; }
        public float ID1Af2Dev { get; set; }
        public float ID1Cdp1Setup { get; set; }
        public float ID1Cdp1Avg { get; set; }
        public float ID1Cdp1Dev { get; set; }
        public float ID1Cdp2Setup { get; set; }
        public float ID1Cdp2Avg { get; set; }
        public float ID1Cdp2Dev { get; set; }

        // Indoor 2
        public EIndoorUse ID2Use { get; set; }
        public EIndoorMode ID2Mode1 { get; set; }
        public EIndoorDuct ID2Duct1 { get; set; }
        public EIndoorMode ID2Mode2 { get; set; }
        public EIndoorDuct ID2Duct2 { get; set; }
        public float ID2EdbSetup { get; set; }
        public float ID2EdbAvg { get; set; }
        public float ID2EdbDev { get; set; }
        public float ID2EwbSetup { get; set; }
        public float ID2EwbAvg { get; set; }
        public float ID2EwbDev { get; set; }
        public float ID2Ldb1Dev { get; set; }
        public float ID2Lwb1Dev { get; set; }
        public float ID2Af1Dev { get; set; }
        public float ID2Ldb2Dev { get; set; }
        public float ID2Lwb2Dev { get; set; }
        public float ID2Af2Dev { get; set; }
        public float ID2Cdp1Setup { get; set; }
        public float ID2Cdp1Avg { get; set; }
        public float ID2Cdp1Dev { get; set; }
        public float ID2Cdp2Setup { get; set; }
        public float ID2Cdp2Avg { get; set; }
        public float ID2Cdp2Dev { get; set; }

        // Outdoor
        public EOutdoorUse ODUse { get; set; }
        public EEtcUse ODDp { get; set; }
        public EEtcUse ODAutoVolt { get; set; }
        public float ODEdbSetup { get; set; }
        public float ODEdbAvg { get; set; }
        public float ODEdbDev { get; set; }
        public float ODEwbSetup { get; set; }
        public float ODEwbAvg { get; set; }
        public float ODEwbDev { get; set; }
        public float ODEdpSetup { get; set; }
        public float ODEdpAvg { get; set; }
        public float ODEdpDev { get; set; }
        public float ODVolt1Setup { get; set; }
        public float ODVolt1Avg { get; set; }
        public float ODVolt1Dev { get; set; }
        public float ODVolt2Setup { get; set; }
        public float ODVolt2Avg { get; set; }
        public float ODVolt2Dev { get; set; }

        public void Select(int paramNo = -1)
        {
            SetTrans(null);
            command.CommandText =
                  $" select * from TB_SCHEDULEPARAM "
                + $" where fk_paramno={paramNo} "
                + $" order by standard, name asc ";
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void SelectOrderByRecNo(int paramNo = -1)
        {
            SetTrans(null);
            command.CommandText =
                  $" select * from TB_SCHEDULEPARAM "
                + $" where fk_paramno={paramNo} "
                + $" order by pk_recno asc ";
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Select(string standard, int paramNo = -1)
        {
            SetTrans(null);
            command.CommandText = 
                  $" select * from TB_SCHEDULEPARAM "
                + $" where fk_paramno={paramNo} and standard like '{standard}%' "
                + $" order by name asc ";
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(FbTransaction trans = null)
        {
            string sql = 
                  $" insert into TB_SCHEDULEPARAM values ({RecNo}, {ParamNo}, "
                + $" '{Standard}', '{Name}', {NoOfSteady}, {Preparation}, {Judgement}, {Repeat}, "
                + $" {(int)ID1Use}, {(int)ID1Mode1}, {(int)ID1Duct1}, {(int)ID1Mode2}, {(int)ID1Duct2}, "
                + $" {ID1EdbSetup}, {ID1EdbAvg}, {ID1EdbDev}, {ID1EwbSetup}, {ID1EwbAvg}, {ID1EwbDev}, "
                + $" {ID1Ldb1Dev}, {ID1Lwb1Dev}, {ID1Af1Dev}, {ID1Ldb2Dev}, {ID1Lwb2Dev}, {ID1Af2Dev}, "
                + $" {ID1Cdp1Setup}, {ID1Cdp1Avg}, {ID1Cdp1Dev}, {ID1Cdp2Setup}, {ID1Cdp2Avg}, {ID1Cdp2Dev}, "
                + $" {(int)ID2Use}, {(int)ID2Mode1}, {(int)ID2Duct1}, {(int)ID2Mode2}, {(int)ID2Duct2}, "
                + $" {ID2EdbSetup}, {ID2EdbAvg}, {ID2EdbDev}, {ID2EwbSetup}, {ID2EwbAvg}, {ID2EwbDev}, "
                + $" {ID2Ldb1Dev}, {ID2Lwb1Dev}, {ID2Af1Dev}, {ID2Ldb2Dev}, {ID2Lwb2Dev}, {ID2Af2Dev}, "
                + $" {ID2Cdp1Setup}, {ID2Cdp1Avg}, {ID2Cdp1Dev}, {ID2Cdp2Setup}, {ID2Cdp2Avg}, {ID2Cdp2Dev}, "
                + $" {(int)ODUse}, {(int)ODDp}, {(int)ODAutoVolt}, {ODEdbSetup}, {ODEdbAvg}, {ODEdbDev}, "
                + $" {ODEwbSetup}, {ODEwbAvg}, {ODEwbDev}, {ODEdpSetup}, {ODEdpAvg}, {ODEdpDev}, "
                + $" {ODVolt1Setup}, {ODVolt1Avg}, {ODVolt1Dev}, {ODVolt2Setup}, {ODVolt2Avg}, {ODVolt2Dev}) ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Update(FbTransaction trans = null)
        {
            string sql = $" update TB_SCHEDULEPARAM set "
                + $" standard='{Standard}', name='{Name}', noofsteady={NoOfSteady}, "
                + $" preparation={Preparation}, judgement={Judgement}, repeat={Repeat}, "
                + $" id1use={(int)ID1Use}, id1mode1={(int)ID1Mode1}, id1duct1={(int)ID1Duct1}, "
                + $" id1mode2={(int)ID1Mode2}, id1duct2={(int)ID1Duct2}, "
                + $" id1edbsetup={ID1EdbSetup}, id1edbavg={ID1EdbAvg}, id1edbdev={ID1EdbDev}, "
                + $" id1ewbsetup={ID1EwbSetup}, id1ewbavg={ID1EwbAvg}, id1ewbdev={ID1EwbDev}, "
                + $" id1ldb1dev={ID1Ldb1Dev}, id1lwb1dev={ID1Lwb1Dev}, id1af1dev={ID1Af1Dev}, "
                + $" id1ldb2dev={ID1Ldb2Dev}, id1lwb2dev={ID1Lwb2Dev}, id1af2dev={ID1Af2Dev}, "
                + $" id1cdp1setup={ID1Cdp1Setup}, id1cdp1avg={ID1Cdp1Avg}, id1cdp1dev={ID1Cdp1Dev}, "
                + $" id1cdp2setup={ID1Cdp2Setup}, id1cdp2avg={ID1Cdp2Avg}, id1cdp2dev={ID1Cdp2Dev}, "
                + $" id2use={(int)ID2Use}, id2mode1={(int)ID2Mode1}, id2duct1={(int)ID2Duct1}, "
                + $" id2mode2={(int)ID2Mode2}, id2duct2={(int)ID2Duct2}, "
                + $" id2edbsetup={ID2EdbSetup}, id2edbavg={ID2EdbAvg}, id2edbdev={ID2EdbDev}, "
                + $" id2ewbsetup={ID2EwbSetup}, id2ewbavg={ID2EwbAvg}, id2ewbdev={ID2EwbDev}, "
                + $" id2ldb1dev={ID2Ldb1Dev}, id2lwb1dev={ID2Lwb1Dev}, id2af1dev={ID2Af1Dev}, "
                + $" id2ldb2dev={ID2Ldb2Dev}, id2lwb2dev={ID2Lwb2Dev}, id2af2dev={ID2Af2Dev}, "
                + $" id2cdp1setup={ID2Cdp1Setup}, id2cdp1avg={ID2Cdp1Avg}, id2cdp1dev={ID2Cdp1Dev}, "
                + $" id2cdp2setup={ID2Cdp2Setup}, id2cdp2avg={ID2Cdp2Avg}, id2cdp2dev={ID2Cdp2Dev}, "
                + $" oduse={(int)ODUse}, oddp={(int)ODDp}, odautovolt={(int)ODAutoVolt}, "
                + $" odedbsetup={ODEdbSetup}, odedbavg={ODEdbAvg}, odedbdev={ODEdbDev}, "
                + $" odewbsetup={ODEwbSetup}, odewbavg={ODEwbAvg}, odewbdev={ODEwbDev}, "
                + $" odedpsetup={ODEdpSetup}, odedpavg={ODEdpAvg}, odedpdev={ODEdpDev}, "
                + $" odvolt1setup={ODVolt1Setup}, odvolt1avg={ODVolt1Avg}, odvolt1dev={ODVolt1Dev}, "
                + $" odvolt2setup={ODVolt2Setup}, odvolt2avg={ODVolt2Avg}, odvolt2dev={ODVolt2Dev} "
                + $" where pk_recno={RecNo} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Delete(FbTransaction trans = null)
        {
            string sql = $"delete from TB_SCHEDULEPARAM where pk_recno={RecNo}";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Delete(int paramNo, FbTransaction trans = null)
        {
            string sql = $" delete from TB_SCHEDULEPARAM where fk_paramno={paramNo} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Fetch(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                Fetch(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                RecNo = 0;
                ParamNo = 0;
                Standard = "";
                Name = "";
                NoOfSteady = 0;
                Preparation = 0;
                Judgement = 0;
                Repeat = 0;

                ID1Use = EIndoorUse.NotUsed;
                ID1Mode1 = EIndoorMode.NotUsed;
                ID1Duct1 = EIndoorDuct.NotUsed;
                ID1Mode2 = EIndoorMode.NotUsed;
                ID1Duct2 = EIndoorDuct.NotUsed;
                ID1EdbSetup = 0;
                ID1EdbAvg = 0;
                ID1EdbDev = 0;
                ID1EwbSetup = 0;
                ID1EwbAvg = 0;
                ID1EwbDev = 0;
                ID1Ldb1Dev = 0;
                ID1Lwb1Dev = 0;
                ID1Af1Dev = 0;
                ID1Ldb2Dev = 0;
                ID1Lwb2Dev = 0;
                ID1Af2Dev = 0;
                ID1Cdp1Setup = 0;
                ID1Cdp1Avg = 0;
                ID1Cdp1Dev = 0;
                ID1Cdp2Setup = 0;
                ID1Cdp2Avg = 0;
                ID1Cdp2Dev = 0;

                ID2Use = EIndoorUse.NotUsed;
                ID2Mode1 = EIndoorMode.NotUsed;
                ID2Duct1 = EIndoorDuct.NotUsed;
                ID2Mode2 = EIndoorMode.NotUsed;
                ID2Duct2 = EIndoorDuct.NotUsed;
                ID2EdbSetup = 0;
                ID2EdbAvg = 0;
                ID2EdbDev = 0;
                ID2EwbSetup = 0;
                ID2EwbAvg = 0;
                ID2EwbDev = 0;
                ID2Ldb1Dev = 0;
                ID2Lwb1Dev = 0;
                ID2Af1Dev = 0;
                ID2Ldb2Dev = 0;
                ID2Lwb2Dev = 0;
                ID2Af2Dev = 0;
                ID2Cdp1Setup = 0;
                ID2Cdp1Avg = 0;
                ID2Cdp1Dev = 0;
                ID2Cdp2Setup = 0;
                ID2Cdp2Avg = 0;
                ID2Cdp2Dev = 0;

                ODUse = EOutdoorUse.NotUsed;
                ODDp = EEtcUse.NotUsed;
                ODAutoVolt = EEtcUse.NotUsed;
                ODEdbSetup = 0;
                ODEdbAvg = 0;
                ODEdbDev = 0;
                ODEwbSetup = 0;
                ODEwbAvg = 0;
                ODEwbDev = 0;
                ODEdpSetup = 0;
                ODEdpAvg = 0;
                ODEdpDev = 0;
                ODVolt1Setup = 0;
                ODVolt1Avg = 0;
                ODVolt1Dev = 0;
                ODVolt2Setup = 0;
                ODVolt2Avg = 0;
                ODVolt2Dev = 0;
            }
        }

        public void Fetch(DataRow row)
        {
            RecNo = Convert.ToInt32(row["pk_recno"]);
            ParamNo = Convert.ToInt32(row["fk_paramno"]);
            Standard = Convert.ToString(row["standard"]);
            Name = Convert.ToString(row["name"]);
            NoOfSteady = Convert.ToInt32(row["noofsteady"]);
            Preparation = Convert.ToInt32(row["preparation"]);
            Judgement = Convert.ToInt32(row["judgement"]);
            Repeat = Convert.ToInt32(row["repeat"]);

            ID1Use = (EIndoorUse)Convert.ToInt32(row["id1use"]);
            ID1Mode1 = (EIndoorMode)Convert.ToInt32(row["id1mode1"]);
            ID1Duct1 = (EIndoorDuct)Convert.ToInt32(row["id1duct1"]);
            ID1Mode2 = (EIndoorMode)Convert.ToInt32(row["id1mode2"]);
            ID1Duct2 = (EIndoorDuct)Convert.ToInt32(row["id1duct2"]);
            ID1EdbSetup = Convert.ToSingle(row["id1edbsetup"]);
            ID1EdbAvg = Convert.ToSingle(row["id1edbavg"]);
            ID1EdbDev = Convert.ToSingle(row["id1edbdev"]);
            ID1EwbSetup = Convert.ToSingle(row["id1ewbsetup"]);
            ID1EwbAvg = Convert.ToSingle(row["id1ewbavg"]);
            ID1EwbDev = Convert.ToSingle(row["id1ewbdev"]);
            ID1Ldb1Dev = Convert.ToSingle(row["id1ldb1dev"]);
            ID1Lwb1Dev = Convert.ToSingle(row["id1lwb1dev"]);
            ID1Af1Dev = Convert.ToSingle(row["id1af1dev"]);
            ID1Ldb2Dev = Convert.ToSingle(row["id1ldb2dev"]);
            ID1Lwb2Dev = Convert.ToSingle(row["id1lwb2dev"]);
            ID1Af2Dev = Convert.ToSingle(row["id1af2dev"]);
            ID1Cdp1Setup = Convert.ToSingle(row["id1cdp1setup"]);
            ID1Cdp1Avg = Convert.ToSingle(row["id1cdp1avg"]);
            ID1Cdp1Dev = Convert.ToSingle(row["id1cdp1dev"]);
            ID1Cdp2Setup = Convert.ToSingle(row["id1cdp2setup"]);
            ID1Cdp2Avg = Convert.ToSingle(row["id1cdp2avg"]);
            ID1Cdp2Dev = Convert.ToSingle(row["id1cdp2dev"]);

            ID2Use = (EIndoorUse)Convert.ToInt32(row["id2use"]);
            ID2Mode1 = (EIndoorMode)Convert.ToInt32(row["id2mode1"]);
            ID2Duct1 = (EIndoorDuct)Convert.ToInt32(row["id2duct1"]);
            ID2Mode2 = (EIndoorMode)Convert.ToInt32(row["id2mode2"]);
            ID2Duct2 = (EIndoorDuct)Convert.ToInt32(row["id2duct2"]);
            ID2EdbSetup = Convert.ToSingle(row["id2edbsetup"]);
            ID2EdbAvg = Convert.ToSingle(row["id2edbavg"]);
            ID2EdbDev = Convert.ToSingle(row["id2edbdev"]);
            ID2EwbSetup = Convert.ToSingle(row["id2ewbsetup"]);
            ID2EwbAvg = Convert.ToSingle(row["id2ewbavg"]);
            ID2EwbDev = Convert.ToSingle(row["id2ewbdev"]);
            ID2Ldb1Dev = Convert.ToSingle(row["id2ldb1dev"]);
            ID2Lwb1Dev = Convert.ToSingle(row["id2lwb1dev"]);
            ID2Af1Dev = Convert.ToSingle(row["id2af1dev"]);
            ID2Ldb2Dev = Convert.ToSingle(row["id2ldb2dev"]);
            ID2Lwb2Dev = Convert.ToSingle(row["id2lwb2dev"]);
            ID2Af2Dev = Convert.ToSingle(row["id2af2dev"]);
            ID2Cdp1Setup = Convert.ToSingle(row["id2cdp1setup"]);
            ID2Cdp1Avg = Convert.ToSingle(row["id2cdp1avg"]);
            ID2Cdp1Dev = Convert.ToSingle(row["id2cdp1dev"]);
            ID2Cdp2Setup = Convert.ToSingle(row["id2cdp2setup"]);
            ID2Cdp2Avg = Convert.ToSingle(row["id2cdp2avg"]);
            ID2Cdp2Dev = Convert.ToSingle(row["id2cdp2dev"]);

            ODUse = (EOutdoorUse)Convert.ToInt32(row["oduse"]);
            ODDp = (EEtcUse)Convert.ToInt32(row["oddp"]);
            ODAutoVolt = (EEtcUse)Convert.ToInt32(row["odautovolt"]);
            ODEdbSetup = Convert.ToSingle(row["odedbsetup"]);
            ODEdbAvg = Convert.ToSingle(row["odedbavg"]);
            ODEdbDev = Convert.ToSingle(row["odedbdev"]);
            ODEwbSetup = Convert.ToSingle(row["odewbsetup"]);
            ODEwbAvg = Convert.ToSingle(row["odewbavg"]);
            ODEwbDev = Convert.ToSingle(row["odewbdev"]);
            ODEdpSetup = Convert.ToSingle(row["odedpsetup"]);
            ODEdpAvg = Convert.ToSingle(row["odedpavg"]);
            ODEdpDev = Convert.ToSingle(row["odedpdev"]);
            ODVolt1Setup = Convert.ToSingle(row["odvolt1setup"]);
            ODVolt1Avg = Convert.ToSingle(row["odvolt1avg"]);
            ODVolt1Dev = Convert.ToSingle(row["odvolt1dev"]);
            ODVolt2Setup = Convert.ToSingle(row["odvolt2setup"]);
            ODVolt2Avg = Convert.ToSingle(row["odvolt2avg"]);
            ODVolt2Dev = Convert.ToSingle(row["odvolt2dev"]);
        }
    }

    public class DataBookDataSet : UlDataSet
    {
        public DataBookDataSet(FbConnection connect, FbCommand command, FbDataAdapter adapter)
            : base(connect, command, adapter)
        {
            Condition = new DataBookCondition();
        }

        public Int64 RecNo { get; set; }
        public int UserNo { get; set; }
        public string BeginTime { get; set; }
        public string EndTime { get; set; }
        public string ElapsedTime { get; set; }
        public int TestLine { get; set; }
        public int IntegCount { get; set; }
        public int IntegTime { get; set; }
        public int ScanTime { get; set; }
        public string Company { get; set; }
        public string TestName { get; set; }
        public string TestNo { get; set; }
        public string Observer { get; set; }
        public string Maker { get; set; }
        public string Model1 { get; set; }
        public string Serial1 { get; set; }
        public string Model2 { get; set; }
        public string Serial2 { get; set; }
        public string Model3 { get; set; }
        public string Serial3 { get; set; }
        public string ExpDevice { get; set; }
        public string Refrige { get; set; }
        public string RefCharge { get; set; }
        public string Capacity { get; set; }
        public string PowerInput { get; set; }
        public string EER_COP { get; set; }
        public string PowerSource { get; set; }
        public string TotalCapacity { get; set; }
        public string TotalPower { get; set; }
        public string TotalEER_COP { get; set; }
        public string Memo { get; set; }
        public ETestState State { get; set; }

        public DataBookCondition Condition { get; private set; }

        public void Select()
        {
            string sql
                = " select t1.*, t2.name as username from TB_DATABOOK t1 "
                + " join TB_USER t2 on t2.pk_recno=t1.fk_userno "
                + " where t1.pk_recno>=0 ";

            if (Condition.TimeUsed == true)
            {
                if (Condition.FromTime.ToString("yyyy-MM-dd") == Condition.ToTime.ToString("yyyy-MM-dd"))
                {
                    sql += $" and t1.begintime like '{Condition.FromTime.ToString("yyyy-MM-dd")}%%' ";
                }
                else
                {
                    sql += $" and (t1.begintime>='{Condition.FromTime.ToString("yyyy-MM-dd")} 00:00:00' ";
                    sql += $" and t1.begintime<='{Condition.ToTime.ToString("yyyy-MM-dd")} 23:59:59') ";
                }
            }

            if (Condition.Line > 0)
            {
                sql += $" and t1.testline={Condition.Line - 1} ";
            }
            
            if (Condition.State > 0)
            {
                ETestState state = (Condition.State == 1) ? ETestState.Done : ETestState.Stopped;

                sql += $" and t1.state={(int)state} ";
            }
            else
            {
                sql += $" and t1.state<>0 ";
            }

            SetTrans(null);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Select(Int64 recNo)
        {
            string sql
                = " select t1.*, t2.name as username from TB_DATABOOK t1 "
                + " join TB_USER t2 on t2.pk_recno=t1.fk_userno "
                + $" where t1.pk_recno={recNo} ";

            SetTrans(null);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(FbTransaction trans = null)
        {
            string sql = $" insert into TB_DATABOOK values ({RecNo}, {UserNo}, '{BeginTime}', '{EndTime}', '{ElapsedTime}', {TestLine}, "
                + $" {IntegCount}, {IntegTime}, {ScanTime}, '{Company}', '{TestName}', '{TestNo}', '{Observer}', '{Maker}', '{Model1}', "
                + $" '{Serial1}', '{Model2}', '{Serial2}', '{Model3}', '{Serial3}', '{ExpDevice}', '{Refrige}', '{RefCharge}', '{Capacity}', "
                + $" '{PowerInput}', '{EER_COP}', '{PowerSource}', '{TotalCapacity}', '{TotalPower}', '{TotalEER_COP}', '{Memo}', {(int)State}) ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        //public void Update(FbTransaction trans = null)
        //{
        //    string sql = $" update TB_DATABOOK set "
        //        + $" fk_userno={UserNo}, begintime='{BeginTime}', endtime='{EndTime}', testline={TestLine}, "
        //        + $" integcount={IntegCount}, integtime={IntegTime}, scantime={ScanTime}, company='{Company}', "
        //        + $" testname='{TestName}', testno='{TestNo}', observer='{Observer}', maker='{Maker}', "
        //        + $" model1='{Model1}', serial1='{Serial1}', model2='{Model2}', serial2='{Serial2}', "
        //        + $" model3='{Model3}', serial3='{Serial3}', expdevice='{ExpDevice}', refrige='{Refrige}', "
        //        + $" refcharge='{RefCharge}', capacity='{Capacity}', powerinput='{PowerInput}', "
        //        + $" eer_cop='{EER_COP}', powersource='{PowerSource}', state={(int)State} "
        //        + $" where pk_recno={RecNo} ";

        //    SetTrans(trans);

        //    try
        //    {
        //        BeginTrans(trans);
        //        command.CommandText = sql;
        //        command.ExecuteNonQuery();
        //        CommitTrans(trans);
        //    }
        //    catch (Exception e)
        //    {
        //        Resource.TLog.Log((int)ELogItem.Error, sql);
        //        Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
        //        RollbackTrans(trans, e);
        //    }
        //}

        public void Update(FbTransaction trans = null)
        {
            string sql
                = $" update TB_DATABOOK set endtime='{EndTime}', elapsedtime='{ElapsedTime}', totalcapacity='{TotalCapacity}', "
                + $" totalpower='{TotalPower}', totaleer_cop='{TotalEER_COP}', state={(int)State} "
                + $" where pk_recno={RecNo} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Update(ETestState state, FbTransaction trans = null)
        {
            string sql 
                = $" update TB_DATABOOK set state={(int)state} "
                + $" where pk_recno={RecNo} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Delete(FbTransaction trans = null)
        {
            string sql = $" delete from TB_DATABOOK where pk_recno={RecNo} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Fetch(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                Fetch(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                RecNo  = 0;
                UserNo  = 0;
                BeginTime  = "";
                EndTime  = "";
                TestLine  = 0;
                IntegCount  = 0;
                IntegTime  = 0;
                ScanTime  = 0;
                Company  = "";
                TestName  = "";
                TestNo  = "";
                Observer  = "";
                Maker  = "";
                Model1  = "";
                Serial1  = "";
                Model2  = "";
                Serial2  = "";
                Model3  = "";
                Serial3  = "";
                ExpDevice  = "";
                Refrige  = "";
                RefCharge  = "";
                Capacity  = "";
                PowerInput  = "";
                EER_COP  = "";
                PowerSource  = "";
                State = ETestState.Testing;
            }
        }

        public void Fetch(DataRow row)
        {
            RecNo = Convert.ToInt64(row["pk_recno"]);
            UserNo = Convert.ToInt32(row["fk_userno"]);
            BeginTime = Convert.ToString(row["begintime"]);
            EndTime = Convert.ToString(row["endtime"]);
            TestLine = Convert.ToInt32(row["testline"]);
            IntegCount = Convert.ToInt32(row["integcount"]);
            IntegTime = Convert.ToInt32(row["integtime"]);
            ScanTime = Convert.ToInt32(row["scantime"]);
            Company = Convert.ToString(row["company"]);
            TestName = Convert.ToString(row["testname"]);
            TestNo = Convert.ToString(row["testno"]);
            Observer = Convert.ToString(row["observer"]);
            Maker = Convert.ToString(row["maker"]);
            Model1 = Convert.ToString(row["model1"]);
            Serial1 = Convert.ToString(row["serial1"]);
            Model2 = Convert.ToString(row["model2"]);
            Serial2 = Convert.ToString(row["serial2"]);
            Model3 = Convert.ToString(row["model3"]);
            Serial3 = Convert.ToString(row["serial3"]);
            ExpDevice = Convert.ToString(row["expdevice"]);
            Refrige = Convert.ToString(row["refrige"]);
            RefCharge = Convert.ToString(row["refcharge"]);
            Capacity = Convert.ToString(row["capacity"]);
            PowerInput = Convert.ToString(row["powerinput"]);
            EER_COP = Convert.ToString(row["eer_cop"]);
            PowerSource = Convert.ToString(row["powersource"]);
            State = (ETestState)Convert.ToInt32(row["state"]);
        }
    }

    public class DataSheetDataSet : UlDataSet
    {
        public DataSheetDataSet(FbConnection connect, FbCommand command, FbDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public Int64 RecNo { get; set; }
        public Int64 DataBookNo { get; set; }
        public string SheetName { get; set; }
        public bool Use { get; set; }
        public string IDTemp { get; set; }
        public string IDState { get; set; }
        public string ODTemp { get; set; }
        public string ODState { get; set; }
        public string NozzleName { get; set; }
        public string NozzleState { get; set; }

        public void Select()
        {
            SetTrans(null);
            command.CommandText = " select * from TB_DATASHEET ";
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Select(Int64 dataBookNo)
        {
            SetTrans(null);
            command.CommandText = $" select * from TB_DATASHEET where fk_databookno={dataBookNo} ";
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(FbTransaction trans = null)
        {
            string sql = $" insert into TB_DATASHEET values "
                + $" ({RecNo}, {DataBookNo}, '{SheetName}', {((Use==false) ? 0 : 1)}, '{IDTemp}', "
                + $" '{IDState}', '{ODTemp}', '{ODState}', '{NozzleName}', '{NozzleState}') ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Update(FbTransaction trans = null)
        {
            string sql = $" update TB_DATASHEET set fk_databookno={DataBookNo}, "
                + $" sheetname='{SheetName}', use={((Use == false) ? 0 : 1)}, "
                + $" idtemp='{IDTemp}', idstate='{IDState}', odtemp='{ODTemp}', "
                + $" odstate='{ODState}', nozzlename='{NozzleName}', nozzlestate='{NozzleState}' "
                + $" where pk_recno={RecNo} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void UpdateTemp(FbTransaction trans = null)
        {
            string sql = $" update TB_DATASHEET set "
                + $" idtemp='{IDTemp}', odtemp='{ODTemp}' "
                + $" where pk_recno={RecNo} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Delete(FbTransaction trans = null)
        {
            string sql = $" delete from TB_DATASHEET where fk_databookno={DataBookNo} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Fetch(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                Fetch(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                RecNo = 0;
                DataBookNo = 0;
                SheetName = "";
                Use = false;
                IDTemp = "";
                IDState = "";
                ODTemp = "";
                ODState = "";
                NozzleName = "";
                NozzleState = "";
            }
        }

        public void Fetch(DataRow row)
        {
            RecNo = Convert.ToInt64(row["pk_recno"]);
            DataBookNo = Convert.ToInt64(row["fk_databookno"]);
            SheetName = Convert.ToString(row["sheetname"]);
            Use = (Convert.ToInt32(row["use"]) == 0) ? false : true;
            IDTemp = Convert.ToString(row["idtemp"]);
            IDState = Convert.ToString(row["idstate"]);
            ODTemp = Convert.ToString(row["odtemp"]);
            ODState = Convert.ToString(row["odstate"]);
            NozzleName = Convert.ToString(row["nozzlename"]);
            NozzleState = Convert.ToString(row["nozzlestate"]);
        }
    }

    public class DataValueUnitDataSet : UlDataSet
    {
        public DataValueUnitDataSet(FbConnection connect, FbCommand command, FbDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public Int64 RecNo { get; set; }
        public Int64 DataSheetNo { get; set; }
        public string ValueName { get; set; }
        public int UnitType { get; set; }
        public int UnitFrom { get; set; }
        public int UnitTo { get; set; }
        public string Format { get; set; }

        public void Select(Int64 sheetNo)
        {
            SetTrans(null);
            command.CommandText = $" select * from TB_DATAVALUEUNIT where fk_datasheetno={sheetNo} ";
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(FbTransaction trans = null)
        {
            string sql = " insert into TB_DATAVALUEUNIT values "
                + $" ({RecNo}, {DataSheetNo}, '{ValueName}', {UnitType}, {UnitFrom}, {UnitTo}, '{Format}') ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Update(FbTransaction trans = null)
        {
        }

        public void Delete(FbTransaction trans = null)
        {
            string sql = $" delete from TB_DATAVALUEUNIT where fk_datasheetno={DataSheetNo} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Fetch(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                Fetch(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                RecNo = 0;
                DataSheetNo = 0;
                ValueName = "";
                UnitType = 0;
                UnitFrom = 0;
                UnitTo = 0;
                Format = "";
            }
        }

        public void Fetch(DataRow row)
        {
            RecNo = Convert.ToInt64(row["pk_recno"]);
            DataSheetNo = Convert.ToInt64(row["fk_datasheetno"]);
            ValueName = Convert.ToString(row["valuename"]);
            UnitType = Convert.ToInt32(row["unittype"]);
            UnitFrom = Convert.ToInt32(row["unitfrom"]);
            UnitTo = Convert.ToInt32(row["unitto"]);
            Format = Convert.ToString(row["format"]);
        }
    }

    public class DataValueDataSet : UlDataSet
    {
        public DataValueDataSet(FbConnection connect, FbCommand command, FbDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public Int64 RecNo { get; set; }
        public Int64 DataValueUnitNo { get; set; }
        public int DataNo { get; set; }
        public float DataValue { get; set; }

        public void Select(Int64 valueUnitNo)
        {
            SetTrans(null);
            command.CommandText = $" select * from TB_DATAVALUE where fk_datavalueunitno={valueUnitNo} ";
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(FbTransaction trans = null)
        {
            float dataValue = (float.IsNaN(DataValue) == true) ? 0.0f : DataValue;
            string sql = $" insert into TB_DATAVALUE values "
                + $" ({RecNo}, {DataValueUnitNo}, {DataNo}, {dataValue}) ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Update(FbTransaction trans = null)
        {
            string sql = $" update TB_DATAVALUE set "
                + $" fk_datavalueunitno={DataValueUnitNo}, {DataNo}, datavalue={DataValue} "
                + $" where pk_recno={RecNo} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Delete(FbTransaction trans = null)
        {
            string sql = $" delete from TB_DATAVALUE where fk_sheetno={DataValueUnitNo} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Fetch(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                Fetch(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                RecNo = 0;
                DataValueUnitNo = 0;
                DataNo = 0;
                DataValue = 0;
            }
        }

        public void Fetch(DataRow row)
        {
            RecNo = Convert.ToInt64(row["pk_recno"]);
            DataValueUnitNo = Convert.ToInt64(row["fk_datavalueunitno"]);
            DataNo = Convert.ToInt32(row["datano"]);
            DataValue = Convert.ToSingle(row["datavalue"]);
        }
    }

    public class DataRawUnitDataSet : UlDataSet
    {
        public DataRawUnitDataSet(FbConnection connect, FbCommand command, FbDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public Int64 RecNo { get; set; }
        public Int64 DataBookNo { get; set; }
        public string DataName { get; set; }
        public int UnitType { get; set; }
        public int UnitFrom { get; set; }
        public int UnitTo { get; set; }

        public void Select(Int64 bookNo)
        {
            SetTrans(null);
            command.CommandText = $" select * from TB_DATARAWUNIT where fk_databookno={bookNo} ";
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void GetDataRawUnit(Int64 bookNo, ConditionMethod method)
        {
            SetTrans(null);
            command.CommandText = $" select distinct unittype, unitto from TB_DATARAWUNIT where fk_databookno={bookNo} ";
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(FbTransaction trans = null)
        {
            string sql = " insert into TB_DATARAWUNIT values "
                + $" ({RecNo}, {DataBookNo}, '{DataName}', {UnitType}, {UnitFrom}, {UnitTo}) ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Update(FbTransaction trans = null)
        {
        }

        public void Delete(FbTransaction trans = null)
        {
            string sql = $" delete from TB_DATARAWUNIT where fk_databookno={DataBookNo} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Fetch(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                Fetch(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                RecNo = 0;
                DataBookNo = 0;
                DataName = "";
                UnitType = 0;
                UnitFrom = 0;
                UnitTo = 0;
            }
        }

        public void Fetch(DataRow row)
        {
            RecNo = Convert.ToInt64(row["pk_recno"]);
            DataBookNo = Convert.ToInt64(row["fk_databookno"]);
            DataName = Convert.ToString(row["DataName"]);
            UnitType = Convert.ToInt32(row["unittype"]);
            UnitFrom = Convert.ToInt32(row["unitfrom"]);
            UnitTo = Convert.ToInt32(row["unitto"]);
        }
    }

    public class DataRawDataSet : UlDataSet
    {
        public DataRawDataSet(FbConnection connect, FbCommand command, FbDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public Int64 RecNo { get; set; }
        public Int64 DataRawUnitNo { get; set; }
        public string RegTime { get; set; }
        public int ScanTime { get; set; }
        public float[] DataRaw { get; set; }

        public void Select()
        {
            SetTrans(null);
            command.CommandText = " select * from TB_DATARAW ";
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Select(Int64 unitNo)
        {
            SetTrans(null);
            command.CommandText = $" select * from TB_DATARAW where fk_datarawunitno={unitNo} ";
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(FbTransaction trans = null)
        {
            string sql = " insert into TB_DATARAW values "
                + $" ({RecNo}, {DataRawUnitNo}, '{RegTime}', {ScanTime}, @dataraw) ";

            byte[] byData = new byte[DataRaw.Length * sizeof(float)];
            Buffer.BlockCopy(DataRaw, 0, byData, 0, byData.Length);

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;

                command.Parameters.Clear();
                command.Parameters.Add("@dataraw", FbDbType.Binary);
                command.Parameters["@dataraw"].Value = byData;

                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Update(FbTransaction trans = null)
        {
            string sql = $" update TB_DATARAW set "
                + $" fk_databookno={DataRawUnitNo}, regtime='{RegTime}', "
                + $" scantime={ScanTime}, dataraw=@dataraw "
                + $" where pk_recno={RecNo} ";

            byte[] byData = new byte[DataRaw.Length * sizeof(float)];
            Buffer.BlockCopy(DataRaw, 0, byData, 0, byData.Length);

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;

                command.Parameters.Clear();
                command.Parameters.Add("@dataraw", FbDbType.Binary);
                command.Parameters["@dataraw"].Value = byData;

                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Delete(FbTransaction trans = null)
        {
            string sql = $" delete from TB_DATARAW where fk_datarawunitno={DataRawUnitNo} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Fetch(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                Fetch(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                RecNo = 0;
                DataRawUnitNo = 0;
                RegTime = "";
                ScanTime = 1;
                DataRaw = null;
            }
        }

        public void Fetch(DataRow row)
        {
            byte[] byData;

            RecNo = Convert.ToInt64(row["pk_recno"]);
            DataRawUnitNo = Convert.ToInt64(row["fk_datarawunitno"]);
            RegTime = Convert.ToString(row["regtime"]);
            ScanTime = Convert.ToInt32(row["scantime"]);
            byData = (byte[])row["dataraw"];

            DataRaw = new float[byData.Length / sizeof(float)];
            Buffer.BlockCopy(byData, 0, DataRaw, 0, byData.Length);
        }
    }

    public class XAxisSettingDataSet : UlDataSet
    {
        public XAxisSettingDataSet(FbConnection connect, FbCommand command, FbDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public int RecNo { get; set; }
        public string Ip { get; set; }
        public int Mode { get; set; }
        public int GraphNo { get; set; }
        public int Minutes { get; set; }

        public void Select()
        {
            string sql = " select * from TB_XAXISSETTING "
                + $" where ip='{Ip}' and mode={Mode} and graphno={GraphNo} ";

            SetTrans(null);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(FbTransaction trans = null)
        {
            string sql = " insert into TB_XAXISSETTING values "
                + $" ({RecNo}, '{Ip}', {Mode}, {GraphNo}, {Minutes}) ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.Parameters.Clear();
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Update(FbTransaction trans = null)
        {
            string sql = $" update TB_XAXISSETTING set minutes={Minutes} "
                + $" where pk_recno={RecNo} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.Parameters.Clear();
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Delete(FbTransaction trans = null)
        {
            string sql = " delete from TB_XAXISSETTING "
                + $" where ip={Ip} and mode={Mode} and graphno={GraphNo} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Fetch(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                Fetch(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                RecNo = 0;
                Ip = "0.0.0.0";
                Mode = 0;
                GraphNo = 0;
                Minutes = 0;
            }
        }

        public void Fetch(DataRow row)
        {
            RecNo = Convert.ToInt32(row["pk_recno"]);
            Ip = Convert.ToString(row["ip"]);
            Mode = Convert.ToInt32(row["mode"]);
            GraphNo = Convert.ToInt32(row["graphno"]);
            Minutes = Convert.ToInt32(row["minutes"]);
        }
    }

    public class YAxisSettingDataSet : UlDataSet
    {
        public YAxisSettingDataSet(FbConnection connect, FbCommand command, FbDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public int RecNo { get; set; }
        public string Ip { get; set; }
        public int Mode { get; set; }
        public int GraphNo { get; set; }
        public bool Checked { get; set; }
        public EAxisAlign Align { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Unit { get; set; }
        public float VisualMin { get; set; }
        public float VisualMax { get; set; }
        public float WholeMin { get; set; }
        public float WholeMax { get; set; }

        public void Select()
        {
            string sql = " select * from TB_YAXISSETTING "
                + $" where ip='{Ip}' and mode={Mode} and graphno={GraphNo} ";

            SetTrans(null);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(FbTransaction trans = null)
        {
            int active = (Checked == false) ? 0 : 1;
            string sql = " insert into TB_YAXISSETTING values "
                + $" ({RecNo}, '{Ip}', {Mode}, {GraphNo}, {active}, {(int)Align}, '{Name}', " 
                + $" '{Desc}', @unit, {VisualMin}, {VisualMax}, {WholeMin}, {WholeMax}) ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.Parameters.Clear();
                command.Parameters.Add("@unit", FbDbType.VarChar);
                command.Parameters["@unit"].Value = Unit;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Update(FbTransaction trans = null)
        {
            int active = (Checked == false) ? 0 : 1;
            string sql = $" update TB_YAXISSETTING set "
                + $" checked={active}, align={(int)Align}, axisname='{Name}', axisdesc='{Desc}', axisunit=@unit, "
                + $" visualmin={VisualMin}, visualmax={VisualMax}, wholemin={WholeMin}, wholemax={WholeMax} "
                + $" where pk_recno={RecNo} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.Parameters.Clear();
                command.Parameters.Add("@unit", FbDbType.VarChar);
                command.Parameters["@unit"].Value = Unit;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Delete(FbTransaction trans = null)
        {
            string sql = " delete from TB_YAXISSETTING "
                + $" where ip={Ip} and mode={Mode} and graphno={GraphNo} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Fetch(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                Fetch(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                RecNo = 0;
                Ip = "0.0.0.0";
                Mode = 0;
                GraphNo = 0;
                Checked = false;
                Align = EAxisAlign.Left;
                Name = "";
                Desc = "";
                Unit = "";
                VisualMin = -100;
                VisualMax = 100;
                WholeMin = -100;
                WholeMax = 100;
            }
        }

        public void Fetch(DataRow row)
        {
            RecNo = Convert.ToInt32(row["pk_recno"]);
            Ip = Convert.ToString(row["ip"]);
            Mode = Convert.ToInt32(row["mode"]);
            GraphNo = Convert.ToInt32(row["graphno"]);
            Checked = (Convert.ToInt32(row["checked"]) == 0) ? false : true;
            Align = (EAxisAlign)Convert.ToInt32(row["align"]);
            Name = Convert.ToString(row["axisname"]);
            Desc = Convert.ToString(row["axisdesc"]);
            Unit = Convert.ToString(row["axisunit"]);
            VisualMin = Convert.ToSingle(row["visualmin"]);
            VisualMax = Convert.ToSingle(row["visualmax"]);
            WholeMin = Convert.ToSingle(row["wholemin"]);
            WholeMax = Convert.ToSingle(row["wholemax"]);
        }
    }

    public class SeriesSettingDataSet : UlDataSet
    {
        public SeriesSettingDataSet(FbConnection connect, FbCommand command, FbDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public int RecNo { get; set; }
        public string Ip { get; set; }
        public int Mode { get; set; }
        public int GraphNo { get; set; }
        public bool Checked { get; set; }
        public Color Color { get; set; }
        public string Name { get; set; }
        public string UnitType { get; set; }

        public void Select()
        {
            string sql = " select * from TB_SERIESSETTING "
                + $" where ip='{Ip}' and mode={Mode} and graphno={GraphNo} ";

            SetTrans(null);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(FbTransaction trans = null)
        {
            int active = (Checked == false) ? 0 : 1;
            string sql = " insert into TB_SERIESSETTING values "
                + $" ({RecNo}, '{Ip}', {Mode}, {GraphNo}, {active}, {Color.ToArgb()}, '{Name}', '{UnitType}') ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Update(FbTransaction trans = null)
        {
            int active = (Checked == false) ? 0 : 1;
            string sql = $" update TB_SERIESSETTING set "
                + $" ip='{Ip}', mode={Mode}, graphno={GraphNo}, checked={active}, "
                + $" color={Color.ToArgb()}, seriesname='{Name}', unittype='{UnitType}' "
                + $" where pk_recno={RecNo} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Delete(FbTransaction trans = null)
        {
            string sql = " delete from TB_SERIESSETTING "
                + $" where ip='{Ip}' and mode={Mode} and graphno={GraphNo} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Error, sql);
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                RollbackTrans(trans, e);
            }
        }

        public void Fetch(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                Fetch(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                RecNo = 0;
                Ip = "0.0.0.0";
                Mode = 0;
                GraphNo = 0;
                Checked = false;
                Color = Color.White;
                Name = "";
                UnitType = "";
            }
        }

        public void Fetch(DataRow row)
        {
            RecNo = Convert.ToInt32(row["pk_recno"]);
            Ip = Convert.ToString(row["ip"]);
            Mode = Convert.ToInt32(row["mode"]);
            GraphNo = Convert.ToInt32(row["graphno"]);
            Checked = (Convert.ToInt32(row["checked"]) == 0) ? false : true;
            Color = Color.FromArgb(Convert.ToInt32(row["color"]));
            Name = Convert.ToString(row["seriesname"]);
            UnitType = Convert.ToString(row["unittype"]);
        }
    }

    public class DataBookCondition
    {
        public bool TimeUsed { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public int Line { get; set; }
        public int State { get; set; }

        public DataBookCondition()
        {
            Reset();
        }

        public void Reset()
        {
            TimeUsed = false;
            FromTime = DateTime.Now;
            ToTime = DateTime.Now;
            Line = 0;
            State = 0;
        }
    }
}
