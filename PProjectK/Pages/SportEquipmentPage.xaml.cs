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
    /// Логика взаимодействия для SportEquipmentPage.xaml
    /// </summary>
    public partial class SportEquipmentPage : Page
    {
        public SportEquipmentPage()
        {
            InitializeComponent();
            SportDG.ItemsSource = Connect.context.SportEquipment.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditSportEquipmentPage(null));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {

            var del = SportDG.SelectedItems.Cast<SportEquipment>().ToList();
            if (MessageBox.Show($"Удалить {del.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Connect.context.SportEquipment.RemoveRange(del);
            try
            {
                Connect.context.SaveChanges();
                SportDG.ItemsSource = Connect.context.SportEquipment.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditSportEquipmentPage((sender as Button).DataContext as SportEquipment));
        }
        private void Poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
        void Update()
        {
            var sale = Connect.context.SportEquipment.ToList();
            if (Poisk.Text.Length > 0)
                sale = sale.Where(sales =>
                sales.NameEuipment.ToLower().Contains(Poisk.Text.ToLower())).ToList();
            SportDG.ItemsSource = sale;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SportDG.ItemsSource = Connect.context.SportEquipment.ToList();
        }
    }
}
