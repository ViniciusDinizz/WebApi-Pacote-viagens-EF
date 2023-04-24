namespace Pacote_viagens_EF.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DtCadastro { get; set; }
        public decimal Value { get; set; }
        public Address Address { get; set; }
    }
}
