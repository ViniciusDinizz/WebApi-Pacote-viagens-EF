using NuGet.Protocol.Core.Types;

namespace Pacote_viagens_EF.Models
{
    public class Package
    {
        public int Id { get; set; }
        public DateTime DtCadastro { get; set; }
        public decimal Value { get; set; }
        public Client Client { get; set; }
        public Ticket Ticket { get; set; }
        public Hotel Hotel { get; set; }
    }
}
