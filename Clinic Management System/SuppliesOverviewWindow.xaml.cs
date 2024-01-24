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
    /// Interaction logic for SuppliesOverviewWindow.xaml
    /// </summary>
    public partial class SuppliesOverviewWindow : Window
    {
        private static string a = "";
        private static string b = "";
        private static string c = "";
        private static string d = "";
        ClinicDatabaseDataContext db = ConstantValues.DBConnectionString;
        public SuppliesOverviewWindow()
        {
            InitializeComponent();
            Fill();
            if (ConstantValues.type == "Admin")
            {
                btnAddSupply.IsEnabled = false;
            }
        }

        private void Fill()
        {
           foreach (tblSupply supply in db.tblSupplies)
            {
                lbSupplyResults.Items.Add(supply.SupplyName);
                if (!cbExpDate.Items.Contains(supply.SupplyExpDate))
                {
                    cbExpDate.Items.Add(supply.SupplyExpDate);
                }
                if (!cbStatus.Items.Contains(supply.SupplyStatus))
                {
                    cbStatus.Items.Add(supply.SupplyStatus);
                }
                if (!cbSupplier.Items.Contains(supply.SupplierName))
                {
                    cbSupplier.Items.Add(supply.SupplierName);
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.BackFunction(ConstantValues.type);
            this.Close();
        }

        private void txtSupplyName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSupplyName.Text.Length != 0)
            {
                lbSupplyResults.Items.Clear();
                cbExpDate.SelectedIndex = -1;
                cbStatus.SelectedIndex = -1;
                cbSupplier.SelectedIndex = -1;
                foreach (tblSupply supply in db.tblSupplies)
                {
                    if (supply.SupplyName.ToLower() == txtSupplyName.Text.ToLower())
                    {
                        lbSupplyResults.Items.Add(supply.SupplyName);
                    }
                }
            }
            
        }

        private void cbSupplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                lbSupplyResults.Items.Clear();

            foreach (tblSupply supply in db.tblSupplies)
            {
                if (cbSupplier.SelectedIndex != -1 && supply.SupplierName.ToLower() == cbSupplier.SelectedItem.ToString().ToLower())
                {
                    lbSupplyResults.Items.Add(supply.SupplyName);
                }
            }
   
       
        }

        private void cbExpDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                lbSupplyResults.Items.Clear();

            foreach (tblSupply supply in db.tblSupplies)
            {
                if (cbExpDate.SelectedIndex != -1 && supply.SupplyExpDate.ToString().ToLower() == cbExpDate.SelectedItem.ToString().ToLower())
                {
                    lbSupplyResults.Items.Add(supply.SupplyName);
                }
            }
           
        }

        private void cbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                lbSupplyResults.Items.Clear();

            foreach (tblSupply supply in db.tblSupplies)
            {
                if (cbStatus.SelectedIndex != -1&&supply.SupplyStatus.ToLower() == cbStatus.SelectedItem.ToString().ToLower())
                {
                    lbSupplyResults.Items.Add(supply.SupplyName);
                }
            }
         
        }

        private void lbSupplyResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConstantValues.sName = lbSupplyResults.SelectedItem.ToString();
            UserlogsWindow ulw = new UserlogsWindow();
            ulw.Show();
            this.Hide();
        }
    }
}
