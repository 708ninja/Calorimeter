﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FirebirdSql.Data.FirebirdClient;

using Ulee.Intel;
using Ulee.Utils;

namespace Hnc.Calorimeter.Server
{
    public class CalibratorCollection
    {
        public CalibratorCollection()
        {
            Ini = new UlIniFile(csCalibIniFName);
            Category = new Dictionary<string, Dictionary<int, CalibratorRow>>();

            Initialize();
        }

        private const string csCalibIniFName = @"..\..\Config\Hnc.Calorimeter.3R.Calibrator.Ini";

        public UlIniFile Ini { get; private set; }

        public Dictionary<string, Dictionary<int, CalibratorRow>> Category { get; private set; }

        public Dictionary<int, CalibratorRow> this[string key]
        { get { return Category[key]; } }

        private void Initialize()
        {
            Category.Add("All", new Dictionary<int, CalibratorRow>());

            int i = 1;
            string key = $"Item{i}";
            string value = Ini.GetString("All", key);

            while (value != "")
            {
                Category.Add(value, new Dictionary<int, CalibratorRow>());

                i++;
                key = $"Item{i}";
                value = Ini.GetString("All", key);
            }

            Dictionary<int, CalibratorRow> rows = null;
            Dictionary<int, CalibratorRow> allRows = null;

            foreach (KeyValuePair<string, Dictionary<int, CalibratorRow>> calRow in Category)
            {
                if (calRow.Key == "All")
                {
                    allRows = calRow.Value;
                    allRows.Clear();
                }
                else
                {
                    rows = calRow.Value;
                    rows.Clear();

                    i = 1;
                    key = $"Item{i}";
                    value = Ini.GetString(calRow.Key, key);

                    while (value != "")
                    {
                        string[] keys = value.Split(new[] { ',' }, StringSplitOptions.None);
                        CalibratorRow row = new CalibratorRow(int.Parse(keys[1]), keys[0]);

                        rows.Add(row.No, row);
                        allRows.Add(row.No, row);

                        i++;
                        key = $"Item{i}";
                        value = Ini.GetString(calRow.Key, key);
                    }
                }
            }
        }
    }

    public class CalibratorRow
    {
        public CalibratorRow(int no, string name)
        {
            Checked = false;
            No = no;
            Name = name;
            Raw = 0;

            Calibrator = new Calibrator();
        }

        public Calibrator Calibrator { get; private set; }

        public bool Checked { get; set; }

        public int No { get; set; }

        public string Name { get; set; }

        public float Raw { get; set; }

        public float Real { get; set; }

        public float PV1
        {
            get { return Calibrator.Points[0].PV; }
            set { Calibrator.Points[0].PV = value; }
        }
        public float SV1
        {
            get { return Calibrator.Points[0].SV; }
            set { Calibrator.Points[0].SV = value; }
        }

        public float PV2
        {
            get { return Calibrator.Points[1].PV; }
            set { Calibrator.Points[1].PV = value; }
        }
        public float SV2
        {
            get { return Calibrator.Points[1].SV; }
            set { Calibrator.Points[1].SV = value; }
        }

        public float PV3
        {
            get { return Calibrator.Points[2].PV; }
            set { Calibrator.Points[2].PV = value; }
        }
        public float SV3
        {
            get { return Calibrator.Points[2].SV; }
            set { Calibrator.Points[2].SV = value; }
        }

        public float PV4
        {
            get { return Calibrator.Points[3].PV; }
            set { Calibrator.Points[3].PV = value; }
        }
        public float SV4
        {
            get { return Calibrator.Points[3].SV; }
            set { Calibrator.Points[3].SV = value; }
        }

        public float PV5
        {
            get { return Calibrator.Points[4].PV; }
            set { Calibrator.Points[4].PV = value; }
        }
        public float SV5
        {
            get { return Calibrator.Points[4].SV; }
            set { Calibrator.Points[4].SV = value; }
        }

        public float PV6
        {
            get { return Calibrator.Points[5].PV; }
            set { Calibrator.Points[5].PV = value; }
        }
        public float SV6
        {
            get { return Calibrator.Points[5].SV; }
            set { Calibrator.Points[5].SV = value; }
        }

        public float PV7
        {
            get { return Calibrator.Points[6].PV; }
            set { Calibrator.Points[6].PV = value; }
        }
        public float SV7
        {
            get { return Calibrator.Points[6].SV; }
            set { Calibrator.Points[6].SV = value; }
        }

        public float PV8
        {
            get { return Calibrator.Points[7].PV; }
            set { Calibrator.Points[7].PV = value; }
        }
        public float SV8
        {
            get { return Calibrator.Points[7].SV; }
            set { Calibrator.Points[7].SV = value; }
        }

