using System;
namespace MobileUX.Models
{
    public class Anuncio
    {
        public int Id { get; set; }
        public string Imagem { get; set; }
        public string Titulo { get; set; }
        public string Valor { get; set; }
        public string Src => "https://classidiario.odiario.com/content/media/imagem/" + Imagem;

        public string Texto { get; set; }
        public string [] Imagens { get; set; }
    }
}
