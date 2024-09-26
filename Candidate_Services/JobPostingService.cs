using Candidate_BusinessObject;
using Candidate_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public class JobPostingService : IJobPostingService
    {
        private readonly IJobPostingRepo postingRepo;

        public JobPostingService()
        {
            postingRepo = new JobPostingRepo();
        }
        public List<JobPosting> GetJobPostings()
        {
            return postingRepo.GetJobPostings();
        }

    }
}
