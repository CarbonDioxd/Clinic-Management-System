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
        ClinicDatabaseDataContext db_con = ConstantValues.DBConnectionString;
        public SuppliesOverviewWindow()
        {
            InitializeComponent();
            Fill();
        }

        private void Fill()
        {
            List<GetAllSuppliesResult> getAllSuppliesResults = db_con.GetAllSupplies().ToList();
            cbExpDate.Items.Add("NONE");
            foreach (var result in getAllSuppliesResults)
            {
                lbSupplyResults.Items.Add(result.SupplyName);
                if (!cbBrandName.Items.Contains(result.SupplierName))
                {
                    cbBrandName.Items.Add(result.SupplyName);
                }
                if (!cbExpDate.Items.Contains(result.SupplyExpDate))
                {
                    cbExpDate.Items.Add(result.SupplyExpDate);
                }
                if (!cbSupplier.Items.Contains(result.SupplierName))
                {
                    cbSupplier.Items.Add(result.SupplierName);
                }
            }
        }
        private void FilterFill()
        {
            lbSupplyResults.Items.Clear();
            List<GetSpecificSupplyResult> getSpecificSupplyResults = db_con.GetSpecificSupply(a, c, b).ToList();
            foreach (var result in getSpecificSupplyResults)
            {
                lbSupplyResults.Items.Add(result.SupplyName);

            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.BackFunction(ConstantValues.type);
            this.Close();
        }

        private void cbExpDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbExpDate.SelectedIndex != -1)
                a = cbExpDate.SelectedItem.ToString();
            else if (cbExpDate.SelectedIndex == 0)
                a = null;
            FilterFill();
        }

        private void cbSupplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbSupplier.SelectedIndex != -1)
                b = cbSupplier.SelectedItem.ToString();
            FilterFill();
        }

        private void cbBrandName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbBrandName.SelectedIndex != -1)
                c = cbBrandName.SelectedItem.ToString();
            FilterFill();
        }

        private void txtSupplyName_TextChanged(object sender, TextChangedEventArgs e)
        {
            d = txtSupplyName.Text;
            cbBrandName.SelectedIndex = -1;
            cbExpDate.SelectedIndex = -1;
            cbSupplier.SelectedIndex = -1;
            FilterFill();
        }
    }
}
