using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomersSimulation
{
    class Simulation
    {
        protected int maxTime;
        public String Result { set; get; }
        public Double SimulationTime { set; get; }
        public List<Action> ActionsCalendar { set; get; }
        public Simulation()
        {
            Stop = false;
            Pause = false;
        }
        public Boolean Stop { set; get; }
        public Boolean Pause { set; get; }
        public Action GetNextAction()
        {
            int minIndex = -1;
            double minTime = Double.MaxValue;
            for(int i = 0; i < ActionsCalendar.Count; i++)
            {
                if(ActionsCalendar[i].EventTime < minTime)
                {
                    minIndex = i;
                    minTime = ActionsCalendar[i].EventTime;
                }
            }
            if(minIndex != -1)
            {
                Action nextAction = ActionsCalendar[minIndex];
                ActionsCalendar.RemoveAt(minIndex);
                return nextAction;
            }
            else
            {
                return null;
            }
        }

        public Simulation Simulate(int iterationsCount, int maxTime)
        {
            this.maxTime = maxTime;
            for(int i = 0; i < iterationsCount; i++)
            {
                SimulationTime = 0;
                DoHookBeforeIteration();
                SimulateIteration();
                if (Stop)
                {
                    break;
                }
                while (Pause)
                {
                    Thread.Sleep(400);

                }
            }
            return this;

        }

        public Simulation SimulateIteration()
        {
            Stop = false;
            Pause = false;
            while(SimulationTime < maxTime)
            {
                Action action = GetNextAction();
                if (action == null)
                {
                    SimulationTime++;
                }
                else if (action.EventTime < maxTime)
                {
                    DoReplication(action);
                }
                else
                {
                    break;
                }
                if (Stop)
                {
                    break;
                }
                while (Pause)
                {
                    Thread.Sleep(400);

                }
            }
           
            return this;
        }
        public virtual void DoHookBeforeIteration()
        {
        }
        public virtual void DoReplication(Action action)
        {
        }
    }
}
