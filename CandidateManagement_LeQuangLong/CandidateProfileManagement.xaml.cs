using Candidate_BusinessObject;
using Candidate_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CandidateManagement_LeQuangLong
{
    /// <summary>
    /// Interaction logic for CandidateProfileManagement.xaml
    /// </summary>
    public partial class CandidateProfileManagement : Window
    {
        private readonly ICandidateProfileService profileService;
        private readonly IJobPostingService postingService;
        private readonly int? roleID;

        public CandidateProfileManagement()
        {
            InitializeComponent();
            this.profileService = new CandidateProfileService();
            this.postingService = new JobPostingService();
        }
        public CandidateProfileManagement(int? roleID)
        {
            InitializeComponent();
            this.profileService = new CandidateProfileService();
            this.postingService = new JobPostingService();
            this.roleID = roleID;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CandidateProfile candidate = new CandidateProfile();
                candidate.CandidateId = txtCandidateID.Text;
                candidate.Fullname = txtFullName.Text;
                candidate.Birthday = txtBirthDate.SelectedDate;
                candidate.ProfileShortDescription = txtDescription.Text;
                candidate.ProfileUrl = txtImageURL.Text;
                candidate.PostingId = cmbJobPosting.SelectedValue.ToString();
                profileService.AddCandidateProfile(candidate);
                MessageBox.Show("Add Success!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.LoadInit();

            }

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtCandidateID.Text.Length > 0)
                {
                    CandidateProfile candidate = new CandidateProfile();
                    candidate.CandidateId = txtCandidateID.Text;
                    candidate.Fullname = txtFullName.Text;
                    candidate.Birthday = txtBirthDate.SelectedDate;
                    candidate.ProfileShortDescription = txtDescription.Text;
                    candidate.ProfileUrl = txtImageURL.Text;
                    candidate.PostingId = cmbJobPosting.SelectedValue.ToString();
                    profileService.UpdateCandidateProfile(candidate);
                }
                else
                {
                    MessageBox.Show("You must select a Candidate profile!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.LoadInit();

            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCandidateID.Text))
                {
                    string candidateId = txtCandidateID.Text;
                    profileService.DeleteCandidateProfile(candidateId);

                }
                else
                {
                    MessageBox.Show("You must select a Candidate profile!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.LoadInit();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            switch (roleID)
            {
                case 1:
                    break;
                case 2:
                    //staff
                    this.btnAdd.IsEnabled = false;
                    break;
                case 3:
                    break;
                default:
                    break;
            }
            this.LoadInit();
        }

        private void LoadInit()
        {
            this.dtgCandidateProfile.ItemsSource = profileService.GetCandidates().Select(a=> new {a.CandidateId,a.Fullname,a.Posting.JobPostingTitle, a.ProfileUrl});
            this.cmbJobPosting.ItemsSource = postingService.GetJobPostings();
            this.cmbJobPosting.DisplayMemberPath = "JobPostingTitle";
            this.cmbJobPosting.SelectedValuePath = "PostingId";
        }
        private void dtgCandidateProfile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dataGrid = sender as DataGrid;

                // Check if there's any row selected
                if (dataGrid.SelectedIndex >= 0 && dataGrid.SelectedItem != null)
                {
                    DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);

                    // Ensure the row is valid
                    if (row != null)
                    {
                        DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;

                        // Ensure the cell is valid
                        if (RowColumn != null)
                        {
                            String id = ((TextBlock)RowColumn.Content).Text;
                            CandidateProfile candidate = profileService.GetCandidateProfile(id);
                            if (candidate != null)
                            {
                                txtCandidateID.Text = candidate.CandidateId.ToString();
                                txtFullName.Text = candidate.Fullname;
                                txtBirthDate.Text = candidate.Birthday.ToString();
                                txtDescription.Text = candidate.ProfileShortDescription;
                                txtImageURL.Text = candidate.ProfileUrl;
                                cmbJobPosting.SelectedValue = candidate.PostingId;
                            }
                            else
                            {
                                MessageBox.Show("Candidate profile not found!");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while selecting candidate: " + ex.Message);
            }
        }

        private void jobpost_Click(object sender, RoutedEventArgs e)
        {
            JobPostingWindow jobPostingWindow = new JobPostingWindow();
            jobPostingWindow.Show();
            this.Close();
        }
    }
}
