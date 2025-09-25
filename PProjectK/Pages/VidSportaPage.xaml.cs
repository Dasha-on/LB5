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
    /// Логика взаимодействия для VidSportaPage.xaml
    /// </summary>
    public partial class VidSportaPage : Page
    {
        public VidSportaPage()
        {
            InitializeComponent();
            VidDG.ItemsSource = Connect.context.VidSport.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditVidSportPage(null));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var del = VidDG.SelectedItems.Cast<VidSport>().ToList();
            foreach (var delete in del)
            {
                var c = Connect.context.SportEquipment.Where(x => x.IDSport == delete.IDVidSport).ToList();
                if (Connect.context.SportEquipment.Any(x => x.IDSport == delete.IDVidSport))
                {
                    MessageBox.Show("Данные используются в таблице спортивного инвентаря", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            if (MessageBox.Show($"Удалить {del.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Connect.context.VidSport.RemoveRange(del);
            try
            {
                Connect.context.SaveChanges();
                VidDG.ItemsSource = Connect.context.VidSport.ToList();
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
            Nav.MainFrame.Navigate(new AddEditVidSportPage((sender as Button).DataContext as VidSport));
        }
        private void Poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
        void Update()
        {
            var sale = Connect.context.VidSport.ToList();
            if (Poisk.Text.Length > 0)
                sale = sale.Where(sales =>
                sales.NameSport.ToLower().Contains(Poisk.Text.ToLower())).ToList();
            VidDG.ItemsSource = sale;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            VidDG.ItemsSource = Connect.context.VidSport.ToList();
        }
    }
}
