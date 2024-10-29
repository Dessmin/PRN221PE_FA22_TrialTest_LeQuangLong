using Candidate_BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAOs
{
    public class CandidateProfileDAO
    {
        private CandidateManagementContext dbcontext;
        private static CandidateProfileDAO instance;

        public static CandidateProfileDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CandidateProfileDAO();
                }
                return instance;
            }
        }
        public CandidateProfileDAO()
        {
            dbcontext = new CandidateManagementContext();
        }

        public List<CandidateProfile> GetCandidates()
        {
            return dbcontext.CandidateProfiles.Include(u => u.Posting).ToList();
        }

        public CandidateProfile GetCandidateProfile(String id)
        {
            return dbcontext.CandidateProfiles.SingleOrDefault(m => m.CandidateId.Equals(id));
        }

        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            CandidateProfile? candidate = GetCandidateProfile(candidateProfile.CandidateId);
            if (candidate == null)
            {
                dbcontext.CandidateProfiles.Add(candidateProfile);
                dbcontext.SaveChanges();
                dbcontext.Entry(candidateProfile).State = EntityState.Detached;
                isSuccess = true;
            }
            return isSuccess;
        }
        public bool DeleteCandidateProfile(string candidateID)
        {
            bool isSuccess = false;
            CandidateProfile? candidate = GetCandidateProfile(candidateID);
            if (candidate != null)
            {
                dbcontext.CandidateProfiles.Remove(candidate);
                dbcontext.SaveChanges();
                dbcontext.Entry(candidate).State = EntityState.Detached;
                isSuccess = true;
            }
            return isSuccess;
        }

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            CandidateProfile? candidate = GetCandidateProfile(candidateProfile.CandidateId);
            if (candidate != null)
            {
                // auto update cac truong ngoai tru key


                //candidate.Fullname = candidateProfile.Fullname;
                //candidate.Birthday = candidateProfile.Birthday;
                //candidate.ProfileShortDescription = candidateProfile.ProfileShortDescription;
                //candidate.ProfileUrl = candidateProfile.ProfileUrl;
                //candidate.PostingId = candidateProfile.PostingId;

                dbcontext.CandidateProfiles.Update(candidateProfile);
                dbcontext.SaveChanges();
                dbcontext.Entry(candidateProfile).State = EntityState.Detached;
                isSuccess = true;
            }
            return isSuccess;
        }
    }
}
