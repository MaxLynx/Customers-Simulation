using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersSimulation
{
    class Action
    {
        public Double EventTime { set; get; }

        public Action(double eventTime)
        {
            EventTime = eventTime;
        }

        public virtual void DoAction() { }
    }
}
