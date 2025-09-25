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
    /// Логика взаимодействия для BildPage.xaml
    /// </summary>
    public partial class BildPage : Page
    {
        public BildPage()
        {
            InitializeComponent();
            BildDG.ItemsSource = Connect.context.Bild.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditBildPage(null));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var del = BildDG.SelectedItems.Cast<Bild>().ToList();
            foreach (var delete in del)
            {
                var c = Connect.context.SportEquipment.Where(x => x.IDZd == delete.IDBild).ToList();
                if (Connect.context.SportEquipment.Any(x => x.IDZd == delete.IDBild))
                {
                    MessageBox.Show("Данные используются в таблице спортивного инвентаря", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            if (MessageBox.Show($"Удалить {del.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Connect.context.Bild.RemoveRange(del);
            try
            {
                Connect.context.SaveChanges();
                BildDG.ItemsSource = Connect.context.Bild.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            BildDG.ItemsSource = Connect.context.Bild.ToList();
        }
       
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditBildPage((sender as Button).DataContext as Bild));
        }
        private void Poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
        void Update()
        {
            var sale = Connect.context.Bild.ToList();
            if (Poisk.Text.Length > 0)
                sale = sale.Where(sales =>
                sales.NameBild.ToLower().Contains(Poisk.Text.ToLower())).ToList();
            BildDG.ItemsSource = sale;
        }
    }
}
