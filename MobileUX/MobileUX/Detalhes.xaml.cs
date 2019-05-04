using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MobileUX.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MobileUX
{
    public partial class Detalhes : ContentPage
    {
        public Anuncio Anuncio { get; set; }

        public Detalhes(Anuncio anuncio)
        {
            Anuncio = anuncio;
            BindingContext = this;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Carregadados();
        }

        async Task Carregadados()
        {
            var url = "https://classidiario.odiario.com/api/anuncio/" + Anuncio.Id;

            var web = new HttpClient();

            var json = await web.GetStringAsync(url);

            var anuncio = JsonConvert.DeserializeObject<Anuncio>(json);

            lblTxt.Text = anuncio.Texto;
        }
    }
}
