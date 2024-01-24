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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Nametb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53351/api/");

                //HTTP POST -------------------------------------- 
                var itm = new Items()
                {
                    Name = nametb.Text,
                    Price = pricetb.Text,
                };
                var postTask = client.PostAsJsonAsync<Items>("Items", itm);
                postTask.Wait();

                var PostResult = postTask.Result;
                if (PostResult.IsSuccessStatusCode)
                {

                    var readTask = PostResult.Content.ReadAsAsync<Items>();
                    readTask.Wait();

                    var insertedProduct = readTask.Result;
                    MessageBox.Show("Success", "Item added");
                }
                else
                {
                    throw new Exception();
                }
            };
        }
    }
}
