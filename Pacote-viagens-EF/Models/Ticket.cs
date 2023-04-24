namespace Pacote_viagens_EF.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public Address Origin { get; set; }
        public Address Destin { get; set; }
        public DateTime DtCadastro { get; set; }
        public decimal Value { get; set; }
    }
}
