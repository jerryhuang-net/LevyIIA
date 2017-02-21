using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.LevyIIA
{
    public class LevyIIA
    {
        /// <summary>
        /// the rate applys to this policy
        /// </summary>
        public decimal LevyRate { get; set; }
        /// <summary>
        /// the cap applys to this policy
        /// </summary>
        public decimal LevyCap { get; set; }
        /// <summary>
        /// the levy amount need to charge
        /// </summary>
        public decimal LevyAmount { get; set; }
        enum LevyYear
        {
            /// <summary>
            /// From 1 January 2018 till 31 March 2019 (both dates inclusive)
            /// </summary>
            Year1,
            /// <summary>
            /// From 1 April 2019 till 31 March 2020 (both dates inclusive)
            /// </summary>
            Year2,
            /// <summary>
            /// From 1 April 2020 till 31 March 2021 (both dates inclusive)
            /// </summary>
            Year3,
            /// <summary>
            /// From 1 April 2021 onwards (date inclusive)
            /// </summary>
            Year4,
            /// <summary>
            /// before 2018
            /// </summary>
            Other
        }
        private static LevyYear GetYearCategory(DateTime effective)
        {
            DateTime y4 = new DateTime(2021, 4, 1);
            if (effective >= y4)
                return LevyYear.Year4;
            DateTime y1from = new DateTime(2018, 1, 1);
            DateTime y2 = new DateTime(2019, 4, 1);
            if (effective >= y1from && effective < y2)
                return LevyYear.Year1;
            DateTime y3 = new DateTime(2020, 4, 1);
            if (effective >= y2 && effective < y3)
                return LevyYear.Year2;
            if (effective >= y3 && effective < y4)
                return LevyYear.Year3;
            return LevyYear.Other;
        }
        public static LevyIIA Calculate(DateTime effective, decimal premium)
        {
            var levy = new LevyIIA();
            var year = GetYearCategory(effective);
            switch (year)
            {
                case LevyYear.Year1:
                    levy.LevyRate = 0.0004M;
                    levy.LevyCap = 40;
                    break;
                case LevyYear.Year2:
                    levy.LevyRate = 0.0006M;
                    levy.LevyCap = 60;
                    break;
                case LevyYear.Year3:
                    levy.LevyRate = 0.00085M;
                    levy.LevyCap = 85;
                    break;
                case LevyYear.Year4:
                    levy.LevyRate = 0.001M;
                    levy.LevyCap = 100;
                    break;
                default:
                    return levy;//all zero
            }
            levy.LevyAmount = Math.Min(
                levy.LevyCap,
                Math.Round(levy.LevyRate * premium, 2)
                );
            return levy;
        }
    }
}
