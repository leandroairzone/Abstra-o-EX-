using System;

namespace Abstração.EX
{
    class Program
    {
        static void Main(string[] args)
        {
           Credito cred = new Credito();

            Console.WriteLine("Digite o valor do produto: ");
            float ValordaCompra = float.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.WriteLine("Selecione a forma de pagamento: ");
            Console.WriteLine("[1] - BOLETO |12% de desconto|");
            Console.WriteLine("[2] - CARTÃO");
            int opcao = int.Parse(Console.ReadLine());

            switch(opcao){

                //Boleto
                case 1:
                    Boleto boleto = new Boleto();
                    boleto.Valor = ValordaCompra;
                    boleto.Registrar(boleto.Valor, boleto.DatadoPagamento, boleto.CodigodeBarras);
    
                break;

                case 2:
                    Console.WriteLine("Selecione uma opção: ");
                    Console.WriteLine("[1] Crédito");
                    Console.WriteLine("[2] Débito");
                    int tipoCartao = int.Parse(Console.ReadLine());

                    switch(tipoCartao){
                        case 1: 
                            Credito credito = new Credito();
                            credito.SalvarCartao();
                            credito.Pagar(ValordaCompra);
                            Console.WriteLine("APROVADO!");
                        break;

                        case 2:
                            Debito debito = new Debito();
                            debito.SalvarCartao();
                            debito.Pagar(ValordaCompra);
                        break;
                    }
                    
                break;
            } 
            
        }
    }
}
