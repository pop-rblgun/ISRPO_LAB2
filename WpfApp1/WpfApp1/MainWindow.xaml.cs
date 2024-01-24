using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
           
        }
        
        private void character_click(object sender, RoutedEventArgs e)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53351/api/");
                var responseTask = client.GetAsync("Characters");
                responseTask.Wait();

                var GetResult = responseTask.Result;
                if (GetResult.IsSuccessStatusCode)
                {
                    var readTask = GetResult.Content.ReadAsAsync<Characters[]>();
                    readTask.Wait();

                    var characters = readTask.Result;
                    datagrid.ItemsSource = characters;
                }
            }
        


        Panel.SetZIndex(item_btn, 0);
            Panel.SetZIndex(inventory_btn, 0);
            Panel.SetZIndex(characters_btn, 1); 
        }

        private void itm_click(object sender, RoutedEventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53351/api/");
                var responseTask = client.GetAsync("Items");
                responseTask.Wait();

                var GetResult = responseTask.Result;
                if (GetResult.IsSuccessStatusCode)
                {
                    var readTask = GetResult.Content.ReadAsAsync<Items[]>();
                    readTask.Wait();

                    var itms = readTask.Result;
                    datagrid.ItemsSource = itms;
                }
            }

            Panel.SetZIndex(item_btn, 1);
            Panel.SetZIndex(inventory_btn, 0);
            Panel.SetZIndex(characters_btn, -1);
        }

        private void inv_click(object sender, RoutedEventArgs e)
        {
            Panel.SetZIndex(item_btn, 0);
            Panel.SetZIndex(inventory_btn, 1);
            Panel.SetZIndex(characters_btn, -1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

     
        private void del_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53351/api/");

                // операция удаления 
                var deleteTask = client.DeleteAsync($"characters/" + deletechartb.Text);
                deleteTask.Wait();

                // получение StatusCode необязательно 
                HttpResponseMessage deleteResult = deleteTask.Result;
                Console.WriteLine(deleteResult.StatusCode.ToString());
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

     

        private void addchr_Click(object sender, RoutedEventArgs e)
        {
            Window1 add = new Window1();
            add.ShowDialog();
        }

        private void addit_Click(object sender, RoutedEventArgs e)
        {
            Window2 add = new Window2();
            add.ShowDialog();
        }

        private void Deleteitemtb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void del2_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53351/api/");

                // операция удаления 
                var deleteTask = client.DeleteAsync($"items/" + deleteitemtb.Text);
                deleteTask.Wait();

                // получение StatusCode необязательно 
                HttpResponseMessage deleteResult = deleteTask.Result;
                Console.WriteLine(deleteResult.StatusCode.ToString());
            }
        }
    }
}
