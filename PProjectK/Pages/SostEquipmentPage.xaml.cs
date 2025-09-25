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
    /// Логика взаимодействия для SostEquipmentPage.xaml
    /// </summary>
    public partial class SostEquipmentPage : Page
    {
        public SostEquipmentPage()
        {
            InitializeComponent();
            SportDG.ItemsSource = Connect.context.CounditionEquipment.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditSostEquipmentPage(null));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var del = SportDG.SelectedItems.Cast<CounditionEquipment>().ToList();
            foreach (var delete in del)
            {
                var c = Connect.context.SportEquipment.Where(x => x.IDCo == delete.IDCoundition).ToList();
                if (Connect.context.SportEquipment.Any(x => x.IDCo == delete.IDCoundition))
                {
                    MessageBox.Show("Данные используются в таблице издательство книг", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            if (MessageBox.Show($"Удалить {del.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Connect.context.CounditionEquipment.RemoveRange(del);
            try
            {
                Connect.context.SaveChanges();
                SportDG.ItemsSource = Connect.context.CounditionEquipment.ToList();
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
            Nav.MainFrame.Navigate(new AddEditSostEquipmentPage((sender as Button).DataContext as CounditionEquipment));
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SportDG.ItemsSource = Connect.context.CounditionEquipment.ToList();
        }
    }
}
