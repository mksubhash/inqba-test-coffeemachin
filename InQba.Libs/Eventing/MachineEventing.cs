using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InQba.Libs
{
    public class MachineEventing : IMachineEventing
    {
        public event EventHandler Warning;
        public event EventHandler NoStock;
        public void OnWarningHappened(CustomEventArgs e)
        {
            EventHandler handler = Warning;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public void OnStockIsLess(CustomEventArgs e)
        {
            EventHandler handler = NoStock;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
