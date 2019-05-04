using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileUX
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public String Email { get; set; }
        public String Senha { get; set; }
        public Command EntrarCommand { get; set; }

        public MainPage()
        {
            BindingContext = this; // qual classe representa meu contexto para biding

            //Dados padrões
            Email = "leandro@lanceloti.com.br";
            Senha = "123123";

            //inicializacao de propriedades
            EntrarCommand = new Command(Entrar);

            InitializeComponent();
        }

        async void Entrar()
        {
      
            var texto = Email + "\r\n" + Senha;

            if (Email.ToLower() == "leandro@lanceloti.com.br" && Senha == "123123")
            {
                Application.Current.MainPage = new NavigationPage(new Anuncios());
            } else
            {
                await DisplayAlert("Erro...", "Dados inválidos!", "Ok");
            }
        }
    }
}
