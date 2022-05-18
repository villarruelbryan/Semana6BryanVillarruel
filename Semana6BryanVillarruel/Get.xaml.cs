using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Semana6BryanVillarruel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Get : ContentPage
    {
        private const string Url = "http://172.100.10.24/moviles/post.php";//<--Poner su IP
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Semana6BryanVillarruel.Datos> _post;
        public Get()
        {
            InitializeComponent();
        }
        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(Url);
            List<Semana6BryanVillarruel.Datos> posts = JsonConvert.DeserializeObject<List<Semana6BryanVillarruel.Datos>>(content);
            _post = new ObservableCollection<Semana6BryanVillarruel.Datos>(posts);
            MyListView.ItemsSource = _post;
        }

       
    }
}