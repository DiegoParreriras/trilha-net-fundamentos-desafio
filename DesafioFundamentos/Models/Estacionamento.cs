using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
 
    public class Estacionamento
    { 
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        { 
            bool menu = true;
            // Ciclo de repeticao onde retorna caso o usuario erre a placa ou digite a placa de um carro ja estacionado
            while (menu)
            {
                Console.WriteLine("Digite a placa do veículo para estacionar:");
                string addPlaca = Console.ReadLine();
                addPlaca = addPlaca.ToUpper();

                if (Regex.IsMatch(addPlaca, "[A-Za-z]{4}[0-9]{4}$"))
                {
                    if (!veiculos.Contains(addPlaca))
                    {
                        veiculos.Add(addPlaca);
                        Console.WriteLine("Carro cadastrado com sucesso.");
                        menu = false;
                    }
                    else
                    {
                        Console.WriteLine("Nao e possivel cadastrar o mesmo carro 2 vezes");
                    }

                }
                else
                {
                    Console.WriteLine("Desculpe mas algo deu errado,digite novante a placa.");
                }
            }
      
        }
        public void RemoverVeiculo()
        {

            Console.WriteLine("Digite a placa do veículo para remover:");
            string removerPlaca = Console.ReadLine();
            removerPlaca = removerPlaca.ToUpper();
            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == removerPlaca.ToUpper()))
            {   // Faz o calculo do valor total a ser pago
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                string inputHoras = Console.ReadLine();
                int horas = int.Parse(inputHoras);
                decimal valorTotal = precoInicial + (precoPorHora * horas);

                veiculos.Remove(removerPlaca.ToUpper());
                Console.WriteLine($"O veículo {removerPlaca} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (string item in veiculos)
                {   // Lista os veiculos separando a placa com "-" exemplo aaaa-1111
                    Console.WriteLine($"Placa do veiculo: {(item.Substring(0, 4) + "-" + item.Substring(4, 4))}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
