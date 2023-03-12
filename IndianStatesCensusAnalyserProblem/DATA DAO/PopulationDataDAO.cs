using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyserProblem.DATA_DAO
{
    public class PopulationDataDAO
    {
        public string state;
        public long population;
        public long area;
        public long density;

        public PopulationDataDAO(string state, string population, string area, string density)
        {
            this.state = state;
            this.population = Convert.ToUInt32(Console.ReadLine());
            this.area = Convert.ToUInt32(Console.ReadLine());
            this.density = Convert.ToUInt32(Console.ReadLine());
        }
    }
}
