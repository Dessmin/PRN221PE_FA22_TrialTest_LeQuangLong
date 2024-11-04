using Candidate_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Candidate_DAOs
{
    public class JobPostingArrayDao
    {
        private string filePath = @"C:\Users\dessm\OneDrive\Documentos\GitHub\PRN221PE_FA22_TrialTest_LeQuangLong\CandidateManagement_LeQuangLong\JobPosting.xml";

        public List<JobPosting> GetAll()
        {
            XDocument doc = XDocument.Load(filePath);
            return doc.Descendants("JobPosting").Select(p => new JobPosting
            {
                PostingId = p.Element("PostingID")?.Value,
                JobPostingTitle = p.Element("JobPostingTitle")?.Value,
                Description = p.Element("Description")?.Value,
                PostedDate = DateTime.Parse(p.Element("PostedDate")?.Value)
            }).ToList();
        }
        public JobPosting GetById(string id)
        {
            XDocument doc = XDocument.Load(filePath);
            var posting = doc.Descendants("JobPosting")
                             .FirstOrDefault(j => j.Element("PostingID")?.Value == id);

            if (posting != null)
            {
                return new JobPosting
                {
                    PostingId = posting.Element("PostingID")?.Value,
                    JobPostingTitle = posting.Element("JobPostingTitle")?.Value,
                    Description = posting.Element("Description")?.Value,
                    PostedDate = DateTime.Parse(posting.Element("PostedDate")?.Value)
                };
            }

            return null; // Nếu không tìm thấy
        }

        // Thêm JobPosting
        public void Add(JobPosting jobPosting)
        {
            XDocument doc = XDocument.Load(filePath);
            doc.Root.Add(new XElement("JobPosting",
                new XElement("PostingID", jobPosting.PostingId),
                new XElement("JobPostingTitle", jobPosting.JobPostingTitle),
                new XElement("Description", jobPosting.Description),
                new XElement("PostedDate", jobPosting.PostedDate.ToString())
            ));
            doc.Save(filePath);
        }

        // Cập nhật JobPosting
        public void Update(JobPosting jobPosting)
        {
            XDocument doc = XDocument.Load(filePath);
            var existingJob = doc.Descendants("JobPosting")
                                 .FirstOrDefault(j => j.Element("PostingID")?.Value == jobPosting.PostingId);

            if (existingJob != null)
            {
                existingJob.Element("JobPostingTitle").Value = jobPosting.JobPostingTitle;
                existingJob.Element("Description").Value = jobPosting.Description;
                existingJob.Element("PostedDate").Value = jobPosting.PostedDate.ToString();
                doc.Save(filePath);
            }
        }

        // Xóa JobPosting
        public void Delete(string postingId)
        {
            XDocument doc = XDocument.Load(filePath);
            var jobPosting = doc.Descendants("JobPosting")
                                .FirstOrDefault(j => j.Element("PostingID")?.Value == postingId);

            if (jobPosting != null)
            {
                jobPosting.Remove();
                doc.Save(filePath);
            }
        }
    }
}
