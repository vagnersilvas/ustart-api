 using System;

namespace UStart.Domain.Commands
{
    public class ClienteCommand
    {
        public Guid Id { get; set; }
        public string CodigoExterno { get; set; }
        public bool Ativo { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string Rua { get; set; }
        public string RazaoSocial { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CidadeId { get; set; }
        public string CidadeNome { get; set; }
        public string CEP { get; set; }
        public string Fone { get; set; }
        public string Email { get; set; }
        public decimal LimiteDeCredito { get; set; }
    }
}