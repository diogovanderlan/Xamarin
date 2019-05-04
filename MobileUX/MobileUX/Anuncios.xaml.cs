using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MobileUX.Models;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileUX
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Anuncios : ContentPage
    {
        public ObservableCollection<Anuncio> Items { get; set; }

        /// <summary>
        /// Contrutor, jamais coloque código pesado aqui!
        /// </summary>
        public Anuncios()
        {       
            Items = new ObservableCollection<Anuncio>();
            //Items.Add(new Anuncio() { Titulo = "Apartamento 3 quartos" });
            //Items.Add(new Anuncio() { Titulo = "Apartamento 2 garagens" });

            BindingContext = this;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Carregadados();
        }

        async Task Carregadados( string busca = "") 
        {
            var url = "https://classidiario.odiario.com/api/busca/?busca=" + busca;

            var web = new HttpClient();

            var json = await web.GetStringAsync(url);

            var anuncios = JsonConvert.DeserializeObject<List<Anuncio>>(json);

            Items.Clear();
            foreach (var anuncio in anuncios)
            {
                Items.Add(anuncio);
            }
        }

        void Handle_SearchButtonPressed(object sender, System.EventArgs e)
        {
            Carregadados(busca.Text);
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null || !(e.Item is Anuncio))
                return;

            var item = (Anuncio)e.Item;

            //await DisplayAlert("Você escolheu", item.Titulo, "OK");
            await Navigation.PushAsync(new Detalhes(item));

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
