using System;
using System.Collections.Generic;
using System.Text;
using ProjetoBancoPoo.Exceptions;

namespace ProjetoBancoPoo.Models
{
    class ContaPoupanca : Conta,IContaInvestimento
    {
        //Propriedades

        public double Rendimentos { get; set; }

        public ContaPoupanca(double numero)
        {

            Numero = numero;
        }


        //Metodos

        public void Sacar(double valor)
        {
            if(Saldo < valor)
            {
                throw new SaldoInsuficienteException($"Valor máximo para saque "+Saldo);

            }

            Saldo -=valor;
        }

        public double CalcularRetornoInvestimento(double taxa)
        {
            return Saldo * taxa;
        }

    }
}
