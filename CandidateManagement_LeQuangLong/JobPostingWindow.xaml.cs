using Candidate_BusinessObject;
using Candidate_Services;
using System;
using System.Windows;
using System.Windows.Controls;

namespace CandidateManagement_LeQuangLong
{
    public partial class JobPostingWindow : Window
    {
        private JobPostingArrayService jobPostingService;

        public JobPostingWindow()
        {
            InitializeComponent();
            jobPostingService = new JobPostingArrayService();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            var newJobPosting = new JobPosting
            {
                PostingId = txtPostingID.Text,
                JobPostingTitle = txtJobPostingTitle.Text,
                Description = txtDescription.Text,
                PostedDate = txtPostedDate.SelectedDate ?? DateTime.Now
            };

            jobPostingService.CreateJobPosting(newJobPosting);
            MessageBox.Show("Job posting created successfully!");
            LoadJobPostings();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dtgJobPosting.SelectedItem is JobPosting selectedJob)
            {
                selectedJob.JobPostingTitle = txtJobPostingTitle.Text;
                selectedJob.Description = txtDescription.Text;
                selectedJob.PostedDate = txtPostedDate.SelectedDate ?? DateTime.Now;

                jobPostingService.UpdateJobPosting(selectedJob);
                MessageBox.Show("Job posting updated successfully!");
                LoadJobPostings();
            }
            else
            {
                MessageBox.Show("Please select a job posting to update.");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dtgJobPosting.SelectedItem is JobPosting selectedJob)
            {
                jobPostingService.DeleteJobPosting(selectedJob.PostingId);
                MessageBox.Show("Job posting deleted successfully!");
                LoadJobPostings();
            }
            else
            {
                MessageBox.Show("Please select a job posting to delete.");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadJobPostings();
        }

        private void dtgJobPosting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgJobPosting.SelectedItem is JobPosting selectedJob)
            {
                txtPostingID.Text = selectedJob.PostingId;
                txtJobPostingTitle.Text = selectedJob.JobPostingTitle;
                txtDescription.Text = selectedJob.Description;
                txtPostedDate.SelectedDate = selectedJob.PostedDate;
            }
            else
            {
                txtPostingID.Text = "";
                txtJobPostingTitle.Text = "";
                txtDescription.Text = "";
                txtPostedDate.SelectedDate = null;
            }
        }

        private void LoadJobPostings()
        {
            var jobPostings = jobPostingService.GetAllJobPostings();
            dtgJobPosting.ItemsSource = jobPostings;
        }

        private void btnCandidates_Click(object sender, RoutedEventArgs e)
        {
            CandidateProfileManagement candidateProfileManagement = new CandidateProfileManagement();
            candidateProfileManagement.Show();
            this.Close();
        }
    }
}
