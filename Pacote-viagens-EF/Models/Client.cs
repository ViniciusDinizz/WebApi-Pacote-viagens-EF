namespace Pacote_viagens_EF.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public Address Address { get; set; }
        public DateTime? DtCadastro { get; set; }
    }
}
