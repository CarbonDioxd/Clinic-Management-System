using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
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
using System.Xml.Linq;

namespace Clinic_Management_System
{
    /// <summary>
    /// Interaction logic for ClinicVisits.xaml
    /// </summary>
    public partial class ClinicVisits : Window
    {
        ClinicDatabaseDataContext clinicDB = ConstantValues.DBConnectionString;
        List<uspSelectAllPatientwAdviserResult> patients = new List<uspSelectAllPatientwAdviserResult>();
        List<uspSelectNursesMedProResult> users = new List<uspSelectNursesMedProResult>();
        int pID = 0;
        public ClinicVisits()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.BackFunction(ConstantValues.type);
            this.Close();
        }

        private void timeinbtn_Click(object sender, RoutedEventArgs e)
        {
            clinicDB.uspAddClinicVisitInfo(pID, ConstantValues.UID);
            clinicDB.uspInsertLogs(ConstantValues.UID, "A patient has been checked in");
            MessageBox.Show("Successfully checked in");
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            fill();
        }
        
        private void fill()
        {
            patientDeetsLB.Items.Clear();
            foreach (tblPatient patient in clinicDB.tblPatients)
            {
                foreach (tblStudentAdviser sa in clinicDB.tblStudentAdvisers)
                {
                    foreach(tblEmergencyContact ec in clinicDB.tblEmergencyContacts)
                    {
                        if (patient.PatientID.ToString() == txtPatientName.Text)
                        {
                            if (patient.AdviserID == sa.AdviserID)
                            {
                                if(ec.PatientID == patient.PatientID)
                                {
                                    patientDeetsLB.Items.Add("Patient Name: " + patient.PatientName + "\nGender: " + patient.PatientGender + "\nAge: " + patient.PatientAge
                                + "\nPatient Type: " + patient.PatientType + "\nDescription: " + patient.PatientDesc + "\nContact Number: " + patient.PatientNum + "\nEmail Address: " + patient.PatientEmail
                                + "\nHome Address: " + patient.PatientAddress + "\n\nStudent Adviser Details:\nAdviser Name: " + sa.AdviserName + "\nAdviser Email: " + sa.AdviserEmail
                                + "\nAdviser Number: " + sa.AdviserNum + "\nDepartment: " + sa.AdviserDept +"\n\nEmergency Contact Details:\nName: " + ec.EmgyContactName + "\nRelationship: " + ec.EmgyRelationship
                                + "\nContact Number: " + ec.EmgyContactNum + "\nEmail Address: " + ec.EmgyContactEmail + "\nHome Address: " + ec.EmgyContactAddress);
                                    pID = patient.PatientID;
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
    }
}
