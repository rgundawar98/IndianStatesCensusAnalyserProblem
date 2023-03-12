using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyserProblem.DATA_DAO
{
    public class StatesDataDAO
    {
        public int SerialNo;
        public string StateName;
        public int Tin;
        public string Statecode;

        public StatesDataDAO(string SerialNo,string StateName,string Tin,string Statecode)
        {
            this.SerialNo = Convert.ToInt32(SerialNo);
            this.StateName = StateName;
            this.Tin=Convert.ToInt32(Tin);
            this.Statecode = Statecode;
        }
    }
}
