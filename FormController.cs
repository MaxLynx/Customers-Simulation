using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersSimulation
{
    class FormController
    {
        NewspaperCustomersSimulation simulation;
        private int ITERATIONS_COUNT = 1;
        private int ITERATION_TIME_IN_MINUTES = 1000000;

        public FormController()
        {}

        public void Simulate()
        {
            simulation = new NewspaperCustomersSimulation();
            simulation.Simulate(ITERATIONS_COUNT, ITERATION_TIME_IN_MINUTES);
        }

        public String GetAverageWaitingTime()
        {
            return (simulation.GetAverageWaitingTime()).ToString();
        }

        public String GetAverageCountInQueue()
        {
            return (simulation.GetAverageCountInQueue() / ITERATIONS_COUNT).ToString();
        }

        public String GetCustomersCount()
        {
            return simulation.CustomersCount.ToString();
        }
    }
}
