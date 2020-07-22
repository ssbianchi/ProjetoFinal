using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinal.DTO
{
    public class ClienteEndereco
    {
        public int ClienteEnderecoId { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
