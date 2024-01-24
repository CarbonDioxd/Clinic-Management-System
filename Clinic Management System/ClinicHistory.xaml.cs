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
    /// Interaction logic for ClinicHistory.xaml
    /// </summary>
    public partial class ClinicHistory : Window
    {
        ClinicDatabaseDataContext clinicDB = ConstantValues.DBConnectionString;
        public ClinicHistory()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            fill();
        }

        private void fill()
        {
            clinicLB.Items.Clear();

            foreach (tblPatient patient in clinicDB.tblPatients)
            {
                foreach (tblClinicVisit cv in clinicDB.tblClinicVisits)
                {
                    foreach (tblUser user in clinicDB.tblUsers)
                    {
                        if (patient.PatientID.ToString() == txtPatientName.Text)
                        {
                            if (cv.PatientID == patient.PatientID)
                            {
                                if (user.UserID == cv.UserID)
                                {
                                    clinicLB.Items.Add("Visit ID: " + cv.VisitID + "\nPatient Name: " + patient.PatientName
                                                    + "\nPatient Type: " + patient.PatientType + "\nMedical Attendant: " + user.UserFullName
                                                    + "\nTime In: " + cv.PatientTimeIn
                                                    + "\nTime Out: " + cv.PatientTimeOut + "\nObservations/Notes: " + cv.PatientNotes + "\n");

                                }
                            }
                        }
                    }
                }
            }
        }




        private void txtPatientName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                fill();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.BackFunction(ConstantValues.type);
            this.Close();
        }
    }
}
