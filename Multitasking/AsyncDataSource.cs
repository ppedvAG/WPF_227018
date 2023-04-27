using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multitasking
{
    internal class AsyncDataSource
    {
        private string fast = "FAST";
        private string slower = "SLOWER";
        private string slow = "SLOW";

        public string Fast { get => fast; set => fast = value; }
        public string Slower 
        {
            get
            {
                Thread.Sleep(5000);
                return slower; 
            }
            set => slower = value; 
        }
        public string Slow 
        {
            get
            {
                Thread.Sleep(10000);
                return slow;
            }
            set => slow = value; 
        }

    }
}
