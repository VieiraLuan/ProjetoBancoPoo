using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBancoPoo.Models
{
    class Cliente
    {

        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }


        public Cliente(string cpf,string nome,string telefone)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Telefone = telefone;

        }
    }
}
