using Candidate_BusinessObject;
using Candidate_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public class JobPostingArrayService
    {
        private JobPostingArrayDao _jobPostingDao;

        public JobPostingArrayService()
        {
            _jobPostingDao = new JobPostingArrayDao();
        }

        public List<JobPosting> GetAllJobPostings()
        {
            return _jobPostingDao.GetAll();
        }

        public JobPosting GetJobPostingById(string id)
        {
            return _jobPostingDao.GetById(id);
        }

        public void CreateJobPosting(JobPosting jobPosting)
        {
            _jobPostingDao.Add(jobPosting);
        }

        public void UpdateJobPosting(JobPosting jobPosting)
        {
            _jobPostingDao.Update(jobPosting);
        }

        public void DeleteJobPosting(string postingId)
        {
            _jobPostingDao.Delete(postingId);
        }
    }
}
