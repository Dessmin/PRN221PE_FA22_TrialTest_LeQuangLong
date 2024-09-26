using Candidate_BusinessObject;
using Candidate_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public class CandidateProfileRepo : ICandidateProfileRepo
    {
        public bool AddCandidateProfile(CandidateProfile candidateProfile)=> CandidateProfileDAO.Instance.AddCandidateProfile(candidateProfile);

        public bool DeleteCandidateProfile(string candidateId)=> CandidateProfileDAO.Instance.DeleteCandidateProfile(candidateId);

        public CandidateProfile GetCandidateProfile(string id)=> CandidateProfileDAO.Instance.GetCandidateProfile(id);

        public List<CandidateProfile> GetCandidates()=> CandidateProfileDAO.Instance.GetCandidates();

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)=> CandidateProfileDAO.Instance.UpdateCandidateProfile(candidateProfile);
    }
}
