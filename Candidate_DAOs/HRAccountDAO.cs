using Candidate_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAOs
{
    public class HRAccountDAO
    {
        private CandidateManagementContext context;

        private static HRAccountDAO instance = null;

        public HRAccountDAO()
        {
            context = new CandidateManagementContext();
        }
        public static HRAccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HRAccountDAO();
                }
                return instance;
            }
        }

        public Hraccount GetHraccountByEmail(string email)
        {
            //lay 1 gia tri SingleOrDefault
            return context.Hraccounts.SingleOrDefault(m=>m.Email.Equals(email));
        }
        public List<Hraccount> GetHraccounts()
        {
            return context.Hraccounts.ToList();
        }
    }
}
