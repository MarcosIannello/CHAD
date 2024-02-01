using System.Text.Json.Serialization;

namespace CHAD_BACK.Model.viewModels
{
    public class TiendaViewModel
    {

        public int? ID_TIENDA { get; set; }

        [JsonPropertyName("Localidad")]
        public string? LOCALIDAD { get; set; }

        [JsonPropertyName("NumeroDeTienda")]
        public int NRO_TIENDA { get; set; }
    }
}