        public float PV9
        {
            get { return Calibrator.Points[8].PV; }
            set { Calibrator.Points[8].PV = value; }
        }
        public float SV9
        {
            get { return Calibrator.Points[8].SV; }
            set { Calibrator.Points[8].SV = value; }
        }

        public float PV10
        {
            get { return Calibrator.Points[9].PV; }
            set { Calibrator.Points[9].PV = value; }
        }
        public float SV10
        {
            get { return Calibrator.Points[9].SV; }
            set { Calibrator.Points[9].SV = value; }
        }

        public float PV11
        {
            get { return Calibrator.Points[10].PV; }
            set { Calibrator.Points[10].PV = value; }
        }
        public float SV11
        {
            get { return Calibrator.Points[10].SV; }
            set { Calibrator.Points[10].SV = value; }
        }

        public float PV12
        {
            get { return Calibrator.Points[11].PV; }
            set { Calibrator.Points[11].PV = value; }
        }
        public float SV12
        {
            get { return Calibrator.Points[11].SV; }
            set { Calibrator.Points[11].SV = value; }
        }

        public float PV13
        {
            get { return Calibrator.Points[12].PV; }
            set { Calibrator.Points[12].PV = value; }
        }
        public float SV13
        {
            get { return Calibrator.Points[12].SV; }
            set { Calibrator.Points[12].SV = value; }
        }

        public float PV14
        {
            get { return Calibrator.Points[13].PV; }
            set { Calibrator.Points[13].PV = value; }
        }
        public float SV14
        {
            get { return Calibrator.Points[13].SV; }
            set { Calibrator.Points[13].SV = value; }
        }

        public float PV15
        {
            get { return Calibrator.Points[14].PV; }
            set { Calibrator.Points[14].PV = value; }
        }
        public float SV15
        {
            get { return Calibrator.Points[14].SV; }
            set { Calibrator.Points[14].SV = value; }
        }

        public float PV16
        {
            get { return Calibrator.Points[15].PV; }
            set { Calibrator.Points[15].PV = value; }
        }
        public float SV16
        {
            get { return Calibrator.Points[15].SV; }
            set { Calibrator.Points[15].SV = value; }
        }
    }

    public class CalibrationPoint
    {
        public CalibrationPoint(float pv, float sv)
        {
            PV = pv;
            SV = sv;
        }

        public float PV { get; set; }
        public float SV { get; set; }
    }

    public class Calibrator
    {
        public Calibrator()
        {
            Clear();

            Points = new List<CalibrationPoint>();

            for (int i = 0; i < 16; i++)
            {
                Points.Add(new CalibrationPoint(0, 0));
            }
        }

        public bool Active { get; set; }

        public List<CalibrationPoint> Points { get; }

        public double RawA { get; set; }
        public double RawB { get; set; }
        public double RawC { get; set; }
        public double DiffA { get; set; }
        public double DiffB { get; set; }
        public double DiffC { get; set; }

        public void Clear()
        {
            Active = false;
            
            RawA = 0;
            RawB = 1;
            RawC = 0;

            DiffA = 0;
            DiffB = 0;
            DiffC = 0;
        }

        public void CurveFit(int length)
        {
            if (length < 2)
            {
                throw new Exception("Occured curvefit's data length low error in Calibrator.CurveFit");
            }

            double[] rawX = new double[length];
            double[] rawY = new double[length];

            for (int i=0; i<length; i++)
            {
                rawX[i] = Points[i].PV;
                rawY[i] = Points[i].SV;
            }

            DiffA = 0;
            DiffB = 0;
            DiffC = 0;

            try
            {
                switch (length)
                {
                    case 2:
                        RawA = rawY[0] - rawX[0];
                        RawB = (rawY[1] - rawY[0]) / (rawX[1] - rawX[0]);
                        RawC = 0;
                        break;

                    default:
                        if ((IsDoubleArrayAllZero(rawX) == false) &&
                            (IsDoubleArrayAllZero(rawY) == false))
                        {
                            double[] raw = Fitting.LsFit(rawX, rawY, 2);
                            RawA = raw[0];
                            RawB = raw[1];
                            RawC = raw[2];
                        }
                        else
                        {
                            RawA = 0;
                            RawB = 1;
                            RawC = 0;
                        }
                        break;
                }

                Active = true;
            }
            catch (Exception e)
            {
                Clear();
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                throw new Exception("Occured calculation error in Calibrator.CurveFit");
            }
        }

        public float Execute(float value)
        {
            if (Active == false) return value;

            double raw = RawA + RawB * value + RawC * Math.Pow(value, 2);

            if ((double.IsInfinity(raw) == true) || (double.IsNaN(raw) == true)) raw = 0.0;

            return (float)raw;
        }

        private bool IsDoubleArrayAllZero(double[] array)
        {
            bool ret = true;

            foreach (double value in array)
            {
                if (value != 0.0)
                {
                    ret = false;
                    break;
                }
            }

            return ret;
        }
    }
}
