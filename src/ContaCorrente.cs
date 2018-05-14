using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp4_Exceptions
{
    public class ContaCorrente
    {
        public static int TotalDeContasCriadas { get; private set; }

        public Cliente Titular { get; }

        public int Numero { get; }
        public int Agencia { get; }

        public double Saldo { get; private set; }

        public ContaCorrente(int agencia, int numero, Cliente titular)
        {
            if (titular == null)
                throw new ArgumentNullException(nameof(titular));

            if (agencia <= 0)
                throw new ArgumentOutOfRangeException($"Parâmetro {nameof(agencia)} deve ser maior que 0.");

            if (numero <= 0)
                throw new ArgumentOutOfRangeException($"Parâmetro {nameof(numero)} deve ser maior que 0.");
            
            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;
        }

        public void Sacar(double valor)
        {
            if (Saldo < valor)
                throw new SaldoInsuficienteException(Saldo, valor);

            if (valor < 0)
                throw new ArgumentOutOfRangeException("O valor de saque não deve ser negativo");

            Saldo -= valor;
        }

        public void Depositar(double valor)
        {
            if (valor < 0)
                throw new ArgumentOutOfRangeException("O valor de deposito não deve ser negativo");

            Saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            Sacar(valor);
            contaDestino.Depositar(valor);
        }
    }
}
