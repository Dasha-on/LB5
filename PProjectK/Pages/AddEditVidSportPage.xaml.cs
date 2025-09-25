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
    /// Логика взаимодействия для AddEditVidSportPage.xaml
    /// </summary>
    public partial class AddEditVidSportPage : Page
    {
        VidSport vidsport;
        bool chk;
        public AddEditVidSportPage(VidSport c)
        {
            InitializeComponent();
            if (c == null)
            {
                c = new VidSport() { NameSport= "Новый вид спорта"};
                chk = true;
            }
            else
                chk = false;
            DataContext = vidsport = c;
        
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (chk)
            {
                Connect.context.VidSport.Add(vidsport);
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
    }
}
