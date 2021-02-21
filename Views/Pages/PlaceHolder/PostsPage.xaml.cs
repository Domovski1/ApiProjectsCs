using API_Projects.Classes.Placeholder;
using Newtonsoft.Json;
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

namespace API_Projects.Views.Pages.PlaceHolder
{
    /// <summary>
    /// Логика взаимодействия для PostsPage.xaml
    /// </summary>
    public partial class PostsPage : Page
    {
        public HttpClient client = new HttpClient();
        public ObservableCollection<PostsClass> posts { get; set; }
        public PostsPage()
        {
            InitializeComponent();

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string url = "https://jsonplaceholder.typicode.com/posts/";
            try
            {
                using (var response = await client.GetAsync(url))
                {
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<PostsClass>));
                        var response_obj = serializer.ReadObject(stream);
                        posts = response_obj as ObservableCollection<PostsClass>;
                        this.DataContext = this;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло так", "Упс", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
