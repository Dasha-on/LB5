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
    /// <summary>
    /// Логика взаимодействия для AddEditSportEquipmentPage.xaml
    /// </summary>
    public partial class AddEditSportEquipmentPage : Page
    {
        SportEquipment sportequipment;
        bool chk;
        public AddEditSportEquipmentPage(SportEquipment c)
        {
            InitializeComponent();
            cndf.ItemsSource = Connect.context.CounditionEquipment.ToList();
            vids.ItemsSource = Connect.context.VidSport.ToList();  
            zd.ItemsSource = Connect.context.Bild.ToList();
            if (c == null)
            {
                c = new SportEquipment() { NameEuipment = "Новый инвентарь", Count = 5};
                chk = true;
            }
            else
                chk = false;
            DataContext = sportequipment = c;
        }
        

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (chk)
            {
                Connect.context.SportEquipment.Add(sportequipment);
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
