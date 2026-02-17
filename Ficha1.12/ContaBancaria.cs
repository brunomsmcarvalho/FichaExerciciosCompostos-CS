using System;
using System.Collections.Generic;

namespace Ficha1._12
{
    public class ContaBancaria
    {
        // ─── CAMPOS PRIVADOS ─────────────────────────────────────────
        private readonly int numeroConta;   // readonly = nunca pode ser alterado após criação
        private string titular;
        private float saldo;
        private const float TAXA_DEBITO = 1f;

        private List<string> historico = new List<string>();

        // ─── PROPRIEDADES ─────────────────────────────────────────────
        public int NumeroConta
        {
            get { return numeroConta; }
        }

        public string Titular
        {
            get { return titular; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("O nome do titular não pode ser vazio.");
                titular = value;
            }
        }

        public float Saldo
        {
            get { return saldo; }
        }

        // ─── CONSTRUTORES ─────────────────────────────────────────────

        // Sem depósito inicial — saldo fica a zero
        public ContaBancaria(int numeroConta, string titular)
        {
            this.numeroConta = numeroConta;
            Titular = titular;
            this.saldo = 0f;

            historico.Add($"[ABERTURA] Conta criada sem depósito inicial. Saldo: {saldo:F2} €");
        }

        // Com depósito inicial
        public ContaBancaria(int numeroConta, string titular, float depositoInicial)
        {
            this.numeroConta = numeroConta;
            Titular = titular;

            if (depositoInicial < 0)
                throw new ArgumentException("O depósito inicial não pode ser negativo.");

            this.saldo = depositoInicial;
            historico.Add($"[ABERTURA] Conta criada com depósito inicial de {depositoInicial:F2} €. Saldo: {saldo:F2} €");
        }

        // ─── MÉTODOS PÚBLICOS ──────────────────────────────────────────

        // Crédito: aumenta o saldo
        public void Creditar(float valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor de crédito deve ser maior que zero.");

            saldo += valor;
            historico.Add($"[CRÉDITO ] +{valor:F2} €  →  Saldo: {saldo:F2} €");
        }

        // Débito: diminui o saldo e cobra taxa de 1€
        public void Debitar(float valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor de débito deve ser maior que zero.");

            saldo -= valor;
            saldo -= TAXA_DEBITO;

            historico.Add($"[DÉBITO  ] -{valor:F2} € (+ {TAXA_DEBITO:F2} € taxa)  →  Saldo: {saldo:F2} €");
        }

        // Histórico de movimentos
        public void ImprimirHistorico()
        {
            Console.WriteLine("\n─── HISTÓRICO DE MOVIMENTOS ─────────────────────────");
            Console.WriteLine($"  Conta: {numeroConta} | Titular: {titular}\n");

            for (int i = 0; i < historico.Count; i++)
            {
                Console.WriteLine($"  {i + 1,2}. {historico[i]}");
            }

            Console.WriteLine("─────────────────────────────────────────────────────");
        }

        // Dados resumidos da conta
        public override string ToString()
        {
            return $"Conta {numeroConta}, Titular: {titular}, Saldo: {saldo:F2} €";
        }
    }
}
