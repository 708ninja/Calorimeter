using HNCSystem.Calorimeter.Shared.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNCSystem.Calorimeter.Shared.Manager
{
    public class DeviceSettings : Settings<DeviceSettings>  // 물리 장비의 설정
    {
        private IDictionary<DeviceKind, IList<string>> deviceNames;

        public SortedDictionary<string, DeviceSetting> Settings { get; private set; } = new SortedDictionary<string, DeviceSetting>();

        protected override void SetDefault()
        {
#if KDNP21
            Settings = new SortedDictionary<string, DeviceSetting>
            {
                ["Controller"] = new DeviceSetting
                {
                    DeviceKind = DeviceKind.Controller,
                    DeviceClass = "HNCSystem.Calorimeter.Shared.Device.UT55AController",
                    ConnectionString = "Ip=192.168.1.101; Port=4001",
                    ConnectionTimeout = 2000,
                    ReceivedTimeout = 2000,
                    Addresses = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 },

                    Properties = new Dictionary<string, object>
                    {
                        ["DefaultFixedDecimal"] = 100d,
                        ["FixedDecimal#13"] = 10d,
                        //["FixedDecimal#11"] = 10d,
                        ["Name#1"] = "INDOOR NO.1 DB (℃)",
                        ["Name#2"] = "INDOOR NO.1 WB (℃)",
                        ["Name#3"] = "ID.1 CHAMBER ΔP (mmAq)",
                        ["Name#4"] = "ID.1 NOZZLE ΔP (mmAq)",
                        ["Name#5"] = "INDOOR NO.2 DB (℃)",
                        ["Name#6"] = "INDOOR NO.2 WB (℃)",
                        ["Name#7"] = "ID.2 CHAMBER ΔP (mmAq)",
                        ["Name#8"] = "ID.2 NOZZLE ΔP (mmAq)",
                        ["Name#9"] = "OUTDOOR SIDE DB (℃)",
                        ["Name#10"] = "OUTDOOR SIDE WB (℃)",
                        ["Name#11"] = "OD CHAMBER ΔP (mmAq)",
                        ["Name#12"] = "OD NOZZLE ΔP (mmAq)",
                        ["Name#13"] = "TEST UNIT VOLTAGE (V)",
                        ["Name#14"] = "열원 WATER TEMP. (℃)",
                        ["Name#15"] = "열원 WATER FLOW (LPM)",
                        ["Name#16"] = "부하 WATER TEMP. (℃)",
                        ["Name#17"] = "부하 WATER FLOW (LPM)",
                        ["Name#18"] = "RETURN TEMP. (℃)",

                        ["Id"] = 1
                    }
                },                

                ["PLC"] = new DeviceSetting
                {
                    DeviceKind = DeviceKind.PLC,
                    DeviceClass = "HNCSystem.Calorimeter.Shared.Device.MasterK200sPLC",
                    ConnectionString = "Ip=192.168.1.101; Port=4002",
                    ConnectionTimeout = 2000,
                    ReceivedTimeout = 2000,
                    Properties = new Dictionary<string, object>
                    {
                        ["Id"] = 1
                    }
                },                

                ["PowerMeter#1"] = new DeviceSetting
                {
                    DisplayName = "WT333",
                    DeviceKind = DeviceKind.PowerMeter,
                    DeviceClass = "HNCSystem.Calorimeter.Shared.Device.WT333PowerMeter2",
                    //DeviceClass = "HNCSystem.Calorimeter.Shared.Device.VirtualPowerMeter",
                    ConnectionString = "Ip=192.168.1.101; Port=4003",
                    ConnectionTimeout = 2000,
                    ReceivedTimeout = 2000,
                    Properties = new Dictionary<string, object>
                    {
                        ["Id"] = 1
                    }
                },                

                ["Recorder#1"] = new DeviceSetting
                {
                    DeviceKind = DeviceKind.Recorder,
                    DeviceClass = "HNCSystem.Calorimeter.Shared.Device.GM10Recorder",
                    //DeviceClass = "HNCSystem.Calorimeter.Shared.Device.VirtualRecorder",
                    ConnectionString = "Ip=192.168.1.102; Port=34434",
                    Channels = 120,
                    ConnectionTimeout = 2000,
                    ReceivedTimeout = 2000,
                    Properties = new Dictionary<string, object>
                    {
                        ["Id"] = 1
                    }
                },                
            };
#endif

#if KDNP22
            Settings = new SortedDictionary<string, DeviceSetting>
            {                
                ["Controller"] = new DeviceSetting
                {
                    DeviceKind = DeviceKind.Controller,
                    DeviceClass = "HNCSystem.Calorimeter.Shared.Device.UT55AController",
                    ConnectionString = "Ip=192.168.1.111; Port=4001",
                    ConnectionTimeout = 2000,
                    ReceivedTimeout = 2000,
                    Addresses = new[] { 19, 20, 21, 22, 23, 24, 25, 26, 27, 28 },

                    Properties = new Dictionary<string, object>
                    {                        
                        ["DefaultFixedDecimal"] = 100d,
                        ["FixedDecimal#27"] = 10d,
                        ["FixedDecimal#28"] = 1d,
                        ["Name#19"] = "INDOOR NO.3 DB (℃)",
                        ["Name#20"] = "INDOOR NO.3 WB (℃)",
                        ["Name#21"] = "SA CHAMBER ΔP (mmAq)",
                        ["Name#22"] = "SA NOZZLE ΔP (mmAq)",
                        ["Name#23"] = "IN && OUTDOOR NO.4 DB (℃)",
                        ["Name#24"] = "IN && OUTDOOR NO.4 WB (℃)",
                        ["Name#25"] = "EA CHAMBER ΔP (mmAq)",
                        ["Name#26"] = "EA NOZZLE ΔP (mmAq)",
                        ["Name#27"] = "TEST UNIT VOLTAGE (V)",
                        ["Name#28"] = "CO2 CONCENTRATION (PPM)",

                        ["Id"] = 1
                    }
                },                

                ["PLC"] = new DeviceSetting
                {
                    DeviceKind = DeviceKind.PLC,
                    DeviceClass = "HNCSystem.Calorimeter.Shared.Device.MasterK200sPLC",
                    ConnectionString = "Ip=192.168.1.111; Port=4002",
                    ConnectionTimeout = 2000,
                    ReceivedTimeout = 2000,
                    Properties = new Dictionary<string, object>
                    {
                        ["Id"] = 2
                    }
                },                

                ["PowerMeter#1"] = new DeviceSetting
                {
                    DisplayName = "WT310",
                    DeviceKind = DeviceKind.PowerMeter,
                    DeviceClass = "HNCSystem.Calorimeter.Shared.Device.WT310PowerMeter2",
                    //DeviceClass = "HNCSystem.Calorimeter.Shared.Device.VirtualPowerMeter",
                    ConnectionString = "Ip=192.168.1.111; Port=4003",
                    ConnectionTimeout = 2000,
                    ReceivedTimeout = 2000,
                    Properties = new Dictionary<string, object>
                    {
                        ["Id"] = 1
                    }
                },                

                ["Recorder#1"] = new DeviceSetting
                {
                    DeviceKind = DeviceKind.Recorder,
                    DeviceClass = "HNCSystem.Calorimeter.Shared.Device.GM10Recorder",
                    //DeviceClass = "HNCSystem.Calorimeter.Shared.Device.VirtualRecorder",
                    ConnectionString = "Ip=192.168.1.112; Port=34434",
                    Channels = 80,
                    ConnectionTimeout = 2000,
                    ReceivedTimeout = 2000,
                    Properties = new Dictionary<string, object>
                    {
                        ["Id"] = 1
                    }
                },
            };
#endif

#if KDNP23
            Settings = new SortedDictionary<string, DeviceSetting>
            {
                ["Controller#1"] = new DeviceSetting
                {
                    DeviceKind = DeviceKind.Controller,
                    DeviceClass = "HNCSystem.Calorimeter.Shared.Device.UT55AController",
                    ConnectionString = "Ip=192.168.1.101; Port=4001",
                    ConnectionTimeout = 2000,
                    ReceivedTimeout = 2000,
                    Addresses = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 },

                    Properties = new Dictionary<string, object>
                    {
                        ["DefaultFixedDecimal"] = 100d,
                        ["FixedDecimal#13"] = 10d,
                        //["FixedDecimal#11"] = 10d,
                        ["Name#1"] = "INDOOR NO.1 DB (℃)",
                        ["Name#2"] = "INDOOR NO.1 WB (℃)",
                        ["Name#3"] = "ID.1 CHAMBER ΔP (mmAq)",
                        ["Name#4"] = "ID.1 NOZZLE ΔP (mmAq)",
                        ["Name#5"] = "INDOOR NO.2 DB (℃)",
                        ["Name#6"] = "INDOOR NO.2 WB (℃)",
                        ["Name#7"] = "ID.2 CHAMBER ΔP (mmAq)",
                        ["Name#8"] = "ID.2 NOZZLE ΔP (mmAq)",
                        ["Name#9"] = "OUTDOOR SIDE DB (℃)",
                        ["Name#10"] = "OUTDOOR SIDE WB (℃)",
                        ["Name#11"] = "OD CHAMBER ΔP (mmAq)",
                        ["Name#12"] = "OD NOZZLE ΔP (mmAq)",
                        ["Name#13"] = "TEST UNIT VOLTAGE (V)",
                        ["Name#14"] = "열원 WATER TEMP. (℃)",
                        ["Name#15"] = "열원 WATER FLOW (LPM)",
                        ["Name#16"] = "부하 WATER TEMP. (℃)",
                        ["Name#17"] = "부하 WATER FLOW (LPM)",
                        ["Name#18"] = "RETURN TEMP. (℃)",

                        ["Id"] = 1
                    }
                },

                ["Controller#2"] = new DeviceSetting
                {
                    DeviceKind = DeviceKind.Controller,
                    DeviceClass = "HNCSystem.Calorimeter.Shared.Device.UT55AController",
                    ConnectionString = "Ip=192.168.1.111; Port=4001",
                    ConnectionTimeout = 2000,
                    ReceivedTimeout = 2000,
                    Addresses = new[] { 19, 20, 21, 22, 23, 24, 25, 26 },

                    Properties = new Dictionary<string, object>
                    {
                        ["DefaultFixedDecimal"] = 100d,
                        //["FixedDecimal#27"] = 10d,
                        //["FixedDecimal#28"] = 10d,
                        ["Name#19"] = "INDOOR NO.3 DB (℃)",
                        ["Name#20"] = "INDOOR NO.3 WB (℃)",
                        ["Name#21"] = "SA CHAMBER ΔP (mmAq)",
                        ["Name#22"] = "SA NOZZLE ΔP (mmAq)",
                        ["Name#23"] = "IN && OUTDOOR NO.4 DB (℃)",
                        ["Name#24"] = "IN && OUTDOOR NO.4 WB (℃)",
                        ["Name#25"] = "EA CHAMBER ΔP (mmAq)",
                        ["Name#26"] = "EA NOZZLE ΔP (mmAq)",
                        //["Name#27"] = "TEST UNIT VOLTAGE (V)",
                        //["Name#28"] = "CO2 CONCENTRATION (PPM)",

                        ["Id"] = 2
                    }
                },

                ["PLC#1"] = new DeviceSetting
                {
                    DeviceKind = DeviceKind.PLC,
                    DeviceClass = "HNCSystem.Calorimeter.Shared.Device.MasterK200sPLC",
                    ConnectionString = "Ip=192.168.1.101; Port=4002",
                    ConnectionTimeout = 2000,
                    ReceivedTimeout = 2000,
                    Properties = new Dictionary<string, object>
                    {
                        ["Id"] = 1
                    }
                },

                ["PLC#2"] = new DeviceSetting
                {
                    DeviceKind = DeviceKind.PLC,
                    DeviceClass = "HNCSystem.Calorimeter.Shared.Device.MasterK200sPLC",
                    ConnectionString = "Ip=192.168.1.111; Port=4002",
                    ConnectionTimeout = 2000,
                    ReceivedTimeout = 2000,
                    Properties = new Dictionary<string, object>
                    {
                        ["Id"] = 2
                    }
                },

                ["PowerMeter#1"] = new DeviceSetting
                {
                    DisplayName = "WT333",
                    DeviceKind = DeviceKind.PowerMeter,
                    DeviceClass = "HNCSystem.Calorimeter.Shared.Device.WT333PowerMeter2",
                    //DeviceClass = "HNCSystem.Calorimeter.Shared.Device.VirtualPowerMeter",
                    ConnectionString = "Ip=192.168.1.101; Port=4003",
                    ConnectionTimeout = 2000,
                    ReceivedTimeout = 2000,
                    Properties = new Dictionary<string, object>
                    {
                        ["Id"] = 1
                    }
                },

                //["PowerMeter#2"] = new DeviceSetting
                //{
                //    DisplayName = "WT310",
                //    DeviceKind = DeviceKind.PowerMeter,
                //    DeviceClass = "HNCSystem.Calorimeter.Shared.Device.WT310PowerMeter",
                //    //DeviceClass = "HNCSystem.Calorimeter.Shared.Device.VirtualPowerMeter",
                //    ConnectionString = "Ip=192.168.1.111; Port=4003",
                //    ConnectionTimeout = 2000,
                //    ReceivedTimeout = 2000,
                //    Properties = new Dictionary<string, object>
                //    {
                //        ["Id"] = 2
                //    }
                //},

                ["Recorder#1"] = new DeviceSetting
                {
                    DeviceKind = DeviceKind.Recorder,
                    DeviceClass = "HNCSystem.Calorimeter.Shared.Device.GM10Recorder",
                    //DeviceClass = "HNCSystem.Calorimeter.Shared.Device.VirtualRecorder",
                    ConnectionString = "Ip=192.168.1.102; Port=34434",
                    Channels = 120,
                    ConnectionTimeout = 2000,
                    ReceivedTimeout = 2000,
                    Properties = new Dictionary<string, object>
                    {
                        ["Id"] = 1
                    }
                },

                ["Recorder#2"] = new DeviceSetting
                {
                    DeviceKind = DeviceKind.Recorder,
                    DeviceClass = "HNCSystem.Calorimeter.Shared.Device.GM10Recorder",
                    //DeviceClass = "HNCSystem.Calorimeter.Shared.Device.VirtualRecorder",
                    ConnectionString = "Ip=192.168.1.112; Port=34434",
                    Channels = 80,
                    ConnectionTimeout = 2000,
                    ReceivedTimeout = 2000,
                    Properties = new Dictionary<string, object>
                    {
                        ["Id"] = 2
                    }
                },                
            };
#endif

#if LGP14
            Settings = new SortedDictionary<string, DeviceSetting>
            {
                //["Controller"] = new DeviceSetting  //* 컨트롤러 수정 {{{
                //{
                //    DeviceKind = DeviceKind.Controller,
                //    DeviceClass = "HNCSystem.Calorimeter.Shared.Device.UT55AController",
                //    ConnectionString = "Ip=192.168.1.101; Port=4001",
                //    ConnectionTimeout = 2000,
                //    ReceivedTimeout = 2000,
                //    Addresses = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 },

                //    Properties = new Dictionary<string, object>
                //    {
                //        ["DefaultFixedDecimal"] = 100d,
                //        ["FixedDecimal#13"] = 10d,
                //        ["FixedDecimal#14"] = 10d,
                //        ["Name#1"] = "INDOOR SIDE A DB (℃)",
                //        ["Name#2"] = "INDOOR SIDE A WB (℃)",
                //        ["Name#3"] = "ID A CHAMBER ΔP #1 (mmAq)",
                //        ["Name#4"] = "ID A CHAMBER ΔP #2 (mmAq)",
                //        ["Name#5"] = "INDOOR SIDE B DB (℃)",
                //        ["Name#6"] = "INDOOR SIDE B WB (℃)",
                //        ["Name#7"] = "ID B CHAMBER ΔP #1 (mmAq)",
                //        ["Name#8"] = "ID B CHAMBER ΔP #2 (mmAq)",                        
                //        ["Name#9"] = "OUTDOOR SIDE DB (℃)",
                //        ["Name#10"] = "OUTDOOR SIDE WB (℃)",
                //        ["Name#11"] = "OUTDOOR SIDE DP (℃)",
                //        ["Name#12"] = "TEST UNIT VOLTAGE #1 (V)",
                //        ["Name#13"] = "TEST UNIT VOLTAGE #2 (V)",                        

                //        ["Id"] = 1
                //    }
                //},  //* 컨트롤러 수정 }}}

                ["PLC#1"] = new DeviceSetting
                {
                    DeviceKind = DeviceKind.PLC,
                    DeviceClass = "HNCSystem.Calorimeter.Shared.Device.XGTsPLC",
                    ConnectionString = "Ip=192.168.1.101; Port=4002",
                    ConnectionTimeout = 2000,
                    ReceivedTimeout = 2000,
                    Properties = new Dictionary<string, object>
                    {
                        ["Id"] = 1
                    }
                },                

                ["PowerMeter#1"] = new DeviceSetting
                {
                    DisplayName = "WT310 (A)",
                    DeviceKind = DeviceKind.PowerMeter,
                    DeviceClass = "HNCSystem.Calorimeter.Shared.Device.WT333PowerMeter2",
                    //DeviceClass = "HNCSystem.Calorimeter.Shared.Device.VirtualPowerMeter",
                    ConnectionString = "Ip=192.168.1.101; Port=4003",
                    ConnectionTimeout = 2000,
                    ReceivedTimeout = 2000,
                    Properties = new Dictionary<string, object>
                    {
                        ["Id"] = 1
                    }
                },

                ["PowerMeter#2"] = new DeviceSetting
                {
                    DisplayName = "WT310 (B)",
                    DeviceKind = DeviceKind.PowerMeter,
                    DeviceClass = "HNCSystem.Calorimeter.Shared.Device.WT333PowerMeter2",
                    //DeviceClass = "HNCSystem.Calorimeter.Shared.Device.VirtualPowerMeter",
                    ConnectionString = "Ip=192.168.1.101; Port=4005",
                    ConnectionTimeout = 2000,
                    ReceivedTimeout = 2000,
                    Properties = new Dictionary<string, object>
                    {
                        ["Id"] = 2
                    }
                },

                ["PowerMeter#3"] = new DeviceSetting
                {
                    DisplayName = "WT333 (150K)",
                    DeviceKind = DeviceKind.PowerMeter,
                    DeviceClass = "HNCSystem.Calorimeter.Shared.Device.WT333PowerMeter2",
                    //DeviceClass = "HNCSystem.Calorimeter.Shared.Device.VirtualPowerMeter",
                    ConnectionString = "Ip=192.168.1.101; Port=4006",
                    ConnectionTimeout = 2000,
                    ReceivedTimeout = 2000,
                    Properties = new Dictionary<string, object>
                    {
                        ["Id"] = 3
                    }
                },

                ["PowerMeter#4"] = new DeviceSetting
                {
                    DisplayName = "WT333 (300K)",
                    DeviceKind = DeviceKind.PowerMeter,
                    DeviceClass = "HNCSystem.Calorimeter.Shared.Device.WT333PowerMeter2",
                    //DeviceClass = "HNCSystem.Calorimeter.Shared.Device.VirtualPowerMeter",
                    ConnectionString = "Ip=192.168.1.101; Port=4007",
                    ConnectionTimeout = 2000,
                    ReceivedTimeout = 2000,
                    Properties = new Dictionary<string, object>
                    {
                        ["Id"] = 4
                    }
                },

                ["Recorder#1"] = new DeviceSetting
                {
                    DeviceKind = DeviceKind.Recorder,
                    DeviceClass = "HNCSystem.Calorimeter.Shared.Device.GM10Recorder",
                    //DeviceClass = "HNCSystem.Calorimeter.Shared.Device.VirtualRecorder",
                    ConnectionString = "Ip=192.168.1.102; Port=34434",
                    Channels = 240,
                    ConnectionTimeout = 2000,
                    ReceivedTimeout = 2000,
                    Properties = new Dictionary<string, object>
                    {
                        ["Id"] = 1
                    }
                },                
            };
#endif
        }

        [JsonIgnore]
        public IDictionary<DeviceKind, IList<string>> DeviceNames => deviceNames;       

        public DeviceSetting[] GetDevices(DeviceKind kind)
        {
            var result = new List<DeviceSetting>();
            foreach (var kv in Settings)
            {
                if (kv.Value.DeviceKind != kind)
                    continue;

                result.Add(kv.Value);
            }

            return result.ToArray();
        }

        protected override void OnLoaded()
        {
            foreach (var kv in Settings)
            {
                kv.Value.Name = kv.Key;  // kv.Value.Name => kv.Key : Controller, PLC, PowerMeter#1, Recorder#1
            }

            deviceNames = new Dictionary<DeviceKind, IList<string>>();
            foreach (var kv in Settings)
            {
                var dk = kv.Value.DeviceKind;  // dk => Controller, PLC, PowerMeter, Recorder
                if (deviceNames.ContainsKey(dk) == false)
                    deviceNames[dk] = new List<string>();  // Controller, PLC, PowerMeter, Recorder 순차 생성

                if (kv.Value.Addresses == null)  // 어드레스가 null일 경우 실행
                {
                    deviceNames[dk].Add(kv.Key);
                    continue;  // 루프의 조건식으로 되돌아감
                }

                foreach (var address in kv.Value.Addresses)  // 어드레스가 있을 경우 실행
                {
                    var dn = $"{kv.Key}#{address}";
                    deviceNames[dk].Add(dn);  // Controller => Controller#1, Controller#2, ... 추가
                }
            }
        }
    }

    public class DeviceSetting
    {
        [JsonIgnore]
        public string Name { get; set; }

        /// <summary>
        /// 화면에 표시될 이름
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 디바이스 종류
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public DeviceKind DeviceKind { get; set; }

        /// <summary>
        /// 디바이스 클래스
        /// </summary>
        public string DeviceClass { get; set; }

        /// <summary>
        /// 디바이스 연결문자
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// 연결 대기 시간(ms)
        /// </summary>
        public int ConnectionTimeout { get; set; }

        /// <summary>
        /// 수신 대기 시간(ms)
        /// </summary>
        public int ReceivedTimeout { get; set; }

        public int[] Addresses { get; set; }

        public int? Channels { get; set; }

        public Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();
    }

    /// <summary>
    /// 디바이스 종류
    /// </summary>
    public enum DeviceKind
    {
        None,
        All,
        //Controller,  //* 컨트롤러 수정
        PLC,
        PowerMeter,
        Recorder
    }
}
