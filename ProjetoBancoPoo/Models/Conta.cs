using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBancoPoo.Models
{
   abstract class Conta
    {

        public double Saldo { get; protected set; }

        public double Numero { get; set; }

        public void Depositar(double valor)
        {
            if (valor < 0)
            {
                //Tratamento de Excessão
                throw new ArgumentException("O Valor não pode ser negativo");

            }
            else
            {

                Saldo += valor;

            }
        }

    }
}
