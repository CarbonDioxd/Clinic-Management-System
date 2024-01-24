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
    /// Interaction logic for UserlogsWindow.xaml
    /// </summary>
    public partial class UserlogsWindow : Window
    {
        ClinicDatabaseDataContext db = ConstantValues.DBConnectionString;

        public UserlogsWindow()
        {
            InitializeComponent();
            Fill();
        }
        private void Fill()
        { 
            foreach(tblSupply s in db.tblSupplies)
            {
                if (s.SupplyName.ToLower() == ConstantValues.sName.ToLower())
                {
                    lbl_ID.Content = s.SupplyID;
                    txtName.Text = s.SupplyName;
                    txtSupplier.Text = s.SupplierName;
                    txtPrice.Text = s.SupplyPrice.ToString();
                    txtQuantity.Text = s.SupplyQty.ToString();
                    txtStatus.Text = s.SupplyStatus.ToString();
                    txtExpDate.Text = s.SupplyExpDate.ToString();
                    txtLastUpd.Text = s.SupplyLastUpdated.ToString();
                }
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
