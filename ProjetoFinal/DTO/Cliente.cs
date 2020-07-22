using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;

namespace ProjetoFinal.DTO
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }

        public virtual ICollection<ClienteEndereco> ClienteEnderecos { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
        public Cliente()
        {
            this.ClienteEnderecos = new List<ClienteEndereco>();
            this.Pedidos = new List<Pedido>();
        }
    }
}
