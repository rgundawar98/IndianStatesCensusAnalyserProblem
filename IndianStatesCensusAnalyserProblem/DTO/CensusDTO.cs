using IndianStatesCensusAnalyserProblem.DATA_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyserProblem.DTO
{
    public class CensusDTO
    {
        public string State;
        public long population;
        public long area;
        public long density;
        public CensusDTO(PopulationDataDAO populationDataDAO) 
        {
            this.State = populationDataDAO.state;
            this.population = populationDataDAO.population;
            this.area = populationDataDAO.area;
            this.density = populationDataDAO.density;
        }
    }
}
