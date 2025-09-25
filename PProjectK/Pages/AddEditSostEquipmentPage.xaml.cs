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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PProjectK.AppData;

namespace PProjectK.Pages
{
   

    public partial class AddEditSostEquipmentPage : Page
    {
        CounditionEquipment counditionequipment;
        bool chk;
        public AddEditSostEquipmentPage(CounditionEquipment c)
        {
            InitializeComponent();
            if (c == null)
            {
                c = new CounditionEquipment() { Coundition = "В разработке"};
                chk = true;
            }
            else
                chk = false;
            DataContext = counditionequipment = c;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (chk)
            {
                Connect.context.CounditionEquipment.Add(counditionequipment);
            }
            try
            {
                Connect.context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Nav.MainFrame.GoBack();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
    }
}
