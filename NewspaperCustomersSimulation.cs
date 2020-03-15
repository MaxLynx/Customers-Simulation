using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersSimulation
{
    class NewspaperCustomersSimulation : Simulation
    {
        List<Double> waitingTimes;
        private ExponentionalGenerator arrivalTimeGenerator;
        private ExponentionalGenerator processTimeGenerator;
        private Random seedGenerator;
        private int lastCustomerNumber;
        private int processedCustomersCount;

        public double GetAverageCountInQueue()
        {
            return sumOfWaitingTimes / maxTime;
        }

        private double sumOfWaitingTimes;

        public int CustomersCount { set; get; }

        public double GetAverageWaitingTime()
        {
            int sum = 0;
            foreach(int waitingTime in waitingTimes)
            {
                sum += waitingTime;
            }
            return sum * 1.0 / CustomersCount;
        }
        public NewspaperCustomersSimulation()
        {
            seedGenerator = new Random();
            waitingTimes = new List<Double>();

        }
        public override void DoHookBeforeIteration()
        {
            arrivalTimeGenerator = new ExponentionalGenerator(5, seedGenerator.Next(0, Int32.MaxValue));
            processTimeGenerator = new ExponentionalGenerator(4, seedGenerator.Next(0, Int32.MaxValue));
            ActionsCalendar = new List<Action>();
            double arrivalTime = 0;
            int i = 1;
            while (arrivalTime < maxTime)
            {
                arrivalTime += arrivalTimeGenerator.Next();
                NewspaperCustomerAction customer = new NewspaperCustomerAction(arrivalTime);
                customer.Number = i++;
                ActionsCalendar.Add(customer);
            }
            CustomersCount = ActionsCalendar.Count;
        }

        public override void DoReplication(Action action)
        {
            if(SimulationTime - action.EventTime < 0)
            {
                waitingTimes.Add(0);
                SimulationTime = action.EventTime;
            }
            else
            {
                waitingTimes.Add(SimulationTime - action.EventTime);
                sumOfWaitingTimes += SimulationTime - action.EventTime;
            }
            action.DoAction();
            double processTime = processTimeGenerator.Next();
            SimulationTime += processTime;
            
        }
    }
}
