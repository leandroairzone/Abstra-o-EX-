using System;

namespace Abstração.EX
{
    class Program
    {
        static void Main(string[] args)
        {
          string ops, rep, opsCD, pagarOuCancelar = "";
            Boleto boleto = new Boleto();
            Credito credito = new Credito();
            Debito debito = new Debito();

            Console.Write($"----------------\nPagamento\n----------------\n");
            do
            {
                Console.Write("Digite a forma de pagamento\n[B] Boleto (Com 12% de desconto!)\n[C] Cartão\n[S] Sair\nOpção: ");
                ops = Console.ReadLine();
                ops = ops.ToUpper();
                CorrigindoOpcao(ops, "B", "C", "S");
                if (ops == "B")
                {
                    do
                    {
                        Console.Write($"Digite o valor a ser pago: R$ ");
                        boleto.Valor = float.Parse(Console.ReadLine());
                        Console.Write($"Digite quantos dias faltam para o vencimento do boleto: ");
                        int dias = int.Parse(Console.ReadLine());
                        while (dias < 0)
                        {
                            Console.Write($"Quantidade de dias inválido ou o boleto já venceu.\nDigite novamente: ");
                            dias = int.Parse(Console.ReadLine());
                        }
                        Console.WriteLine("--------------------------------");
                        boleto.Registar(boleto.Valor, boleto.Data, boleto.CodigoDeBarras, dias);
                        Console.Write("--------------------------------\nDeseja gerar um outro boleto?\n[S] Sim\n[N] Não\nOpção: ");
                        rep = Console.ReadLine();
                        rep = rep.ToUpper();
                        CorrigindoOpcaoSN(rep, "S", "N");
                    }while(rep == "S");
                }
                else if(ops == "C")
                {
                    Console.WriteLine($"Crédito ou débito: \n[C] Crédito\n[D] Débito\n opção: ");
                    opsCD = Console.ReadLine();
                    opsCD = opsCD.ToUpper();
                    CorrigindoOpcaoSN(opsCD, "C", "D");
                    switch (opsCD)
                    {
                        case "C":
                            Console.Write($"Digite o valor a ser pago: R$ ");
                            credito.Valor = float.Parse(Console.ReadLine());
                            credito.SalvarCartao();
                            Console.Write($"Parcelas:\n1x sem juros\n2x com 5% de juros\n3x com 5% de juros\n4x com 5% de juros\n5x com 5% de juros\n6x com 5% de juros\n7x com 8% de juros\n8x com 8% de juros\n9x com 8% de juros\n10x com 8% de juros\n11x com 8% de juros\n12x com 8% de juros\nQuantas vezes você quer parcelar?\nParcelar em: ");
                            int parcelando = int.Parse(Console.ReadLine());
                            credito.Pagar(credito.Valor, parcelando, pagarOuCancelar);
                            Console.WriteLine(credito.Limite);
                            
                            break;
                        default:
                            break;
                    }
                    
                }
            }while(ops != "S");




            //Funções
            void CorrigindoOpcao(string opcao, string a, string b, string c){
                while (opcao != a && ops != b && ops != c)
                {
                    Console.Write($"Opção inválida.\nDigite a opção novamente: ");
                    opcao = Console.ReadLine();
                    opcao = ops.ToUpper();
                }
            }
            void CorrigindoOpcaoSN(string opcao, string a, string b){
                while (opcao != a && opcao != b)
                {
                    Console.Write($"Opção inválida.\nDigite a opção novamente: ");
                    opcao = Console.ReadLine();
                    opcao = opcao.ToUpper();
                } 
            }
            void MostrarCartoes(string[] a, string[] b, int contador){
                for (var i = 0; i < 3; i++)
                {
                    Console.WriteLine($"Cartão {i + 1}\nNome do titular: {a[1]}\nBandeira: {b[i]}");
                }
            }
        }
    }
}
