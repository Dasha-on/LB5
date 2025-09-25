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
    /// Логика взаимодействия для AddEditBildPage.xaml
    /// </summary>
    public partial class AddEditBildPage : Page
    {
        Bild  bild;
        bool chekNew;
        public AddEditBildPage(Bild c)
        {
            InitializeComponent();
           
            if (c == null)
            {
                c = new Bild() { NameBild = "Новое здание", Location = "Новый адрес"};
                chekNew = true;
            }
            else
                chekNew = false;
            DataContext = bild = c;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (chekNew)
            {
                Connect.context.Bild.Add(bild);
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
