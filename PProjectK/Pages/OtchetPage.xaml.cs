using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
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
using Exel = Microsoft.Office.Interop.Excel;

namespace PProjectK.Pages
{
    /// <summary>
    /// Логика взаимодействия для OtchetPage.xaml
    /// </summary>
    public partial class OtchetPage : Page
    {
        List<SportEquipment> registers;
        public OtchetPage()
        {
            InitializeComponent();
            OthcetDG.ItemsSource = Connect.context.SportEquipment.ToList();
            registers = Connect.context.SportEquipment.ToList();
           

        }



        private void Otchet_Click(object sender, RoutedEventArgs e)
        {
            Exel.Application application = new Exel.Application();
            application.Visible = true;
            application.SheetsInNewWorkbook = 1;
            Exel.Workbook workbook = application.Workbooks.Add(Type.Missing);
            Exel.Worksheet worksheet = workbook.Worksheets.get_Item(1);
            Exel.Range range = worksheet.get_Range("A1", "E1");
            range.Merge();
            range.Value = "Ведомость о процедурах";
            range.HorizontalAlignment = Exel.XlHAlign.xlHAlignCenter;
            var curRow = 3;
            worksheet.Cells[curRow, 1].Value = "Название спорт. инвентаря";
            worksheet.Cells[curRow, 2].Value = "Кол-во";
            worksheet.Cells[curRow, 3].Value = "Состояние";
            worksheet.Cells[curRow, 4].Value = "Вид спорта";
            worksheet.Cells[curRow, 5].Value = "Здание";
            curRow++;

            foreach (var client in registers)
            {
                worksheet.Cells[curRow, 1].Value = client.NameEuipment;
                worksheet.Cells[curRow, 2].Value = client.Count;
                worksheet.Cells[curRow, 3].Value = client.CounditionEquipment.Coundition;
                worksheet.Cells[curRow, 4].Value = client.VidSport.NameSport;
                worksheet.Cells[curRow, 5].Value = client.Bild.NameBild;
                curRow++;
            }

            Exel.Range r1 = worksheet.Cells[curRow, 1];
            Exel.Range r2 = worksheet.Cells[curRow, 4];
            range = worksheet.get_Range(r1, r2);
            range.Merge();



          

            r1 = worksheet.Cells[3, 1];
            r2 = worksheet.Cells[curRow, 5];
            range = worksheet.get_Range(r1, r2);
            range.Borders.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
            worksheet.Columns.AutoFit();
        }


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

      
    }
}

