using System;

namespace Domain.DTO
{
    public class ProcessoDTO
    {
        public string Id { get; set; }
        public string Numero { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string FiscalResponsavel { get; set; }
        public DateTime Relato { get; set; }
    }
}
