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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53351/api/");

                //HTTP POST -------------------------------------- 
                var character = new Characters()
                {
                    Name = name_tb.Text,
                    Profiency = proftb.Text,
                };
                var postTask = client.PostAsJsonAsync<Characters>("Characters", character);
                postTask.Wait();

                var PostResult = postTask.Result;
                if (PostResult.IsSuccessStatusCode)
                {

                    var readTask = PostResult.Content.ReadAsAsync<Characters>();
                    readTask.Wait();

                    var insertedProduct = readTask.Result;
                    MessageBox.Show("Attention", "Character added");
                }
                else
                {
                    throw new Exception();
                }
            };
        }
    }

}
