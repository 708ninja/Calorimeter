﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using Ulee.DllImport.Win32;
using Ulee.Utils;

namespace Hnc.Calorimeter.Client
{
    public enum EClientState
    {
        Openning,
        Running,
        Closing
    }

    static public class Resource
    {
        private const string csConfigIniFName = @"..\..\Config\Hnc.Calorimeter.3R.Client.Config.Ini";
        public const string csExcelOriginReport = @"..\..\Resource\Excel\PsychrometricDataSheet.LG.P14.xlsx";
        public const string csDateFormat = "yyyy-MM-dd";
        public const string csDateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        public const string Caption = "Calorimeter.Client";

        public const int WM_TEST_NORMAL_TERMINATED      = (Win32.WM_USER + 0);
        public const int WM_TEST_ABNORMAL_TERMINATED    = (Win32.WM_USER + 1);
        public const int WM_TEST_VALUE_INSERT_DATABOOK  = (Win32.WM_USER + 2);

        static public UlBinSets BusySets { get; set; }

        static public bool Busy
        {
            get
            {
                return (BusySets.Byte(0) == 0) ? false : true;
            }
        }

        static public EClientState State { get; set; }

        static public string Ip { get; private set; }

        static public int UserNo { get; set; }

        static public EUserAuthority Authority { get; set; }

        static public UlIniFile Ini { get; private set; }

        static public UlLogger TLog { get; private set; }

        static public UlLogger ALog { get; private set; }

        static public List<CalorimeterTestDatabase> TestDB { get; private set; }
        static public CalorimeterViewDatabase ViewDB { get; private set; }
        static public CalorimeterConfigDatabase ConfigDB { get; private set; }

        static public CalorimeterClient Client { get; private set; }
        
        static public NameTag Tag { get; private set; }

        static public TestValue Variables { get; set; }

        static public TestSettings Settings { get; set; }

        static public FormClientMain MainForm { get; set; }

        static public void Create()
        {
            BusySets = new UlBinSets(1);

            State = EClientState.Openning;

            //Ini = new UlIniFile(csConfigIniFName);

            Ip = GetLocalIP();

            UserNo = -1;
            Authority = EUserAuthority.Viewer;

            Tag = new NameTag(Ini);

            //TLog = new UlLogger();
            //TLog.Path = Ini.GetString("Log", "TotalPath");
            //TLog.FName = Ini.GetString("Log", "TotalFileName");
            //TLog.AddHead("NOTE");
            //TLog.AddHead("ERROR");
            //TLog.AddHead("EXCEPTION");

            Client = new CalorimeterClient(Ini);

            Settings = new TestSettings(Ini);
            Settings.Load();

            TestDB = new List<CalorimeterTestDatabase>();
            TestDB.Add(new CalorimeterTestDatabase());
            TestDB.Add(new CalorimeterTestDatabase());
            TestDB.Add(new CalorimeterTestDatabase());
            TestDB.Add(new CalorimeterTestDatabase());

            for (int i = 0; i < 4; i++)
            {
                TestDB[i].Database = Ini.GetString("Database", "FileName");
                TestDB[i].Open();
            }

            ViewDB = new CalorimeterViewDatabase();
            ViewDB.Database = Ini.GetString("Database", "FileName");
            ViewDB.Open();

            ConfigDB = new CalorimeterConfigDatabase();
            ConfigDB.Database = Ini.GetString("Database", "FileName");
            ConfigDB.Open();
        }

        static public void CreateLogger()
        {
            Ini = new UlIniFile(csConfigIniFName);

            TLog = new UlLogger();
            TLog.Path = Ini.GetString("Log", "TotalPath");
            TLog.FName = Ini.GetString("Log", "TotalFileName");
            TLog.AddHead("NOTE");
            TLog.AddHead("ERROR");
            TLog.AddHead("EXCEPTION");
        }

        static public void Destroy()
        {
            for (int i = 0; i < 4; i++)
            {
                if (TestDB[i] != null)
                {
                    TestDB[i].Close();
                }
            }

            if (ViewDB != null)
            {
                ViewDB.Close();
            }

            if (ConfigDB != null)
            {
                ConfigDB.Close();
            }
        }

        static private string GetLocalIP()
        {
            string localIP = "0.0.0.0";
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }

            return localIP;
        }
    }

    public class NameTag
    {
        public NameTag(UlIniFile ini)
        {
            Thermos = new List<MeasureRow>();
            Presses = new List<MeasureRow>();

            string value = ini.GetString("Recorder", "Pressure");
            string[] values = value.Split(new[] { ',' }, StringSplitOptions.None);

            PressIndex = int.Parse(values[0]);
            PressLength = int.Parse(values[1]);

            value = ini.GetString("Recorder", "Thermocouple");
            values = value.Split(new[] { ',' }, StringSplitOptions.None);

            ThermoIndex = int.Parse(values[0]);
            ThermoLength = int.Parse(values[1]);

            int i = 1;
            string key = $"Tag{i}";
            string name = ini.GetString("TC.Tag", key);

            while (string.IsNullOrWhiteSpace(name) == false)
            {
                Thermos.Add(new MeasureRow(null, "", name, i));

                i++;
                key = $"Tag{i}";
                name = ini.GetString("TC.Tag", key);
            }

            i = 1;
            key = $"Tag{i}";
            name = ini.GetString("Press.Tag", key);

            while (string.IsNullOrWhiteSpace(name) == false)
            {
                Presses.Add(new MeasureRow(null, "", name, i));

                i++;
                key = $"Tag{i}";
                name = ini.GetString("Press.Tag", key);
            }
        }

        public int ThermoIndex { get; private set; }
        public int ThermoLength { get; private set; }
        public List<MeasureRow> Thermos { get; private set; }

        public int PressIndex { get; private set; }
        public int PressLength { get; private set; }
        public List<MeasureRow> Presses { get; private set; }
    }
}
