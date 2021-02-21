using API_Projects.Classes;
using API_Projects.Classes.Competition;
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

namespace API_Projects.Views.Pages.Competition
{
    /// <summary>
    /// Логика взаимодействия для CompetitionPage.xaml
    /// </summary>
    public partial class CompetitionPage : Page
    {
        public ObservableCollection<CompetitionClass> competitions { get; set; }

        public CompetitionPage()
        {
            InitializeComponent();

            competitions = new ObservableCollection<CompetitionClass>();
            this.DataContext = this;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://dev.hakta.pro/o/rally/api/competition");

            var response = await client.GetAsync(client.BaseAddress);
            var result = await response.Content.ReadAsStringAsync();

            var strem = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var serializer = new DataContractJsonSerializer(typeof(ServerResponse<CompetitionClass>));

            var response_object = (ServerResponse<CompetitionClass>)serializer.ReadObject(strem);
            competitions = new ObservableCollection<CompetitionClass>(response_object.data);

            this.DataContext = null;
            this.DataContext = this;


        }
    }
}
