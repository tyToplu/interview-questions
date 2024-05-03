using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DesktopAppThreads
{
    public class ThreadClass
    {
        PrimeCalculation calculation;
        public ThreadClass(PrimeCalculation calculation)
        {
            this.calculation = calculation;
        }
        public String SetPrimeNumbersJob(string BoundStr)
        {

            Thread thread = Thread.CurrentThread;
            int BoundInt = Int32.Parse(BoundStr);
            List<int> result = calculation.FindPrimeUpToN(BoundInt);
            String text = String.Join(", ", result);
            return text;
        }
       }
}
