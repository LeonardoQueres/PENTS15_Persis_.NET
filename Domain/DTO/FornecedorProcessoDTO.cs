using System;

namespace Domain.DTO
{
    public class FornecedorProcessoDTO
    {
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public decimal ReceitaBruta { get; set; }
        public string RelatoFiscalizacao { get; set; }
        public DateTime Relato { get; set; }
    }
}
