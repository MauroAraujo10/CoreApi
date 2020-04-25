namespace ProAgil.WebApi.dto
{
    public class EventoPostDto
    {
        public string Local { get; set; }
        public string Data { get; set; }
        public string Tema { get; set; }
        public int QuantidadePessoas { get; set; }
        public string Lote { get; set; }
        public decimal Valor { get; set; }
        public string ImagemURL { get; set; } 
    }
}