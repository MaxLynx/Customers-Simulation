using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersSimulation
{
    class ExponentionalGenerator
    {
        private Random random;
        private double mean;

        public ExponentionalGenerator(double mean, int seed)
        {
            this.mean = mean;
            random = new Random(seed);           
            
        }

        public ExponentionalGenerator(double mean)
        {
            this.mean = mean;
            random = new Random();

        }

        public double Next()
        {
            return (Math.Log(1 - random.NextDouble()) * (-mean));

        }
    }
}
