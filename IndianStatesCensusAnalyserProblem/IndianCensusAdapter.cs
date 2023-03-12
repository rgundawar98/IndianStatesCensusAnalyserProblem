using IndianStatesCensusAnalyserProblem.DATA_DAO;
using IndianStatesCensusAnalyserProblem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyserProblem
{
    public class IndianCensusAdapter:CensusAdapter
    {
        string[] censusData;
        Dictionary<string, CensusDTO> censusState;
        public Dictionary<string,CensusDTO> LoadCensusData(string csvFilePath,string dataHeaders)
        {
            try
            {
                censusState = new Dictionary<string, CensusDTO>();
                censusData = GetCensusData(csvFilePath, dataHeaders);
                foreach(string data in censusData.Skip(1))
                {
                    if(!data.Contains(","))
                    {
                       throw new CensusAnalyserException("Files Contains wrong Delimiter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMETER);
                    }
                    string[] coloumn = data.Split(',');
                    if (csvFilePath.Contains("IndianPopulationData.CSV"))
                        censusState.Add(coloumn[0], new CensusDTO(new PopulationDataDAO(coloumn[0], coloumn[1], coloumn[2], coloumn[3])));
                }
                return censusState;
            }
            catch(CensusAnalyserException  ex)
            {
                throw ex;
            }
        }
    }
}
