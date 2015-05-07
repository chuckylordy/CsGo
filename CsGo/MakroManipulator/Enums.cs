using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakroManipulator
{
    public class Enums
    {
        public enum Modes
        {
            TriggerC,
            Continuous
        }




        internal static Modes GetMode(string p)
        {


            if (Enum.IsDefined(typeof(Enums.Modes), p))
            {
                return ParseEnum<Modes>(p);
            }
            else
            {
                return Enums.Modes.Continuous;
            }
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
