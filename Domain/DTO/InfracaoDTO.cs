namespace Domain.DTO
{
    public class InfracaoDTO
    {
        public string Id { get; set; }
        public string ProcessoId { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public decimal Multa { get; set; }
    }
}
