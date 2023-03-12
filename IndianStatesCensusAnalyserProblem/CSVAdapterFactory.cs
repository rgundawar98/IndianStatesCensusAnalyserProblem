using IndianStatesCensusAnalyserProblem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyserProblem
{
    public class CSVAdapterFactory
    {
        public Dictionary<string,CensusDTO> LoadCSVData(CensusAnalyzer.Country country, string csvFilePath ,string dataHeaders)
        {
            try
            {
                switch (country)
                {
                    case (CensusAnalyzer.Country.INDIA):
                        return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                    default:
                        throw new CensusAnalyserException("No Such Country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
                }
            }
            catch(CensusAnalyserException ex)
            {
                throw ex;
            }
        }
    }
}
