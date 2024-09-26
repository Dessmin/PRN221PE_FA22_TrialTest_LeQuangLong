using Candidate_BusinessObject;
using Candidate_Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CandidateManagement_LeQuangLong
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private IHRAccountService iAccountService;
        public LoginWindow()
        {
            InitializeComponent();
            iAccountService = new HRAccountService();
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Hraccount hraccount = iAccountService.GetHraccountByEmail(txtEmail.Text.Trim());

            if (hraccount != null && txtPassword.Password.Equals(hraccount.Password))
            {
                int? roleID = hraccount.MemberRole;
                switch (roleID)
                {
                    case 1:
                        //this.Hide();
                        CandidateProfileManagement canFrom = new CandidateProfileManagement();
                        canFrom.Show();
                        this.Close();
                        break;
                    case 2:
                        CandidateProfileManagement staffCandidate = new CandidateProfileManagement(roleID);
                        staffCandidate.Show();
                        this.Close();
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Bye Bye!");
            }
        }
    }
}