﻿using Candidate_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAOs
{
    public class JobPostingDAO
    {
        private CandidateManagementContext dbContext;
        private static JobPostingDAO instance;

        public JobPostingDAO() 
        {
            dbContext = new CandidateManagementContext();
        }

        public static JobPostingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JobPostingDAO();
                }
                return instance;
            }
        }

        public List<JobPosting> GetJobPostings()
        {
            return dbContext.JobPostings.ToList();
        }
    }
}
