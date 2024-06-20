using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMMaintenance.Class_Files
{
    class globalvariables
    {
        static string strBranch = "";

        public static string DftBranch
        {
            get { return strBranch; }

            set { strBranch = value; }
        }
    }
}
