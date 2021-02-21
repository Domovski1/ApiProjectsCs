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
    /// Логика взаимодействия для CommentsPage.xaml
    /// </summary>
    public partial class CommentsPage : Page
    {
        public ObservableCollection<Comments> comments { get; set; }

        public NewsClass news { get; set; }
        public CommentsPage(NewsClass GetNew)
        {
            InitializeComponent();

            comments = new ObservableCollection<Comments>();
            news = GetNew;
            this.DataContext = this;

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri($"http://dev.hakta.pro/o/rally/api/news/{news.id}/comments/");

            var response = await client.GetAsync(client.BaseAddress);
            var result = await response.Content.ReadAsStringAsync();

            var stream = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var serializer = new DataContractJsonSerializer(typeof(ServerResponse<Comments>));

            var response_object = (ServerResponse<Comments>)serializer.ReadObject(stream);

            comments = new ObservableCollection<Comments>(response_object.data);

            this.DataContext = null;
            this.DataContext = this;
        }
    }
}
