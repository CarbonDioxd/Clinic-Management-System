using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Clinic_Management_System
{
    /// <summary>
    /// Interaction logic for UserLogs.xaml
    /// </summary>
    public partial class UserLogs : Window
    {
        ClinicDatabaseDataContext clinicDB = ConstantValues.DBConnectionString;

        public UserLogs()
        {
            InitializeComponent();
            Fill();
        }

        private void Fill()
        {
            foreach (tblLog Log in clinicDB.tblLogs)
            {
                lbxAllLog.Items.Add("(" + Log.LogDate + ")" + " " + Log.LogDesc );
                foreach (tblUser user in clinicDB.tblUsers)
                {
                    if (Log.UserID == user.UserID)
                    {
                        if(!cbUserLog.Items.Contains(user.UserFullName))
                        {
                            cbUserLog.Items.Add(user.UserFullName);
                        }
                    }
                }
            }
        }
        private void lbxSpecificUserLog_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void cbUserLog_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbxSpecificU.Items.Clear();
            foreach (tblUser user in clinicDB.tblUsers)
            {
                if (cbUserLog.SelectedItem.ToString() == user.UserFullName)
                {
                    foreach (tblLog log in clinicDB.tblLogs)
                    {
                        if (log.UserID == user.UserID)
                        {
                            lbxSpecificU.Items.Add("(" + log.LogDate + ")" + " " + log.LogDesc);

                        }
                    }
                }
            }
        }
    }
}
