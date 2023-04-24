namespace Pacote_viagens_EF.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Burgh { get; set; }
        public string Cep { get; set; }
        public string Complement { get; set; }
        public City City { get; set; }
        public DateTime DtCadastro { get; set; }
    }
}
