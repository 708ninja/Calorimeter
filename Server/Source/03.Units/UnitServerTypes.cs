using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hnc.Calorimeter.Server
{
    public enum EClientState
    { Observation, Idle, Preparation, Stabilization, Integration }

    public enum EUserAuthority
    { Maker, Admin, Operator, Viewer }

    public enum EValueType
    { Raw, Real }

    public enum ELogItem
    { Note, Error, Exception }

    public delegate void DefaultHandler();

    class AuthorityTypeFmt : IFormatProvider, ICustomFormatter
    {
        public AuthorityTypeFmt()
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
                case 0:
                    typeString = "Maker";
                    break;

                case 1:
                    typeString = "Admin";
                    break;

                case 2:
                    typeString = "Operator";
                    break;

                case 3:
                    typeString = "Viewer";
                    break;
            }

            return typeString;
        }
    }
}
