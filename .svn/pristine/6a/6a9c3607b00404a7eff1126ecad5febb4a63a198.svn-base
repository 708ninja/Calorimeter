using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hnc.Calorimeter.Client
{
    public static class WaterFormula
    {
        /// <summary>
        /// 물의 밀도(kg/㎥)
        /// </summary>
        /// <param name="twi">Water Inlet Temperature</param>
        /// <returns></returns>
        public static double GetWaterDensity(double twi)
        {
            double[] C1 = new double[]
            {
                9.998395639e2d,
                6.798299989e-2d,
                -9.106025564e-3d,
                1.005272999e-4d,
                -1.126713526e-6d,
                6.591795606e-9d,
                1.00732d,
                -8.1615e-4d,
                2.70583e-5d,
                -4.34220e-7d,
                3.57344e-9d,
                -1.12472e-11d
            };

            var dw = C1[0] + C1[1] * twi + C1[2] * Math.Pow(twi, 2) + C1[3] * Math.Pow(twi, 3) + C1[4] * Math.Pow(twi, 4) + C1[5] * Math.Pow(twi, 5);
            return dw;
        }

        //public static double GetWaterDensity2(double twi)
        //{
        //    return twi > 30.0 ? twi > 70.0 ?
        //        (1005.549 - 0.2207933 * twi - 0.002513545 * Math.Pow(twi, 2.0)) :
        //        (1002.054 - 0.1135961 * twi - 0.003332962 * Math.Pow(twi, 2.0)) :
        //        (999.9221 + 0.03048826 * twi - 0.005760126 * Math.Pow(twi, 2.0));
        //}

        /// <summary>
        /// 비열 (kJ/kg℃)
        /// </summary>
        /// <param name="twi">Water Inlet Temperature</param>
        /// <returns></returns>
        public static double GetSpecificHeat(double twi)
        {
            var value = 0d;

            if (twi <= 30d)
                value = (1.0072d - 0.000642383d * twi + 0.0000113358d * Math.Pow(twi, 2)) * 4.1868d;
            else if (twi <= 70d)
                value = (1.000516d - 0.0001433055d * twi + 0.000002159978d * Math.Pow(twi, 2)) * 4.1868d;
            else
                value = (1.001604 - 0.0001651832 * twi + 0.000002225232d * Math.Pow(twi, 2)) * 4.1868d;

            return value;
        }

        //public static double GetSpecificHeat2(double twi)
        //{
        //    return twi > 30.0 ? twi > 70.0 ?
        //        (1.001604 - 0.0001651832 * twi + 2.225232E-06 * Math.Pow(twi, 2.0)) :
        //        (1.000516 - 0.0001433055 * twi + 2.159978E-06 * Math.Pow(twi, 2.0)) :
        //        (1.0072 - 0.000642383 * twi + 1.13358E-05 * Math.Pow(twi, 2.0));
        //}

        /// <summary>
        /// 물 차압 단위 변환 (kg/㎠ -> kPa)
        /// </summary>
        /// <param name="preesureDropKgcm2"></param>
        /// <returns></returns>
        public static double GetPressureDropTokPa(double preesureDropKgcm2)
        {
            return preesureDropKgcm2 * 98.0661358d;
        }

        /// <summary>
        /// 질량유량 (kg/s)
        /// </summary>
        /// <param name="waterFlowRate">체적유량 (L/min)</param>
        /// <param name="waterDensity">물의 밀도 (kg/㎥)</param>
        /// <returns></returns>
        public static double GetMassWaterFlow(double waterFlowRate, double waterDensity)
        {
            return (waterFlowRate * 0.001d) / 60d * waterDensity;
        }

        /// <summary>
        /// 체적유량 단위 변환(L/min -> L/s)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static double GetWaterFlowRateToLs(double waterFlowRate)
        {
            return waterFlowRate / 60d;
        }

        /// <summary>
        /// Pump Power (W)
        /// </summary>
        /// <param name="waterFlowRate">체적유량 (L/min)</param>
        /// <param name="pressureDrop">물 차압 (kg/㎠)</param>
        /// <returns></returns>
        public static double GetPumpPower(double waterFlowRate, double pressureDrop)
        {
            return waterFlowRate / 60 * 10e-4d * GetPressureDropTokPa(pressureDrop) * 1000d / 0.3d;
        }


        /// <summary>
        /// Capacity
        /// </summary>
        /// <param name="waterFlowRate">체적유량 (L/min)</param>
        /// <param name="waterInletTemp">Water Inlet Temperature</param>
        /// <param name="waterOutletTemp">Water Outlet Temperature</param>
        /// <returns></returns>
        public static double GetCapacity(double waterFlowRate, double waterInletTemp, double waterOutletTemp)
        {
            return (GetMassWaterFlow(waterFlowRate, GetWaterDensity(waterInletTemp)) * GetSpecificHeat(waterInletTemp) * (waterInletTemp - waterOutletTemp)) * 1000d;
        }
    }
}
