using Candidate_BusinessObject;
using Candidate_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public class CandidateProfileService : ICandidateProfileService
    {
        private readonly ICandidateProfileRepo profileRepo;

        public CandidateProfileService() 
        {
            profileRepo = new CandidateProfileRepo();
        }
        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            return profileRepo.AddCandidateProfile(candidateProfile);
        }

        public bool DeleteCandidateProfile(string candidateId)
        {
            return profileRepo.DeleteCandidateProfile(candidateId);
        }

        public CandidateProfile GetCandidateProfile(string id)
        {
            return profileRepo.GetCandidateProfile(id);
        }

        public List<CandidateProfile> GetCandidates()
        {
            return profileRepo.GetCandidates();
        }

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {
            return profileRepo.UpdateCandidateProfile(candidateProfile);
        }
    }
}
