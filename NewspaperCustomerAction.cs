using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersSimulation
{
    class NewspaperCustomerAction : Action
    {
        public NewspaperCustomerAction(double eventTime) : base(eventTime){}
        public Int32 Number { get; set; }
        public override void DoAction()
        {
            //Buy a newspaper
        }

    }
}
