using API_Projects.Classes;
using API_Projects.Classes.News;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
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

namespace API_Projects.Views.Pages.News
{
    /// <summary>
    /// Логика взаимодействия для NewsListPage.xaml
    /// </summary>
    public partial class NewsListPage : Page
    {
        public ObservableCollection<NewsClass> News { get; set; }
        public NewsListPage()
        {
            InitializeComponent();
            News = new ObservableCollection<NewsClass>();
            
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            // Задание адресса, откуда получаем данные (API)
            client.BaseAddress = new Uri("http://dev.hakta.pro/o/rally/api/news/");

            // Получает данные от сервера
            var response = await client.GetAsync(client.BaseAddress);
            
            // записываем результат 
            var result = await response.Content.ReadAsStringAsync();


            var stream = new MemoryStream(Encoding.UTF8.GetBytes(result));
            // Дессериализируем данные
            var serializer = new DataContractJsonSerializer(typeof(ServerResponse<NewsClass>));

            // Читаем данные как объект (?)
            var response_object = (ServerResponse<NewsClass>)serializer.ReadObject(stream);

            News = new ObservableCollection<NewsClass>(response_object.data);

            
            this.DataContext = this;

        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new CommentsPage((NewsClass)NewsListViews.SelectedItem));
        }
    }
}
