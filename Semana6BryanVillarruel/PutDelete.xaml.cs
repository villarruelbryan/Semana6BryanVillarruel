using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Semana6BryanVillarruel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PutDelete : ContentPage
    {

        public PutDelete(int codigo, string nombre, string apellido, int edad)
        {
            InitializeComponent();
            txtcodigo.Text = codigo.ToString();
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtEdad.Text = edad.ToString();
        }

        public class Datos
        {
            public int codigo { get; set; }
            public string nombre { get; set; }
            public string apellido { get; set; }
            public int edad { get; set; }
        }

        private async void btnActulizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                Datos datos = new Datos
                {
                    codigo = Convert.ToInt32(txtcodigo.Text),
                    nombre = txtNombre.Text,
                    apellido = txtApellido.Text,
                    edad = Convert.ToInt32(txtEdad.Text)
                };
                HttpClient httpClient = new HttpClient();
                Uri uri = new Uri("http://172.100.10.24/moviles/post.php");
                var Json = JsonConvert.SerializeObject(datos);
                var contentJason = new StringContent(Json, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(uri, contentJason);

                var msj = "Datos Actualizados";
                DependencyService.Get<Mensaje>().alertShort(msj);
                await Navigation.PushAsync(new Get());
            }
            catch (Exception ex)
            {
                await DisplayAlert("ALERTA", ex.Message, "OK");
            }

        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                await httpClient.DeleteAsync("http://172.100.10.24/moviles/post.php?codigo=" + txtcodigo.Text);

                var msj = "Datos Eliminados";
                DependencyService.Get<Mensaje>().alertShort(msj);
                await Navigation.PushAsync(new Get());
            }
            catch (Exception ex)
            {
                await DisplayAlert("ALERTA", ex.Message, "OK");
            }

        }
    }
}