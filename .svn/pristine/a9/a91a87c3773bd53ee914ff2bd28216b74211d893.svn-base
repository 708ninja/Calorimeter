using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hnc.Calorimeter.Client
{
    public static class AirFormula
    {
        /// <summary>
        /// 대기압 Pb (Atmospheric Pressure) [mmHg] - 고정 760 mmHg
        /// </summary>
        public static double Pb => 760d;

        public static double mmHg2Pa => 1.0d;

        public static double mmAq2Pa => 1.0d;

        public static double AdjPws => 1.0d;


        private static readonly double[] c1 =
        {
            -5.6745359e3d,
            6.3925247d,
            -9.677843e-3d,
            6.2215701e-7d,
            2.0747825e-9d,
            -9.484024e-13d,
            4.1635019d
        };
        private static readonly double[] c2 =
        {
            -5.8002206e3d,
            1.3914993d,
            -4.8640239e-2d,
            4.1764768e-5d,
            -1.4452093e-8d,
            6.5459673d
        };

        /// <summary>
        /// 포화수증기압 Pws [mmHg]
        /// 
        /// 건구 온도 기준일 때 Td 입력, 습구 온도 기준일 때 Tw 입력
        /// </summary>
        /// <param name="temp">건구/습구 온도 [℃]</param>
        /// <returns></returns>
        public static double GetPws(double temp)
        {
            // 절대 온도로 변경
            temp = temp + 273.15d;

            if (temp < 273.15d)
            {
                return Math.Exp(c1[0] / temp
                    + c1[1]
                    + c1[2] * temp
                    + c1[3] * Math.Pow(temp, 2)
                    + c1[4] * Math.Pow(temp, 3)
                    + c1[5] * Math.Pow(temp, 4)
                    + c1[6] * Math.Log(temp))
                    * 760d / 101325d;
            }
            else
            {
                return Math.Exp(c2[0] / temp
                    + c2[1]
                    + c2[2] * temp
                    + c2[3] * Math.Pow(temp, 2)
                    + c2[4] * Math.Pow(temp, 3)
                    + c2[5] * Math.Log(temp))
                    * 760d / 101325d;
            }
        }

        public static double GetVmDry(double ga, double vw, double nvw, double xw)
        {
            var vm = ga * 60d * vw / nvw;
            return vm;
        }

        public static double GetMaDry(double ga, double vw)
        {
            var ma = (ga * 60d) / vw;
            return ma;
        }

        ///// <summary>
        ///// 질량 유량 Ma [m3/min]
        ///// </summary>
        ///// <param name="ga"></param>
        ///// <param name="vw"></param>
        ///// <returns></returns>
        //public static double GetMa(double ga, double vw, double td, double tw, double xs)
        //{
        //    var ma = ga / vw;
        //    var maDry = GetMaDry(ma, td, tw, xs);

        //    return 0d;
        //}

        /// <summary>
        /// 포화절대습도 Xs [kg/kg']
        /// 
        /// Pws가 건구 온도 일 경우 건구온도 기준 포화절대습도
        /// Pws가 습구 온도 일 경우 습구온도 기준 포화절대습도
        /// </summary>
        /// <param name="pb">대기압 [mmHq]</param>
        /// <param name="pws">포화수증기압 [mmHq]</param>
        /// <returns></returns>
        public static double GetXs(double pb, double pws)
        {
            pb = mmHg2Pa * pb;

            return 0.62198d * (AdjPws * pws / (pb - AdjPws * pws));
            //return 0.622d * (AdjPws * pws / (pb - AdjPws * pws));
        }

        /// <summary>
        /// 절대습도(습구온도기준) Xw (Humidity Ratio) [kg/kg']
        /// 
        /// 난방(Heating) 시험일 대 입구측(Indoor Entering) 절대습도와 출구측 (Indoor Leaving) 절대습도는 같음
        /// </summary>
        /// <param name="td">건구온도 [℃]</param>
        /// <param name="tw">습구온도 [℃]</param>
        /// <param name="xs">포화절대습도 [kg/kg']</param>
        /// <returns></returns>
        public static double GetXw(double td, double tw, double xs)
        {
            return xs - ((0.24d + 0.441d * xs) * (td - tw)) / (597.3d + 0.441d * td - tw);
        }

        /// <summary>
        /// 비체적(건공기 기준) Vd [m3/kg']
        /// </summary>
        /// <param name="pb">대기압 [mmHg]</param>
        /// <param name="td">건구온도 [℃]</param>
        /// <param name="xw">절대습도 [kg/kg’]</param>
        /// <returns></returns>
        public static double GetVd(double pb, double td, double xw)
        {
            pb = mmHg2Pa * pb;

            return 0.4555d * (td + 273.15d) * (0.622d + xw) * 760d / 100d / pb;
        }

        /// <summary>
        /// 비체적(습공기기준) Vw [m3/kg]
        /// </summary>
        /// <param name="vd">비체적(건공기 기준) [m3/kg']</param>
        /// <param name="xw">절대습도[kg/kg']</param>
        /// <returns></returns>
        public static double GetVw(double vd, double xw)
        {
            return vd / (1d + xw);
        }

        /// <summary>
        /// 비엔탈피 Ha [kcal/kg']
        /// </summary>
        /// <param name="td">건구온도 [℃]</param>
        /// <param name="xw">절대습도 [kg/kg']</param>
        /// <returns></returns>
        public static double GetHa(double td, double xw)
        {
            return 0.24d * td + xw * (597.3d + 0.441d * td);
        }

        /// <summary>
        /// 현열 비엔탈피 Hs [kcal/kg']
        /// </summary>
        /// <param name="td">건구온도 [℃]</param>
        /// <param name="xw">절대습도 [kg/kg']</param>
        /// <returns></returns>
        public static double GetHs(double td, double xw)
        {
            return 0d;
        }

        /// <summary>
        /// 잠열 비엔탈피 HI [kcal/kg']
        /// </summary>
        /// <param name="xw">절대습도 [kg/kg']</param>
        /// <returns></returns>
        public static double GetHi(double xw)
        {
            return 0d;
        }

        /// <summary>
        /// 정압비열 Cp [kcal/kg'℃]
        /// </summary>
        /// <param name="xw">절대습도 [kg/kg']</param>
        /// <returns></returns>
        public static double GetCp(double xw)
        {
            return 0.24d + 0.441d * xw;
        }

        //public static double GetPe(double tw)
        //{
        //    return 3.25d * Math.Pow(tw, 2) + 18.6d * tw + 692.0d;
        //}

        //public static double GetPp(double pe, double pb, double td, double tw)
        //{
        //    return pe - pb * (td - tw) / 1500.0d;
        //}

        //public static double GetRho0(double pb, double pp, double td)
        //{
        //    return (pb - 0.378d * pp) / (287.1d * (td + 273.15d));
        //}

        //public static double GetRho5(double rho0, double pc, double pb)
        //{
        //    return rho0 * (pc + pb) / pb;
        //}

        public static double GetRho5(double td, double tw, double pc, double pb)
        {
            var pe = 3.25d * Math.Pow(tw, 2) + 18.6d * tw + 692.0d;
            var pp = pe - pb * (td - tw) / 1500.0d;
            var rho0 = (pb - 0.378d * pp) / (287.1d * (td + 273.15d));

            return rho0 * (pc + pb) / pb;
        }

        /// <summary>
        /// 팽창계수 Yex [m3/kg']
        /// </summary>
        /// <param name="td">건구온도 [℃]</param>
        /// <param name="tw">습구온도 [℃]</param>
        /// <param name="pn">노즐차압 [mmAq]</param>
        /// <param name="pc">챔버차압 [mmAq]</param>
        /// <param name="pb">대기압 [mmAq]</param>
        /// <returns></returns>
        public static double GetYex(double td, double tw, double pn, double pc, double pb)
        {
            pn = pn * mmAq2Pa;
            pc = pc * mmAq2Pa;
            pb = pb * mmHg2Pa;

            // 노즐 전단 밀도 계산
            var rho5 = GetRho5(td, tw, pc, pb);

            // 알파비 계산
            var alpha = 1.0d - pn / (pb * 13.6d);
            //var alpha = 1.0d - pn / (rho5 * 287.1d * (td + 273.15d));

            // 베타비 계산
            //var beta = 0m;      // 정체실 근접 가정

            return 0.452d + 0.548d * alpha;
            //return Math.Sqrt(1.4d / 0.4d * Math.Pow(alpha, (2.0d / 1.4d))
            //* (1.0d - Math.Pow(alpha, (0.4d / 1.4d))) / (1.0d - alpha));
        }

        /// <summary>
        /// 노즐통과풍속 Vx [m/sec]
        /// </summary>
        /// <param name="d">D1 ~ D6 : 노즐의 직경 [m]</param>
        /// <param name="pn">노즐차압 [mmAq]</param>
        /// <param name="rho5">노즐 전단 밀도</param>
        /// <returns></returns>
        public static double[] GetVx(double[] d, double pn, double pb, double rho5, double td, double vw)
        {
            var kv = 0.000003139d * Math.Pow((273.15d + td), 2.5d) / pb / (383.55d + td);
            var vx0 = Math.Pow((2d * pn), 0.5d);

            var vx = new double[d.Length];
            for (var i = 0; i < vx.Length; i++)
            {
                double vx1 = 0d;

                for (var j = 0; j < 49; j++)
                {
                    // Reynolds 수 계산
                    var re = vx0 * d[i] / kv;
                    var c = 0.9986d - 7.006d / Math.Pow(re, 0.5d) + 134.6d / re;
                    vx1 = c * Math.Pow((2d * 9.80665d * vw * pn), 0.5d);
                    var dv = Math.Abs(vx1 - vx0) / vx1;

                    if (dv < 0.001)
                    {
                        vx0 = Math.Pow((2d * pn), 0.5d);
                        break;
                    }
                    else
                    {
                        vx0 = vx1;
                    }
                }
                vx[i] = vx1;
            }
            return vx;

            // 노즐 유량계수 (Discharge coefficient) 계산
            // D/L = 0.6
            //var vx = new double[d.Length];
            //for (var i = 0; i < d.Length; i++)
            //vx[i] = 0.9986d - 7.006d / Math.Sqrt(re[i]) + 134.6d / re[i];

            //return vx;
        }

        /// <summary>
        /// 포화도 U [%]
        /// 
        /// Pws가 건구 온도 기준 - 건구온도 기준 포화절대습도
        /// Pws가 습구 온도 기준 - 습구온도 기준 포화절대습도
        /// </summary>
        /// <param name="xw">계산 포인트의 절대습도 [kg/kg']</param>
        /// <param name="xs">건구온도(DB) 기준 포화절대습도 [kg/kg']</param>
        /// <returns></returns>
        public static double GetU(double xw, double xs)
        {
            return xw / xs;
        }


        /// <summary>
        /// 상대습도 RH (Relative Humidity) [%]
        /// </summary>
        /// <param name="pb">대기압 [mmHq]</param>
        /// <param name="pws">건구온도(DB)기준 포화수증기압 [mmHq]</param>
        /// <param name="u"><포화도 [%]/param>
        /// <returns></returns>
        public static double GetRh(double pb, double pws, double xw, double u, double td)
        {
            pb = mmHg2Pa * pb;

            var fs = 1.0d + 0.004d * pb / 760d + Math.Pow((0.0008d * td - 0.004d), 2.0d);  // Pb --> pb 변경 (20161204)
            var rh1 = 50d;
            var rh2 = 49d;
            double rh = 0d;
            double rh3 = 0d;

            for (var i = 0; i < 49; i++)
            {
                var pw1 = pws * fs * rh1 * 0.01d;
                var pw2 = pws * fs * rh2 * 0.01d;
                var ws1 = 0.622d * (pw1 / (pb - pw1));
                var ws2 = 0.622d * (pw2 / (pb - pw2));

                rh3 = rh1 + (rh2 - rh1) * (xw - ws1) / (ws2 - ws1);
                var pw3 = pws * fs * rh3 * 0.01d;
                var ws3 = 0.622d * (pw3 / (pb - pw3));

                if (Math.Abs((ws3 - ws2) / ws3) < Math.Pow(10d, -8d))
                {
                    break;
                }
                else
                {
                    rh1 = rh2;
                    rh2 = rh3;
                }
            }
            return rh = rh3;

            //var rh = 100.0d * u / (1.0d - (1.0d - u) * (AdjPws * pws / pb));
            //if (rh > 100.0d)
            //rh = 100.0d;

            //return rh;
        }

        /// <summary>
        /// 체적풍량 Ga [m3/min]
        /// 
        /// - NOZ1 ~ NOZ6은 노즐의 개폐 여부로 0과 1
        /// - D1 ~ D6은 Coefficients 옵션의 Nozzle Diameter 값, mm -> m 변경 필요
        /// - 계산된 결과에 Airfow(풍량 보정계수) 값을 최종 Q에 곱함
        /// - Vw(습공기 기준 비체적)은 출구 온도 기준, 단, 비체적 계산에 들어가는 건구 온도는 출구쪽 건구 온도가 아닌 Nozzle Inlet Temp.의 건구 온도 사용
        /// </summary>
        /// <param name="noz">노즐 Open 여부(0 or 1)</param>
        /// <param name="vx">노즐통과풍속 [m/sec]</param>
        /// <param name="d">노즐의 직경 [m]</param>
        /// <param name="yex">팽창계수 [m3/kg']</param>
        /// <param name="pn">노즐차압 [mmAq]</param>
        /// <param name="vw">비체적(습공기기준) [m3/kg]</param>
        /// <returns></returns>
        public static double GetGa(double[] noz, double[] vx, double[] d, double yex, double pn, double vw)
        {
            pn = pn * mmAq2Pa;

            // 노즐 단면적 계산
            var a = new double[d.Length];
            for (var i = 0; i < d.Length; i++)
                a[i] = Math.PI * Math.Pow(d[i], 2d);

            // 풍량 계산
            double q = 0d;
            for (var i = 0; i < d.Length; i++)
            {
                if (noz[i] == 0d)
                    continue;

                q += ((noz[i] * vx[i] * a[i] * yex) / 4d);
            }
            return q;
        }

        /// <summary>
        /// 열손실 계수 QLoss [kcal/h]
        /// </summary>
        /// 
        /// - 난방 시험일 경우△t는 (출구 건구 온도 - 입구 건구) 온도 임
        /// - 연손실 계순 x는 Coefficients 옵션의 'Colling H.L.K'와 'Heating H.L.K' 값
        /// ※ 보조 덕트 사용 개수에 따라 연손실 계수(QLoss)가 추가 될 수 도 있음 (합산 적용)
        /// <param name="x">열손실계수 [kcal/hm2℃]</param>
        /// <param name="deltaT">△t : 입구건구온도 - 출구건구온도 [℃]</param>
        /// <returns></returns>
        public static double GetQLoss(double x, double deltaT)
        {
            return x * deltaT;
        }

        /// <summary>
        /// 냉방 전열량 Qac (Capacity) [kacl/h]
        /// 
        /// - Qac에 Colling Capacity(냉방능력 보정계수)를 곱해야 함
        /// </summary>
        /// <param name="ga">체적 풍량 [m3/min]</param>
        /// <param name="vw">출구측 비체적 (습공기기준) [m3/kg]</param>
        /// <param name="xw">입구측 절대습도 [kg/kg']</param>
        /// <param name="haI">입구측 비엔탈피 [kcal/kg']</param>
        /// <param name="haO">출구측 비엔탈피 [kcal/kg']</param>
        /// <param name="qLoss">열손실 [kcal/h]</param>
        /// <returns></returns>
        public static double GetQacCold(double maDry, double vw, double xw, double haI, double haO, double qLoss)
        {
            // 열교환량 계산
            return maDry * (haI - haO) * 60d + qLoss;
        }

        /// <summary>
        /// 난방 전열량 Qac (Capacity) [kcal/h]
        /// 
        /// - Qac에 Heating Capacity(난방능력 보정계수)를 곱해야 함
        /// - 난방(Heating) 시험일 때 입구측(Indoor Entering) 절대습도와 출구측(Indoor Leaving) 절대습도가 같음
        /// Vw(습공기 기준 비체적)은 출구 온도 기준, 단, 비체적 계산에 들어가는 건구 온도는 출구측 건구 온도가 아닌 Nozzle Inlet Temp.의 건구 온도 사용
        /// </summary>
        /// <param name="ga">체적 풍량 [m3/min]</param>
        /// <param name="vw">출구측 비체적 (습공기기준) [m3/kg]</param>
        /// <param name="xw">입구측 절대습도 [kg/kg']</param>
        /// <param name="tdI">입구측 건구온도 [℃]</param>
        /// <param name="tdO">출구측 건구온도 [℃]</param>
        /// <param name="qLoss">연손실</param>
        /// <returns></returns>
        public static double GetQacHeat(double maDry, double vw, double xw, double tdI, double tdO, double qLoss)
        {
            // 열교환량 계산
            return maDry * (tdO - tdI) * (0.24d + 0.441d * xw) * 60d + qLoss;
        }

        /// <summary>
        /// 냉방 현열량 Qs (Sensible Heat) [kcal/h]
        /// </summary>
        /// <param name="maDry">질량 풍량 [kg/min]</param>
        /// <param name="hsI">입구측 현열 비엔탈피 [kcal/kg']</param>
        /// <param name="hsO">출구측 현열 비엔탈피 [kcal/kg']</param>
        /// <param name="qLoss">열손실 [kcal/h]</param>
        /// <returns></returns>
        public static double GetQsCold(double maDry, double hsI, double hsO, double qLoss)
        {
            return maDry * (hsI - hsO) * 1000d + qLoss;
        }

        /// <summary>
        /// 난방 현열량 Qs (Sensible Heat) [kcal/h]
        /// </summary>
        /// <param name="maDry">질량 풍량 [kg/min]</param>
        /// <param name="xw">입구측 절대습도 [kg/kg']</param>
        /// <param name="tdI">입구측 건구온도 [℃]</param>
        /// <param name="tdO">출구측 건구온도 [℃]</param>
        /// <param name="qLoss">열손시 [kcal/h]</param>
        /// <returns></returns>
        public static double GetQsHeat(double maDry, double xw, double tdI, double tdO, double qLoss)
        {
            return maDry * (tdI - tdO) * (1.006d + 1.86d * xw) * 1000d * qLoss;
        }

        /// <summary>
        /// 잠열량 Qcc (Latent Heat) [kcal/h]
        /// </summary>
        /// <param name="qac">전열량 [kcal/h]</param>
        /// <param name="qs">현열량 [kcal/h]</param>
        /// <returns></returns>
        public static double GetQcc(double qac, double qs)
        {
            return 588.0d * qs;
        }

        /// <summary>
        /// 응축수량 Gcw (Drain Weight) [g/h]
        /// </summary>
        /// <param name="maDry"질량 풍량 [kg/min]></param>
        /// <param name="xwI">입구측 절대습도 [kg/kg']</param>
        /// <param name="xwO">출구측 절대습도 [kg/kg']</param>
        /// <returns></returns>
        public static double GetGcw(double maDry, double xwI, double xwO)
        {
            return maDry * (xwI - xwO) * 60d;
        }

        /// <summary>
        /// 현열비 SHR (Sensible Heat Ratio)
        /// </summary>
        /// <param name="qac">전열량 [kcal/h]</param>
        /// <param name="qs">현열량 [kcal/h]</param>
        /// <returns></returns>
        public static double GetShr(double qac, double qs)
        {
            return qs / qac * 100d;
        }

        /// <summary>
        /// Fan Power (W)
        /// </summary>
        /// <param name="airflowLev">Air Flow [Lev] (㎥/min)</param>
        /// <param name="staticPressure">Static Pressure (mmAq)</param>
        /// <returns></returns>
        public static double GetFanPower(double airflowLev, double staticPressure)
        {
            return (airflowLev / 60d * 1000d) * 10e-3d * (staticPressure * 9.80661358d) / 0.3d;
        }

        /// <summary>
        /// 노점온도 DP (Dew Point) [℃]
        /// </summary>
        /// <param name="pb">대기압 [mmHq]</param>
        /// <param name="ws"></param>
        /// <returns></returns>
        public static double GetDp(double pb, double td, double ws)
        {
            var dp1 = td;
            var dp2 = td - 1d;
            double dp = 0d;
            double dp3 = 0d;

            for (var i = 0; i < 49; i++)
            {
                var pw1 = GetPws(dp1);
                var pw2 = GetPws(dp2);
                var ws1 = 0.622d * (pw1 / (pb - pw1));
                var ws2 = 0.622d * (pw2 / (pb - pw2));

                if (Math.Abs(ws2 - ws1) < Math.Pow(10d, -8d))
                {
                    dp3 = dp1;
                    break;
                }
                dp3 = dp1 + (dp2 - dp1) * (ws - ws1) / (ws2 - ws1);

                var pw3 = GetPws(dp3);
                var ws3 = 0.622d * (pw3 / (pb - pw3));
                var xw3 = GetXwn(ws3, td, dp3);

                if (Math.Abs((xw3 - ws2) / xw3) < Math.Pow(10d, -8d))
                {
                    break;
                }
                else
                {
                    dp1 = dp2;
                    dp2 = dp3;
                }
            }
            return dp = dp3;
        }

        /// <summary>
        /// 습구온도 WB (Wet Bulb) [℃]
        /// </summary>
        /// <param name="pb">대기압 [mmHq]</param>
        /// <param name="pws">건구온도(DB)기준 포화수증기압 [mmHq]</param>
        /// <param name="RH">상대습도 [%]</param>
        /// <returns></returns>
        public static double GetWb(double pb, double pws, double td, double rh)
        {
            //pb = Pb;
            var fs = 1.0d + 0.004d * pb / 760d + Math.Pow((0.0008d * td - 0.004d), 2.0d);

            var pw = pws * fs * rh * 0.01d;
            var ws = 0.622d * (pw / (pb - pw));

            return WetBulb(pb, td, ws);
        }

        private static double WetBulb(double pb, double td, double ws)
        {
            var wb1 = td;
            var wb2 = td - 1d;
            double wb = 0d;
            double wb3 = 0d;

            for (var i = 0; i < 49; i++)
            {
                var pw1 = GetPws(wb1);
                var pw2 = GetPws(wb2);
                var ws1 = 0.622d * (pw1 / (pb - pw1));
                var ws2 = 0.622d * (pw2 / (pb - pw2));

                var xw1 = GetXwn(ws1, td, wb1);
                var xw2 = GetXwn(ws2, td, wb2);
                //var xw1 = GetXw(td, wb1, ws1);
                //var xw2 = GetXw(td, wb2, ws2);
                wb3 = wb1 + (wb2 - wb1) * (ws - xw1) / (xw2 - xw1);

                var pw3 = GetPws(wb3);
                var ws3 = 0.622d * (pw3 / (pb - pw3));
                var xw3 = GetXwn(ws3, td, wb3);
                //var xw3 = GetXw(td, wb3, ws3);

                if (Math.Abs((xw3 - xw2) / xw3) < Math.Pow(10d, -8d))
                {
                    break;
                }
                else
                {
                    wb1 = wb2;
                    wb2 = wb3;
                }
            }
            return wb = wb3;
        }

        public static double GetXwn(double ws, double td, double wb)
        {
            var n1 = (0.24d + 0.441d * ws) * (td - wb);
            var n2 = (597.3d + 0.441d * td);
            var n3 = wb < 0.0 ? (0.5d * wb - 79.7d) : wb;

            return ws - n1 / (n2 - n3);
        }
    }
}
