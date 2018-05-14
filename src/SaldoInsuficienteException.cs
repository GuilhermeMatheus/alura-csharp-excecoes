using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp4_Exceptions
{
    public class SaldoInsuficienteException : Exception
    {
        public SaldoInsuficienteException(double saldo, double valorDaOperacao)
            : this($"Saldo disponível: {saldo}, valor da operação: {valorDaOperacao}")
        {
        }

        public SaldoInsuficienteException(string mensagem) : base(mensagem)
        {
        }
    }
}
