using System;
using System.Collections.Generic;
using System.Text;


namespace ProjetoBancoPoo.Exceptions
{
    class SaldoInsuficienteException : Exception
    {
        //Construtor que recebe msg

        public SaldoInsuficienteException(string msg): base(msg) 
        {
        
        }

    }
}
